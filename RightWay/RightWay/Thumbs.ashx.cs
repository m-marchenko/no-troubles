using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Drawing;
using System.Drawing.Imaging;

namespace TourizmWebApp
{
    /// <summary>
    /// Summary description for thumbs
    /// </summary>
    public class Thumbs : IHttpHandler
    {
        private const int DEFAULT_THUMB_SIZE = 120;

        private int m_Size = DEFAULT_THUMB_SIZE;		

        public void ProcessRequest(HttpContext context)
        {
            			string filename = context.Request["FileName"];

			if (null != context.Request["Size"])
			{
				try
				{
					string size = context.Request["Size"];
					m_Size = Int32.Parse(size);
				}
				catch
				{
					m_Size = DEFAULT_THUMB_SIZE;		
				}
			}
			else
				m_Size = DEFAULT_THUMB_SIZE;		
			
			try
			{
				Bitmap image = new Bitmap(context.Server.MapPath(filename));
				double w = image.Width;
				double h = image.Height;				

				int width;
				int height;

				if (w > h)
				{
					width = m_Size;
					height = (int)(m_Size * h / w);
				}
				else
				{
					height = m_Size;
					width = (int)(m_Size * w / h);
				}
			

				Image.GetThumbnailImageAbort callback = new System.Drawing.Image.GetThumbnailImageAbort(ThumbnailCallback);
				Image thumb = image.GetThumbnailImage(width, height, callback, IntPtr.Zero);

				context.Response.Clear();
				context.Response.ContentType = "image/jpeg";
				thumb.Save(context.Response.OutputStream, ImageFormat.Jpeg);

				context.Response.End();

			}
			catch (Exception err)
			{
				context.Response.Write(err.Message);
			}

		}
        

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }

        public bool ThumbnailCallback()
        {
            return false;
        }

    }
}
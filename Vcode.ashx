<%@ WebHandler Language="C#" Class="Vcode" %>

using System;
using System.Web;
using System.Web.SessionState;
using System.Drawing;

public class Vcode : IHttpHandler,IRequiresSessionState {
    
    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "image/jpeg"; 
        using (Image img = new Bitmap(80, 30))
        {
            using (Graphics g = Graphics.FromImage(img))
            {
                g.FillRectangle(Brushes.White, 0, 0, img.Width, img.Height);
                string codestr = MakeCode(4);
                context.Session["vCode"] = codestr;
                g.DrawString(codestr, new Font("微软雅黑", 12), Brushes.Black, 17, 4);
                for (int i = 0; i < 5; i++)
                {
                    Point p1 = new Point(rand.Next(1, img.Width - 2), rand.Next(1, img.Height - 2));
                    Point p2 = new Point(rand.Next(1, img.Width - 2), rand.Next(1, img.Height - 2));
                    g.DrawLine(Pens.LightBlue, p1, p2);
                }
            }
            img.Save(context.Response.OutputStream, System.Drawing.Imaging.ImageFormat.Jpeg);
        }
    }
    Random rand = new Random();
    private string MakeCode(int length)
    {
        System.Text.StringBuilder sbCode = new System.Text.StringBuilder(length);
        for (int i = 0; i < length; i++)
        {
            int value = rand.Next(10);
            sbCode.Append(value.ToString());
        }
        return sbCode.ToString();
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}
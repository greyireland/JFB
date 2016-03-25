<%@ WebHandler Language="C#" Class="Handler" %>

using System;
using System.Web;
using System.Web.SessionState;
using System.IO;
using System.Drawing;
using System.Text;
public class Handler : IHttpHandler, IRequiresSessionState
{

    public void ProcessRequest(HttpContext context)
    {
        context.Response.ContentType = "text/plain";
        HttpPostedFile file = context.Request.Files["headfile"];
        if (context.Session["TmpImg"] != null)
            File.Delete(context.Session["TmpImg"].ToString());
        string path = "UploadImgs\\";
        //Bitmap map = new Bitmap(filePath);
        string fileName = Guid.NewGuid().ToString()+Path.GetFileName(file.FileName);
        string mapPath = context.Server.MapPath("~");
        string savePath = mapPath + "\\" + path + fileName;
        context.Session["TmpImg"] = savePath;
        //map.Save(savePath);  
        file.SaveAs(savePath);
        //上传成功后显示IMG文件
        context.Response.Write(path+fileName);
    }

    public bool IsReusable
    {
        get
        {
            return false;
        }
    }

}
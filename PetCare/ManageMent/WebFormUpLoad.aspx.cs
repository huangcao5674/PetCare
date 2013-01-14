using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

namespace PetCare.ManageMent
{
    public partial class WebFormUpLoad : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
  
 

        protected void UpLoadPhoto_Click1(object sender, EventArgs e)
        {
            if (FileUpload1.HasFile)
            {
                string fileContentType = FileUpload1.PostedFile.ContentType;
                if (fileContentType == "image/bmp" || fileContentType == "image/gif" || fileContentType == "image/pjpeg")
                {
                    string name = FileUpload1.PostedFile.FileName; // 客户端文件路径 
                    FileInfo file = new FileInfo(name);
                    string fileName = file.Name; // 文件名称 
                    string fileName_s = "s_" + file.Name; // 缩略图文件名称                 
                    string webFilePath = Server.MapPath("../Images/" + fileName); // 服务器端文件路径 
                    string webFilePath_s = Server.MapPath("../Images/" + fileName_s);　　// 服务器端缩略图路径 
                    if (!File.Exists(webFilePath))
                    {
                        try
                        {
                            FileUpload1.SaveAs(webFilePath); // 使用 SaveAs 方法保存文件 
                            MakeThumbnail(webFilePath, webFilePath_s, 100, 100, "Cut"); // 生成缩略图方法 
                           // ScriptManager.RegisterStartupScript(UpdatePanel1, typeof(UpdatePanel), "scriptname", "alert('文件上传成功!')", true);
                            //this.RegisterStartupScript("hello", "<script>alert('文件上传成功!')</script>");
                          //  Tools.AddLog("0", "上传照片成功信息成功！");
                            imgPhoto.Visible = true;
                            imgPhoto.ImageUrl = webFilePath_s;
                          //  PhotoUrl = webFilePath_s;
                        }
                        catch (Exception ex)
                        {
                          //  Tools.AddLog("1", "上传照片成功信息失败！");
                            throw new Exception("提示：文件上传失败，失败原因" + ex.Message);
                        }
                    }
                    else
                    {
                        this.RegisterStartupScript("hello", "<script>alert('图片已经存在，请重命名后上传!')</script>");
                    }
                }
                else
                {
                    this.RegisterStartupScript("hello", "<script>alert('文件类型不符!')</script>");
                }
            }
            else
            {
               // ScriptManager.RegisterStartupScript(UpdatePanel1, typeof(UpdatePanel), "scriptname", "alert('请选择照片!')", true);
            }
        }



        /// <summary> 
        /// 生成缩略图 
        /// </summary> 
        /// <param name="originalImagePath">源图路径（物理路径）</param> 
        /// <param name="thumbnailPath">缩略图路径（物理路径）</param> 
        /// <param name="width">缩略图宽度</param> 
        /// <param name="height">缩略图高度</param> 
        /// <param name="mode">生成缩略图的方式</param> 
        public static void MakeThumbnail(string originalImagePath, string thumbnailPath, int width, int height, string mode)
        {
            System.Drawing.Image originalImage = System.Drawing.Image.FromFile(originalImagePath);

            int towidth = width;
            int toheight = height;

            int x = 0;
            int y = 0;
            int ow = originalImage.Width;
            int oh = originalImage.Height;

            switch (mode)
            {
                case "HW"://指定高宽缩放（可能变形） 
                    break;
                case "W"://指定宽，高按比例 
                    toheight = originalImage.Height * width / originalImage.Width;
                    break;
                case "H"://指定高，宽按比例 
                    towidth = originalImage.Width * height / originalImage.Height;
                    break;
                case "Cut"://指定高宽裁减（不变形） 
                    if ((double)originalImage.Width / (double)originalImage.Height > (double)towidth / (double)toheight)
                    {
                        oh = originalImage.Height;
                        ow = originalImage.Height * towidth / toheight;
                        y = 0;
                        x = (originalImage.Width - ow) / 2;
                    }
                    else
                    {
                        ow = originalImage.Width;
                        oh = originalImage.Width * height / towidth;
                        x = 0;
                        y = (originalImage.Height - oh) / 2;
                    }
                    break;
                default:
                    break;
            }

            //新建一个bmp图片 
            System.Drawing.Image bitmap = new System.Drawing.Bitmap(towidth, toheight);

            //新建一个画板 
            System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(bitmap);

            //设置高质量插值法 
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.High;

            //设置高质量,低速度呈现平滑程度 
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;

            //清空画布并以透明背景色填充 
            g.Clear(System.Drawing.Color.Transparent);

            //在指定位置并且按指定大小绘制原图片的指定部分 
            g.DrawImage(originalImage, new System.Drawing.Rectangle(0, 0, towidth, toheight),
            new System.Drawing.Rectangle(x, y, ow, oh),
            System.Drawing.GraphicsUnit.Pixel);

            try
            {
                //以jpg格式保存缩略图 
                bitmap.Save(thumbnailPath, System.Drawing.Imaging.ImageFormat.Jpeg);
            }
            catch (System.Exception e)
            {
                throw e;
            }
            finally
            {
                originalImage.Dispose();
                bitmap.Dispose();
                g.Dispose();
            }
        }
    }
}
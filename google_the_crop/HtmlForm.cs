using System;
using System.IO;
using System.Text;
using System.Net;
using System.Xml.Linq;
using Pinta.Core;

namespace GoogleTheCrop
{
    public static class HtmlForm
    {
        private const string HtmlTemplateP1 = "<html><head><title>Google Image</title></head>" +
                                              "<body><form id=\"f\" method=\"POST\" " +
                                              "action=\"https://www.google.com/searchbyimage/upload\" enctype=\"multipart/form-data\">" +
                                              "<input type=\"hidden\" name=\"image_content\" value=\"";
        private const string HtmlTemplateP2 = "\">" +
                                              "<input type=\"hidden\" name=\"filename\" value=\"\">" +
                                              "<input type=\"hidden\" name=\"image_url\" value=\"\">" +
                                              "<input type=\"hidden\" name=\"sbisrc\" value=\"cr_1_5_1\">" +
                                              "</form>" +
                                              "<script>document.getElementById(\"f\").submit();</script></body></html>";

        public static string Encode (string imgFilePath)
        {
            byte[] imageData;

            FileStream fileStream = File.OpenRead (imgFilePath);
            imageData = new byte[fileStream.Length];
            fileStream.Read (imageData, 0, imageData.Length);
            fileStream.Close ();

            string base64img = System.Convert.ToBase64String (imageData);
            base64img = base64img.Replace ("+", "-").Replace ("/", "_").Replace (".", "=");

            var htmlForm = Encoding.ASCII.GetBytes (HtmlTemplateP1 + base64img + HtmlTemplateP2);

            var htmlPath = imgFilePath + ".html";

            FileStream output = File.OpenWrite (htmlPath);
            output.Write (htmlForm, 0, htmlForm.Length);
            output.Close ();

            return htmlPath;
        }
    }
}

using System;
using System.IO;
using System.Text;
using System.Net;
using System.Xml.Linq;
using Pinta.Core;


namespace GoogleTheCrop
{
    public static class Imgur
    {
        private const String API_KEY = "ecf58baa7533e4c4535205bcac51a010";

        public static string Upload (string imagFilePath)
        {
            byte[] imageData;

            FileStream fileStream = File.OpenRead (imagFilePath);
            imageData = new byte[fileStream.Length];
            fileStream.Read (imageData, 0, imageData.Length);
            fileStream.Close ();

            const int MAX_URI_LENGTH = 32766;
            string base64img = System.Convert.ToBase64String (imageData);
            StringBuilder sb = new StringBuilder ();

            for (int i = 0; i < base64img.Length; i += MAX_URI_LENGTH) {
                sb.Append (Uri.EscapeDataString (base64img.Substring (i, Math.Min (MAX_URI_LENGTH, base64img.Length - i))));
            }

            string uploadRequestString =
                "image=" + sb.ToString () +
                "&key=" + API_KEY;

            System.Net.ServicePointManager.ServerCertificateValidationCallback += (o, certificate, chain, errors) => true;
            HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create ("https://api.imgur.com/2/upload");
            webRequest.Method = "POST";
            webRequest.ContentType = "application/x-www-form-urlencoded";
            webRequest.ServicePoint.Expect100Continue = false;

            StreamWriter streamWriter = new StreamWriter (webRequest.GetRequestStream ());
            streamWriter.Write (uploadRequestString);
            streamWriter.Close ();

            WebResponse response = webRequest.GetResponse ();
            Stream responseStream = response.GetResponseStream ();
            StreamReader responseReader = new StreamReader (responseStream);

            string responseString = responseReader.ReadToEnd ();

            return ParseResult(responseString);
        }

        private static string ParseResult (string result)
        {
            XDocument resultXML = XDocument.Parse (result);
            var url = resultXML.Element ("upload").Element ("links").Element ("original").Value;
            Log.Line (url);
            Log.Line (resultXML.Element ("upload").Element ("links").Element ("delete_page").Value);
            return url;
        }
    }
}

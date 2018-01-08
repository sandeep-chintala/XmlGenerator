using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Xml;
using XmlGenerator.BL;
using XmlGenerator.Models;

namespace XmlGenerator.WebApi.Controllers
{
    public class FileController : ApiController
    {
        public List<KeyValuePair<string, string>> XmlKeyvalue = new List<KeyValuePair<string, string>>();
        public void Post([FromBody]string file)
        {

        }
        public string Get()
        {
            return "File controller";
        }

        [Route("file/upload")]
        public XmlField UploadFile()
        {
            HttpResponseMessage response = new HttpResponseMessage();
            var httpRequest = HttpContext.Current.Request;
            if (httpRequest.Files.Count > 0)
            {
                foreach (string file in httpRequest.Files)
                {
                    var postedFile = httpRequest.Files[file];
                    var filePath = HttpContext.Current.Server.MapPath("~/" + postedFile.FileName);
                    XmlFileParser xmlFileParser = new XmlFileParser();
                    XmlField xmlField = xmlFileParser.ParseFile(postedFile.InputStream);
                    return xmlField;                    
                }
            }
            return null;
        }
    }
}

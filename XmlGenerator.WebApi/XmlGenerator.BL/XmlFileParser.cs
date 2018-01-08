using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using XmlGenerator.Models;

namespace XmlGenerator.BL
{
    public class XmlFileParser
    {
        public XmlField xmlKeyvalue = new XmlField();
        public XmlField ParseFile(Stream stream)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(stream);
            xmlKeyvalue.Key = "Data";
            xmlKeyvalue.Values = new List<ChildField>();
            xmlKeyvalue.childKey = new List<XmlField>();
            foreach (XmlNode xmlNode in doc.DocumentElement.ChildNodes)
            {
                GetKeyValueFromNode(xmlNode, xmlKeyvalue);
            }
            return xmlKeyvalue;
        }

        private XmlField GetKeyValueFromNode(XmlNode node, XmlField xmlKeyValue)
        {
            XmlField childKeyField = new XmlField();
            childKeyField.Key = node.Name;
            childKeyField.Values = new List<ChildField>();
            childKeyField.childKey = new List<XmlField>();
            if (node.HasChildNodes)
            {
                if (node.ChildNodes.Count==1 && node.FirstChild.NodeType == XmlNodeType.Text)
                {
                    xmlKeyValue.Values.Add(new ChildField() { key = node.Name, value = node.FirstChild.Value });
                }
                else
                {
                    foreach (XmlNode childNode in node.ChildNodes)
                    {
                        GetKeyValueFromNode(childNode, childKeyField);
                    }
                    xmlKeyValue.childKey.Add(childKeyField);
                }
            }            
            return xmlKeyValue;
        }
    }
}

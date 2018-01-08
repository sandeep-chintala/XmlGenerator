using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XmlGenerator.Models
{
    public class XmlField
    {
        public string Key { set; get; }
        public List<ChildField> Values { get; set; }
        public List<XmlField> childKey { get; set; }
    }
}

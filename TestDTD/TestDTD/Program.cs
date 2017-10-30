using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace TestDTD
{
    class Program
    {
        static void Main(string[] args)
        {
            ReadXML();
        }

        public static void ReadXML()
        {
            XDocument doc = XDocument.Load(@"c:\users\administrator\documents\visual studio 2013\Projects\TestDTD\TestDTD\XMLFile1.xml");
            //XElement root = doc.Root;
            //Console.WriteLine(root.Value);
            foreach (XElement item in doc.Root.Elements())
            {
                Console.WriteLine(item);
            }

            
            XElement xele = doc.Root.Element("书").Element("价格");
            //Console.WriteLine(xele.Value);

            //xele.AddAfterSelf(new XElement("AddDate", DateTime.Now));
            

        }
    }
}

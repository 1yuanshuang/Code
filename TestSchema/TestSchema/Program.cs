using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Schema;

namespace TestSchema
{
    class Program
    {
        static void Main(string[] args)
        {
            string xsdMarkup =@"<xsd:schema xmlns:xsd='http://www.w3.org/2001/XMLSchema'>
                   <xsd:element name='Root'>
                    <xsd:complexType>
                     <xsd:sequence>
                      <xsd:element name='Child1' minOccurs='1' maxOccurs='1'/>
                      <xsd:element name='Child2' minOccurs='1' maxOccurs='1'/>
                     </xsd:sequence>
                    </xsd:complexType>
                   </xsd:element>
                  </xsd:schema>";
            XmlSchemaSet schemas = new XmlSchemaSet();
            schemas.Add("", XmlReader.Create(new StringReader(xsdMarkup)));

            XDocument doc1 = new XDocument(new XElement("Root",
                    new XElement("Child1", "content1"),
                    new XElement("Child2", "content1")
                )
            );

            XDocument doc2 = new XDocument(
                new XElement("Root",
                    new XElement("Child1", "content1"),
                    new XElement("Child3", "content1")
                )
            );

            Console.WriteLine("Validating doc1");
            bool errors = false;
            doc1.Validate(schemas, (o, e) =>
            {
                Console.WriteLine("{0}", e.Message);
                errors = true;
            });
            Console.WriteLine("doc1 {0}", errors ? "did not validate" : "validated");

            Console.WriteLine();
            Console.WriteLine("Validating doc2");
            errors = false;
            doc2.Validate(schemas, (o, e) =>
            {
                Console.WriteLine("{0}", e.Message);
                errors = true;
            });
            Console.WriteLine("doc2 {0}", errors ? "did not validate" : "validated");    
            
            //XNamespace xsiNs = "http://www.w3.org/2001/XMLSchema-instance";
            //XDocument doc = XDocument.Load(@"c:\users\y0019.synthflex\documents\visual studio 2012\Projects\TestSchema\TestSchema\XMLFile1.xml", LoadOptions.SetLineInfo);
            //XmlSchemaSet schemaSet = new XmlSchemaSet();
            
            //if (doc.Root.Attribute(xsiNs + "noNamespaceSchemaLocation") != null)
            //{
            //    schemaSet.Add(null, doc.Root.Attribute(xsiNs + "noNamespaceSchemaLocation").Value);
            //}

            //doc.Validate(schemaSet, delegate(object sender, ValidationEventArgs vargs)
            //{
            //    IXmlLineInfo lineInfo = sender as IXmlLineInfo;
            //    Console.WriteLine("{0}: {1}; Line: {2}", vargs.Severity, vargs.Message, lineInfo.LineNumber);
            //}, true); 

          
            
            //XmlReaderSettings settings = new XmlReaderSettings();
            //settings.DtdProcessing = DtdProcessing.Parse;//DtdProcessin 获取或设置确定 DTD 的处理的值。
            //settings.ValidationType = ValidationType.DTD;//ValidationType获取或设置一个值，该值指示是否XmlReader将执行验证或读取时键入分配。
            //settings.ValidationEventHandler += new ValidationEventHandler(ValidationCallBack); //ValidationEventHandler 在读取器遇到验证错误时发生

            //XmlReader reader = XmlReader.Create(@"c:\users\y0019.synthflex\documents\visual studio 2012\Projects\TestSchema\TestSchema\XMLFile1.xml", settings);
            //// Parse the file. 
            //while (reader.Read()) ;
        }

        // Display any validation errors.
        //private static void ValidationCallBack(object sender, ValidationEventArgs e)
        //{
        //    Console.WriteLine("Validation Error: {0}", e.Message);
        //}
    }
}

//通过 XmlReader 使用 DTD 进行验证

//文档类型定义 (DTD) 验证使用在万维网联合会 (W3C) 可扩展标记语言 (XML) 1.0 建议中定义的有效性约束来实现。 DTD 使用形式语法来描述符合标准的 XML 文档的结构和语法；它们指定 XML 文档所允许的内容和值。
//为针对 DTD 执行验证，XmlReader 使用 XML 文档的 DOCTYPE 声明中所定义的 DTD。 DOCTYPE 声明既可以指向内联 DTD，也可以是对外部 DTD 文件的引用。
//将 XmlReaderSettings.DtdProcessing 属性设置为 DtdProcessing.Parse.
//将 XmlReaderSettings.ValidationType 属性设置为 ValidationType.DTD。
//如果 DTD 是存储在要求进行身份验证的网络资源上的外部文件，请将具有必要凭据的 XmlResolver 对象传递给 Create 方法。

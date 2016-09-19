using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using TestXml.Properties;

namespace TestXml
{
    public class Program
    {
        public static void Main(string[] args)
        {
            XDocument doc = XDocument.Parse(Resources._2016_05_25T14_34_10_891_BNDA201605250013);

            string val = doc.Root.Element("BIC").Value;
            var authors = doc.Descendants("SttlmInf");
            Console.WriteLine(val);
            foreach (var author in authors)
            {
                Console.WriteLine(author.Value);
            }
            Console.ReadLine();
        }
    }
}

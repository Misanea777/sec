using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml;

namespace Sesiuriti
{
    class AuditFileParser
    {
        private FileReader fileReader;
        private string safeFileName;
        public XmlDocument doc = new XmlDocument();
        private static string initialTemplate = "<custom_item>";
        private static Regex initialRx = new Regex(initialTemplate, RegexOptions.Compiled);
        private static string endTemplate = "</custom_item>";
        private static Regex endRx = new Regex(endTemplate, RegexOptions.Compiled);
        private static Regex rx = new Regex("^      (?<name>\\S+)\\s*:\\s(?<value>(\".+\")|(\\S.+\\S))",
            RegexOptions.Compiled);


        public AuditFileParser(string fileName, string SafeFileName)
        {
            safeFileName = SafeFileName;
            fileReader = new FileReader(fileName);
            doc.LoadXml("<?xml version='1.0' ?>" + "<root></root>" );
        }

        public void fileParser()
        {
            XmlElement Xelement;
            int ItemIndex = 0;


            //GC.TryStartNoGCRegion(10);

            while (true)
            {
                while (initialRx.Matches(fileReader.currentLine).Count == 0)
                {
                    fileReader.getNextLine();
                    if (fileReader.currentLine == null)
                    {
                        doc.Save(safeFileName + ".xml");
                        return;
                    }
                }

                fileReader.getNextLine();
                ItemIndex++;
                Xelement = doc.CreateElement("item_" + ItemIndex);
                createItemElement(Xelement);
                doc.DocumentElement.AppendChild(Xelement);
            }
        }

        private void createItemElement(XmlElement Xelement)
        {
            XmlElement labelElement = doc.CreateElement("void");
            Label tmp;

            while (true)
            {
                tmp = createLabel();
                if (tmp.Name == "")
                {
                    labelElement.InnerText += fileReader.currentLine;
                }
                else
                {
                    labelElement = doc.CreateElement(tmp.Name);
                    labelElement.InnerText = tmp.Value;
                    Xelement.AppendChild(labelElement);
                }


                fileReader.getNextLine();
                if (endRx.Matches(fileReader.currentLine).Count > 0)
                {
                    break;
                }
            }

            return;
        }

        public Label createLabel()
        {
            Match m = rx.Match(fileReader.currentLine); 
            string name = "";
            string value = "";
            try
            {
                name = m.Groups["name"].Value;
                value = m.Groups["value"].Value;
            }
            catch (Exception ex) { }

            return new Label(name, value);
        }
        
    }
}

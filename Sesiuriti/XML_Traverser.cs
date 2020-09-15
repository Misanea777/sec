using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace Sesiuriti
{
    class XML_Traverser
    {
        public XmlDocument doc = new XmlDocument();
        public XmlNode root;

        public XML_Traverser(string path)
        {
            doc.Load(path);
            root = doc.FirstChild.NextSibling; 
        }

        public void AddNode(XmlNode inXmlNode, TreeNode inTreeNode)
        {
            // Loop through the XML nodes until the leaf is reached.
            // Add the nodes to the TreeView during the looping process.
            if (inXmlNode.ChildNodes.OfType<XmlElement>().Any())
            {
                XmlNodeList nodeList = inXmlNode.ChildNodes;
                if(nodeList.Count > 1)
                {
                    for (int i = 0; i <= nodeList.Count - 1; i++)
                    {
                        XmlNode xNode = inXmlNode.ChildNodes[i];
                        inTreeNode.Nodes.Add(new TreeNode(xNode.ChildNodes.Item(1).InnerText));
                        TreeNode tNode = inTreeNode.Nodes[i];
                        //AddIntermediarNode(xNode, tNode);
                    }
                }

            }
        }
        

        public XmlNode findItemByIndex(int index)
        {
            XmlNodeList nodes = root.SelectNodes("item_"+index);
            return nodes[0];
        }

        
    }
}

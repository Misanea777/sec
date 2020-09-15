using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace Sesiuriti
{
    public partial class Form1 : Form
    {
        XML_Traverser xmlTraverser;
        XmlDocument doc = new XmlDocument();
        public Form1()
        {
            InitializeComponent();
            Controller();
        }



        private void Controller()
        {
            OpenButton.Visible = false;
            textBox1.Visible = false;
            AddButton.Visible = false;
            CancelButton.Visible = false;
            FileNameLabel.Visible = false;
            FileNameTextBox.Visible = false;
            SavePolicyTextBox.Visible = false;
            Cbutton.Visible = false;

            PoliciesTreeView.CheckBoxes = true;

            string[] paresedFilesDir = getParsedFilesDir();
            updatePoliciesList(paresedFilesDir);

        }

        private void updatePoliciesList(string[] policiesList)
        {
            comboBox1.Items.Clear();
            foreach (string s in policiesList)
            {
                comboBox1.Items.Add(Path.GetFileName(s));
            }
        }

        private string[] getParsedFilesDir()
        {
            var path = System.IO.Path.GetDirectoryName(
                System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase).Substring(6);
            return Directory.GetFiles(path, "*.xml");
        }




        public OpenFileDialog ofd = new OpenFileDialog();
        private void button2_Click(object sender, EventArgs e)
        {
            ofd.Filter = "AUDIT|*.audit";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = ofd.FileName;
                FileNameTextBox.Text = (Path.GetFileNameWithoutExtension(ofd.SafeFileName));


            }
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.TextLength != 0)
            {
                OpenButton.Visible = false;
                textBox1.Visible = false;
                AddButton.Visible = false;
                CancelButton.Visible = false;
                FileNameLabel.Visible = false;
                FileNameTextBox.Visible = false;

                Cursor = Cursors.WaitCursor;
                

                AuditFileParser parser = new AuditFileParser(textBox1.Text, FileNameTextBox.Text);
                parser.fileParser();
                updatePoliciesList(getParsedFilesDir());

                Cursor = Cursors.Arrow;
                AddNewButton.Visible = true;
            }
        }


        private void comboBox1_SelectionChangeCommitted(object sender, EventArgs e)
        {
            PoliciesTreeView.Nodes.Clear();
            string name = comboBox1.SelectedItem.ToString();
            name = name.Substring(0, name.Length - 4);
            TreeNode mainNode =  PoliciesTreeView.Nodes.Add(name);
            xmlTraverser = new XML_Traverser(comboBox1.SelectedItem.ToString());
            xmlTraverser.AddNode(xmlTraverser.root, mainNode);

        }

        private void button3_Click(object sender, EventArgs e)
        {
            AddNewButton.Visible = false;
            OpenButton.Visible = true;
            textBox1.Visible = true;
            AddButton.Visible = true;
            CancelButton.Visible = true;
            FileNameLabel.Visible = true;
            FileNameTextBox.Visible = true;

        }

        private void button4_Click(object sender, EventArgs e)
        {
            OpenButton.Visible = false;
            textBox1.Visible = false;
            CancelButton.Visible = false;
            AddButton.Visible = false;
            AddNewButton.Visible = true;
            FileNameLabel.Visible = false;
            FileNameTextBox.Visible = false;
        }

   

        public void createCustomAuditFile(List<int> itemIndexes)
        {
            
            doc.LoadXml("<?xml version='1.0' ?>" + "<root></root>");
            foreach (int index in itemIndexes)
            {
                XmlNode exNode = xmlTraverser.findItemByIndex(index);
                XmlNode importNode = doc.ImportNode(exNode, true);
                doc.DocumentElement.AppendChild(importNode);
 
            }
            SavePolicyTextBox.Visible = true;
            Cbutton.Visible = true;
            CreateButton.Visible = false;

        }


        public List<int> getSelectedPoliciesIndex(TreeNodeCollection nodes)
        {
            List<int> selectedNodes = new List<int>();
            foreach (TreeNode aNode in nodes)
            {
                if (!aNode.Checked)
                    continue;
                selectedNodes.Add(aNode.Index + 1);
                //Console.WriteLine(aNode.Name);
            }
            return selectedNodes;
        }

        private void Cbutton_Click(object sender, EventArgs e)
        {
            SavePolicyTextBox.Visible = false;
            Cbutton.Visible = false;
            CreateButton.Visible = true;
            doc.Save(SavePolicyTextBox.Text + ".xml");
            updatePoliciesList(getParsedFilesDir());
        }

        private void CreateButton_Click_1(object sender, EventArgs e)
        {
            TreeNode node = PoliciesTreeView.Nodes[0];
            createCustomAuditFile(getSelectedPoliciesIndex(node.Nodes));
        }

        public void filterNodes()
        {
            TreeNode mainNode = PoliciesTreeView.Nodes[0];
  
            int len = mainNode.Nodes.Count;
            for (int i=0; i<len; i++)
            {
                if (!mainNode.Nodes[i].Text.Contains(SearchTextBox.Text))
                {
                    Console.WriteLine(mainNode.Nodes[i].Text);
                    mainNode.Nodes[i].Remove();
                    i--;
                    len--;
                }
            }

        }

        private void SearchButton_Click(object sender, EventArgs e)
        {
            comboBox1_SelectionChangeCommitted(new object(), new EventArgs());
            filterNodes();
            
        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }

        private void button1_Click_2(object sender, EventArgs e)
        {

        }

        private void SelectAllButton_Click(object sender, EventArgs e)
        {
            TreeNode node = PoliciesTreeView.Nodes[0];
            foreach (TreeNode aNode in node.Nodes)
            {
                aNode.Checked = true;
            }
        }

        private void DeselectAllButton_Click(object sender, EventArgs e)
        {
            TreeNode node = PoliciesTreeView.Nodes[0];
            foreach (TreeNode aNode in node.Nodes)
            {
                aNode.Checked = false;
            }
        }
    }
}

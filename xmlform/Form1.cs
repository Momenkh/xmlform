using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;


namespace xmlform
{
    
    public partial class Form1 : Form
    {
        XmlDocument xmldoc;
        XmlNodeList name;
        XmlNodeList phones;
        XmlNodeList addresses;
        XmlNodeList email;
        int count = 0;
        public Form1()
        {
            xmldoc = new XmlDocument();
            xmldoc.Load(@"D:\Momen\ITI\XML\Tasks\1.xml");
           
            InitializeComponent();
            
            try
            {
                
                
                name = xmldoc.GetElementsByTagName("name");
                textBox1.Text = name[0].InnerText;
                phones = xmldoc.GetElementsByTagName("phone");
                textBox2.Text = phones[0].InnerText;
                addresses = xmldoc.GetElementsByTagName("address");
                textBox3.Text = addresses[0].InnerText;
                email = xmldoc.GetElementsByTagName("email");
                textBox4.Text = email[0].InnerText;
            }
            catch
            {
                MessageBox.Show("error");
            }
           

        }

        private void button2_Click(object sender, EventArgs e) //next
        {
            XmlDocument xmldoc = new XmlDocument();
            if (count >= 0)
            {
                count++;
                textBox1.Text = name[count].InnerText;
                textBox2.Text = phones[count].InnerText;
                textBox3.Text = addresses[count].InnerText;
                textBox4.Text = email[count].InnerText;
            }
                
            
        }

        private void button1_Click(object sender, EventArgs e) //prev
        {
            if (count > 0)
            {
                count--;
                textBox1.Text = name[count].InnerText;
                textBox2.Text = phones[count].InnerText;
                textBox3.Text = addresses[count].InnerText;
                textBox4.Text = email[count].InnerText;
            }
        }

        private void button3_Click(object sender, EventArgs e) //search
        {
            int flag = 0;
            for(int i=0;i<name.Count;i++)
            {

                if (name[i].InnerText == textBox1.Text)
                {
                    count = i;
                    try
                    {
                        textBox1.Text = name[count].InnerText;
                        textBox2.Text = phones[count].InnerText;
                        textBox3.Text = addresses[count].InnerText;
                        textBox4.Text = email[count].InnerText;
                        
                    }
                    catch { }
                    flag = 1;
                    break;
                }
                else flag = 0;
                
            }
            if (flag == 0) { MessageBox.Show("user not found"); }
            
        }

        private void button4_Click(object sender, EventArgs e) //insert
        {
            XmlDocument xmldoc = new XmlDocument();
            xmldoc.Load(@"D:\Momen\ITI\XML\Tasks\1.xml");
            XmlElement root = xmldoc.CreateElement("employee");
            XmlElement name = xmldoc.CreateElement("name");
            XmlElement phone = xmldoc.CreateElement("phone");
            XmlElement address = xmldoc.CreateElement("address");
            XmlElement email = xmldoc.CreateElement("email");
            name.InnerText = textBox1.Text;
            phone.InnerText = textBox2.Text;
            address.InnerText = textBox3.Text;
            email.InnerText = textBox4.Text;
            root.AppendChild(name);
            root.AppendChild(phone);
            root.AppendChild(address);
            root.AppendChild(email);
            xmldoc.DocumentElement.AppendChild(root);
            xmldoc.Save(@"D:\Momen\ITI\XML\Tasks\1.xml");
            MessageBox.Show("success");
        }

        private void button5_Click(object sender, EventArgs e) //update
        {
            name[count].InnerText = textBox1.Text;
            phones[count].InnerText = textBox2.Text;
            addresses[count].InnerText = textBox3.Text;
            email[count].InnerText = textBox4.Text;
            xmldoc.Save(@"D:\Momen\ITI\XML\Tasks\1.xml");
            MessageBox.Show("successful update");
        }

        private void button6_Click(object sender, EventArgs e) //delete
        {
            XmlElement root = xmldoc.DocumentElement;
            XmlNode employee = root?.LastChild;
            XmlNode prev = employee.PreviousSibling;
            employee.OwnerDocument.DocumentElement.RemoveChild(employee);

            if (prev.NodeType == XmlNodeType.SignificantWhitespace)
            {
                prev.OwnerDocument.DocumentElement.RemoveChild(prev);
            }
            xmldoc.Save(@"D:\Momen\ITI\XML\Tasks\1.xml");
            MessageBox.Show("deleted");
            count--;
            xmldoc.Load(@"D:\Momen\ITI\XML\Tasks\1.xml");

        }

        private void button7_Click(object sender, EventArgs e) //save
        {
            xmldoc.Save(@"D:\Momen\ITI\XML\Tasks\1.xml");
            MessageBox.Show("saved");
            xmldoc.Load(@"D:\Momen\ITI\XML\Tasks\1.xml");
        }
    }
}

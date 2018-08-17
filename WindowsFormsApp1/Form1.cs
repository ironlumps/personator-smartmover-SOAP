using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
using System.Net;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        Personator.Request req = new Personator.Request();
        Personator.Response rep = new Personator.Response();
        Personator.ServicemdContactVerifySOAP action = new Personator.ServicemdContactVerifySOAP();

        int ARRAYSIZE;
        XmlSerializer XmlSer;
        FileStream fs;
        XmlDocument xmlDoc = new XmlDocument();


        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            label1.Text = "Adress 1: ";

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            label1.Text = "Address 1: ";
            button1.Text = "Send Request";
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            ARRAYSIZE = 1;
            InitializeComponent();

            req.Records[0] = new Personator.RequestRecord();
            req.Records[0].RecordID = "1";

            req.Records[0].AddressLine1 = label1.Text;

            try
            {
                rep = action.doContactVerify(req);

                XmlSer = new XmlSerializer(rep.GetType());

                fs = new FileStream((System.Environment.CurrentDirectory + "\\Response.xml"), FileMode.Create);
                XmlSer.Serialize(fs, rep);
                fs.Close();
              
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception: " + ex.Message + "\r\n");
                return;
            }

            label1.Text = rep.Records[0].AddressLine1;

            
        }
    }
}

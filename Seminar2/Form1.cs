using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace Seminar2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            string filename = openFileDialog1.FileName;
            string readfile = File.ReadAllText(filename);
            richTextBox1.Text = readfile;
            string result = Regex.Replace(readfile, @"<[^>]*>", String.Empty);
            richTextBox2.Text = result;
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
          
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string html_text = richTextBox1.Text;
            string result = Regex.Replace(html_text, @"<[^>]*>", String.Empty);
            richTextBox2.Text = result;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string url = textBox1.Text;
            System.Net.HttpWebRequest request = (System.Net.HttpWebRequest)System.Net.WebRequest.Create(url);
            System.Net.HttpWebResponse response = (System.Net.HttpWebResponse)request.GetResponse();

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                Stream receiveStream = response.GetResponseStream();
                StreamReader readStream = new StreamReader(receiveStream, Encoding.GetEncoding(response.CharacterSet));
                string data = readStream.ReadToEnd();
                String result = Regex.Replace(data, @"<[^>]*>", String.Empty);
                richTextBox2.Text = result;
                response.Close();
                readStream.Close();
            }

        }
    
    }
}

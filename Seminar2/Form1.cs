using System;
using System.ComponentModel;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Net;

namespace Seminar2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "HTML files|*.htm;*.html|All files|*.*";
            openFileDialog1.FileName = "Select file";
            openFileDialog1.Title = "Choose file";
            if (openFileDialog1.ShowDialog()== DialogResult.OK)
            {
            
            richTextBox1.Text = File.ReadAllText(openFileDialog1.FileName); ;
            string result = Regex.Replace(richTextBox1.Text, @"<.*?>", String.Empty);
            richTextBox2.Text = WebUtility.HtmlDecode(result);
            }
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
          
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string html_text = richTextBox1.Text;
            string result = Regex.Replace(html_text, @"<.*?>", String.Empty);
            richTextBox2.Text = WebUtility.HtmlDecode(result);
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
                richTextBox1.Text = data;
                String result = Regex.Replace(data, @"<.*?>", String.Empty);
                richTextBox2.Text = WebUtility.HtmlDecode(result);
                response.Close();
                readStream.Close();
            }

        }
    
    }
}

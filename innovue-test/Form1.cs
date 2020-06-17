using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Net;
using System.Xml.Linq;
using System.Text.RegularExpressions;

namespace innovue_test
{
    public partial class WorkTwo : Form
    {
        public WorkTwo()
        {
            InitializeComponent();
            textBox1.Text = "6001234";
            textBox2.Text = "https://www.google.com.tw/";
        }

        public static string urlx = null;
        public static MatchCollection matches;
        public static string xpr = null;//正則後暫存用

        private void button1_Click(object sender, EventArgs e)
        {
            WebClient url = new WebClient();
            url.DownloadFile(textBox2.Text, textBox1.Text + ".html");
        }

        private void html2xml_Click(object sender, EventArgs e)
        {
            urlx = textBox1.Text;

            string path =   urlx + ".html";  //<相對路徑的html檔
            //Console.WriteLine(path);
            if (!File.Exists(path))
            {
                MessageBox.Show(path + " 檔案不存在");
            }
            else
            {
                StreamReader streamReader = new StreamReader(path, Encoding.GetEncoding("utf-8"));
                string content = streamReader.ReadToEnd();
                //MessageBox.Show(content);


                //string pattern = "<TITLE>[a-zA-Z0-9 !-@]+" + "</TITLE>";
                ////MatchCollection matches;

                //Regex defaultRegex = new Regex(pattern);

                ////Get matches of pattern in text
                //matches = defaultRegex.Matches(content);

                //foreach (Match ctr in matches)
                //{
                //    MatchCollection matches2;
                //    string pattern2 = @"[0-9]+";
                //    defaultRegex = new Regex(pattern2);
                //    matches2 = defaultRegex.Matches(ctr.Value);
                //    //Console.WriteLine(ctr.Value);
                //    foreach (Match ctr2 in matches2)
                //    {
                //        Console.WriteLine(ctr2);
                //        xpr = ctr2.Value;
                //    }
                //}//HTML段落正則，再取得需要的內容

                //pattern = @"[0-9]+";
                //defaultRegex = new Regex(pattern);
                //matches = defaultRegex.Matches(content);
                //foreach(Match ctr in matches)
                //{
                //    Console.WriteLine(ctr);

                //}


                String patten = @"[a-z_0-9]+" + ".png";
                Regex defaultRegex = new Regex(patten);
                matches = defaultRegex.Matches(content);
                //MessageBox.Show(content);
                foreach(Match ctr in matches)
                {
                    //Console.WriteLine(ctr);
                    MessageBox.Show(ctr.Value);

                }

                streamReader.Close();
                streamReader.Dispose();//關閉使用中的HTML

                //XDocument doc = new XDocument();

                //doc = new XDocument(
                //    new XElement("PatentInfo",
                //        new XElement("PN", xpr)
                //    )
                //);//編碼成XML格式

                //doc.Declaration = new XDeclaration("1.0", "utf-8", "true");//編碼格式
                //doc.Save(textBox1.Text + ".xml");//存檔


            }
         }

        private void xml2html_Click(object sender, EventArgs e)
        {
            urlx = textBox1.Text;

            string path = urlx + ".xml";  //<相對路徑的html檔
            Console.WriteLine(File.Exists(path));
            if (!File.Exists(path))
            { MessageBox.Show(path + "檔案不存在"); }
            else
            {


            }
        }
    }
}

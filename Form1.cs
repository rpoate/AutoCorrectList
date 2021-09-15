using System;
using System.Collections;
using System.IO;
using System.Windows.Forms;

namespace AutoCorrectList
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            this.htmlEditControl1.CSSText = "body {font-family: Segoe UI, Arial}";
            this.htmlEditControl1.EnableInlineSpelling = true;
            this.htmlEditControl1.SpellingAutoCorrectionList = ReadFileToHashTable("autocorrects.csv");
            this.htmlEditControl1.DocumentHTML = "<h1>Autocorrect List example</h2><p>Loads an autocorrect list from file into the SpellingAutoCorrectList property. Please note that the autocorrect acronyms are case-sensitive. Try typing <b>BRB</b>, <b>AFAIK</b>, <b>BISFLATM</b>, or <b>AWOL</b>";

        }

        private static Hashtable ReadFileToHashTable(string filepath)
        {
            string line;
            Hashtable oHash = new Hashtable();

            StreamReader sr = new StreamReader(filepath);

            while (sr.Peek() >= 0)
            {
                line = sr.ReadLine();
                try
                {
                    oHash.Add(line.Split(new char[] { ',' }, 2)[0], line.Split(new char[] { ',' }, 2)[1].Replace("\"", ""));
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message); // duplicate key
                }
            }
            sr.Close();

            return oHash;
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Net;
using System.Windows.Forms;

namespace BrowserLoginForms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            var appName = System.IO.Path.GetFileName(System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName);
            Microsoft.Win32.Registry.SetValue(@"HKEY_CURRENT_USER\Software\Microsoft\Internet Explorer\Main\FeatureControl\FEATURE_BROWSER_EMULATION",
                  appName, 11000, Microsoft.Win32.RegistryValueKind.DWord);
            InitializeComponent();
        }
        void IncarcaPagina()
        {
            webBrowser1.ScriptErrorsSuppressed = true;
            webBrowser1.Navigate("https://rodnia.net/users/login#section_container");
            System.Threading.Thread.Sleep(2000);
            
        }
        void scrieNume(string nume)
        {
            webBrowser1.Document.GetElementsByTagName("input").GetElementsByName("username")[1].SetAttribute("value", nume);
        }
        void scrieParola(string parola)
        {
            webBrowser1.Document.GetElementsByTagName("input").GetElementsByName("password")[1].SetAttribute("value", parola);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            IncarcaPagina();
        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            scrieNume("Hardy");
            scrieParola("Hardy12");
        }
        void AuthButton()
        {
           HtmlElementCollection elem = webBrowser1.Document.GetElementsByTagName("input");
            foreach(HtmlElement element in elem)
            {
                if(element.GetAttribute("value") == "Autentificare")
                {
                    element.InvokeMember("Click");
                }
            }

        }
        void Deconectare()
        {
            webBrowser1.Navigate("https://rodnia.net/users/logout");
            webBrowser1.DocumentCompleted += new WebBrowserDocumentCompletedEventHandler(webBrowser_DocumentCompleted);
        }
        void webBrowser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            webBrowser1.Navigate("https://rodnia.net/users/login#section_container");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            AuthButton();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Deconectare();
        }
    }
}

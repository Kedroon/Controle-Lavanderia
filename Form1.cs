using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Interactions;


namespace ConsultaSiscomex
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FirefoxDriver fox = new FirefoxDriver();
            fox.Navigate().GoToUrl("https://www.siscomex.gov.br/vicomex/public/index.jsf");
            fox.Manage().Timeouts().ImplicitlyWait((TimeSpan.FromSeconds(10)));
            //fox.manage().timeouts().pageLoadTimeout(10, TimeUnit.SECONDS);
            fox.FindElement(By.CssSelector("a.logo_certificado")).Click();
            SendKeys.SendWait("{ENTER}"); 

            /*FirefoxDriver fox = new FirefoxDriver();
            fox.Navigate().GoToUrl("https://www.youtube.com");
            fox.FindElementById("masthead-search-term").SendKeys("epic sax");
            SendKeys.SendWait("{ENTER}");
            fox.FindElement(By.LinkText("Epic sax guy 10 hours")).Click();*/
            


        }

        private void button2_Click(object sender, EventArgs e)
        {
            FirefoxDriver fox = new FirefoxDriver();
            fox.Navigate().GoToUrl("http://site.suframa.gov.br/assuntos/servicos");
            //fox.FindElement(By.LinkText("Consultas On-Line da Mercadoria Estrangeira")).Click();
            fox.FindElementByClassName("outstanding-header").Click();
            //fox.Manage().Timeouts().ImplicitlyWait((TimeSpan.FromSeconds(20)));
            //fox.FindElementById("login").Clear();
            SendKeys.SendWait("04337168000148");
            //fox.FindElementById("login").SendKeys("04337168000148");
            fox.FindElementById("senha2").Clear();
            fox.FindElementById("senha2").SendKeys("Shda2016");
            fox.FindElementById("btn01").Click();
            fox.FindElementByCssSelector("img[alt=\"Consultas e Serviços do Internamento Estrangeiro\"]").Click();
            fox.FindElementByLinkText("MOTO HONDA DA AMAZONIA LTDA.").Click();
            fox.FindElementByLinkText("Pedido de Licenciamento de Importação").Click();
            fox.FindElementByXPath("//div[@id='content']/table/tbody/tr/td/p[4]/font/a/small/font").Click();
            fox.FindElementById("inscsuf").Clear();
            fox.FindElementById("inscsuf").SendKeys("200076019");
            fox.FindElementById("numini").Clear();
            fox.FindElementById("numini").SendKeys("2016/06098");
            fox.FindElementById("numfim").Clear();
            fox.FindElementById("numfim").SendKeys("2016/06110");
            fox.FindElementById("ContinueBtn").Click();
        }
    }
}

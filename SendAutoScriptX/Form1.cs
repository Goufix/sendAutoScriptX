using FMUtils.KeyboardHook;
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
using System.Runtime.InteropServices;
using System.Threading;

namespace SendAutoScriptX
{
    public partial class Form1 : Form
    {
        bool topMost = false;
        Hook kb = new Hook("kb");
        int contagem = 0;
        List<string> frases = new List<string>();
        string arquivo = "";



        public Form1()
        {
            InitializeComponent();
            kb.KeyDownEvent += kbhooks;
            MessageBox.Show("Para deixar o programa sem borda, no canto da tela e sempre acima dos programas aperte F2\nPara avançar uma linha aperte F4\nPara retroceder uma linha aperte F3\n=============================================\nPara enviar o conteúdo da caixa de texto aperte F7");
        }

        [DllImport("user32.dll")]
        static extern void keybd_event(byte bVk, byte bScan, uint dwFlags, UIntPtr dwExtraInfo);

        #region MÉTODO CORREÇÃO
        private string CorrecaoLinha(string fraseErrada)
        {
            if (fraseErrada.IndexOf("{)}") != -1 || fraseErrada.IndexOf("{(}") != -1 || fraseErrada.IndexOf("{+}") != -1 || fraseErrada.IndexOf("{~}") != -1 ||
                fraseErrada.IndexOf("{^}") != -1 || fraseErrada.IndexOf("{%}") != -1)
            {
                return fraseErrada;
            }
            int inicio = 1;
            int ColcheteAbre, ColcheteFecha, Circuflexo, Porcentagem, Til, Mais = 0;
            string frase = fraseErrada;
            if (frase.IndexOf("(") != -1)
            {
                ColcheteAbre = 0;
            }
            else
            {
                ColcheteAbre = 1;
            }
            if (frase.IndexOf(")") != -1)
            {
                ColcheteFecha = 0;
            }
            else
            {
                ColcheteFecha = 1;
            }
            if (frase.IndexOf("^") != -1)
            {
                Circuflexo = 0;
            }
            else
            {
                Circuflexo = 1;
            }
            if (frase.IndexOf("%") != -1)
            {
                Porcentagem = 0;
            }
            else
            {
                Porcentagem = 1;
            }
            if (frase.IndexOf("~") != -1)
            {
                Til = 0;
            }
            else
            {
                Til = 1;
            }
            if (frase.IndexOf("+") != -1)
            {
                Mais = 0;
            }
            else
            {
                Mais = 1;
            }
            string frasePronta = "";
            while (ColcheteAbre == 0)
            {
                if (frase.IndexOf("(") != -1 && frase.IndexOf("{(}") == -1)
                {
                    string[] FraseSplit = frase.Split('(');
                    foreach (string x in FraseSplit)
                    {
                        if (inicio == 1)
                        {
                            frasePronta = frasePronta + x;
                            inicio = 0;
                        }
                        else
                        {
                            frasePronta = frasePronta + "{(}" + x;
                        }
                    }
                    ColcheteAbre = 1; frase = frasePronta; frasePronta = ""; inicio = 1;
                }
            }
            while (ColcheteFecha == 0)
            {
                if (frase.IndexOf(")") != -1 && frase.IndexOf("{)}") == -1)
                {
                    string[] FraseSplit = frase.Split(')');
                    //string frasePronta = "";
                    foreach (string x in FraseSplit)
                    {
                        if (inicio == 1)
                        {
                            frasePronta += x;
                            inicio = 0;
                        }
                        else
                        {
                            frasePronta = frasePronta + "{)}" + x;
                        }
                    }
                    ColcheteFecha = 1;
                    frase = frasePronta;
                    frasePronta = "";
                    inicio = 1;
                }
            }
            while (Circuflexo == 0)
            {
                if (frase.IndexOf("^") != -1 && frase.IndexOf("{^}") == -1)
                {
                    string[] FraseSplit = frase.Split('^');
                    //string frasePronta = "";
                    foreach (string x in FraseSplit)
                    {
                        if (inicio == 1)
                        {
                            frasePronta += x;
                            inicio = 0;
                        }
                        else
                        {
                            frasePronta = frasePronta + "{^}" + x;
                        }
                        Circuflexo = 1;
                        inicio = 1;
                        frase = frasePronta;
                    }
                    Circuflexo = 1;
                    frase = frasePronta;
                    frasePronta = "";
                    inicio = 1;
                }
                else { Circuflexo = 1; }
            }
            while (Porcentagem == 0)
            {
                if (frase.IndexOf("%") != -1 && frase.IndexOf("{%}") == -1)
                {
                    string[] FraseSplit = frase.Split('%');
                    //string frasePronta = "";
                    foreach (string x in FraseSplit)
                    {
                        if (inicio == 1)
                        {
                            frasePronta = frasePronta + x;
                            inicio = 0;
                        }
                        else
                        {
                            frasePronta = frasePronta + "{%}" + x;
                        }
                    }
                    Porcentagem = 1;
                    frase = frasePronta;
                    frasePronta = "";
                    inicio = 1;
                }
                else { Porcentagem = 1; }
            }
            while (Til == 0)
            {
                if (frase.IndexOf("~") != -1 && frase.IndexOf("{~}") == -1)
                {
                    string[] FraseSplit = frase.Split('~');
                    //string frasePronta = "";
                    foreach (string x in FraseSplit)
                    {
                        if (inicio == 1)
                        {
                            frasePronta += x;
                            inicio = 0;
                        }
                        else
                        {
                            frasePronta = frasePronta + "{~}" + x;
                        }
                    }
                    Til = 1;
                    frase = frasePronta;
                    frasePronta = "";
                    inicio = 1;
                }
                else { Til = 1; }
            }
            while (Mais == 0)
            {
                if (frase.IndexOf("+") != -1 && frase.IndexOf("{+}") == -1)
                {
                    string[] FraseSplit = frase.Split('+');
                    //string frasePronta = "";
                    foreach (string x in FraseSplit)
                    {
                        if (inicio == 1)
                        {
                            frasePronta += x;
                            inicio = 0;
                        }
                        else
                        {
                            frasePronta = frasePronta + "{+}" + x;
                        }
                    }
                    Mais = 1;
                    frase = frasePronta;
                    frasePronta = "";
                    inicio = 1;
                }
                else { Mais = 1; }
            }
            return frase;
        }
        #endregion

        private void kbhooks(KeyboardHookEventArgs e)
        {
            if (e.Key == Keys.F2)
            {
                if (!topMost)
                {
                    this.Location = new Point(0, 400);
                    this.TopMost = true;
                    this.FormBorderStyle = FormBorderStyle.None;
                    topMost = true;
                }
                else
                {
                    this.Location = new Point(200, 400);
                    this.TopMost = false;
                    this.FormBorderStyle = FormBorderStyle.Sizable;
                    topMost = false;
                }
            }
            if (e.Key == Keys.F3)
            {
                int contagemDefault = contagem;
                try {
                contagem -= 1;
                txtFrase.Text = frases[contagem]; }catch { contagem = contagemDefault; }
            }
            if (e.Key == Keys.F4)
            {
                int contagemDefault = contagem;
                try
                {
                    contagem += 1;
                    txtFrase.Text = frases[contagem];
                }
                catch { contagem = contagemDefault; }
            }
            if (e.Key == Keys.F7)
            {
                int contagemDefault = contagem;
                try {
                    if (Control.IsKeyLocked(Keys.CapsLock))
                    {
                        const int KEYEVENTF_EXTENDEDKEY = 0x1;
                        const int KEYEVENTF_KEYUP = 0x2;
                        keybd_event(0x14, 0x45, KEYEVENTF_EXTENDEDKEY, (UIntPtr)0);
                        keybd_event(0x14, 0x45, KEYEVENTF_EXTENDEDKEY | KEYEVENTF_KEYUP,
                        (UIntPtr)0);
                    }
                    string fraseAEnviar = CorrecaoLinha(txtFrase.Text);
                    SendKeys.Send(fraseAEnviar);
                    SendKeys.SendWait("+{Enter}");
                    contagem += 1;
                    txtFrase.Text = frases[contagem];
                }
                catch { contagem = contagemDefault; }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frases.Clear();
            OpenFileDialog file = new OpenFileDialog();
            file.Title = "Abrir Script";
            file.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            if (file.ShowDialog() == DialogResult.OK)
            {
                arquivo = file.FileName;
                StreamReader sr = new StreamReader(file.FileName, Encoding.Default);
                while (!sr.EndOfStream)
                {
                    string linha = sr.ReadLine();
                    if(linha != "")
                        frases.Add(linha);
                }
                txtFrase.Text = frases[0];
            }
            
        }
    }
}

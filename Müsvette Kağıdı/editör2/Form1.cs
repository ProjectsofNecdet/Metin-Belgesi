using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;


namespace editör2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private string dosya;
        //çıkış
        private void çıkışToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            if (richTextBox1.Text != "")
            {
                DialogResult a = MessageBox.Show("Son Değişikliklerinizi Kaydetmek İstermisiniz?", "Müsvette Kağıdı", MessageBoxButtons.YesNoCancel);
                if (a == DialogResult.Yes)
                {
                    kaydet();
                    this.Close();
                }
                if (a == DialogResult.No)
                {
                    this.Close();
                }
                if (a == DialogResult.Cancel)
                {
                    toolStripStatusLabel1.Text = "Belgede Değişiklik Yapmaya Devam Ediyorsunuz...";
                }
            }
            else
            {
                this.Close();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
            
        }
        //kaydet
        private void kaydetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog ksk = new SaveFileDialog();
            ksk.Filter = "Zengin Metin Biçimi|*.rtf";
            
            if (dosya == null)
            {
                if (ksk.ShowDialog() == DialogResult.OK)
                {
                    dosya = ksk.FileName;
                    richTextBox1.SaveFile(dosya);
                    toolStripStatusLabel1.Text = "Değişiklikleri Kaydettiniz...";
                }
            }
            else
            {
                richTextBox1.SaveFile(dosya);
            }
            toolStripStatusLabel1.Text = "Değişiklikleri Kaydettiniz...";
        }
        //yeni
        private void yeniToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (richTextBox1.Text != "")
            {
                DialogResult a = MessageBox.Show("Son Değişikliklerinizi Kaydetmek İstermisiniz?", "Müsvette Kağıdı", MessageBoxButtons.YesNoCancel);
                if (a == DialogResult.Yes)
                    kaydet();
                else if (a == DialogResult.No)
                {
                    richTextBox1.Text = "";
                    toolStripStatusLabel1.Text = "Yeni Belge Oluşturuldunuz...";
                }
                if (a == DialogResult.Cancel)
                {
                    toolStripStatusLabel1.Text = "Belgede Değişiklik Yapmaya Devam Ediyorsunuz...";
                }
            }
            else
            {
                richTextBox1.Text = "";
                toolStripStatusLabel1.Text = "Yeni Belge Oluşturuldunuz...";
            }
        }
        //kaydet degişkeni
        private void kaydet()
        {
            SaveFileDialog ksk = new SaveFileDialog();
            ksk.Title = "Kaydet";
            ksk.Filter = "Zengin Metin Biçimi (*.rtf)|*.rtf|Metin Belgesi (*.txt)|*.txt";
            DialogResult dr = ksk.ShowDialog();
            if (dr == DialogResult.OK)
                richTextBox1.SaveFile(ksk.FileName);
            this.Text = Path.GetFileName(ksk.FileName) + " - Müsvette Kağıdı";
        }
        //aç
        private void açToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (richTextBox1.Text != "")
            {
                DialogResult a = MessageBox.Show("Son Değişikliklerinizi Kaydetmek İstermisiniz?", "Müsvette Kağıdı", MessageBoxButtons.YesNoCancel);
                if (a == DialogResult.Yes)
                    kaydet();
                else if (a == DialogResult.No)
                {
                    richTextBox1.Text = ""; 
                    OpenFileDialog sfd = new OpenFileDialog();
                    sfd.Filter = "Zengin Metin Biçimi|*.rtf";
                    
                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                        dosya = sfd.FileName;
                        richTextBox1.LoadFile(dosya);
                    }
                }
                if (a == DialogResult.Cancel)
                {
                    toolStripStatusLabel1.Text = "Belgede Değişiklik Yapmaya Devam Ediyorsunuz...";
                }
            }
            else
            {
                OpenFileDialog sfd = new OpenFileDialog();
                sfd.Filter = "Zengin Metin Biçimi|*.rtf";
                
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    dosya = sfd.FileName;
                    richTextBox1.LoadFile(dosya);
                    toolStripStatusLabel1.Text = "İstediğniz Belge Açılmıştır...";
                }
            }
        }
        //farklı kaydet
        private void toolStripMenuItem6_Click(object sender, EventArgs e)
        {
            SaveFileDialog a = new SaveFileDialog();
            a.Filter = "Zengin Metin Biçimi|*.rtf";
            DialogResult dr = a.ShowDialog();
            if (dr == DialogResult.OK)
            {
                richTextBox1.SaveFile(a.FileName);

            }
            toolStripStatusLabel1.Text = "Yeni Dosya Oluşturup Kaydettiniz...";
        }
        //tümünü seç
        private void tümünüSeçToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectAll();
            toolStripStatusLabel1.Text = "Metinler Seçilidir...";
        }
            //yapıştır
        private void yapıştırToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Paste();
            toolStripStatusLabel1.Text = "Yapıştırma İşlemini Yaptınız";
        }
        //kopyala
        private void kopyalaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Copy();
            toolStripStatusLabel1.Text = "Seçiki Metinler Kopyalama İşlemi İçin Hazırdır...";
        }
        //kes
        private void kesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Cut();
            toolStripStatusLabel1.Text = "Kesme İşlemi İçin Hazırdır...";
        }
        //gerial
        private void geriAlToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Undo();
            toolStripStatusLabel1.Text = "Geri Alma İşlemini Gerçekleştirdiniz...";
        }
        //yazı tipi
        private void yazıTipiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FontDialog neco = new FontDialog();
            if (neco.ShowDialog() == DialogResult.OK)
            {
                richTextBox1.SelectionFont = neco.Font;
                toolStripStatusLabel1.Text = "Yazı Tipini Değiştirdiniz...";
            }
        }
        // yazı rengi
        private void yazıRengiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog cdl = new ColorDialog();
            DialogResult dr = cdl.ShowDialog();
            if (dr == DialogResult.OK)
            {
                richTextBox1.SelectionColor = cdl.Color;
                toolStripStatusLabel1.Text = "Yazının Rengini Değiştirdiniz...";
            }
        }
        //arka plan rengi
        private void arkaPlanRengiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog renk = new ColorDialog();
            DialogResult dr = renk.ShowDialog();
            if (dr == DialogResult.OK)
            {
                this.richTextBox1.BackColor = renk.Color;
                toolStripStatusLabel1.Text = "Arka Plan Rengini Değiştirdiniz...";
            }
            
        }
        // sözcük kaydırma
        private void sözcükKaydırToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (richTextBox1.WordWrap == true)
            {
                richTextBox1.WordWrap = false;
                sözcükKaydırToolStripMenuItem.Checked = false;
                toolStripStatusLabel1.Text = "Sözcük Kaydırma Özelliği Etkindir...";
            }
            else
            {
                richTextBox1.WordWrap = true;
                sözcükKaydırToolStripMenuItem.Checked = true;
                toolStripStatusLabel1.Text = "Sözcük Kaydırma Özelliği Etkin Değildir...";
            }
        }

        private void hakkındaToolStripMenuItem_Click(object sender, EventArgs e)
        {

            Form3 acl = new Form3();
            acl.Show();
       
        }

        private void düzenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (richTextBox1.Text == "")
            {
                kopyalaToolStripMenuItem.Enabled = false;
                kesToolStripMenuItem.Enabled = false;
                yapıştırToolStripMenuItem.Enabled = false;
                geriAlToolStripMenuItem.Enabled = false;
                tümünüSeçToolStripMenuItem.Enabled = false;
            }
            else
            {
                geriAlToolStripMenuItem.Enabled = true;
                tümünüSeçToolStripMenuItem.Enabled = true;
                kesToolStripMenuItem.Enabled = true;
                kopyalaToolStripMenuItem.Enabled = true;
                yapıştırToolStripMenuItem.Enabled = true;
            }
        }

        private void richTextBox1_TextChanged(object sender, System.EventArgs e)
        {
            //kelime saydırma
            int bosluksay = 0;
            int i;
            for (i = 1; i <= Microsoft.VisualBasic.Strings.Len(richTextBox1.Text); i++)
            {
                if (Microsoft.VisualBasic.Strings.Mid(richTextBox1.Text, i, 1) == Microsoft.VisualBasic.Strings.Chr(32).ToString())
                {
                    bosluksay++;
                    toolStripStatusLabel2.Text = (bosluksay + 1) + " Kelimeden Oluşmaktadır.";
                }
            }
            
            //harf saydırma
            int adet = 0;
            string cumle;
            char[] sesli = { 'a', 'b', 'c', 'ç', 'd', 'e', 'f', 'g', 'ğ', 'h', 'ı', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'ö', 'p', 'r', 's', 'ş', 't', 'u', 'ü', 'v', 'y', 'z', 'A', 'B', 'C', 'Ç', 'D', 'E', 'F', 'G', 'Ğ', 'H', 'I', 'İ', 'J', 'K', 'L', 'M', 'N', 'O', 'Ö', 'P', 'R', 'S', 'Ş', 'T', 'U', 'Ü', 'V', 'Y', 'Z' , 'x', 'w', 'q', 'X', 'W', 'Q'};
            cumle = richTextBox1.Text;
            for (int ksk = 0; ksk < cumle.Length; ksk++)
            {
                for (int b = 0; b < 64; b++)
                {
                    if (cumle[ksk] == sesli[b])
                    {
                        adet = adet + 1;
                    }
                }
            }
            toolStripStatusLabel3.Text = adet + " Harften Olusmaktadır.";

            //harflerı saydırma
            int[] harfler = new int[32];
            for (int q = 0; q < richTextBox1.Text.Length; q++)
            {
                char ch = richTextBox1.Text[q];
                int x = (int)ch;
                if ((x > 64) && (x < 91))
                {
                    harfler[x - 65]++;
                }
                if ((x > 96) && (x < 123))
                {
                    harfler[x - 97]++;
                }
                if ((x == 305) || (x == 304)) //ı
                {
                    harfler[26]++;
                }
                if ((x == 350) || (x == 351)) //ş
                {
                    harfler[27]++;
                }
                if((x==231) || (x==199)) //ç
                {
                    harfler[28]++;
                }
                if ((x==287) || (x==208)) //ğ
                {
                    harfler[29]++;
                }
                if((x==246) || (x==214)) // ö
                {
                    harfler[30]++;
                }
                if ((x == 252) || (x == 220)) //ü
                {
                    harfler[31]++;
                }

             }
            richTextBox2.Text = "A = " + harfler[0];
            richTextBox2.Text = richTextBox2.Text + "\nB = " + harfler[1];
            richTextBox2.Text = richTextBox2.Text + "\nC = " + harfler[2];
            richTextBox2.Text = richTextBox2.Text + "\nÇ = " + harfler[28];
            richTextBox2.Text = richTextBox2.Text + "\nD = " + harfler[3];
            richTextBox2.Text = richTextBox2.Text + "\nE = " + harfler[4];
            richTextBox2.Text = richTextBox2.Text + "\nF = " + harfler[5];
            richTextBox2.Text = richTextBox2.Text + "\nG = " + harfler[6];
            richTextBox2.Text = richTextBox2.Text + "\nĞ = " + harfler[29];
            richTextBox2.Text = richTextBox2.Text + "\nH = " + harfler[7];
            richTextBox2.Text = richTextBox2.Text + "\nI = " + harfler[26];
            richTextBox2.Text = richTextBox2.Text + "\nİ = " + harfler[8];
            richTextBox2.Text = richTextBox2.Text + "\nJ = " + harfler[9];
            richTextBox2.Text = richTextBox2.Text + "\nK = " + harfler[10];
            richTextBox2.Text = richTextBox2.Text + "\nL = " + harfler[11];
            richTextBox2.Text = richTextBox2.Text + "\nM = " + harfler[12];
            richTextBox2.Text = richTextBox2.Text + "\nN = " + harfler[13];
            richTextBox2.Text = richTextBox2.Text + "\nO = " + harfler[14];
            richTextBox2.Text = richTextBox2.Text + "\nÖ = " + harfler[30];
            richTextBox2.Text = richTextBox2.Text + "\nP = " + harfler[15];
            richTextBox2.Text = richTextBox2.Text + "\nQ = " + harfler[16];
            richTextBox2.Text = richTextBox2.Text + "\nR = " + harfler[17];
            richTextBox2.Text = richTextBox2.Text + "\nS = " + harfler[18];
            richTextBox2.Text = richTextBox2.Text + "\nŞ = " + harfler[27];
            richTextBox2.Text = richTextBox2.Text + "\nT = " + harfler[19];
            richTextBox2.Text = richTextBox2.Text + "\nU = " + harfler[20];
            richTextBox2.Text = richTextBox2.Text + "\nÜ = " + harfler[31];
            richTextBox2.Text = richTextBox2.Text + "\nV = " + harfler[21];
            richTextBox2.Text = richTextBox2.Text + "\nW = " + harfler[22];
            richTextBox2.Text = richTextBox2.Text + "\nX = " + harfler[23];
            richTextBox2.Text = richTextBox2.Text + "\nY = " + harfler[24];
            richTextBox2.Text = richTextBox2.Text + "\nZ = " + harfler[25];
            
            
            

        }
        public static string abc;
        public static string neco;
        private void metinBilgisiToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            neco = richTextBox2.Text;
            abc = richTextBox1.Text;
            Form2 ksk = new Form2();
            ksk.Show();
        }
    }
}

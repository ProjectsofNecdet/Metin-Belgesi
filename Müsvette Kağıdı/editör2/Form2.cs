using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace editör2
{
    public partial class Form2 : Form
    {
        public int Marjin { get; set; }
        public Form2()
        {
            InitializeComponent();
            Marjin = 60;
        }

        int[] harfler = new int[33];
        int[] C = new int[33];

        private void Form2_Load(object sender, EventArgs e)
        {
            richTextBox1.Text = Form1.neco.ToString();


            string kelime;
            kelime = Form1.abc.ToString();


            for (int i = 0; i < kelime.Length; i++)
            {
                char ch = kelime[i];
                int x = (int)ch;
                if ((x > 64) && (x < 91))
                {
                    harfler[x - 65]++;
                }
                if ((x > 96) && (x < 123))
                {
                    harfler[x - 97]++;

                }
                //ç harfinin atanması
                if ((x == 231) || (x == 199)) { harfler[26]++; }

                //ğ harfinin atanması
                if ((x == 287) || (x == 208)) { harfler[27]++; }
                //i harfinin atanması
                if ((x == 305) || (x == 304)) { harfler[28]++; }
                //ş harfinin atanması
                if ((x == 351) || (x == 350)) { harfler[29]++; }
                //ö harfinin atanması
                if ((x == 246) || (x == 214)) { harfler[30]++; }
                //ü harfinin atanması
                if ((x == 252) || (x == 220)) { harfler[31]++; }
            }
        }
            protected override void OnPaint(PaintEventArgs e)
        {

            int k = 0;
            for (int l = 0; l < 33; l++)
            {
                C[l] = harfler[l];
            }

            for (int i = 0; i < 33; i = i + k)
            {
                if (Height < C[i])
                {
                    for (int z = 0; z < 33; z++)
                    {
                        C[z] = C[z] / 2;

                        k = 0;
                    }
                }
                else
                {
                    k = 1;
                }
            }

            base.OnPaint(e);
            Graphics g = e.Graphics;
            int w = Width - 2 * Marjin;
            int h = Height - 3 * Marjin;
            g.DrawLine(Pens.Red, (Marjin / 2), (Height - Marjin), (Width - Marjin), (Height - Marjin));
            g.DrawLine(Pens.Red, (Marjin / 2), (Height - Marjin), (Marjin / 2), (Marjin / 2));

            //noktalar
            Font drawfont = new Font("tahoma", 10);

            SolidBrush drawbrush = new SolidBrush(Color.Black);

            int a, hizalama = 1;
            for (a = 0; a < 26; a++)
            {
                char dm;
                dm = (char)(a + 65);
                string laz = Convert.ToString(dm);

                //ust kısımdakı ısaret noktası
                g.FillEllipse(Brushes.Black, hizalama * (Marjin / 2) + 8, (Height - (Marjin + 2)) - C[a], 5, 5);
                //noktadan tuvale olan cızgı
                g.DrawLine(Pens.Pink, hizalama * (Marjin / 2) + 8, (Height - (Marjin + 2)) - C[a], hizalama * (Marjin / 2) + 8, (Height - Marjin));
                //noktaların ismi
                g.DrawString(laz, drawfont, drawbrush, hizalama * (Marjin / 2) + 10, (Height - Marjin));

                //noktalar arası cızgı
                g.DrawLine(Pens.Green, hizalama * (Marjin / 2) + 10, (Height - (Marjin + 2)) - C[a], ((++hizalama) * (Marjin / 2)) + 10, (Height - (Marjin + 2)) - C[a + 1]);
                //alt satır ısaret noktası
                g.FillEllipse(Brushes.Black, hizalama * (Marjin / 2) + 8, (Height - Marjin), 3, 3);
            }

            //ç harfinin grafige eklenmesi
            //ust kısımdakı ısaret noktası
            string n = "Ç";
            g.FillEllipse(Brushes.Black, hizalama * (Marjin / 2) + 8, (Height - (Marjin + 2)) - C[26], 5, 5);
            //noktadan tuvale olan cızgı
            g.DrawLine(Pens.Pink, hizalama * (Marjin / 2) + 8, (Height - (Marjin + 2)) - C[26], hizalama * (Marjin / 2) + 8, (Height - Marjin));
            //noktaların ismi
            g.DrawString(n, drawfont, drawbrush, hizalama * (Marjin / 2) + 10, (Height - Marjin));

            //noktalar arası cızgı
            g.DrawLine(Pens.Green, hizalama * (Marjin / 2) + 10, (Height - (Marjin + 2)) - C[26], ((++hizalama) * (Marjin / 2)) + 10, (Height - (Marjin + 2)) - C[26 + 1]);
            //alt satır ısaret noktası
            g.FillEllipse(Brushes.Black, hizalama * (Marjin / 2) + 8, (Height - Marjin), 3, 3);

            //ğ harfinin grafige eklenmesi
            //ust kısımdakı ısaret noktası
            string q = "Ğ";
            g.FillEllipse(Brushes.Black, hizalama * (Marjin / 2) + 8, (Height - (Marjin + 2)) - C[27], 5, 5);
            //noktadan tuvale olan cızgı
            g.DrawLine(Pens.Pink, hizalama * (Marjin / 2) + 8, (Height - (Marjin + 2)) - C[27], hizalama * (Marjin / 2) + 8, (Height - Marjin));
            //noktaların ismi
            g.DrawString(q, drawfont, drawbrush, hizalama * (Marjin / 2) + 10, (Height - Marjin));

            //noktalar arası cızgı
            g.DrawLine(Pens.Green, hizalama * (Marjin / 2) + 10, (Height - (Marjin + 2)) - C[27], ((++hizalama) * (Marjin / 2)) + 10, (Height - (Marjin + 2)) - C[27 + 1]);
            //alt satır ısaret noktası
            g.FillEllipse(Brushes.Black, hizalama * (Marjin / 2) + 8, (Height - Marjin), 3, 3);

            //I harfinin grafige eklenmesi
            //ust kısımdakı ısaret noktası
            string y = "İ";
            g.FillEllipse(Brushes.Black, hizalama * (Marjin / 2) + 8, (Height - (Marjin + 2)) - C[28], 5, 5);
            //noktadan tuvale olan cızgı
            g.DrawLine(Pens.Pink, hizalama * (Marjin / 2) + 8, (Height - (Marjin + 2)) - C[28], hizalama * (Marjin / 2) + 8, (Height - Marjin));
            //noktaların ismi
            g.DrawString(y, drawfont, drawbrush, hizalama * (Marjin / 2) + 10, (Height - Marjin));

            //noktalar arası cızgı
            g.DrawLine(Pens.Green, hizalama * (Marjin / 2) + 10, (Height - (Marjin + 2)) - C[28], ((++hizalama) * (Marjin / 2)) + 10, (Height - (Marjin + 2)) - C[28 + 1]);
            //alt satır ısaret noktası
            g.FillEllipse(Brushes.Black, hizalama * (Marjin / 2) + 8, (Height - Marjin), 3, 3);

            //ş harfinin grafige eklenmesi
            //ust kısımdakı ısaret noktası
            string u = "Ş";
            g.FillEllipse(Brushes.Black, hizalama * (Marjin / 2) + 8, (Height - (Marjin + 2)) - C[29], 5, 5);
            //noktadan tuvale olan cızgı
            g.DrawLine(Pens.Pink, hizalama * (Marjin / 2) + 8, (Height - (Marjin + 2)) - C[29], hizalama * (Marjin / 2) + 8, (Height - Marjin));
            //noktaların ismi
            g.DrawString(u, drawfont, drawbrush, hizalama * (Marjin / 2) + 10, (Height - Marjin));

            //noktalar arası cızgı
            g.DrawLine(Pens.Green, hizalama * (Marjin / 2) + 10, (Height - (Marjin + 2)) - C[29], ((++hizalama) * (Marjin / 2)) + 10, (Height - (Marjin + 2)) - C[29 + 1]);
            //alt satır ısaret noktası
            g.FillEllipse(Brushes.Black, hizalama * (Marjin / 2) + 8, (Height - Marjin), 3, 3);

            //ö harfinin grafige eklenmesi
            //ust kısımdakı ısaret noktası
            string r = "Ö";
            g.FillEllipse(Brushes.Black, hizalama * (Marjin / 2) + 8, (Height - (Marjin + 2)) - C[30], 5, 5);
            //noktadan tuvale olan cızgı
            g.DrawLine(Pens.Pink, hizalama * (Marjin / 2) + 8, (Height - (Marjin + 2)) - C[30], hizalama * (Marjin / 2) + 8, (Height - Marjin));
            //noktaların ismi
            g.DrawString(r, drawfont, drawbrush, hizalama * (Marjin / 2) + 10, (Height - Marjin));

            //noktalar arası cızgı
            g.DrawLine(Pens.Green, hizalama * (Marjin / 2) + 10, (Height - (Marjin + 2)) - C[30], ((++hizalama) * (Marjin / 2)) + 10, (Height - (Marjin + 2)) - C[30 + 1]);
            //alt satır ısaret noktası
            g.FillEllipse(Brushes.Black, hizalama * (Marjin / 2) + 8, (Height - Marjin), 3, 3);

            //ü harfinin grafige eklenmesi
            //ust kısımdakı ısaret noktası
            string p = "Ü";
            g.FillEllipse(Brushes.Black, hizalama * (Marjin / 2) + 8, (Height - (Marjin + 2)) - C[31], 5, 5);
            //noktadan tuvale olan cızgı
            g.DrawLine(Pens.Pink, hizalama * (Marjin / 2) + 8, (Height - (Marjin + 2)) - C[31], hizalama * (Marjin / 2) + 8, (Height - Marjin));
            //noktaların ismi
            g.DrawString(p, drawfont, drawbrush, hizalama * (Marjin / 2) + 10, (Height - Marjin));

            //noktalar arası cızgı
            g.DrawLine(Pens.Green, hizalama * (Marjin / 2) + 10, (Height - (Marjin + 2)) - C[31], ((++hizalama) * (Marjin / 2)) + 10, (Height - (Marjin + 2)) - C[31 + 1]);
            //alt satır ısaret noktası
            g.FillEllipse(Brushes.Black, hizalama * (Marjin / 2) + 8, (Height - Marjin), 3, 3);

        }

        private void Form2_Resize(object sender, EventArgs e)
        {
            Refresh();
        }
    }
}

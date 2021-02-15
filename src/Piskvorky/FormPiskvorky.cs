using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Piskvorky
{
    public partial class FormPiskvorky : Form
    {
        /// <summary> Mapa všech políček. </summary>
        private Policko[,] mapa;

        /// <summary> Rozměry jednoho políčka v pixelech. </summary>
        private int sirkaPolicka=12, vyskaPolicka=12;

        /// <summary> Souřadnice čáry, která škrtá vítěznou řadu značek. </summary>
        private int caraX, caraY, caraX2, caraY2;

        /// <summary> V jakém je hra stavu. </summary>
        private Stav stav=Stav.TAHNE1;

        private Brush koleckoStetec = Brushes.Blue;
        private Pen krizekStetec = new Pen(Color.Crimson, 2f);
        private Pen caraStetec = new Pen(Color.GreenYellow, 3f);
        
        /// <summary> Kolik značek vedle sebe znamená vítězství. </summary>
        private const int MAX = 5;

        /// <summary> Rozměry mapy, která se použije při nové hře. </summary>
        private int novaSirka=25, novaVyska=30;

        private Sitovani sitovani;
        private String staryTextOcekavatPripojeni;
        private bool sitovaHra = false;
        private int cisloHrace = 0;

        public FormPiskvorky()
        {
            VytvorMapu(novaSirka, novaVyska);
            sitovani = new Sitovani(new Sitovani.Volani(pripojeno), new Sitovani.Volani(zruseno), new Sitovani.Tah(tahPresSit));

            InitializeComponent();
            staryTextOcekavatPripojeni = buttonPoslouchat.Text;
        }

        public void VytvorMapu(int sirka, int vyska)
        {
            mapa = new Policko[sirka, vyska];
        }

        /// <summary>
        /// Počet sloupců na herní mapě.
        /// </summary>
        /// <returns>Počet sloupců na herní mapě.</returns>
        public int Sirka()
        {
            return mapa.GetLength(0);
        }

        /// <summary>
        /// Počet řádků na herní mapě.
        /// </summary>
        /// <returns>Počet řádků na herní mapě.</returns>
        public int Vyska()
        {
            return mapa.GetLength(1);
        }

        /// <summary>
        /// Vykreslí kolečko na zadané souřadnice.
        /// </summary>
        /// <param name="x">sloupec, ve kterém je vykreslované kolečko</param>
        /// <param name="y">řádek, ve kterém je vykreslované kolečko</param>
        /// <param name="g">plátno, které se má použít ke kreslení</param>
        private void kolecko(int x, int y, Graphics g)
        {
            g.FillEllipse(koleckoStetec, x * sirkaPolicka, y * vyskaPolicka, sirkaPolicka, vyskaPolicka);
        }

        /// <summary>
        /// Vykreslí křížek na zadané souřadnice.
        /// </summary>
        /// <param name="x">sloupec, ve kterém je vykreslovaný křížek</param>
        /// <param name="y">řádek, ve kterém je vykreslovaný křížek</param>
        /// <param name="g">plátno, které se má použít ke kreslení</param>
        private void krizek(int x, int y, Graphics g)
        {
            g.DrawLine(krizekStetec, x * sirkaPolicka, y * vyskaPolicka, x * sirkaPolicka + sirkaPolicka, y * vyskaPolicka + vyskaPolicka);
            g.DrawLine(krizekStetec, x * sirkaPolicka + sirkaPolicka, y * vyskaPolicka, x * sirkaPolicka, y * vyskaPolicka + vyskaPolicka);
        }

        private void panelHlavni_Paint(object sender, PaintEventArgs e)
        {
            Graphics g=e.Graphics;
            
            Pen pen=new Pen(Color.Aqua);

            //vykreslení čar mřížky
            for (int i = 0; i <= Sirka(); i++)
                g.DrawLine(pen, i * sirkaPolicka, 0, i * sirkaPolicka, Vyska() * vyskaPolicka);
            
            for (int i = 0; i <= Vyska(); i++)
                g.DrawLine(pen, 0, i * vyskaPolicka, Sirka()*sirkaPolicka, i*vyskaPolicka);

            //vykresleni policek
            for (int x = 0; x < Sirka(); x++)
                for (int y = 0; y < Vyska(); y++)
                    switch (mapa[x, y])
                    {
                        case Policko.KOLECKO:
                            kolecko(x, y, g);
                            break;
                        case Policko.KRIZEK:
                            krizek(x, y, g);
                            break;
                    }

            //vykreslit pripadne caru, která škrtá vítězovu řadu
            if (HraSkoncila)
            {
                g.DrawLine(caraStetec, caraX, caraY, caraX2, caraY2);
            }

        }

        private void tahPresSit(int x, int y)
        {
            
            while (HraSkoncila); //jestli hra skončila, tak počkat až to hráč odklepne

            tah(x, y);
        }

        private void tah(int x, int y)
        {
            //pridat znacku
            if (stav == Stav.TAHNE1)
            {
                mapa[x, y] = Policko.KOLECKO;
                stav = Stav.TAHNE2;

                //zkontrolovat, jestli neskončila hra
                zkontrolovatKonec(x, y);

            }
            else if (stav == Stav.TAHNE2)
            {
                mapa[x, y] = Policko.KRIZEK;
                stav = Stav.TAHNE1;

                //zkontrolovat, jestli neskončila hra
                zkontrolovatKonec(x, y);
            }

            //prekreslit
            Refresh();
        }

        /// <summary>
        /// Zkontroluje, jeslti neskončila hra (jestli někdo nemá pět značek vedle sebe).
        /// </summary>
        /// <param name="x">sloupec, ve kterém je nová značka</param>
        /// <param name="y">řádek, ve kterém je nová značka</param>
        private void zkontrolovatKonec(int x, int y)
        {
            if (mapa[x, y] == Policko.PRAZDNO) return;

            //kdo vyhraje, jestli vyhraje
            Stav hrac = mapa[x, y] == Policko.KOLECKO ? Stav.VYHRAL1 : Stav.VYHRAL2;

            //pocty kamenu v jednotlivych smerech
            int svisle, svisle1, svisle2;
            int vodorovne, vodorovne1, vodorovne2;
            int sikmo, sikmo1, sikmo2;
            int sikmo_2, sikmo1_2, sikmo2_2;

            svisle1 = zkontrolovatSmer(x, y, +0, +1);
            svisle2 = zkontrolovatSmer(x, y, +0, -1);
            svisle = svisle1 + svisle2 + 1;

            vodorovne1 = zkontrolovatSmer(x, y, +1, +0);
            vodorovne2 = zkontrolovatSmer(x, y, -1, +0);
            vodorovne = vodorovne1 + vodorovne2 + 1;

            sikmo1=zkontrolovatSmer(x, y, -1, -1);
            sikmo2= zkontrolovatSmer(x, y, +1, +1);
            sikmo =  sikmo1+sikmo2 + 1;

            sikmo1_2= zkontrolovatSmer(x, y, -1, +1);
            sikmo2_2= zkontrolovatSmer(x, y, +1, -1);
            sikmo_2 =  sikmo1_2 + sikmo2_2 + 1;

            if (svisle >= MAX)
            {
                oznacVyhru(x, y + svisle1, x, y - svisle2, hrac);
            }
            else if (vodorovne >= MAX)
            {
                oznacVyhru(x + vodorovne1, y, x - vodorovne2, y, hrac);
            }
            else if (sikmo >= MAX)
            {
                oznacVyhru(x - sikmo1, y - sikmo1, x + sikmo2, y + sikmo2, hrac);
            }
            else if (sikmo_2 >= MAX)
            {
                oznacVyhru(x - sikmo1_2, y + sikmo1_2, x + sikmo2_2, y - sikmo2_2, hrac);
            }
        }

        /// <summary>
        /// Spočítá, kolik v zadaném směru je stejných značek.
        /// </summary>
        /// <param name="x">výchozí sloupec</param>
        /// <param name="y">výchozí řádek</param>
        /// <param name="smerX">přírustek sloupce</param>
        /// <param name="smerY">přírustek řádku</param>
        /// <returns>kolik je v zadaném směru stejných značek</returns>
        private int zkontrolovatSmer(int x, int y, int smerX, int smerY)
        {
            Policko hledany=mapa[x,y];
            int i;

            for (i = 1; i <= MAX; i++)
            {
                if (mapa[x + i * smerX, y + i * smerY] != hledany) 
                    return i-1;
            }

            return i-1;
        }

        /// <summary>
        /// Označí výhru hráče.
        /// </summary>
        /// <param name="x">sloupec prvního konce vítězné řady</param>
        /// <param name="y">řádek prvního konce vítězné řady</param>
        /// <param name="x2">sloupec druhého konce vítězné řady</param>
        /// <param name="y2">řádek druhého konce vítězné řady</param>
        /// <param name="hrac">který hráč je vítěz</param>
        private void oznacVyhru(int x, int y, int x2, int y2, Stav hrac)
        {
            caraX = x * sirkaPolicka + sirkaPolicka/2;
            caraY = y * vyskaPolicka + vyskaPolicka/2;
            caraX2 = x2 * sirkaPolicka + sirkaPolicka / 2;
            caraY2 = y2 * vyskaPolicka + vyskaPolicka / 2;

            stav = hrac;

            //prekreslit
            Refresh();
       }

        /// <summary>
        /// Zavolá se při stisku myši. Pokud je hráč na tahu, tak umístí značku.
        /// </summary>
        private void panelHlavni_MouseDown(object sender, MouseEventArgs e)
        {
            if (!HraSkoncila)
            {
                int x=e.X / sirkaPolicka;
                int y=e.Y / vyskaPolicka;

                //zkontrolovat, jestli neklikl za okraj nebo na obsazene policko
                if (x >= Sirka() || y >= Vyska() || mapa[x, y] != Policko.PRAZDNO)
                    return;

                if (!sitovaHra)
                {
                    tah(x, y);
                }
                else if((stav == Stav.TAHNE1 && cisloHrace == 1) || (stav == Stav.TAHNE2 && cisloHrace == 2)) 
                {                    
                    //je sitova hra a mistni hrac je na tahu
                    tah(x,y);

                    //poslat pres síť
                    sitovani.tah(x,y);
                }
            }
            else
            {   
                //hra uz skončila, takže začít novou hru
                
                //vymazat mapu
                VytvorMapu(novaSirka, novaVyska);

                //tahne hráč, který prohrál
                if (stav == Stav.VYHRAL1) 
                    stav = Stav.TAHNE2;
                else 
                    stav = Stav.TAHNE1;
            }

            //prekreslit
            Refresh();
        }

        /// <summary>
        /// Vrátí true, jestli hra už skončila.
        /// </summary>
        public bool HraSkoncila
        {
            get
            {
                return stav == Stav.VYHRAL1 || stav == Stav.VYHRAL2;
            }
        }

        private void buttonPripoj_Click(object sender, EventArgs e)
        {
            bool uspech=sitovani.PripojitSe(textBoxServer.Text, int.Parse(textBoxPort.Text));

            if (uspech)
            {
                panelTypHry.Visible = false;
                panelSitove.Visible = false;

                cisloHrace = 1;

                sitovani.zacitCteni();
            }
        }

        private void buttonJeden_Click(object sender, EventArgs e)
        {
            panelTypHry.Visible = false;
            panelSitove.Visible = false;
            sitovaHra = false;
        }

        private void buttonSit_Click(object sender, EventArgs e)
        {
            panelTypHry.Visible = false;
            panelSitove.Visible = true;
            sitovaHra = true;
        }

        private void buttonPoslouchat_Click(object sender, EventArgs e)
        {
            int port=int.Parse(textBoxPortJa.Text);
            sitovani.Poslouchat(port);
            Invoke(new NastavitText(nastavitText), "Poslouchám na portu " + port);
        }

        private delegate void NastavitText(String text);

        private void pripojeno()
        {
            panelTypHry.Visible = false;
            panelSitove.Visible = false;

            cisloHrace = 2;

            //nejsme na tahu, cekat na druheho hrace
            sitovani.zacitCteni();
        }

        private void zruseno()
        {
            Invoke(new NastavitText(nastavitText), staryTextOcekavatPripojeni);
        }

        private void nastavitText(String novyText)
        {
            buttonPoslouchat.Text = novyText;
        }
    }
}

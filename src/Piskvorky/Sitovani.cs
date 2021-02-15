using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Windows.Forms;

namespace Piskvorky
{
    /// <summary>
    /// Třída, která se stará o síťovou komunikaci.
    /// </summary>
    class Sitovani
    {
        /// <summary>Spojení s protihráčem. </summary>
        private Socket pripojeni;

        public delegate void Volani();
        public delegate void Tah(int x, int y);

        /// <summary>Metoda, která se má zavolat, když se někdo připojí.</summary>
        private Volani pripojeno;

        /// <summary>Metoda, která se má zavolat, když bude připojení zrušeno.</summary>
        private Volani zruseno;

        /// <summary>Metoda, která se má zavolat, když protihráč udělá tah.</summary>
        private Tah tahDelegat;

        /// <summary>True, jestli hra byla zastavena.</summary>
        private Boolean zastaveno = false;

        /// <summary>
        /// Vytvoří novou instanci třídy.
        /// </summary>
        /// <param name="pripojeno">Metoda, která se má zavolat, když se někdo připojí.</param>
        /// <param name="zruseno">Metoda, která se má zavolat, když bude připojení zrušeno.</param>
        /// <param name="tahDelegat">Metoda, která se má zavolat, když protihráč udělá tah.</param>
        public Sitovani(Volani pripojeno, Volani zruseno, Tah tahDelegat)
        {
            this.pripojeno = pripojeno;
            this.zruseno = zruseno;
            this.tahDelegat = tahDelegat;
        }

        /// <summary>
        /// Začne očekávat připojení na zadaném portu.
        /// </summary>
        /// <param name="port">číslo portu</param>
        public void Poslouchat(int port)
        {
            //jestli uz jsme socket použili, tak ho vymazat
            Zrusit();

            pripojeni = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            pripojeni.Bind(new IPEndPoint(IPAddress.Any, port));
            pripojeni.Listen(1);
            pripojeni.Blocking = true;

            Thread vlakno=new Thread(new ThreadStart(Poslouchani));
            vlakno.Name = "Poslouchani " + port;
            vlakno.Start();
        }
        /// <summary>
        /// Očekáva připojení na zadaném portu. Spouští se v samostatném vlákně.
        /// </summary>
        private void Poslouchani()
        {
            try
            {
                Socket klient = pripojeni.Accept();

                if (klient != null)
                {
                    Zrusit();
                    pripojeni = klient;

                    pripojeno.Invoke();
                }
                else
                {
                    zruseno.Invoke();
                }
            }
            catch (Exception)
            {
                zruseno.Invoke();
            }
        }

        /// <summary>
        /// Připojí se k zadanému počítači na zadaný port.
        /// </summary>
        /// <param name="pocitac">cílový počítač (jméno nebo ip adresa)</param>
        /// <param name="port">číslo cílového portu</param>
        /// <returns>true, jestli bylo připojení úspěšné</returns>
        public bool PripojitSe(String pocitac, int port)
        {
            //jestli uz jsme socket použili, tak ho vymazat
            Zrusit();

            pripojeni = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            try
            {
                pripojeni.Connect(pocitac, port);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Zruší připojení, jestli nějaké existuje.
        /// </summary>
        private void Zrusit()
        {
            if (pripojeni != null)
            {
                pripojeni.Close();
                pripojeni = null;
            }
        }

        /// <summary>
        /// Je true, jestliže existuje nějaké připojení.
        /// </summary>
        public bool Pripojeno
        {
            get { return pripojeni.Connected; }
        }

        /// <summary>
        /// Pošle protihráči zprávu o provedení tahu.
        /// </summary>
        /// <param name="x">sloupec provedeného tahu</param>
        /// <param name="y">řádek provedeného tahu</param>
        public void tah(int x, int y)
        {
            pripojeni.Send(BitConverter.GetBytes(x));
            pripojeni.Send(BitConverter.GetBytes(y));
        }

        /// <summary>
        /// Spustí vlákno, které se stará o přijímání síťových zpráv.
        /// </summary>
        public void zacitCteni()
        {
            Thread vlakno = new Thread(new ThreadStart(precist));
            vlakno.Name = "Cteni";
            vlakno.Start();
        }

        /// <summary>
        /// Stará se o přijímání síťových zpráv. Spouští se v samostatném vlákně.
        /// </summary>
        private void precist()
        {
            try
            {
                while (!zastaveno)
                {
                    byte[] buffer = new byte[8];
                    int pocet = 0;

                    //precist souradnice do bufferu
                    while (pocet != buffer.Length)
                    {
                        int ted = pripojeni.Receive(buffer, pocet, buffer.Length - pocet, SocketFlags.None);
                        if (ted == -1 || ted == 0) return;
                        pocet += ted;
                    }

                    int x = BitConverter.ToInt32(buffer, 0);
                    int y = BitConverter.ToInt32(buffer, 4);

                    tahDelegat(x, y);
                }
            }
            catch (Exception)
            {
                return;
            }
        }

        /// <summary>
        /// Zruší připojení.
        /// </summary>
        public void Dispose()
        {
            zastaveno = true;
            Zrusit();
        }
    }
}

using Oracle.ManagedDataAccess.Types;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proiect_BDM
{
    public class Tablouri
    {
        private int id;
        private string numeArtist;
        private string denumire;
        private string tema;
        private int pret;
        private byte[] imagine;

        public Tablouri()
        {
        }

        public Tablouri(int id, string numeArtist, string denumire, string tema, int pret, byte[] imagine)
        {
            this.id = id;
            this.numeArtist = numeArtist;
            this.denumire = denumire;
            this.tema = tema;
            this.pret = pret;
            this.imagine = imagine;
          
        }

        public Tablouri(int id, string numeArtist, string denumire, string tema, int pret)
        {
            this.id = id;
            this.numeArtist = numeArtist;
            this.denumire = denumire;
            this.tema = tema;
            this.pret = pret;

        }

        public int Id { get => id; set => id = value; }
        public string NumeArtist { get => numeArtist; set => numeArtist = value; }
        public string Denumire { get => denumire; set => denumire = value; }
        public string Tema { get => tema; set => tema = value; }
        public int Pret { get => pret; set => pret = value; }
        public byte[] Imagine { get => imagine; set => imagine = value; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestiune_anvelope
{
    class Anvelopa
    {
        string producator;
        string tip;
        int latime;
        int inaltime;
        string raza;
        int nrBucati;
        float pret;
        public Anvelopa(string producator_,string tip_ ,int latime_,int inaltime_,string raza_,int nrBucati_,float pret_)
        {
             producator=producator_;
             tip=tip_;
             latime=latime_;
             inaltime=inaltime_;
             raza=raza_;
             nrBucati=nrBucati_;
             pret=pret_;
        }

        public string Producator
        {
            get { return producator; }
            set { producator = value; }
        }
        public string Tip
        {
            get { return tip; }
            set { tip = value; }
        }
        public int Latime
        {
            get { return latime; }
            set { latime = value; }
        }
        public int Inaltime
        {
            get { return inaltime; }
            set { inaltime = value; }
        }
        public string Raza
        {
            get { return raza; }
            set { raza = value; }
        }
        public int NrBucati
        {
            get { return nrBucati; }
            set { nrBucati = value; }
        }
        public float Pret
        {
            get { return pret; }
            set { pret = value; }
        }
        public override string ToString()
        {
            return "Producator: " + producator + ", Tip: "+tip+", Latime: "+latime+", Inaltime: "+inaltime+", raza: "+raza+", Numar Bucati: "+nrBucati+", pret: "+pret;
        }
        public  string ToFile()
        {
            return  producator + "," + tip + "," + latime + "," + inaltime + "," + raza + "," + nrBucati + "," + pret;
        }

    }
}

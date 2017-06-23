using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Linq;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.IO;


namespace SteamProgramm
{

    [Serializable]
    public class Verwaltung
    {
        public string SpielName { get; set; }
        public string SBeschreibung { get; set; }

        public void save(string path)
        {
            System.IO.FileStream fs = new System.IO.FileStream(path, System.IO.FileMode.Create);    //Speichern
            BinaryFormatter bn = new BinaryFormatter();

            bn.Serialize(fs, this);

            fs.Dispose();

        }

        public Verwaltung load(string path)
        {
            Verwaltung us = new Verwaltung();

            System.IO.FileStream fs = new System.IO.FileStream(path, System.IO.FileMode.Open);  //Laden 
            BinaryFormatter bn = new BinaryFormatter();

            us = (Verwaltung)bn.Deserialize(fs);


            return us;
        }

        public void GetPfad()
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "exe | *.exe";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                // Hier kommt Anwendung für Pfad
            }
            else
            {
                throw new NullReferenceException();
            }
        }

    }
}

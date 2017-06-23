using System;
using System.Collections.Generic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Xml.Linq;

namespace SteamProgramm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public void Clear_All()
        {
            dataGridView1.Columns.Clear();
        }

        public void ReadXml(string file)
        {
            Clear_All();
            DataSet myDataset = new DataSet();
            myDataset.ReadXml(file);
            dataGridView1.DataSource = myDataset.Tables[0].DefaultView;
        }

        public void SaveXml(string file)
        {
            DataTable dTable = new DataTable("sID");

            for (int i = 0; i < dataGridView1.ColumnCount; i++)
            {
                dTable.Columns.Add(dataGridView1.Columns[i].Name, typeof(System.String));
            }
            DataRow dRow;
            int icols = dataGridView1.Columns.Count;

            foreach (DataGridViewRow drow in this.dataGridView1.Rows)
            {
                if (drow.Cells[0].Value != null)    //Damit keine Leeren spalten gespeichert werden
                {
                    dRow = dTable.NewRow();

                    for (int i = 0; i < icols; i++)
                    {
                        dRow[i] = drow.Cells[i].Value;
                    }

                    dTable.Rows.Add(dRow);
                }
            }
            dTable.WriteXml(file);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            saveFileDialog1.ShowDialog();
            SaveXml(saveFileDialog1.FileName);

            Verwaltung vw = new Verwaltung();

            vw.SpielName = textBox1.Text;
            vw.SBeschreibung = textBox2.Text;

            vw.save(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "//SpielDaten1.xml");

        }

        private void button2_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();       //Datei name wird Pfad übergeben von der 
            ReadXml(openFileDialog1.FileName);  //Datei die man aufgerufen hat

            Verwaltung vw = new Verwaltung();

            vw.load(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "//SpielDaten1.xml");

            textBox1.Text = vw.SpielName;


        }

        private void button3_Click(object sender, EventArgs e)
        {
            Verwaltung vw = new Verwaltung();

            string pfad;

            if (pfad == null)
            {
                throw new NullReferenceException();
            }
            else
            {
                System.Diagnostics.Process.Start(pfad);
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {

            if (name == null)
            {
                throw new NullReferenceException();
            }
            else
            {
                for (int i = 0; i < Verwaltung.Count; i++)
                {
                    if (Verwaltung[i].SpielBezeichnung == name)
                    {
                    }
                }
            }
        }

    }
}
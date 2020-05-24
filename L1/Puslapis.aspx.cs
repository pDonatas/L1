using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace L1
{
    public partial class Puslapis : System.Web.UI.Page
    {
        private string irasymas = "U3rez.txt";
        private int viso = 0;
        /// <summary>
        /// Mygtuko paspaudimas
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button1_Click(object sender, EventArgs e)
        {
            string aplankas = Path.Combine(HttpContext.Current.Request.PhysicalApplicationPath, "App_Data");
            Marsrutai marsrutai = new Marsrutai(100);
            Skaitymas(aplankas + "\\" + "U3.txt", marsrutai, out string pMiestas);
            if (pMiestas != "")
            {
                List<string> pravaziuoti = new List<string>();

                Label1.Text = pMiestas;
                Vykdymas(marsrutai, pMiestas, pravaziuoti);
                Label1.Text += $" ({viso} km)";
                PradiniaiDuomenys("PradiniaiDuomenys.txt", marsrutai, pMiestas);
                Lentele(marsrutai, pMiestas);
            }
            else
            {
                Label1.Text = "Duomenų nerasta";
            }
        }
        /// <summary>
        /// Lentelės kūrimo klasė
        /// </summary>
        /// <param name="marsrutai">Maršrutų sąrašas</param>
        /// <param name="pMiestas">Pradinis miestas</param>
        void Lentele(Marsrutai marsrutai, string pMiestas)
        {
            string text = null;
            text = ("--------------------------------------------------------------<br/>");
            text += ($"Kiekis: {marsrutai.Kiekis}<br/>");
            text += ("--------------------------------------------------------------<br/>");
            text+=($"Pradinis miestas: {pMiestas}<br/>");
            text+=("--------------------------------------------------------------<br/>");
            Label2.Text = text;
            TableRow row = new TableRow();
            TableCell cell = new TableCell
            {
                Text = "Miestas1"
            };
            row.Cells.Add(cell);
            TableCell cell2 = new TableCell
            {
                Text = "Miestas2"
            };
            row.Cells.Add(cell2);
            TableCell cell3 = new TableCell
            {
                Text = "Atstumas"
            };
            row.Cells.Add(cell3);
            Table1.Rows.Add(row);

            for (int i = 0; i < marsrutai.Kiekis; i++)
            {
                TableRow duom = new TableRow();
                TableCell m1 = new TableCell
                {
                    Text = marsrutai.Get(i).Miestas1
                };
                duom.Cells.Add(m1);
                TableCell m2 = new TableCell
                {
                    Text = marsrutai.Get(i).Miestas2
                };
                duom.Cells.Add(m2);
                TableCell a = new TableCell
                {
                    Text = marsrutai.Get(i).Atstumas.ToString()
                };
                duom.Cells.Add(a);
                Table1.Rows.Add(duom);
            }
        }
        /// <summary>
        /// Pradinių duomenų sudarymo metodas
        /// </summary>
        /// <param name="failas">Failas</param>
        /// <param name="marsrutai">Maršrutų sąrašas</param>
        /// <param name="pMiestas">Pradinis miestas</param>
        void PradiniaiDuomenys(string failas, Marsrutai marsrutai, string pMiestas)
        {
            string aplankas = Path.Combine(HttpContext.Current.Request.PhysicalApplicationPath, "App_Data");
            using (StreamWriter sw = new StreamWriter(aplankas + "//" + failas))
            {
                sw.WriteLine("--------------------------------------------------------------");
                sw.WriteLine($"Kiekis: {marsrutai.Kiekis}");
                sw.WriteLine("--------------------------------------------------------------");
                sw.WriteLine($"Pradinis miestas: {pMiestas}");
                sw.WriteLine("--------------------------------------------------------------");
                string header = string.Format("{0, -20} {1, -20} {2, -20}", "Miestas1", "Miestas2", "Atstumas");
                sw.WriteLine(header);
                for (int i = 0; i < marsrutai.Kiekis; i++)
                {
                    string rasyti = string.Format("{0, -20} {1, -20} {2, -20}", marsrutai.Get(i).Miestas1, marsrutai.Get(i).Miestas2, marsrutai.Get(i).Atstumas);
                    sw.WriteLine(rasyti);
                }
            }
        }
        /// <summary>
        /// Skaitymas iš failo
        /// </summary>
        /// <param name="failas">Skaitomas failas</param>
        /// <param name="marsrutai">Maršrutų sąrašas</param>
        /// <param name="pMiestas">Pradinis miestas</param>
        void Skaitymas(string failas, Marsrutai marsrutai, out string pMiestas)
        {
            using (StreamReader reader = new StreamReader(failas))
            {
                string eilute = null;
                if ((eilute = reader.ReadLine()) != null)
                {
                    int kiekis = int.Parse(eilute);
                    pMiestas = reader.ReadLine();
                    for (int i = 0; i < kiekis; i++)
                    {
                        string[] duom = reader.ReadLine().Split(' ');
                        Marsrutas marsrutas = new Marsrutas(duom[0], duom[1], int.Parse(duom[2]));
                        marsrutai.Add(marsrutas);
                    }
                }
                else
                {
                    pMiestas = "";
                }
            }
        }
        /// <summary>
        /// Programos vykdymo metodas
        /// </summary>
        /// <param name="marsrutai">Maršrutų sąrašas</param>
        /// <param name="miestas">Dabartinis miestas</param>
        /// <param name="pravaziuoti">Pravažiuoti miestai</param>
        void Vykdymas(Marsrutai marsrutai, string miestas, List<string> pravaziuoti)
        {
            pravaziuoti.Add(miestas);
            int max = 0;
            string lmiestas = null;
            for(int i = 0; i < marsrutai.Kiekis; i++)
            {
                if (marsrutai.Get(i).Miestas1 == miestas)
                {
                    if (!pravaziuoti.Contains(marsrutai.Get(i).Miestas2))
                    {
                        if (marsrutai.Get(i).Atstumas > max)
                        {
                            max = marsrutai.Get(i).Atstumas;
                            lmiestas = marsrutai.Get(i).Miestas2;
                        }
                    }
                }
                else if (marsrutai.Get(i).Miestas2 == miestas)
                {
                    if (!pravaziuoti.Contains(marsrutai.Get(i).Miestas1))
                    {
                        if (marsrutai.Get(i).Atstumas > max)
                        {
                            max = marsrutai.Get(i).Atstumas;
                            lmiestas = marsrutai.Get(i).Miestas1;
                        }
                    }
                }
            }
            if (lmiestas == null)
            {
                Irasymas();
                return;
            }
            Label1.Text += " - " +lmiestas;
            viso += max;

            Vykdymas(marsrutai, lmiestas, pravaziuoti);
        }
        /// <summary>
        /// Įrašymo funkcija
        /// </summary>
        void Irasymas()
        {
            string aplankas = Path.Combine(HttpContext.Current.Request.PhysicalApplicationPath, "App_Data");
            using (StreamWriter sw = new StreamWriter(aplankas + "\\" + irasymas))
            {
                sw.WriteLine(Label1.Text);
            }
        }
    }
}
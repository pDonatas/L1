using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace L1
{
    /// <summary>
    /// Maršrutų klasė
    /// </summary>
    public class Marsrutas
    {
        public string Miestas1 { get; set; }
        public string Miestas2 { get; set; }
        public int Atstumas { get; set; }
        public bool Pravaziuota = false;
        /// <summary>
        /// Konstruktorius
        /// </summary>
        /// <param name="miestas1">Pradinis miestas</param>
        /// <param name="miestas2">Galutinis miestas</param>
        /// <param name="atstumas">Atstumas tarp miestų</param>
        public Marsrutas(string miestas1, string miestas2, int atstumas)
        {
            Miestas1 = miestas1;
            Miestas2 = miestas2;
            Atstumas = atstumas;
        }
    }
}
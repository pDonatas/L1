using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace L1
{
    /// <summary>
    /// Maršrutų konteinerinė klasė
    /// </summary>
    public class Marsrutai
    {
        private Marsrutas[] Marsrutas;
        public int Kiekis { get; private set; }
        /// <summary>
        /// Konstruktorius
        /// </summary>
        /// <param name="kiekis">Objektų skaičius</param>
        public Marsrutai(int kiekis)
        {
            Marsrutas = new Marsrutas[kiekis];
        }
        /// <summary>
        /// Pridėjimas
        /// </summary>
        /// <param name="marsrutas">Maršruto objektas</param>
        public void Add(Marsrutas marsrutas)
        {
            Marsrutas[Kiekis++] = marsrutas;
        }
        /// <summary>
        /// Gavimas
        /// </summary>
        /// <param name="id">Maršruto id</param>
        /// <returns>Grąžinamas maršrutas pagal nurodytą ID</returns>
        public Marsrutas Get(int id)
        {
            return Marsrutas[id];
        }
    }
}
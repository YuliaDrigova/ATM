using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ATM
{
    class CassetteLoader
    {
        public Money Cassettes;

        public void LoadCassettes(string fileName)
        {
            StreamReader reader = new StreamReader(fileName);
            string line;
            Dictionary<Banknote, int> Banknotes = new Dictionary<Banknote, int>();
            while (!reader.EndOfStream)
            {
                line = reader.ReadLine();
                string[] elements = new string[2];
                elements = line.Split(' ');
                Banknotes.Add(new Banknote(Convert.ToInt32(elements[0])), Convert.ToInt32(elements[1]));
            }
            Cassettes = new Money {Banknotes = Banknotes};
        }
    }
}

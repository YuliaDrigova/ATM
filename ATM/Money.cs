using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM
{
    class Money
    {
        public Dictionary<Banknote, int> Banknotes = new Dictionary<Banknote,int>();
        public int AllSum
        {
            get { return Banknotes.Sum(x => x.Key.Nominal * x.Value); }
        }

        public Money Safecopy()
        {
            Dictionary<Banknote, int> cassettes = new Dictionary<Banknote, int>();
            for (int i = 0; i < Banknotes.Count(); i++)
            {
                cassettes.Add(Banknotes.ElementAt(i).Key, Banknotes.ElementAt(i).Value);
            }
            return new Money() { Banknotes = cassettes};
        }
    }
}

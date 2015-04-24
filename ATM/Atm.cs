using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ATM
{
    enum StatesATM { Ok, NotEnoughMoney, ImpossibleSum}
    class Atm
    {
       
        Money Cassettes;
        WithdrawMoneyAlgorithm Algorithm;
        StatesATM state;
        public Money WithdrawMoney(int sum)
        {
            if (Algorithm.state == StatesAlgorithm.ImpossibleSum)
            {
                state = StatesATM.ImpossibleSum;
                return null;
            }
            else if (Algorithm.state == StatesAlgorithm.NotEnoughMoney)
            {
                state = StatesATM.NotEnoughMoney;
                return null;
            }
            else if (Algorithm.state == StatesAlgorithm.Ok)
            {
                state = StatesATM.Ok;
            }
                Money withdrawMoney = Algorithm.Algorithm(sum, Cassettes);
                if (state == StatesATM.Ok)
                    UpdateMoney(withdrawMoney, Cassettes);               
            
             return withdrawMoney;
        }

        public void InputCassettes(Money cassettes)
        {
            Cassettes = cassettes.Safecopy();
        }

        public Money UpdateMoney(Money update, Money cassettes)
        {
            Dictionary<Banknote, int> updatingCassettes = new Dictionary<Banknote, int>();
            for (int i = 0; i < cassettes.Banknotes.Count(); i++)
            {
                updatingCassettes.Add(cassettes.Banknotes.ElementAt(i).Key, cassettes.Banknotes.ElementAt(i).Value - update.Banknotes.ElementAt(i).Value);
            }
            return new Money() { Banknotes = updatingCassettes };
        }
    }
}

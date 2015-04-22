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
        public Atm(WithdrawMoneyAlgorithm algorithm)
        {
            Algorithm = algorithm;
        }
        public Money WithdrawMoney(int sum)
        {
            Atm t = new Atm(Algorithm);
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
            if(state == StatesATM.Ok)
                t.UpdateMoney(withdrawMoney);               
            
             return withdrawMoney;
        }

        public void InputCassettes(Money cassettes)
        {
            Cassettes = cassettes.Safecopy();
        }

        public void UpdateMoney(Money update)
        {
            foreach (KeyValuePair<Banknote, int> a in update.Banknotes)
            {
                Cassettes.Banknotes[a.Key] -= a.Value;
            }
        }
    }
}

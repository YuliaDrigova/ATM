using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM
{
    enum StatesAlgorithm { Ok, NotEnoughMoney, ImpossibleSum}
    class WithdrawMoneyAlgorithm
    {
        public StatesAlgorithm state;
        public Money Algorithm(int sum, Money cassettes)
        {

            if (cassettes.AllSum < sum)
            {
                state = StatesAlgorithm.NotEnoughMoney;
                return null;
            }
            
            List<int[]> prevSum = new List<int[]>();
            List<int[]> curSum = new List<int[]>();
            prevSum.Add(new int[cassettes.Banknotes.Count + 1]);
            bool flag = false;
            do
            {
                for (int i = 0; i < prevSum.Count; i++)
                {
                    for (int j = 0; j < cassettes.Banknotes.Count; j++)
                    {
                        if (prevSum[i][0] + cassettes.Banknotes.ElementAt(j).Key.Nominal <= sum)
                        {
                            int[] buf = new int[cassettes.Banknotes.Count + 1];
                            prevSum[i].CopyTo(buf, 0);
                            buf[0] += cassettes.Banknotes.ElementAt(j).Key.Nominal;
                            if (buf[0] <= sum)
                                flag = true;
                            buf[j + 1]++;
                            curSum.Add(buf);
                            if (buf[0] == sum)
                            {
                                state = StatesAlgorithm.Ok;
                                Dictionary<Banknote, int> withdrawMoney = new Dictionary<Banknote, int>();
                                for (int k = 1; k < buf.Count(); k++)
                                {
                                    withdrawMoney.Add(cassettes.Banknotes.ElementAt(k - 1).Key, buf[k]);
                                }
                                return new Money() { Banknotes = withdrawMoney };
                            }
                        }
                    }

                }


                if (flag)
                {
                    prevSum = curSum;
                    curSum = new List<int[]>();
                    flag = false;
                }
                else
                {
                    state = StatesAlgorithm.ImpossibleSum;
                    return null;
                }
            }
            while (true);
            
        }
            
    }
}

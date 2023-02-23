using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0220hw
{
    class Program
    {
        static void Main(string[] args)
        {
            Creditcard cc = new Creditcard("1111 1111 1111 1111", "fName", "lName", new DateTime(2023, 2, 23), "3456", 5000);
            cc.ev1 += new MoneyEv(cc.AddMoney);
            cc.MoneyEventCall("3456",3000);
            Console.WriteLine(cc.ToString());

            cc.ev1 -= cc.AddMoney;
            cc.ev1 += new MoneyEv(cc.TakeMoney);
            cc.MoneyEventCall("3456", 2000);
            Console.WriteLine(cc.ToString());

            cc.ev2 += new PINEv(cc.ChangePIN);
            cc.PINEventCall("3456", "8791");
            Console.WriteLine(cc.ToString());

            cc.ev3 += new CreditLimEv(cc.LimMoneySwitch);
            cc.CreditLimEventCall("8791");
        }
    }
}

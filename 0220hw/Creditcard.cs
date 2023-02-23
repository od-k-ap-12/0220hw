using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0220hw
{
    public delegate void MoneyEv(string _PIN, double _money);
    public delegate void PINEv(string _PIN, string _newPIN);
    public delegate void CreditLimEv(string _PIN);
    class Creditcard
    {
        private double money;
        private string cardnumber;
        private string firstname;
        private string lastname;
        private DateTime expiration;
        private string PIN;
        private static double creditlim=100000;
        public static bool usingcreditlim = false;
        public Creditcard(string _cardnumber, string _firstname, string _lastname, DateTime _expiration, string _PIN, double _money)
        {
            cardnumber = _cardnumber;
            firstname = _firstname;
            lastname = _lastname;
            expiration = _expiration;
            PIN = _PIN;
            money = _money;
        }
        public event MoneyEv ev1;
        public event PINEv ev2;
        public event CreditLimEv ev3;
        public void AddMoney(string _PIN,double _money)
        {
            if (_PIN == PIN)
            {
                money += _money;
            }
            else
            {
                Console.WriteLine("Invalid PIN");
            }
        }

        public void TakeMoney(string _PIN,double _money)
        {
            if (_PIN == PIN)
            {
                if (money - _money < 0)
                {
                    Console.WriteLine("Not enough money to take");
                }
                else
                {
                    money = -_money;
                }
            }
            else
            {
                Console.WriteLine("Invalid PIN");
            }
        }

        public void LimMoneySwitch(string _PIN)
        {
            if (_PIN == PIN)
            {
                if (usingcreditlim == false)
                {
                    usingcreditlim = true;
                }
                else
                {
                    usingcreditlim = false;
                }
            }
            else
            {
                Console.WriteLine("Invalid PIN");
            }
        }
        public void ChangePIN(string _PIN,string _newPIN)
        {
            if (PIN == _PIN)
            {
                PIN = _newPIN;
            }
        }

        public void MoneyEventCall(string _PIN, double _money)
        {
            ev1?.Invoke(_PIN, _money);
        }

        public void CreditLimEventCall(string _PIN)
        {
            ev3?.Invoke(_PIN);
        }

        public void PINEventCall(string _PIN, string _newPIN)
        {
            ev2?.Invoke(_PIN, _newPIN);
        }

        public double Money { get => money; }
        public string CardNumber { get => cardnumber; }
        public string FirstName { get => firstname; }
        public string LastName { get => lastname; }
        public DateTime Expiration { get => expiration; }
        public string _PIN { get => PIN; }

        public static Creditcard operator +(Creditcard opl, int op2)
        {
            Creditcard result = opl;
            result.money = opl.money + op2;
            return result;
        }
        public static Creditcard operator -(Creditcard opl, int op2)
        {
            Creditcard result = opl;
            result.money = opl.money - op2;
            return result;
        }

        public void Print()
        {
            Console.WriteLine("Card number: " + cardnumber + "\nFirst name: " + firstname + "\nLast name: " + lastname + "\nExpiration date: " + expiration + "\nPIN:" + PIN + "\nCurrent balance: " + money+"\nCredit limit: "+creditlim);
        }
        public override string ToString()
        {
            return "Card number: " + cardnumber + "\nFirst name: " + firstname + "\nLast name: " + lastname + "\nExpiration date: " + expiration + "\nPIN:" + PIN + "\nCurrent balance: " + money+"\nCredit limit: " + creditlim;
        }
    }
}

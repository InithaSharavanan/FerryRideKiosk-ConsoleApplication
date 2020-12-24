using System;
using System.Collections.Generic;
using System.Text;

namespace KiskLibrary
{
    public class Check : Payment
    {
        private IScreen _screen;
        private IKeyPad _keypad;
        private int _bankNumber;
        private int _routingNumber;
        private decimal _checkamount;
        public Check(IScreen screen,IKeyPad keypad)
        {
            _screen = screen;
            _keypad = keypad;
        }
        public Check(int bankNumber, int routingNumber, decimal checkamount)
        {
            BankNumber = bankNumber;
            RoutingNumber = routingNumber;
            CheckAmount = checkamount;
        }
        public int BankNumber
        {
            get
            {
                return _bankNumber;
            }
            set
            {
                _bankNumber = value;
            }
        }
        public decimal CheckAmount
        {
            get
            {
                return _checkamount;
            }
            set
            {
                _checkamount = value;
            }
        }
        public int RoutingNumber
        {
            get
            {
                return _routingNumber;
            }
            set
            {
                _routingNumber = value;
            }
        }

        public override string MenuName => "Check";

        public bool ValidateRoutingNumber(int routingNumber)
        {
            if (routingNumber==RoutingNumber)
            {
                return true;
            }
            else
            {
                throw new ArgumentException($"Entered Routing Number : {routingNumber} is invalid");
            }

        }
        public static Check FetchCheckDetails(long bankNumber, int routingNumber)
        {
            foreach (Check check in _checkDatabase)
            {
                if (check.BankNumber == bankNumber)
                {
                    if (check.ValidateRoutingNumber(routingNumber))
                    {
                        return check;
                    }
                }
                else
                {
                    throw new ArgumentException($"Entered Bank Number: {bankNumber} is invalid");
                }
            }
            return null;
        }
        public static List<Check> _checkDatabase = new List<Check>()
        {
            new Check(123456,123456789,Amount)
        };
        public override decimal PaymentAmount(decimal amount)
        {
            if (Amount - amount < 0)
            {
                throw new ArgumentException($"You do not have sufficient Balance In your Account");
            }
            return Amount - amount;
        }
        public override Payment Process(decimal amount)
        {
            _screen.WriteLine("Enter your Bank Number");
            int bankNum = (int)_keypad.ReadValue(6);
            _screen.WriteLine("Enter your Routing Number");
            int routingNum = (int)_keypad.ReadValue(9);
            Check check = FetchCheckDetails(bankNum, routingNum);
            Amount = PaymentAmount(amount);
            if (check != null)
            {
                return check;
            }
            return null;
        }
    }
}

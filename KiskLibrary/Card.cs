using System;
using System.Collections.Generic;
using System.Text;

namespace KiskLibrary
{
    public class Card : Payment
    {
        private IScreen _screen;
        private IKeyPad _keypad;
        private decimal _cardamount;
        private long _cardNumber;
        private int _expDate;
        private int _cvv;

        public Card(IScreen screen, IKeyPad keypad)
        {
            _screen = screen;
            _keypad = keypad;
        }
        public Card(long cardNumber, int expDate, int cvv,decimal amount)
        {
            _cardNumber = cardNumber;
            _expDate = expDate;
            _cvv = cvv;
            _cardamount = amount;
        }
        public long CardNumber
        {
            get
            {
                return _cardNumber;
            }
            set
            {
                _cardNumber = value;
            }
        }
        public int ExpirationDate
        {
            get
            {
                return _expDate;
            }
            set
            {
                _expDate = value;
            }
        }
        public int CVV
        {
            get
            {
                return _cvv;
            }
            set
            {
                _cvv = value;
            }
        }
        public decimal CardAmount
        {
            get
            {
                return _cardamount;
            }
            set
            {
                _cardamount = value;
            }
        }

        public override string MenuName => "Credit Card";
        public bool ValidateCardCVV(int cvv,int expDate) 
        {
            if (cvv == CVV && expDate==ExpirationDate)
            {
                return true;
            }
            else
            {
                throw new ArgumentException($"Entered CVV : {cvv} or Expiration Date : {expDate} is invalid");
            }
            
        }
        public static Card FetchCardDetails(long cardNumber,int expDate,int cvv)
        {
            foreach (Card card in _cardDatabase)
            {
                if (card.CardNumber == cardNumber)
                {
                    if (card.ValidateCardCVV(cvv, expDate))
                    {
                        return card;
                    }
                }
                else
                {
                    throw new ArgumentException($"Card Number : {cardNumber} is invalid");
                }
            }
            return null;
        }
        public static List<Card> _cardDatabase = new List<Card>()
        {
            new Card(1234567890123456,1221,111,Amount)
        };
        public override decimal PaymentAmount(decimal amount)
        {
            if (Amount - amount < 0)
            {
                throw new ArgumentException($"You do not have sufficient Balance In your card");
            }
            return Amount - amount;
        }
        public override Payment Process(decimal amount)
        {
            _screen.WriteLine("Enter your Credit Card Number");
            long creditcardNum = _keypad.ReadValue();
            _screen.WriteLine("Enter your four digits expiration date");
            int expDate = (int)_keypad.ReadValue(4);
            _screen.WriteLine("Enter your CVV");
            int cvv = (int)_keypad.ReadValue(3);
            Card card=FetchCardDetails(creditcardNum, expDate, cvv);
            Amount= PaymentAmount(amount);
            if (card != null)
            {
                return card;
            }
            return null;
        }

    }
}

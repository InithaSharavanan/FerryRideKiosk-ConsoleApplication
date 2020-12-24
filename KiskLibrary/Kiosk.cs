using System;

namespace KiskLibrary
{
    public class Kiosk
    {
        private readonly IScreen _screen;
        private readonly IKeyPad _keypad;
        Payment _pay;

        public Kiosk(IScreen screen, IKeyPad keypad)
        {
            _screen = screen;
            _keypad = keypad;
        }
        public void Run()
        {
            _screen.WriteLine($"Welcome!!\n In this Kiosk you will be travelling between Hawaiian Islands");
            _screen.WriteLine($"Please enter numerical values for making your choices");
            _screen.WriteLine($"\n");
            while (true)
            {
                try
                {
                    Route[] routes = new Route[]
                    {
                        new Ferry1(_screen,_keypad),
                        new Ferry2(_screen,_keypad),
                        new Flight1(_screen,_keypad),
                        new Flight2(_screen,_keypad),
                        new Flight3(_screen,_keypad)

                    };
                    _screen.WriteLine("Add a Route by entering a number corresponds to one of the following routes");
                    decimal amount = 0;
                    for (int i = 0; i < routes.Length; i++)
                    {
                        _screen.WriteLine($"{i + 1}       {routes[i].Name} goes from {routes[i].From} to {routes[i].To} or viceversa for {routes[i].Price:C}");
                    }
                    int choice = (int)_keypad.ReadValue(1);
                    if (choice > 0 && choice <= routes.Length)
                    {
                        Route route = routes[choice - 1];
                        amount= route.Process();  
                    }
                    _screen.WriteLine("Enter 1 if you want to pay. Otherwise you will continue entering your new routes");
                    PaymentMenu(amount);
                }
                catch (Exception ex)
                {
                    _screen.WriteLine(ex.Message);
                }
            }  
        }
        public void PaymentMenu(decimal amount)
        {
           
            Payment[] payments = new Payment[]
            {
                new Card(_screen,_keypad),
                new Check(_screen,_keypad)
            };
            int choice = 0;
            while (choice <payments.Length-1)
            {
                _screen.WriteLine("Enter the following payment options");
              
                for (int i = 0; i < payments.Length; i++)
                {
                    _screen.WriteLine($"{i + 1}       {payments[i].MenuName}");
                }
                choice = (int)_keypad.ReadValue(1);
                if (choice > 0 && choice <= payments.Length)
                {
                    Payment payment = payments[choice - 1];
                    _pay=payment.Process(amount);
                    if (_pay != null)
                    {
                        _screen.WriteLine($"The transaction amount {amount:C} is sucessfull");
                    }
                  
                }
            }
            
        }
     
    }
}

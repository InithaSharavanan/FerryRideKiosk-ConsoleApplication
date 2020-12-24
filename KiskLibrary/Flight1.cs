using System;
using System.Collections.Generic;
using System.Text;

namespace KiskLibrary
{
    public class Flight1 : Flight
    {
        private IScreen _screen;
        private IKeyPad _keypad;
        public Flight1(IScreen screen, IKeyPad keypad)
            :base(screen,keypad)
        {
            _screen = screen;
            _keypad = keypad;
        }
       
        public override string From => "Oahu";

        public override string To => "Maui";

        public override decimal Price => 80;
        public override decimal TotalPrice => Price * Quantity;

        public override string ToString()
        {
             return $"Route Summary - {Name} goes {From} to {To} for {Quantity} X {Price:C} = {TotalPrice:C}";
        }
        public override decimal Process()
        {
            _screen.WriteLine($"Enter 1 if you want to go from {From} to {To}; otherwise, you want to go from {To} to {From}");
            int choice = (int)_keypad.ReadValue(1);
            _screen.WriteLine($"Enter 1 if the passenger is a child,otherwise, an adult");
            choice = (int)_keypad.ReadValue(1);
            _screen.WriteLine($"Enter the number of people travelling with this route");
            Quantity = (int)_keypad.ReadValue();
            _screen.WriteLine(ToString());
            return TotalPrice;
            
        }

    }
}

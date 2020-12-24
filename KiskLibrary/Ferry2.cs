using System;
using System.Collections.Generic;
using System.Text;

namespace KiskLibrary
{
    public class Ferry2:Ferry 
    {

        private IScreen _screen;
        private IKeyPad _keypad;
        public Ferry2(IScreen screen, IKeyPad keypad)
            : base(screen, keypad)
        {
            _screen = screen;
            _keypad = keypad;
        }

        public override string From => "Maui";

        public override string To => "Molokai";

        public override decimal Price
        {
            get
            {
                if (IsChild)
                {
                    return 20;
                }
                return 40;
            }
        }


        public override decimal TotalPrice => Quantity * Price;

     
        public override string ToString()
        {
            if (IsChild)
            {
                return $"Route Summary - {Name} goes {From} to {To} for {Quantity} X {Price:C} = {TotalPrice:C} (Children)";
            }
            else
            {
                return $"Route Summary - {Name} goes {From} to {To} for {Quantity} X {Price:C} = {TotalPrice:C}";
            }
            
        }
        public override decimal Process()
        {
            _screen.WriteLine($"Enter 1 if you want to go from {From} to {To}; otherwise, you want to go from {To} to {From}");
            int choice = (int)_keypad.ReadValue(1);
            _screen.WriteLine($"Enter 1 if the passenger is a child,otherwise, an adult");
            choice = (int)_keypad.ReadValue(1);
            choice = (int)_keypad.ReadValue(1);
            if (choice == 1)
            {
                IsChild = true;
            }
            _screen.WriteLine($"Enter the number of people travelling with this route");
            Quantity = (int)_keypad.ReadValue();
            _screen.WriteLine(ToString());
            return TotalPrice;
        }

    }
}

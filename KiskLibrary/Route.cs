using System;
using System.Collections.Generic;
using System.Text;

namespace KiskLibrary
{
    public abstract class Route
    {
        private IScreen _screen;
        private IKeyPad _keypad;
        private int _quantity;
        public abstract string From { get; }
        public abstract string To { get; }
        public abstract decimal Price { get; }
        public Route(IScreen screen, IKeyPad keypad)
        {
            _screen = screen;
            _keypad = keypad;
        }

        public  int Quantity
        {
            get
            {
                return _quantity;
            }
            set
            {
                _quantity = value;
            }
        }
        public abstract decimal TotalPrice { get; }
        public abstract string Name { get; }
      
        public abstract decimal Process();
        
        public override string ToString()
        {
            return $"Route Summary - {Name} goes {From} to {To} for {Quantity} X {Price:C} = {TotalPrice:C}";
        }
        
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace KiskLibrary
{
    public abstract class Ferry : Route
    {
        public bool _isChild;

        public Ferry(IScreen screen, IKeyPad keypad) 
            : base(screen, keypad)
        {
        }

        public bool IsChild
        {
            get
            {
                return _isChild;
            }
            set
            {
                _isChild = value;
            }
        }
        public override string Name => "Ferry";
        public override string ToString()
        {
            return $"Route Summary - {Name} goes {From} to {To} for {Quantity} X {Price:C} = {TotalPrice:C}";
        }
    }
}

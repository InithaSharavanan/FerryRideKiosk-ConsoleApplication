using System;
using System.Collections.Generic;
using System.Text;

namespace KiskLibrary
{
    public abstract class Flight : Route
    {
       
        public Flight(IScreen screen, IKeyPad keypad)
            :base(screen,keypad)
        {
            
        }

        public override string Name => "Flight";
        public override string ToString()
        {
            return $"{base.ToString()}\n{Name}";
        }

       
    }
}

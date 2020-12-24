using System;
using System.Collections.Generic;
using System.Text;

namespace KiskLibrary
{
    public abstract class Payment
    {
        public static decimal Amount =500;
        public abstract decimal PaymentAmount(decimal amount);
        public abstract string MenuName { get; }
        public abstract Payment Process(decimal amount);
        
    }
}

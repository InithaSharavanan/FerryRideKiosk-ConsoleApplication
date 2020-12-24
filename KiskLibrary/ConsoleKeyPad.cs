using System;
using System.Collections.Generic;
using System.Text;

namespace KiskLibrary
{
    public class ConsoleKeyPad : IKeyPad
    {
        public long ReadValue(int NoOfDigits)
        {
             int num = 0;
            int digits = 1;
            if (NoOfDigits > 18)
            {
                throw new ArgumentException($"The value {NoOfDigits} is greater than 18");
            }
            for (int i = 0; i < NoOfDigits - 1; i++)
            {
                digits *= 10;
            }
            while (digits > 0)
            {
                ConsoleKeyInfo key = Console.ReadKey();
                if (key.KeyChar >= '0' && key.KeyChar <= '9')
                {
                    num = num + digits * (key.KeyChar - '0');
                    digits = digits / 10;
                }
                else
                {
                    throw new ArgumentException($"The value {key} is not a valid number");
                }
            }
            Console.WriteLine();
            return num;
        }

        public long ReadValue()
        {
            string message = Console.ReadLine();
            long value;
            if(!long.TryParse(message,out value))
            {
                throw new ArgumentException($"The value {message} is not a valid number");
            }
            if (value < 0)
            {
                throw new ArgumentException($"The value cannot be negative");
            }
            return value;
        }
    }
}

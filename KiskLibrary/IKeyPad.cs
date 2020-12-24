using System;
using System.Collections.Generic;
using System.Text;

namespace KiskLibrary
{
    public interface IKeyPad
    {
        long ReadValue(int NoOfDigits);
        long ReadValue();
    }
}

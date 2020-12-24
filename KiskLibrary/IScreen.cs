using System;
using System.Collections.Generic;
using System.Text;

namespace KiskLibrary
{
    public interface IScreen
    {
        void Write(string message);
        void WriteLine(string message);
    }
}

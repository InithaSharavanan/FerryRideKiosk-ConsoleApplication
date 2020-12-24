using System;
using KiskLibrary;

namespace KioskSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            var screen = new ConsoleScreen();
            var keypad = new ConsoleKeyPad();
            Kiosk kiosk = new Kiosk(screen,keypad);
            kiosk.Run();
        }
    }
}

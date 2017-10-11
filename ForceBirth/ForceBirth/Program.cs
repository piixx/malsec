using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ForceBirth
{
    class Program
    {
        // opacity stuff
        [DllImport("user32.dll")]
        static extern bool SetLayeredWindowAttributes(IntPtr hwnd, uint crKey, byte bAlpha, uint dwFlags);
        [DllImport("user32.dll")]
        static extern int SetWindowLong(IntPtr Handle, int exStyle, int oldValue);
        [DllImport("user32.dll")]
        static extern int GetWindowLong(IntPtr Handle, int exStyle);
        public const int GWL_EXSTYLE = -20;
        public const int WS_EX_LAYERED = 0x80000;
        public const int LWA_ALPHA = 0x2;
        public const int LWA_COLORKEY = 0x1;

        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Black;
            Console.WriteLine("This is an unpassworded 'security' tool by piixx.");
            Console.WriteLine("Generate all your malware names and such. Very nice.");
            setOpacity(40);
            gen();
        }
        public static void gen()
        {
            Console.WriteLine("Generating a name for you...");
            Random rdm = new Random();
            Random rdm2 = new Random();
            Console.WriteLine(nameGen(rdm.Next(1,42), rdm2.Next(1,54))+"\n");
            Console.ReadLine();
            gen();
        }
        public static void setOpacity(int byteDeduction)
        {
            if (byteDeduction > 255)
            {
                throw new NotSupportedException("Cannot have an empty window. Number must be <255");
            }
            IntPtr Handle = Process.GetCurrentProcess().MainWindowHandle;
            Int32 oldValue = GetWindowLong(Handle, GWL_EXSTYLE);
            Int32 AlsoOldValue = SetWindowLong(Handle, GWL_EXSTYLE, oldValue | WS_EX_LAYERED);
            for (int x = 0; x <= byteDeduction; x++)
            {
                int z = 255 - x;
                byte a = Convert.ToByte(z);
                bool result = SetLayeredWindowAttributes(Handle, 0, a, LWA_ALPHA);
            }
        }
        public static string nameGen(int a, int b)
        {
            a = a - 1;
            b = b - 1;
            string[] suffix =
            {
               "Eternal",
               "Permanent",
               "Forever",
               "Moon",
               "Sun",
               "Wire",
               "Elder",
               "Young",
               "Paradoxical",
               "Crimson",
               "Golden",
               "Aesthetic",
               "Incendiary",
               "Fire",
               "Ice",
               "Euphoric",
               "Invictus",
               "Aeonian",
               "Obsidian",
               "Plasmatic",
               "Celestial",
               "Chaotic",
               "Neo",
               "Ethereal",
               "Lacuna",
               "Jejune",
               "Vagrant",
               "Entelechy",
               "Turbo",
               "Gyr",
               "Snowy",
               "Harpy",
               "Bald",
               "Maddening",
               "Honey",
               "Cut",
               "Der",
               "Generic",
               "After",
               "Before",
               "Flux",
               "Mass",
               "Hyper"
            };
            string[] prefix =
            {
                "Blue",
                "Yellow",
                "Red",
                "Teal",
                "Destruction",
                "Deicide",
                "Citizen",
                "Gopher",
                "Eel",
                "Piggy",
                "Snake",
                "Delta",
                "Alpha",
                "Wire",
                "Apex",
                "Shaker",
                "Interceptor",
                "Hopper",
                "Rabbit",
                "Deity",
                "Ichor",
                "Spring",
                "Winter",
                "Queen",
                "King",
                "Arcanum",
                "Alchemy",
                "Chemist",
                "Psychologist",
                "Architect",
                "Warden",
                "Eagle",
                "Beak",
                "Owl",
                "Sparrow",
                "Hawk",
                "Bit",
                "Byte",
                "Adderall",
                "Orion",
                "Tremor",
                "Kraken",
                "Midnight",
                "Lastnight",
                "Morning",
                "Evening",
                "Dusk",
                "Dawn",
                "Capacitor",
                "Overwrite",
                "Cocoon",
                "Genocide",
                "Homicide",
                "Suicide",
                "Turtle"
            };
            return suffix[a].ToString() +""+ prefix[b].ToString();
        }
    }
}

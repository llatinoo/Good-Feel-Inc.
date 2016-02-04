using System;
using System.IO;

namespace DialogToXML
{
    class Program
    {
        static void Main(string[] args)
        {
            bool doLoop = true;
            int i = 1;
            do
            {
                Console.WriteLine("szene");
                string scene = Console.ReadLine();
                if (scene.ToLower() != "exit")
                {
                    Console.WriteLine("abschnitt");
                    string part = Console.ReadLine();
                    Console.WriteLine("speaker");
                    string speaker = Console.ReadLine();
                    Console.WriteLine("speakerPicture");
                    string speakerPicture = Console.ReadLine();
                    Console.WriteLine("listener");
                    string listener = Console.ReadLine();
                    Console.WriteLine("listenerPicture");
                    string listenerPicture = Console.ReadLine();
                    Console.WriteLine("textRow1");
                    string textRow1 = Console.ReadLine();
                    Console.WriteLine("textRow2");
                    string textRow2 = Console.ReadLine();
                    Console.WriteLine("textRow3");
                    string textRow3 = Console.ReadLine();
                    Console.WriteLine("textRow4");
                    string textRow4 = Console.ReadLine();
                    Console.WriteLine("speichern? (j)");

                    if (Console.ReadLine().ToLower() == "j")
                    {
                        string filePath = String.Format(@"C:\Users\dengler\OneDrive\RPG\RPG Dokumente\RPGDialogs\{0}\{1}.xml",scene, part);
                        string data = String.Format("<TextBox id=\"{8}\" speaker=\"{0}\" speakerPicture=\"{1}\" listener=\"{2}\" listenerPicture=\"{3}\" row1=\"{4}\" row2=\"{5}\" row3=\"{6}\" row4=\"{7}\"/>", speaker, speakerPicture, listener, listenerPicture, textRow1, textRow2, textRow3, textRow4, i);
                        File.AppendAllText(filePath, data + Environment.NewLine);
                        i++;
                    }
                }
                else
                {
                    doLoop = false;
                }
            } while (doLoop);
        }
    }
}

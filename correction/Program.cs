using System;
using System.IO;

namespace correction
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Directory.CreateDirectory("C:\\Principals Record");
                var path = "C:\\Principals Record\\newscore.txt";
                var oldPath = "C:\\Principals Record\\oldScore.txt";
                //File.Create(path);
                File.WriteAllText(path, "");

                foreach (var line in File.ReadAllLines(path))
                {
                    var dMark = line.Split('-')[1];

                    var markUp = new MarkUpgrader();
                    var newMark = markUp.Upgrade(Int32.Parse(dMark));
                    var newLineContent = line.Split("-")[0] + "-" + newMark;
                    File.AppendAllLines(path, new string[] { newLineContent });

                }
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
                Console.ReadLine();
            }
            
        }
    }
}

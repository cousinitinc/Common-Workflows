using System;
using CommandLine;
using System.IO;

namespace helloWorld
{
    class Program
    {
        public class Options
        {
            [Option('f', "folder", Required = true, HelpText = "Path to the folder whose contents should be printed")]
            public string Folder { get; set; }
        }
        static void Main(string[] args)
        {
            string folder = "";
            Parser.Default.ParseArguments<Options>(args)
                .WithParsed<Options>(o =>
                {
                    folder = o.Folder;
                });
            
            foreach(string filePath in Directory.GetFiles(folder))
            {
                Console.WriteLine("printing from: " + filePath);
                string fileContent = File.ReadAllText(filePath);
                Console.WriteLine(fileContent);
            }
            
        }
    }
}

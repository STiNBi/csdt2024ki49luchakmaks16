using System;
using System.IO.Ports;
using System.Xml.Linq;

class Program
{
    static void Main(string[] args)
    {
        
        SerialPort serialPort = new SerialPort("COM3", 9600);       
        string xmlBuffer = "";
      
        serialPort.DataReceived += (sender, e) =>
        {
            
            xmlBuffer += serialPort.ReadLine();

            if (xmlBuffer.Contains("</movemant>"))
            {
                try
                {
                    
                    XDocument xdoc = XDocument.Parse(xmlBuffer);        
                    string distanceStr = xdoc.Root.Value;
                   
                    xmlBuffer = "";
                 
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("movemant:");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine(distanceStr + " CM");
                    Console.ResetColor();


                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error parsing XML: {ex.Message}");

                    xmlBuffer = "";
                }
            }
        };

        try
        {
            serialPort.Open();
        }
        catch (UnauthorizedAccessException)
        {
            Console.WriteLine("Error: Access to the COM port is denied. Please run the program as an administrator.");
        }

        Console.WriteLine("Press any key to exit...");
        Console.ReadKey();

        serialPort.Close();
    }
}

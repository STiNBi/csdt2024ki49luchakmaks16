using System;
using System.IO.Ports;
using System.Xml.Linq;

 static public class Program
{
    static public string xmlBuffer = "";
    static public bool CheckXMLbuffer()
    {
        return xmlBuffer.Contains("</movemant>");
    }
    static public string GetDistanceSTR()
    {
        XDocument xdoc = XDocument.Parse(xmlBuffer);
        string distanceStr = xdoc.Root.Value;
        return distanceStr;
    }

    /// <summary>
    /// основна функція, яка приймає дані із ардуіно, а саме, відстань від нашого датчику, та виводить її у консолі у сантиметрах
    /// </summary>
    static void Main(string[] args)
    {
        
        
        SerialPort serialPort = new SerialPort("COM3", 9600);       
        
      
        serialPort.DataReceived += (sender, e) =>
        {
            
            xmlBuffer += serialPort.ReadLine();

            if (CheckXMLbuffer())
            {
                try
                {                
                    xmlBuffer = "";
                 
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("movemant:");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine(GetDistanceSTR() + " CM");
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

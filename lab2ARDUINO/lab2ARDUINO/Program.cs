using System;
using System.IO.Ports;

class Program
{
    static SerialPort serialPort;

    static void Main()
    {
        serialPort = new SerialPort("COM3", 9600); 
        serialPort.DataReceived += SerialPort_DataReceived;

        try
        {
            serialPort.Open();

            while (true)
            {                
                System.Threading.Thread.Sleep(100); 
            }
        }

        catch (Exception ex)
        {
            Console.WriteLine("Помилка відкриття порту: " + ex.Message);
        }

        finally
        {
            serialPort.Close();
        }
    }

    private static void SerialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
    {
        SerialPort sp = (SerialPort)sender;
        string data = sp.ReadLine();      
        string[] operands = data.Split(',');

        if (operands.Length == 2)
        {           
            int result = int.Parse(operands[0]) + int.Parse(operands[1]);
            Console.WriteLine($"resul: {operands[0]} + {operands[1]} = {result}");
        }
    }
}
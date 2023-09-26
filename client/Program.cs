using System;
using System.Net.Sockets;
using System.Text;

class Client
{
    static void Main()
    {
        TcpClient client = new TcpClient("localhost", 1302);
        Console.WriteLine("Connected");
        NetworkStream stream = client.GetStream();
        int
            number = 5; // number to send, calculate and return factorial
        string textToSend = number.ToString();
        byte[] data = Encoding.ASCII.GetBytes(textToSend);
        stream.Write(data, 0, data.Length);
        Console.WriteLine("Data sent: " + textToSend);
        client.Close();
    }
}
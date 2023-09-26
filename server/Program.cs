using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

class Server
{
    static void Main()
    {
        TcpListener server = new TcpListener(IPAddress.Any, 1302);
        server.Start();
        Console.WriteLine("Server started...");
        while (true)
        {
            TcpClient client = server.AcceptTcpClient();
            Console.WriteLine("Connected!");
            NetworkStream stream = client.GetStream();
            byte[] buffer = new byte[1024];
            int bytesRead = stream.Read(buffer, 0, buffer.Length);
            string receivedText = Encoding.ASCII.GetString(buffer, 0, bytesRead);
            if (!int.TryParse(receivedText, out var number))
            {
                Console.WriteLine("Invalid number received, closing connection...");
                client.Close();
                continue;
            }

            Array.Clear(buffer, 0,
                buffer.Length); // очистка буфера для следующего обмена
            Console.WriteLine("Number received: {0}", number);
            client.Close();
        }
    }
}
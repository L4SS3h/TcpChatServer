using System;
using System.Dynamic;
using System.IO;
using System.Net.Sockets;

namespace TcpChatServer
{
    class Program
    {
        //Server side of a TCP chat server.
        static void Main(string[] args)
        {
            TcpListener serverSocket = new TcpListener(6789);
            serverSocket.Start();
            Console.WriteLine("Server started!");
            TcpClient connectionSocket = serverSocket.AcceptTcpClient();
            Console.WriteLine("Server activated!");
            
            NetworkStream ns = connectionSocket.GetStream();
            StreamReader st = new StreamReader(ns);
            StreamWriter sw = new StreamWriter(ns);

            while (true)
            {
                string message = st.ReadLine();
                Console.WriteLine("Client: " + message);


                sw.AutoFlush = true;
                string message1 = Console.ReadLine();
                sw.WriteLine(message1);
                
            }
            Console.ReadLine();

            ns.Close();
            connectionSocket.Close();
            serverSocket.Stop();
        }
    }
}

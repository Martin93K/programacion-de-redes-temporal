using System.Net.Sockets;

namespace Servidor;

public class TcpConnection
{
    public static void ListenToClients(Socket localSocket)
    {
        while (GlobalState.ServerActive)
        {
            try
            {
                Socket client = localSocket.Accept();
                Console.WriteLine($"{client.LocalEndPoint} connected to the server");

                Thread clientThread = new Thread(() => ClientHandler.Handle(client));
                clientThread.Start();
            }
            catch (SocketException)
            {
                Console.WriteLine("Thread (Listening to Clients) has stopped.");
            }
        }
    }
}
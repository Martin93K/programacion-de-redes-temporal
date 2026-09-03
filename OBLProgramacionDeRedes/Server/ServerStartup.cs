using System.Net;
using System.Net.Sockets;
using System.Text;
using Servidor.Services;

namespace Servidor;

class ServerStartup
{
    private const int Port = 10000; // TODO: Decidir puerto para la especificación
    private const int MaxClients = 50;
    private static bool ServerActive { get; set; } = true;

    static void Main(string[] args)
    {
        Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        IPEndPoint myEndPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), Port);
        
        socket.Bind(myEndPoint);
        socket.Listen(MaxClients);

        Thread listenToClients = new Thread(() => ListenToClients(socket));
        listenToClients.Start();

        do
        {
          Console.WriteLine("Type \"exit\" to stop the server.");  
        } while (!string.Equals (Console.ReadLine(), "exit", 
                     StringComparison.OrdinalIgnoreCase));
        
        ServerActive = false;
        socket.Close();
        Console.WriteLine("Server has been stopped.");
        
    }
    
    public static void ListenToClients(Socket localSocket)
    {
        while (ServerActive)
        {
            try
            {
                Socket client = localSocket.Accept();
                Console.WriteLine($"{client.LocalEndPoint} connected to the server");

                Thread clientThread = new Thread(() => HandleClient(client));
                clientThread.Start();
            }
            catch (SocketException)
            {
                Console.WriteLine("Thread (Listening to Clients) has stopped.");
            }
        }
    }

    public static void HandleClient(Socket client)
    {
        while (ServerActive)
        {
            // TODO: a decidir en especificación el protocolo de comunicación
            // por ejemplo como se mandan los bytes y la información entre sockets
            client.Send(Encoding.UTF8.GetBytes(Menu.Options()));
        }
    }
}
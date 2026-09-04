using System.Net.Sockets;
using System.Text;
using Servidor.Services;

namespace Servidor;

public class ClientHandler
{
    public static void Handle(Socket client)
    {
        while (GlobalState.ServerActive)
        {
            // TODO: a decidir en especificación el protocolo de comunicación
            // por ejemplo como se mandan los bytes y la información entre sockets
            client.Send(Encoding.UTF8.GetBytes(Menu.Options()));
        }
    }
}
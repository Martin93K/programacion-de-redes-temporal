namespace Servidor;

public class GlobalState
{
    private static bool _serverActive = true;
    private static Lock _lock = new Lock();

    public static bool ServerActive
    {
        get
        {
            lock (_lock) return _serverActive;
        }
        set
        {
            lock (_lock) _serverActive = value;
        }
    }
}
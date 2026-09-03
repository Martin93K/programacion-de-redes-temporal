namespace Servidor.Services;

public class UserService
{
    public void Register(string nombreUsuario, string contrasena)
    {
       // buscar en lista de usuarios que no exista usuario con ese nombre
       // crear modelo User
       // agregarlo
    }
    
    public void Login(string nombreUsuario, string contrasena)
    {
        // buscar en la lista si existe el usuario con ese nombre
        // si existe entonces validar que la contraseña sea correcta (comparar)
        // si coinicide entrar al sistema
    }

    public void Logout()
    {
        
    }
}
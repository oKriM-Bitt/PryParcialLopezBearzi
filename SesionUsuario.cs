using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PryPueblox
{
   
    // Clase estática para mantener la información del usuario logueado.
    public static class SesionUsuario
    {
        // Propiedades para guardar datos del usuario actual
        public static int IdUsuarioLogueado { get; private set; } = 0; // 0 significa nadie logueado
        public static string NombreUsuarioLogueado { get; private set; } = string.Empty;
        public static string NombreCompleto { get; private set; } = string.Empty;
        public static string Correo { get; private set; } = string.Empty;
        public static int IdRol { get; private set; } = 0;


        /// <summary>
        /// Establece los datos del usuario cuando inicia sesión.
        /// </summary>
        public static void IniciarSesion(int idUsuario, string nombreUsuario, string nombre, string apellido, string correo, int idRol)
        {
            IdUsuarioLogueado = idUsuario;
            NombreUsuarioLogueado = nombreUsuario;
            NombreCompleto = $"{nombre} {apellido}".Trim();
            Correo = correo;
            IdRol = idRol;
            Console.WriteLine($"Sesión iniciada: ID={idUsuario}, Usuario={nombreUsuario}, RolID={idRol}");
        }

        
        /// Limpia los datos de sesión al cerrar sesión o cerrar la app.
       
        public static void CerrarSesion()
        {
            IdUsuarioLogueado = 0;
            NombreUsuarioLogueado = string.Empty;
            NombreCompleto = string.Empty;
            Correo = string.Empty;
            IdRol = 0;
            Console.WriteLine("Sesión cerrada.");
        }

        
        /// Verifica si hay un usuario actualmente logueado.
        
        public static bool IsUserLoggedIn => IdUsuarioLogueado > 0;
    }
}
using CapaDatos.Database;
using CapaNegocios.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocios.Acciones
{
    public class AccionesUsuario : AccionesBase
    {
        public TM_Usuario loginAdministrador(string email, string password)
        {
            //string encryptedPassword = PasswordEncryptor.EncryptPassword(password);
            return dbLibContext.TM_Usuarios.Where(i => i.Email == email && i.Contrasena == password).FirstOrDefault();
        }

        public TM_Estudiante loginEstudiante(string email, string password)
        {
            //string encryptedPassword = PasswordEncryptor.EncryptPassword(password);
            return dbLibContext.TM_Estudiantes.Where(i => i.Email == email && i.Contrasena == password).FirstOrDefault();
        }

    }
}

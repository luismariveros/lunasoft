using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LunaSoft
{
    public class classUsuario
    {
        private static string _nombre;
        private static int _id_usuario;
        private static int _nivel; // 1:administrador   0:usuario normal

        public classUsuario()
        {
        }

        public classUsuario(string nombre, int id_usuario, int nivel)
        {
            _nombre = nombre;
            _id_usuario = id_usuario;
            _nivel = nivel;
        }

        public string Usuario
        {
            get
            {
                return _nombre;
            }
            set
            {
                _nombre = value;
            }
        }
        
        public int Usuario_ID
        {
            get
            {
                return _id_usuario;
            }
            set
            {
                _id_usuario = value;
            }
        }

        public int Usuario_Nivel
        {
            get
            {
                return _nivel;
            }
            set
            {
                _nivel = value;
            }
        }
    }
}

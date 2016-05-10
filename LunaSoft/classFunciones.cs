using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LunaSoft
{
    class classFunciones
    {
        public static string eliminarComa(string parametro)
        {
            return parametro.Replace(',','.');   
        }

        public static string agregar_evento(string descripcion, bool usuario)
        {
            string ret;
            if(usuario)
                ret = "; INSERT INTO auditorias(fecha_hora,descripcion,id_usuario) VALUES('" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:00") + "','" + descripcion +"'," + frmInicio.User.Usuario_ID + ")";
            else
                ret = "; INSERT INTO auditorias(fecha_hora,descripcion) VALUES('" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:00") + "','" + descripcion + "')";
            return ret;
        }
        
        
    }
}

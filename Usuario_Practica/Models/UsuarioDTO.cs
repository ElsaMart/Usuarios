using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Usuario_Practica.Models
{
    public class UsuarioDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int Edad { get; set; }
        public string Correo { get; set; }
    }
}
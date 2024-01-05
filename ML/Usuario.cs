﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class Usuario
    {
        public int IdUsuario { get; set; }
        public string UserName { get; set; }
        public byte[] Password { get; set; } //byte
        public string Contra { get; set; } //string
        public ML.Rol Rol { get; set; }
        public string Email { get; set; }
        public string Nombre { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }

        public string MensajeError { get; set; }

        public List<object> Usuarios { get; set; }
    }
}

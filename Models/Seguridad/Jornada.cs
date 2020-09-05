using System;
using System.Collections.Generic;


namespace SistemaNH.Models.Seguridad
{
    public class Jornada : IAcceso
    {
        public int? Id { get; set; }

        public string NombreJornada { get; set; }


        public List<Usuario> Usuarios { get; set; }

        public List<Rol> Roles { get; set; }

        public string UsuarioIngreso { get; set; }

        public DateTime? FechaIngreso { get; set; }

        public string UsuarioModificacion { get; set; }

        public DateTime? FechaModificacion { get; set; }
    }
}

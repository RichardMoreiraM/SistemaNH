using System;
using System.Collections.Generic;
using SistemaNH.Models.ViewModel;


namespace SistemaNH.Models.Seguridad
{
    public class Rol : IAcceso
    {
        public Rol() { }

        public Rol(int id) => Id = id;

        public Rol(ActualizarRol viewModel)
        {
            Id = viewModel.Id;
            Descripcion = viewModel.Descripcion;
            Jornada = new Jornada { Id = viewModel.IdJornada };
            Estado = "1";
            EstadoTabla = 1;
        }


        public int? Id { get; set; }

        public string Descripcion { get; set; }

        public int EstadoTabla { get; set; }

        public string Estado { get; set; }

        public Jornada Jornada { get; set; }


        public string UsuarioIngreso { get; set; }

        public DateTime? FechaIngreso { get; set; }

        public string UsuarioModificacion { get; set; }

        public DateTime? FechaModificacion { get; set; }
    }
}

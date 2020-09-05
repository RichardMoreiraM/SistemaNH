using System;
using System.Text.Json;
using System.Collections.Generic;
using SistemaNH.Models.ViewModel;
using SistemaNH.Models.DAO;


namespace SistemaNH.Models.DTO
{
    public class Usuario 
    {
         public Usuario() { }

        public Usuario(string id) => Id = id;

        public Usuario(Login viewModel)
        {
            Id = viewModel.Id;
            Clave = viewModel.Clave;
        }

        public Usuario(ActualizarUsuario viewModel)
        {
            Id = viewModel.Id;
            Clave = viewModel.Clave;
            NombreCompleto = viewModel.NombreCompleto;
            FechaExpiracion = viewModel.FechaExpiracion;
            Jornada = new Jornada { Id = viewModel.IdJornada };
            Estado = "1";
            EstadoTabla = 1;
        }
        public string Id { get; set; }

        public string Cedula { get; set; }
        
        public string Nombres { get; set; }

        public string Email { get; set; }

        public string Clave { get; set; }

        public int Estado { get; set; }

        public string UsuarioIngreso { get; set; }

        public DateTime? FechaIngreso { get; set; }

        public string UsuarioModificacion { get; set; }

        public DateTime? FechaModificacion { get; set; }

        public Rol Rol { get; set; }

        public List<string> Jornada { get; set; }

        public string ToJSON() {
            var serializeOptions = new JsonSerializerOptions {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true
            };
            return JsonSerializer.Serialize(this, serializeOptions);
        }
    }
}

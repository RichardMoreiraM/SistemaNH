using System.ComponentModel.DataAnnotations;
using SistemaNH.Models.Seguridad;


namespace SistemaNH.Models.ViewModel
{
    public class ActualizarRol
    {
        public ActualizarRol() { }

        public ActualizarRol(Rol rol)
        {
            Id = rol.Id;
            Descripcion = rol.Descripcion;
            IdJornada = rol.Jornada.Id;
        }


        [Required(ErrorMessage = "Identificador es requerido!")]
        public int? Id { get; set; }


        [Required(ErrorMessage = "Descripcion es requerida!")]
        [StringLength(100, ErrorMessage = "La maxima longitud de caracteres es 100!")]
        public string Descripcion { get; set; }


        [Required(ErrorMessage = "Jornada es requerido!")]
        public int? IdJornada { get; set; }
    }
}


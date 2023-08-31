using System.ComponentModel.DataAnnotations;

namespace WebApiBDClinica.Models
{
    public class PA_MEDICOS_ESPECIALIDAD
    {
        [Key]
        public string codmed { get; set; }
        public string nommed { get; set; }
        public int anio_colegio { get; set; }
        public string nomesp { get; set; }
        public string nomdis { get; set; }
        public string eliminado { get; set; }
    }
}

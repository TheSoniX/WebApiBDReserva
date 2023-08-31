using System.ComponentModel.DataAnnotations;

namespace WebApiBDClinica.Models
{
    public class PA_CITAS_ANIO
    {
        [Key]
        public int nrocita { get; set; }
        public string fecha { get; set; }
        public string codpac { get; set; }
        public string nompac { get; set; }
        public decimal pago { get; set; }
        public string codmed { get; set; }
        public string nommed { get; set; }
        public string descrip { get; set; }
    }
}

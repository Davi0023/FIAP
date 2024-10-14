namespace Fiap.Web.Challenge.Models
{
    public class OcorrenciaModel
    {
        public int id_ocorrencia { get; set; }
        public DateTime dt_ocorrencia { get; set; }
        public int id_sensor { get; set; }
        public SensoresModel? Sensores { get; set; }
        public int id_poluente { get; set; }
        public PoluenteModel? Poluente { get; set; }
    }
}

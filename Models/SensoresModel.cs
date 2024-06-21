namespace Fiap.Web.Challenge.Models
{
    public class SensoresModel
    {
        public int id_sensor { get; set; }
        public string ds_modelo { get; set; }
        public string ds_fabricante { get; set; }
        public string id_oceano { get; set; }
        //public int id_local { get; set; }
        public LocalModel? id_local { get; set; }

    }
}

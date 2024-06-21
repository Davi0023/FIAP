namespace Fiap.Web.Challenge.Models
{
    public class LocalModel
    {
        public int id_local { get; set; }
        public string ds_coordenadas { get; set; }
        public DateTime dt_instalacao { get; set; }
        public OrgaoModel? id_orgao { get; set; }   
        public string nm_oceano {get; set; }    
    }
}

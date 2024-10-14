

namespace Fiap.Web.Challenge.Models
{
    public class LocalModel
    {
        public int id_local { get; set; }
        public string ds_coordenadas { get; set; }  
        public string nm_oceano {get; set; }
        public int id_orgao { get; set; }
        public OrgaoModel? Orgao { get; set; }
    }
}

using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace Fiap.Web.Challenge.Models.ViewModels
{
    public class SensoresCadastroViewModel
    {
        public int id_sensor { get; set; }

        [Required(ErrorMessage = "O campo Nome é obrigatório")]
        [Display(Name = "Descrição do Modelo")]
        [StringLength(100, ErrorMessage = "O campo Nome deve ter no máximo 100 caracteres")]
        public string ds_modelo { get; set; }

        [Required(ErrorMessage = "O campo Fabricante é obrigatório")]
        [Display(Name = "Fabricante")]
        [StringLength(100, ErrorMessage = "O campo Fabricante deve ter no máximo 100 caracteres")]
        public string ds_fabricante { get; set; }

        [Required(ErrorMessage = "O campo Tipo é obrigatório")]
        [Display(Name = "Tipo")]
        [StringLength(100, ErrorMessage = "O campo Tipo deve ter no máximo 100 caracteres")]
        public string nm_oceano { get; set; }

        [Required(ErrorMessage = "O campo Local é obrigatório")]
        [Display(Name = "Local")]
        public int id_local { get; set; }

        [Required(ErrorMessage = "O campo Latitude é obrigatório")]
        [Display(Name = "Local")]
        public SelectList Local { get; set; }

        public SensoresCadastroViewModel()
        {
            Local = new SelectList(Enumerable.Empty<SelectListItem>());
        }


    }
}

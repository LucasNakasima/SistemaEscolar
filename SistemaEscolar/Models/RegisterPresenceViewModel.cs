using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SitemaUnicesumar.Models
{
    public class RegisterPresenceViewModel
    {
        public RegisterPresenceViewModel() 
        {
            ListStudent = new List<StudentViewModel>();
            ListBimester = new List<BimesterViewModel>();
            ListDisciplineContent = new List<DisciplineContentViewModel>();
        }

        public int Id { get; set; }

        public int ClassId { get; set; }

        public string ClassTitle { get; set; }

        [Display(Name = "Bimestre")]
        [Required(ErrorMessage = "Informe o bimestre", AllowEmptyStrings = false)]
        public int BimesterId { get; set; }

        [Display(Name = "Conteúdo Aplicado")]
        [Required(ErrorMessage = "Informe o conteúdo aplicado", AllowEmptyStrings = false)]
        public int DisciplineContentId { get; set; }

        public int DisciplineId { get; set; }

        [Display(Name = "Data do Registro")]
        [Required(ErrorMessage = "Informe a data do registro", AllowEmptyStrings = false)]
        public DateTime DateRegister { get; set; }

        public string StrDateRegister => DateRegister.ToString("dd/MM/yyyy HH:mm");

        [Display(Name = "Descrição/Observações:")]
        public string DescriptionContent { get; set; }

        public string ErrorMenssage { get; set; }

        public ClassViewModel Class { get; set; }

        public List<StudentViewModel> ListStudent { get; set; }

        public List<BimesterViewModel> ListBimester { get; set; }

        public List<DisciplineContentViewModel> ListDisciplineContent { get; set; }
    }
}
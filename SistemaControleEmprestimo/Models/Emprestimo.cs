using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaControleEmprestimo.Models
{
    [Table("Emprestimos")]
    public class Emprestimo
    {
        public int Id { get; set; }

        [Required]
        public string Nome { get; set; }

        [Required]
        [Display(Name = "Data de Empréstimo")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DataEmprestimo { get; set; }

        [Required]
        [Display(Name = "Amigo")]
        [ForeignKey("Amigo")]
        public int IdAmigo { get; set; }

        [Required]
        [Display(Name = "Jogo")]
        [ForeignKey("Jogo")]
        public int IdJogo { get; set; }

        public virtual Amigo Amigo { get; set; }

        public virtual Jogo Jogo { get; set; }
    }
}
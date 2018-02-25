using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaControleEmprestimo.Models
{
    [Table("Jogos")]
    public class Jogo
    {
        public int Id { get; set; }

        [Required]
        public string Nome { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace SistemaControleEmprestimo.Models
{
    public class SistemaControleEmprestimoContext: DbContext
    {
        public SistemaControleEmprestimoContext() : base("SistemaControleEmprestimo")
        {

        }

        public DbSet<Amigo> Amigos { get; set; }

        public DbSet<Jogo> Jogos { get; set; }

        public DbSet<Emprestimo> Emprestimos { get; set; }
    }
}
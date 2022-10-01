using System;
using System.Collections.Generic;

namespace DataLayer.Models
{
    public class Pessoa
    {
        public Pessoa()
        {
            Usuario = new HashSet<Usuario>();
        }

        public int IdPessoa { get; set; }
        
        public string NomeCompleto { get; set; }
        
        public string Cpf { get; set; }

        public DateTime? DataNascimento { get; set; }

        public string Email { get; set; }

        public virtual ICollection<Usuario> Usuario { get; set; }

        public virtual Aluno Aluno { get; set; }
    }
}

using System;
using System.Collections.Generic;

#nullable disable

namespace DataLayer.Models
{
    public partial class Aluno
    {
        public Aluno()
        {
            Contratos = new HashSet<Contrato>();
            Pagamentos = new HashSet<Pagamento>();
            Documentos = new HashSet<Documento>();
        }

        public int Id { get; set; }

        public string Matricula { get; set; }

        public int IdPessoa { get; set; }

        public virtual ICollection<Contrato> Contratos { get; set; }

        public virtual ICollection<Pagamento> Pagamentos { get; set; }

        public virtual Pessoa Pessoa { get; set; }

        public virtual ICollection<Documento> Documentos { get; set; }
       
    }
}

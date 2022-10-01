using System.Collections.Generic;

namespace DataLayer.Models
{
    public class Documento
    {
        public int IdDocumento { get; set; }

        public int IdAluno{ get; set; }

        public string NomeDocumento { get; set; }

        public string Descricao { get; set; }

        public string MimeType { get; set; }

        public string Arquivo { get; set; }

        public virtual Aluno Aluno { get; set; }
    }
}

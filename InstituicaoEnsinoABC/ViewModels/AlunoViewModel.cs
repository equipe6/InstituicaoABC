using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace InstituicaoEnsinoABC.ViewModels
{
    public class AlunoViewModel
    {
        public int Id { get; set; }
        public string NomeCompleto { get; set; }
        public string Matricula { get; set; }
        public List<ContratoViewModel> Contratos { get; set; }
        public List<PagamentoViewModel> PagamentoViewModels { get; set; }
        public List<DocumentoViewModel> Documentos { get; set; }

        public int IdPessoa { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InstituicaoEnsinoABC.ViewModels
{
    public class PagamentoViewModel
    {
        public int Id { get; set; }
        public string FormaPagamento { get; set; }

        public List<ParcelaViewModel> Parcelas { get; set; }
        public AlunoViewModel Aluno { get; set; }
    }
}

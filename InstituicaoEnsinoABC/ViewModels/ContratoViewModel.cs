using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InstituicaoEnsinoABC.ViewModels
{
    public class ContratoViewModel
    {
        public int Id { get; set; }
        public string Descricao { get; set; }

        public List<ParcelaViewModel> Parcelas { get; set; }
    }
}

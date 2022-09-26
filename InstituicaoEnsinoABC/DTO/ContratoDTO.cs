using DataLayer.Models;
using InstituicaoEnsinoABC.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InstituicaoEnsinoABC.DTO
{
    public static class ContratoDTO
    {
        public static ContratoViewModel ContratoDataTransferObject(Contrato _contrato)
        {
            ContratoViewModel _contratoViewModel = new ContratoViewModel
            {
                Id = _contrato.Id,
                Descricao = _contrato.Descricao,
                Parcelas = new List<ParcelaViewModel>()
            };

            foreach (Parcela parcela in _contrato.ParcelasNavigation)
            {
                _contratoViewModel.Parcelas.Add(ParcelaDataTransferObject(parcela));
            }

            return _contratoViewModel;
        }

        public static ParcelaViewModel ParcelaDataTransferObject(Parcela _parcela)
        {
            ParcelaViewModel _parcelaViewModel = new ParcelaViewModel
            {
                Id = _parcela.Id,
                NumeroParcela = _parcela.NumeroParcela,
                Pagamento = new PagamentoViewModel()
            };

            if (_parcela.Pagamentos != null)
            {
                foreach (Pagamento _pagamento in _parcela.Pagamentos)
                {
                    _parcelaViewModel.Pagamento = new PagamentoViewModel
                    {
                        Id = _pagamento.Id,
                        FormaPagamento = _pagamento.FormaPagamento
                    };
                }
            }

            return _parcelaViewModel;
        }
    }
}

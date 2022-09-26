using DataLayer.Models;
using InstituicaoEnsinoABC.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InstituicaoEnsinoABC.DTO
{
    public static class ParcelaDTO
    {
        public static ParcelaViewModel ParcelaDataTransferObject(Parcela _parcela)
        {
            ParcelaViewModel _parcelaViewModel = new ParcelaViewModel
            {
                Id = _parcela.Id,
                NumeroParcela = _parcela.NumeroParcela,
                Contrato = new ContratoViewModel()
            };

            if (_parcela.IdContratoNavigation != null)
            {
                _parcelaViewModel.Contrato = new ContratoViewModel
                {
                    Id = _parcela.IdContratoNavigation.Id,
                    Descricao = _parcela.IdContratoNavigation.Descricao
                };
            }

            return _parcelaViewModel;
        }
    }
}

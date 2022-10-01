using DataLayer.Context;
using DataLayer.Models;
using InstituicaoEnsinoABC.Builders;
using InstituicaoEnsinoABC.DTO;
using InstituicaoEnsinoABC.Services.ApiClient;
using InstituicaoEnsinoABC.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace InstituicaoEnsinoABC.Services
{
    public class ContratoService
    {
        private InstituicaoEnsinoABCDbContext _db;

        public ContratoService(InstituicaoEnsinoABCDbContext dBContext)
        {
            _db = dBContext;
        }

        public List<ContratoViewModel> ReadContratos()
        {
            var _listContratoViewModel = new List<ContratoViewModel>();

            var _contratosDb = _db.Contratos.ToList();

            foreach (Contrato contrato in _contratosDb)
            {
                _listContratoViewModel.Add(DataTransferObject.ContratoDTO(contrato));
            }

            return _listContratoViewModel;
        }

        public ContratoViewModel ReadContratoPorId(int id)
        {
            var _contrato = _db.Contratos.Include(x => x.ParcelasNavigation).FirstOrDefault(x => x.Id == id);

            _contrato.ParcelasNavigation = _db.Parcelas.Where(x => x.IdContrato == id).ToList();

            if (_contrato.ParcelasNavigation != null)
            {
                foreach (Parcela _parcela in _contrato.ParcelasNavigation)
                {
                    _parcela.Pagamentos = _db.Pagamentos.Where(x => x.IdParcela == _parcela.Id).ToList();
                }
            }

            return ContratoDTO.ContratoDataTransferObject(_contrato);
        }

        public async Task<ParcelaViewModel> ReadParcelaPorId(int id, int idContrato)
        {
            var _parcela = _db.Parcelas.Include(x => x.IdContratoNavigation).FirstOrDefault(x => x.Id == id && x.IdContrato == idContrato);

            var alunoService = new AlunoService(_db);

            var aluno = alunoService.ReadAlunoPorId(id);

            var OpenApiRequest = new OpenPixRequestBuilder(aluno, _parcela).BuildOpenPixCriarCobrancaRequestDTO();
            var clientCommunication = new ClientCommunicationService();
            var response = await clientCommunication.GerarCobrancaPix(OpenApiRequest);

            var parcelaPix = await clientCommunication.ObterParcelaPixPorcorrelationID(response.IdCorrelacao); 
           
            var parcela = ParcelaDTO.ParcelaDataTransferObject(_parcela);

            parcela.InformacoesPix = new PixViewModel
            {
                IdCorrellacao = parcelaPix.Cobranca.IdCorrelacao,
                ChavePix = parcelaPix.Cobranca.ChavePix,
                UrlQrCode = parcelaPix.Cobranca.QrCodeUrl,
                Valor = parcelaPix.Cobranca.Valor
            };

            return parcela;
        }
    }
}

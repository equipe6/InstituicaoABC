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
            // _parcela.IdContratoNavigation = _db.Cont.Where(x => x.IdContrato == id).ToList();

            // if (_parcela.ParcelasNavigation != null)
            // {
            //     foreach (Parcela _parcela in _parcela.ParcelasNavigation)
            //     {
            //         _parcela.Pagamentos = _db.Pagamentos.Where(x => x.IdParcela == _parcela.Id).ToList();
            //     }
            // }
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

        /*public ChecklistViewModel CadastraChecklist(ChecklistViewModel checklistViewModel)
        {
            var checklist = new Checklist
            {
                Nome = checklistViewModel.Nome,
                Descricao = checklistViewModel.Descricao
            };
            _db.Checklists.Add(checklist);
            _db.SaveChanges();
            return ChecklistDTO.ChecklistDataTransferObject(checklist);
        }*/

        /*public bool AtivarChecklist(ChecklistViewModel checklistViewModel)
        {
            var checklist = _db.Checklists.Find(checklistViewModel.Id);
            _db.SaveChanges();
            return true;
        }*/

        /*public Checklist ConsultarChecklistPorNome(ChecklistViewModel checklistViewModel)
        {
            var checklist = _db.Checklists.FirstOrDefault(x => x.Nome == checklistViewModel.Nome);
            return checklist;
        }*/

        /*public ChecklistItemViewModel ConsultarChecklistItemPorId(int id_checklist, int id)
        {
            var checklistItem = _db.ChecklistItems.FirstOrDefault(x => x.Id == id && x.IdChecklist == id_checklist);
            return ChecklistDTO.ChecklistItemDataTransferObject(checklistItem);
        }*/

        /*public List<ChecklistItemViewModel> VerificarItemsDisponiveisDaChecklist(ChecklistViewModel checklistViewModel)
        {
            var ckecklists = _db.ChecklistItems.Where(x =>
                x.IdChecklist == checklistViewModel.Id
            );
            var checklistsItems = new List<ChecklistItemViewModel>();
            foreach (ChecklistItem checklist in ckecklists)
            {
                checklistsItems.Add(ChecklistDTO.ChecklistItemDataTransferObject(checklist));
            }
            return checklistsItems;
        }*/

        /*public ChecklistItemViewModel CadastraChecklistItem(ChecklistItemViewModel checklistItemViewModel)
        {
            var checklist = new ChecklistItem
            {
                Tarefa = checklistItemViewModel.Tarefa,
                IdChecklist = checklistItemViewModel.IdChecklist
            };
            _db.ChecklistItems.Add(checklist);
            _db.SaveChanges();
            return ChecklistDTO.ChecklistItemDataTransferObject(checklist);
        }*/

        /*public List<ChecklistItemViewModel> BuscarChecklistsItems(string id_checklist)
        {
            var ChecklistItemViewModel = new List<ChecklistItemViewModel>();

            int id = Int32.Parse(id_checklist);
            List<ChecklistItem> checklists;

            if (id > 0)
            {
                checklists = _db.ChecklistItems.Where(x => x.IdChecklist == id).ToList();
            }
            else
            {
                checklists = _db.ChecklistItems.ToList();
            }

            foreach (ChecklistItem checklist in checklists)
            {
                checklist.IdChecklistNavigation = _db.Checklists.FirstOrDefault(x => x.Id == checklist.IdChecklist);

                ChecklistItemViewModel.Add(DataTransferObject.ChecklistItemDTO(checklist));
            }

            return ChecklistItemViewModel;
        }*/

        /*public ChecklistViewModel EditarChecklist(ChecklistViewModel ChecklistViewModel)
        {
            var checklist = _db.Checklists.Find(ChecklistViewModel.Id);

            checklist.Nome = ChecklistViewModel.Nome;
            checklist.Descricao = ChecklistViewModel.Descricao;

            _db.SaveChanges();

            ChecklistViewModel.Id = checklist.Id;

            return ChecklistViewModel;
        }*/

        /*public bool RemoverChecklist(ChecklistViewModel checklistViewModel)
        {
            try
            {
                var checklist = _db.Checklists.Find(checklistViewModel.Id);
                _db.Checklists.Remove(checklist);
                _db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }*/

        /*public ChecklistItemViewModel EditarChecklistItem(ChecklistItemViewModel ChecklistItemViewModel)
        {
            var checklist = _db.ChecklistItems.Find(ChecklistItemViewModel.Id);

            checklist.Tarefa = ChecklistItemViewModel.Tarefa;

            _db.SaveChanges();

            ChecklistItemViewModel.Id = checklist.Id;

            return ChecklistItemViewModel;
        }*/

        /*public bool RemoverChecklistItem(ChecklistItemViewModel ChecklistItemViewModel)
        {
            try
            {
                var checklist = _db.ChecklistItems.Find(ChecklistItemViewModel.Id);
                _db.ChecklistItems.Remove(checklist);
                _db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }*/
    }
}

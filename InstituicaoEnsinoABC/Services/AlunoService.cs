using DataLayer.Context;
using DataLayer.Models;
using InstituicaoEnsinoABC.DTO;
using InstituicaoEnsinoABC.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace InstituicaoEnsinoABC.Services
{
    public class AlunoService
    {
        private InstituicaoEnsinoABCDbContext _db;
        // private VacinaService vacinaService;
        // private MedicamentoService medicamentoService;

        public AlunoService(InstituicaoEnsinoABCDbContext dBContext)
        {
            _db = dBContext;
            // vacinaService = new VacinaService(dBContext);
            // medicamentoService = new MedicamentoService(dBContext);
        }

        public List<AlunoViewModel> ReadAlunos()
        {
            var _listAlunoViewModel = new List<AlunoViewModel>();

            var _alunosDb = _db.Alunos.Include(x => x.Contratos).ToList();

            foreach (Aluno aluno in _alunosDb)
            {
                _listAlunoViewModel.Add(DataTransferObject.AlunoDTO(aluno));
            }

            return _listAlunoViewModel;
        }

        public AlunoViewModel CreateAluno(AlunoViewModel alunoViewModel)
        {
            var aluno = new Aluno
            {
                NomeCompleto = alunoViewModel.NomeCompleto,
                Cpf = alunoViewModel.Cpf,
                DataNascimento = DateTime.Parse(alunoViewModel.DataNascimento),
                EnderecoCompleto = alunoViewModel.EnderecoCompleto,
                // Genero = alunoViewModel.Genero,
                // Cns = alunoViewModel.Cns
            };
            _db.Alunos.Add(aluno);
            _db.SaveChanges();
            alunoViewModel.Id = aluno.Id;
            return alunoViewModel;
        }

        public AlunoViewModel ReadAlunoPorId(int id)
        {
            var aluno = _db.Alunos.FirstOrDefault(x => x.Id == id);

            // aluno.Anamneses = _db.Anamneses.Where(x => x.IdPaciente == id).OrderBy(x => x.Data).ToList();

            // aluno.AlunoMedicamentos = _db.AlunoMedicamentos.Where(x => x.IdAluno == id).ToList();

            // foreach (AlunoMedicamento alunoMedicamento in aluno.AlunoMedicamentos)
            // {
            //     alunoMedicamento.IdMedicamentoNavigation = _db.Medicamentos.FirstOrDefault(x => x.Id == alunoMedicamento.IdMedicamento);
            // }

            // aluno.AlunoVacinaLotes = _db.AlunoVacinaLotes.Where(x => x.IdAluno == id).ToList();

            // foreach (AlunoVacinaLote alunoVacinaLote in aluno.AlunoVacinaLotes)
            // {
            //     alunoVacinaLote.IdVacinaLoteNavigation = _db.VacinaLotes.FirstOrDefault(x => x.Id == alunoVacinaLote.IdVacinaLote);

            //     alunoVacinaLote.IdVacinaLoteNavigation.IdVacinaNavigation = _db.Vacinas.FirstOrDefault(x => x.Id == alunoVacinaLote.IdVacinaLoteNavigation.IdVacina);
            // }

            // aluno.AlunoChecklistItems = _db.AlunoChecklistItems.Where(x => x.IdAluno == id).ToList();

            // foreach (AlunoChecklistItem alunoChecklistItem in aluno.AlunoChecklistItems)
            // {
            //     alunoChecklistItem.IdChecklistItemNavigation = _db.ChecklistItems.FirstOrDefault(x => x.Id == alunoChecklistItem.IdChecklistItem);

            //     alunoChecklistItem.IdChecklistItemNavigation.IdChecklistNavigation = _db.Checklists.FirstOrDefault(x => x.Id == alunoChecklistItem.IdChecklistItemNavigation.IdChecklist);
            // }

            return DataTransferObject.AlunoDTO(aluno);
        }

        public AlunoViewModel UpdateAluno(AlunoViewModel alunoViewModel)
        {
            var aluno = _db.Alunos.Find(alunoViewModel.Id);

            aluno.NomeCompleto = alunoViewModel.NomeCompleto;
            aluno.Cpf = alunoViewModel.Cpf;
            aluno.DataNascimento = DateTime.Parse(alunoViewModel.DataNascimento);
            aluno.EnderecoCompleto = alunoViewModel.EnderecoCompleto;

            _db.SaveChanges();

            alunoViewModel.Id = aluno.Id;

            return alunoViewModel;
        }

        public bool DeleteAluno(AlunoViewModel alunoViewModel)
        {
            try
            {
                var aluno = _db.Alunos.Find(alunoViewModel.Id);
                _db.Alunos.Remove(aluno);
                _db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        /*public AlunoViewModel ConsultarAlunoPorNome(AlunoViewModel alunoViewModel)
        {
            var aluno = _db.Alunos.Find(alunoViewModel.Nome);
            return DataTransferObject.AlunoDTO(aluno);
        }*/

        /*public bool CadastrarVacinaNoAluno(AlunoViewModel alunoViewModel)
        {
            var aluno = _db.Alunos.Find(alunoViewModel.Id);
            foreach (VacinaLoteViewModel vacinaLoteViewModel in alunoViewModel.Vacinas)
            {
                var alunoVacinaLote = new AlunoVacinaLote
                {
                    IdVacinaLote = vacinaLoteViewModel.Id,
                    DataVacinacao = DateTime.Parse(vacinaLoteViewModel.DataVacinacao)
                };
                aluno.AlunoVacinaLotes.Add(alunoVacinaLote);
            }
            _db.SaveChanges();
            return true;
        }*/

        /*public bool CadastrarAtividadeNoAluno(AlunoViewModel alunoViewModel)
        {
            var aluno = _db.Alunos.Find(alunoViewModel.Id);
            foreach (ChecklistItemViewModel checklistItemViewModel in alunoViewModel.Checklists)
            {
                var alunoChecklistItem = new AlunoChecklistItem
                {
                    IdChecklistItem = checklistItemViewModel.Id,
                    FezTarefa = 1
                };
                aluno.AlunoChecklistItems.Add(alunoChecklistItem);
            }
            _db.SaveChanges();
            return true;
        }*/

        /*public List<VacinaLoteViewModel> VerificarVacinasAluno(AlunoViewModel alunoViewModel)
        {
            var aluno = _db.Alunos.Find(alunoViewModel.Id);

            aluno.AlunoVacinaLotes = _db.AlunoVacinaLotes.Where(x => x.IdAluno == alunoViewModel.Id).ToList();

            return DataTransferObject.AlunoDTO(aluno).Vacinas;
        }*/

        /*public bool CadastrarMedicamentoNoAluno(AlunoViewModel alunoViewModel)
        {
            var aluno = _db.Alunos.Find(alunoViewModel.Id);
            foreach (MedicamentoViewModel medicamentoViewModel in alunoViewModel.Medicamentos)
            {
                var alunoMedicamento = new AlunoMedicamento
                {
                    IdAluno = aluno.Id,
                    IdMedicamento = medicamentoViewModel.Id,
                    DataMedicacao = DateTime.Parse(medicamentoViewModel.DataMedicacao)
                };
                _db.AlunoMedicamentos.Add(alunoMedicamento);
            }
            _db.SaveChanges();
            return true;
        }*/

        /*public List<MedicamentoViewModel> VerificarMedicamentoAluno(AlunoViewModel alunoViewModel)
        {
            var aluno = _db.Alunos.Find(alunoViewModel.Id);

            return DataTransferObject.AlunoDTO(aluno).Medicamentos;
        }*/
    }
}

using DataLayer.Models;
using InstituicaoEnsinoABC.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InstituicaoEnsinoABC.DTO
{
    public static class AlunoDTO
    {
        public static AlunoViewModel AlunoDataTransferObject(Aluno aluno)
        {
            AlunoViewModel alunoViewModel = new AlunoViewModel
            {
                Id = aluno.Id,
                NomeCompleto = aluno.NomeCompleto,
                Cpf = aluno.Cpf,
                DataNascimento = aluno.DataNascimento?.ToString("yyyy-MM-dd"),
                EnderecoCompleto = aluno.EnderecoCompleto,
                // Anamneses = new List<AnamneseViewModel>(),
                // Medicamentos = new List<MedicamentoViewModel>(),
                // Vacinas = new List<VacinaLoteViewModel>(),
                // Checklists = new List<ChecklistItemViewModel>()
            };

            /*if (interno.Anamneses.Count() > 0)
            {
                foreach (Anamnese anamnese in interno.Anamneses)
                {
                    internoViewModel.Anamneses.Add(new AnamneseViewModel
                    {
                        Id = anamnese.Id,
                        Data = anamnese.Data?.ToString("yyyy-MM-dd HH:mm"),
                        FrequenciaCardiaca = anamnese.FrequenciaCardiaca,
                        FrequenciaRespiratoria = anamnese.FrequenciaRespiratoria,
                        PressaoArterial = anamnese.PressaoArterial,
                        Saturacao = anamnese.Saturacao,
                        Temperatura = anamnese.Temperatura
                    });
                }
            }*/

            /*if (interno.InternoMedicamentos.Count() > 0)
            {
                foreach (InternoMedicamento InternoMedicamento in interno.InternoMedicamentos)
                {
                    internoViewModel.Medicamentos.Add(new MedicamentoViewModel
                    {
                        Id = InternoMedicamento.IdMedicamentoNavigation.Id,
                        Nome = InternoMedicamento.IdMedicamentoNavigation.Nome,
                        Gramagem = InternoMedicamento.IdMedicamentoNavigation.Gramagem,
                        DataMedicacao = InternoMedicamento.DataMedicacao?.ToString("yyyy-MM-dd HH:mm:ss")
                    });
                }
            }*/

            /*if (interno.InternoVacinaLotes.Count() > 0)
            {
                foreach (InternoVacinaLote internoVacinaLotes in interno.InternoVacinaLotes)
                {
                    internoViewModel.Vacinas.Add(new VacinaLoteViewModel
                    {
                        Id = internoVacinaLotes.IdVacinaLoteNavigation.Id,
                        DataFabricacao = internoVacinaLotes.IdVacinaLoteNavigation.DataFabricacao?.ToString("yyyy-MM-dd"),
                        DataValidade = internoVacinaLotes.IdVacinaLoteNavigation.DataValidade?.ToString("yyyy-MM-dd"),
                        NtoDoLote = internoVacinaLotes.IdVacinaLoteNavigation.NtoDoLote,
                        DataVacinacao = internoVacinaLotes.DataVacinacao?.ToString("yyyy-MM-dd HH:mm:ss"),
                        Vacina = new VacinaViewModel
                        {
                            Id = internoVacinaLotes.IdVacinaLoteNavigation.IdVacinaNavigation.Id,
                            Nome = internoVacinaLotes.IdVacinaLoteNavigation.IdVacinaNavigation.Nome,
                            NroDeDoses = internoVacinaLotes.IdVacinaLoteNavigation.IdVacinaNavigation.NroDeDoses,
                            Ativo = internoVacinaLotes.IdVacinaLoteNavigation.IdVacinaNavigation.Ativo
                        }
                    });
                }
            }*/

            /*if (interno.InternoChecklistItems.Count() > 0)
            {
                foreach (InternoChecklistItem internoChecklistItem in interno.InternoChecklistItems)
                {
                    internoViewModel.Checklists.Add(new ChecklistItemViewModel
                    {
                        Id = internoChecklistItem.IdChecklistItemNavigation.Id,
                        Tarefa = internoChecklistItem.IdChecklistItemNavigation.Tarefa,
                        FezTarefa = internoChecklistItem.FezTarefa,
                        Checklist = new ChecklistViewModel
                        {
                            Id = internoChecklistItem.IdChecklistItemNavigation.IdChecklistNavigation.Id,
                            Nome = internoChecklistItem.IdChecklistItemNavigation.IdChecklistNavigation.Nome,
                            Descricao = internoChecklistItem.IdChecklistItemNavigation.IdChecklistNavigation.Descricao
                        }
                    });
                }
            }*/

            return alunoViewModel;
        }

    }
}

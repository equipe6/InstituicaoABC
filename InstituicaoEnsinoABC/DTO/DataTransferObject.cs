using DataLayer.Models;
using InstituicaoEnsinoABC.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InstituicaoEnsinoABC
{
    public static class DataTransferObject
    {
        public static AlunoViewModel AlunoDTO(Aluno aluno)
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

            /*if (aluno.Anamneses.Count() > 0)
            {
                foreach (Anamnese anamnese in aluno.Anamneses)
                {
                    alunoViewModel.Anamneses.Add(new AnamneseViewModel
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

            /*if (aluno.AlunoMedicamentos.Count() > 0)
            {
                foreach (AlunoMedicamento AlunoMedicamento in aluno.AlunoMedicamentos)
                {
                    alunoViewModel.Medicamentos.Add(new MedicamentoViewModel
                    {
                        Id = AlunoMedicamento.IdMedicamentoNavigation.Id,
                        Nome = AlunoMedicamento.IdMedicamentoNavigation.Nome,
                        Gramagem = AlunoMedicamento.IdMedicamentoNavigation.Gramagem,
                        DataMedicacao = AlunoMedicamento.DataMedicacao?.ToString("yyyy-MM-dd HH:mm:ss")
                    });
                }
            }*/

            /*if (aluno.AlunoVacinaLotes.Count() > 0)
            {
                foreach (AlunoVacinaLote alunoVacinaLotes in aluno.AlunoVacinaLotes)
                {
                    alunoViewModel.Vacinas.Add(new VacinaLoteViewModel
                    {
                        Id = alunoVacinaLotes.IdVacinaLoteNavigation.Id,
                        DataFabricacao = alunoVacinaLotes.IdVacinaLoteNavigation.DataFabricacao?.ToString("yyyy-MM-dd"),
                        DataValidade = alunoVacinaLotes.IdVacinaLoteNavigation.DataValidade?.ToString("yyyy-MM-dd"),
                        NtoDoLote = alunoVacinaLotes.IdVacinaLoteNavigation.NtoDoLote,
                        DataVacinacao = alunoVacinaLotes.DataVacinacao?.ToString("yyyy-MM-dd HH:mm:ss"),
                        Vacina = new VacinaViewModel
                        {
                            Id = alunoVacinaLotes.IdVacinaLoteNavigation.IdVacinaNavigation.Id,
                            Nome = alunoVacinaLotes.IdVacinaLoteNavigation.IdVacinaNavigation.Nome,
                            NroDeDoses = alunoVacinaLotes.IdVacinaLoteNavigation.IdVacinaNavigation.NroDeDoses,
                            Ativo = alunoVacinaLotes.IdVacinaLoteNavigation.IdVacinaNavigation.Ativo
                        }
                    });
                }
            }*/

            /*if (aluno.AlunoChecklistItems.Count() > 0)
            {
                foreach (AlunoChecklistItem alunoChecklistItem in aluno.AlunoChecklistItems)
                {
                    alunoViewModel.Checklists.Add(new ChecklistItemViewModel
                    {
                        Id = alunoChecklistItem.IdChecklistItemNavigation.Id,
                        Tarefa = alunoChecklistItem.IdChecklistItemNavigation.Tarefa,
                        FezTarefa = alunoChecklistItem.FezTarefa,
                        Checklist = new ChecklistViewModel
                        {
                            Id = alunoChecklistItem.IdChecklistItemNavigation.IdChecklistNavigation.Id,
                            Nome = alunoChecklistItem.IdChecklistItemNavigation.IdChecklistNavigation.Nome,
                            Descricao = alunoChecklistItem.IdChecklistItemNavigation.IdChecklistNavigation.Descricao
                        }
                    });
                }
            }*/

            return alunoViewModel;
        }

        public static ContratoViewModel ContratoDTO(Contrato _contrato)
        {
            ContratoViewModel _contratoViewModel = new ContratoViewModel
            {
                Id = _contrato.Id,
                Descricao = _contrato.Descricao
            };
            foreach (Parcela _parcela in _contrato.ParcelasNavigation)
            {
                _contratoViewModel.Parcelas.Add(ParcelaDTO(_parcela));
            }
            return _contratoViewModel;
        }

        public static ParcelaViewModel ParcelaDTO(Parcela _parcela)
        {
            ParcelaViewModel _parcelaViewModel = new ParcelaViewModel
            {
                Id = _parcela.Id,
                NumeroParcela = _parcela.NumeroParcela
            };
            if (_parcelaViewModel.Contrato is not null)
            {
                _parcelaViewModel.Contrato = new ContratoViewModel
                {
                    Id = _parcela.IdContratoNavigation.Id,
                    Descricao = _parcela.IdContratoNavigation.Descricao
                };
            }
            return _parcelaViewModel;
        }

        /*public static VacinaViewModel VacinaDTO(Vacina vacina)
        {
            VacinaViewModel vacinaViewModel = new VacinaViewModel
            {
                Id = vacina.Id,
                Nome = vacina.Nome,
                NroDeDoses = vacina.NroDeDoses,
                Ativo = vacina.Ativo
            };
            foreach (VacinaLote item in vacina.VacinaLotes)
            {
                vacinaViewModel.Lotes.Add(VacinaLoteDTO(item));
            }
            return vacinaViewModel;
        }*/

        /*public static VacinaLoteViewModel VacinaLoteDTO(VacinaLote vacinaLote)
        {
            VacinaLoteViewModel vacinaLoteViewModelViewModel = new VacinaLoteViewModel
            {
                DataFabricacao = vacinaLote.DataFabricacao?.ToString("yyyy-MM-dd"),
                DataValidade = vacinaLote.DataValidade?.ToString("yyyy-MM-dd"),
                NtoDoLote = vacinaLote.NtoDoLote,
                Id = vacinaLote.Id
            };
            if (vacinaLote.IdVacinaNavigation is not null)
            {
                vacinaLoteViewModelViewModel.Vacina = new VacinaViewModel
                {
                    Nome = vacinaLote.IdVacinaNavigation.Nome,
                    Ativo = vacinaLote.IdVacinaNavigation.Ativo,
                    NroDeDoses = vacinaLote.IdVacinaNavigation.NroDeDoses,
                    Id = vacinaLote.IdVacinaNavigation.Id
                };
            }
            return vacinaLoteViewModelViewModel;
        }*/

        /*public static MedicamentoViewModel MedicamentoDTO(Medicamento medicamento)
        {
            MedicamentoViewModel medicamentoViewModel = new MedicamentoViewModel
            {
                Id = medicamento.Id,
                Nome = medicamento.Nome,
                Gramagem = medicamento.Gramagem
            };
            return medicamentoViewModel;
        }*/

        /*public static AnamneseViewModel AnamneseDTO(Anamnese anamnese)
        {
            AnamneseViewModel anamneseViewModel = new AnamneseViewModel
            {
                Id = anamnese.Id,
                Data = anamnese.Data?.ToString("yyyy-MM-dd HH:mm"),
                FrequenciaCardiaca = anamnese.FrequenciaCardiaca,
                FrequenciaRespiratoria = anamnese.FrequenciaRespiratoria,
                PressaoArterial = anamnese.PressaoArterial,
                Saturacao = anamnese.Saturacao,
                Temperatura = anamnese.Temperatura
            };

            if (anamnese.IdPacienteNavigation is not null)
            {
                anamneseViewModel.Paciente = new AlunoViewModel
                {
                    Nome = anamnese.IdPacienteNavigation.Nome,
                    Id = anamnese.IdPacienteNavigation.Id,
                    Cns = anamnese.IdPacienteNavigation.Cns,
                    Cpf = anamnese.IdPacienteNavigation.Cpf,
                    DataNascimento = anamnese.IdPacienteNavigation.DataNascimento?.ToString("yyyy-MM-dd"),
                    Genero = anamnese.IdPacienteNavigation.Genero,
                    NomeSocial = anamnese.IdPacienteNavigation.NomeSocial
                };
            }

            return anamneseViewModel;
        }*/
    }
}

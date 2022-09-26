using DataLayer.Models;
using InstituicaoEnsinoABC.DTO.OpenPixDTOs.RequestsDTO;
using InstituicaoEnsinoABC.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InstituicaoEnsinoABC.Builders
{
    public class OpenPixRequestBuilder
    {
        private readonly AlunoViewModel _aluno;
        private readonly Parcela _parcela;

        public OpenPixRequestBuilder(AlunoViewModel aluno, Parcela parcela)
        {
            _aluno = aluno;
            _parcela = parcela;
        }

        public OpenPixCriarCobrancaRequestDTO BuildOpenPixCriarCobrancaRequestDTO()
        {
            return new OpenPixCriarCobrancaRequestDTO
            {
                IdCorrelacao = Guid.NewGuid().ToString(),
                Valor = _parcela.ValorParcela.Value,
                Comentario = "Pagamento Parcela",
                InformacoesAlunoRequestDTO = new InformacoesAlunoRequestDTO
                {
                    Nome = _aluno.NomeCompleto,
                    CPF = _aluno.Cpf,
                    Email = String.Empty,
                    Phone = string.Empty
                },
                InformacoesAdicionais = new InformacoesAdicionaisDTO { 
                    Chave = "Financeiro",
                    Valor = "Parcela universitária"
                }
            };
        }
    }
}

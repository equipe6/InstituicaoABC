using DataLayer.Models;
using InstituicaoEnsinoABC.ViewModels;

namespace InstituicaoEnsinoABC
{
    public static class DataTransferObject
    {
        public static AlunoViewModel AlunoDTO(Aluno aluno)
        {
            AlunoViewModel alunoViewModel = new AlunoViewModel
            {
                Id = aluno.Id,
                Matricula = aluno.Matricula,
            };

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
            var _parcelaViewModel = new ParcelaViewModel
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


        public static PessoaViewModel PessoaDTO(Pessoa pessoa)
        {
            var pessoaViewModel = new PessoaViewModel
            {
                IdPessoa = pessoa.IdPessoa,
                NomeCompleto = pessoa.NomeCompleto,
                Cpf = pessoa.Cpf,
                DataNascimento = pessoa.DataNascimento.Value,
                Email = pessoa.Email
            };

            return pessoaViewModel;
        }

        public static DocumentoViewModel DocumentoDTO(Documento documento)
        {
            var documentoViewModel = new DocumentoViewModel
            {
                IdDocumento = documento.IdDocumento,
                IdAluno = documento.IdAluno,
                NomeDocumento = documento.NomeDocumento,
                Arquivo = documento.Arquivo,
                MimeType = documento.MimeType,
                Descricao = documento.Descricao
            };

            return documentoViewModel;
        }
    }
}

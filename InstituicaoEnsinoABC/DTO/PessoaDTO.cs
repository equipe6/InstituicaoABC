using DataLayer.Models;
using InstituicaoEnsinoABC.ViewModels;

namespace InstituicaoEnsinoABC.DTO
{
    public class PessoaDTO
    {
        public static PessoaViewModel PessoaDataTransferObject(Pessoa pessoa)
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
    }
}
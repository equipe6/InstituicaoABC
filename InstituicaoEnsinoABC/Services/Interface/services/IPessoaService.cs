using InstituicaoEnsinoABC.ViewModels;
using System.Collections.Generic;

namespace InstituicaoEnsinoABC.Services.Interface.services
{
    public interface IPessoaService
    {
        public List<PessoaViewModel> ReadPessoas();

        public PessoaViewModel CreatePessoa(PessoaViewModel pessoaViewModel);

        public PessoaViewModel ReadPessoaPorId(int id);

        public PessoaViewModel UpdatePessoa(PessoaViewModel pessoaViewModel);

        public bool DeletePessoa(PessoaViewModel pessoaViewModel);
    }
}

using System;

namespace InstituicaoEnsinoABC.ViewModels
{
    public class PessoaViewModel
    {
        public int IdPessoa { get; set; }

        public string NomeCompleto { get; set; }

        public string Cpf { get; set; }

        public DateTime? DataNascimento { get; set; }

        public string Email { get; set; }
    }
}

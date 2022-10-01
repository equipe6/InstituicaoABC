using DataLayer.Context;
using DataLayer.Models;
using InstituicaoEnsinoABC.Services.Interface.services;
using InstituicaoEnsinoABC.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace InstituicaoEnsinoABC.Services
{
    public class PessoaService : IPessoaService
    {
        private readonly InstituicaoEnsinoABCDbContext _db;

        public PessoaService(InstituicaoEnsinoABCDbContext db)
        {
            _db = db;
        }

        public PessoaViewModel CreatePessoa(PessoaViewModel pessoaViewModel)
        {
            var pessoa = new Pessoa
            {
                NomeCompleto = pessoaViewModel.NomeCompleto,
                Cpf = pessoaViewModel.Cpf,
                DataNascimento = pessoaViewModel.DataNascimento,
                Email = pessoaViewModel.Email
            };

            _db.Pessoas.Add(pessoa);
            _db.SaveChanges();
            pessoaViewModel.IdPessoa = pessoa.IdPessoa;
            return pessoaViewModel;
        }

        public bool DeletePessoa(PessoaViewModel pessoaViewModel)
        {
            try
            {
                var pessoa = _db.Pessoas.Find(pessoaViewModel.IdPessoa);
                _db.Pessoas.Remove(pessoa);
                _db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public PessoaViewModel ReadPessoaPorId(int id)
        {
            var pessoa = _db.Pessoas.FirstOrDefault(x => x.IdPessoa == id);

            return DataTransferObject.PessoaDTO(pessoa);
        }

        public List<PessoaViewModel> ReadPessoas()
        {
            var listPessoaViewModel = new List<PessoaViewModel>();

            var pessoas = _db.Pessoas.ToList();

            foreach (var pessoa in pessoas)
            {
                listPessoaViewModel.Add(DataTransferObject.PessoaDTO(pessoa));
            }

            return listPessoaViewModel;
        }

        public PessoaViewModel UpdatePessoa(PessoaViewModel pessoaViewModel)
        {
            var pessoa = _db.Pessoas.Find(pessoaViewModel.IdPessoa);

            pessoa.Cpf = pessoaViewModel.Cpf;
            pessoa.NomeCompleto = pessoaViewModel.NomeCompleto;
            pessoa.DataNascimento = pessoaViewModel.DataNascimento;
            pessoa.Email = pessoaViewModel.Email;

            _db.SaveChanges();

            pessoaViewModel.IdPessoa = pessoa.IdPessoa;

            return pessoaViewModel;
        }
    }
}

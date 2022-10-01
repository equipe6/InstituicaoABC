using InstituicaoEnsinoABC.Services;
using InstituicaoEnsinoABC.Services.Interface.services;
using InstituicaoEnsinoABC.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace InstituicaoEnsinoABC.Controllers
{
    [Route("api/[controller]")]
    [ApiController, Authorize]
    public class PessoaController : ControllerBase
    {
        private readonly IPessoaService _pessoaService;

        public PessoaController(IPessoaService pessoaService)
        {
            _pessoaService = pessoaService;
        }

        [HttpGet]
        public IActionResult ReadPessoas()
        {
            return Ok(_pessoaService.ReadPessoas());
        }

        [HttpPost]
        public IActionResult CreatePessoa(PessoaViewModel pessoaViewModel)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var pessoas = _pessoaService.CreatePessoa(pessoaViewModel);
            return Ok(pessoas);
        }

        [HttpGet("{id}")]
        public IActionResult ReadPessoaPorId(string id)
        {
            var Pessoas = _pessoaService.ReadPessoaPorId(Int32.Parse(id));

            return Ok(Pessoas);
        }

        [HttpPut]
        public IActionResult UpdatePessoa(PessoaViewModel pessoaViewModel)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var Pessoas = _pessoaService.UpdatePessoa(pessoaViewModel);
            return Ok(Pessoas);
        }

        [HttpDelete("{id}")]
        public IActionResult DeletePessoa(string id)
        {
            var pessoaViewModel = new PessoaViewModel
            {
                IdPessoa = Int32.Parse(id)
            };

            var Pessoas = this._pessoaService.DeletePessoa(pessoaViewModel);
            return Ok(Pessoas);
        }
    }
}

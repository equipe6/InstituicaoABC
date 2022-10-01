using DataLayer.Context;
using DataLayer.Models;
using InstituicaoEnsinoABC.Services;
using InstituicaoEnsinoABC.Services.Interface.services;
using InstituicaoEnsinoABC.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InstituicaoEnsinoABC.Controllers
{
    [Route("api/[controller]")]
    [ApiController, Authorize]
    public class AlunoController : ControllerBase
    {
        private readonly AlunoService _alunoService;
        private readonly IDocumentoService _DocumentoService;

        public AlunoController(AlunoService alunoService, IDocumentoService documentoService)
        {
            this._alunoService = alunoService;
            _DocumentoService = documentoService;
        }

        [HttpGet]
        public IActionResult ReadAlunos()
        {
            return Ok(this._alunoService.ReadAlunos());
        }

        [HttpPost]
        public IActionResult CreateAluno(AlunoViewModel alunoViewModel)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var aluno = this._alunoService.CreateAluno(alunoViewModel);

            alunoViewModel.Documentos.Select(a => a.IdAluno = aluno.Id).FirstOrDefault();

            foreach (var documento in alunoViewModel.Documentos)
            {
                _DocumentoService.CreateDocumento(documento);
            }

            return Ok(aluno);
        }

        [HttpGet("{id}")]
        public IActionResult ReadAlunoPorId(string id)
        {
            var alunos = this._alunoService.ReadAlunoPorId(Int32.Parse(id));

            alunos.Documentos = _DocumentoService.ReadDocumentosPorAlunoId(Int32.Parse(id));

            return Ok(alunos);
        }

        [HttpPut]
        public IActionResult UpdateAluno(AlunoViewModel alunoViewModel)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var Alunos = this._alunoService.UpdateAluno(alunoViewModel);

            _DocumentoService.DeleteDocumentoPorIdAluno(alunoViewModel.Id);

            foreach (var documento in alunoViewModel.Documentos)
            {
                documento.IdAluno = alunoViewModel.Id;

                _DocumentoService.CreateDocumento(documento);
            }

            return Ok(Alunos);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteAluno(string id)
        {
            var alunoViewModel = new AlunoViewModel
            {
                Id = Int32.Parse(id)
            };

            var Alunos = this._alunoService.DeleteAluno(alunoViewModel);
            return Ok(Alunos);
        }
    }
}

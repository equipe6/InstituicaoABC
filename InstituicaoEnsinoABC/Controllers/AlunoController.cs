using DataLayer.Context;
using DataLayer.Models;
using InstituicaoEnsinoABC.Services;
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

        public AlunoController(AlunoService alunoService)
        {
            this._alunoService = alunoService;
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

            var Alunos = this._alunoService.CreateAluno(alunoViewModel);
            return Ok(Alunos);
        }

        [HttpGet("{id}")]
        public IActionResult ReadAlunoPorId(string id)
        {
            var Alunos = this._alunoService.ReadAlunoPorId(Int32.Parse(id));

            return Ok(Alunos);
        }

        [HttpPut]
        public IActionResult UpdateAluno(AlunoViewModel alunoViewModel)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var Alunos = this._alunoService.UpdateAluno(alunoViewModel);
            return Ok(Alunos);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteAluno(string id)
        {
            AlunoViewModel alunoViewModel = new AlunoViewModel
            {
                Id = Int32.Parse(id)
            };

            var Alunos = this._alunoService.DeleteAluno(alunoViewModel);
            return Ok(Alunos);
        }

        /*[HttpGet("nome/{nome}")]
        public IActionResult GetConsultarInternoPoNome(string nome)
        {
            InternoViewModel internoViewModel = new InternoViewModel
            {
                Nome = nome,
            };

            var Internos = this.InternoService.ConsultarInternoPorNome(internoViewModel);

            return Ok(Internos);
        }*/

        /*[HttpGet("verificar-vacinas/{id}")]
        public IActionResult GetVerificarVacinasInterno(string id)
        {
            InternoViewModel InternoViewModel = new InternoViewModel
            {
                Id = Int32.Parse(id)
            };

            var Internos = this.InternoService.VerificarVacinasInterno(InternoViewModel);

            return Ok(Internos);
        }*/

        /*[HttpGet("verificar-medicamentos/{id}")]
        public IActionResult GetVerificarMedicamentoInterno(string id)
        {
            InternoViewModel InternoViewModel = new InternoViewModel
            {
                Id = Int32.Parse(id)
            };

            var Internos = this.InternoService.VerificarMedicamentoInterno(InternoViewModel);

            return Ok(Internos);
        }*/

        /*[HttpPost("registrar-atividades/{interno_id}/{checklist_item_id}/{data_realizacao}")]
        public IActionResult PostCadastrarAtividadeNoInterno(string interno_id, string checklist_item_id, string data_realizacao)
        {
            InternoViewModel internoViewModel = new InternoViewModel
            {
                Id = Int32.Parse(interno_id),
                Checklists = new List<ChecklistItemViewModel>()
            };
            internoViewModel.Checklists.Add(new ChecklistItemViewModel
            {
                Id = Int32.Parse(checklist_item_id)
                //, DataRealizacao = DateTime.Parse(data_realizacao)
            });
            var Internos = this.InternoService.CadastrarAtividadeNoInterno(internoViewModel);
            return Ok(Internos);
        }*/

        /*[HttpPost("vacinar-interno/{interno_id}/{vacina_lote_id}/{data_aplicacao}")]
        public IActionResult PostCadastrarVacinaNoInterno(string interno_id, string vacina_lote_id, string data_aplicacao)
        {
            InternoViewModel internoViewModel = new InternoViewModel
            {
                Id = Int32.Parse(interno_id),
                Vacinas = new List<VacinaLoteViewModel>()
            };
            internoViewModel.Vacinas.Add(new VacinaLoteViewModel
            {
                Id = Int32.Parse(vacina_lote_id),
                DataVacinacao = data_aplicacao
            });
            var Internos = this.InternoService.CadastrarVacinaNoInterno(internoViewModel);
            return Ok(Internos);
        }*/

        /*[HttpPost("medicar-interno/{interno_id}/{medicamento_id}/{data_aplicacao}")]
        public IActionResult PostCadastrarMedicamentoNoInterno(string interno_id, string medicamento_id, string data_aplicacao)
        {
            InternoViewModel internoViewModel = new InternoViewModel
            {
                Id = Int32.Parse(interno_id),
                Medicamentos = new List<MedicamentoViewModel>()
            };
            internoViewModel.Medicamentos.Add(new MedicamentoViewModel
            {
                Id = Int32.Parse(medicamento_id),
                DataMedicacao = data_aplicacao
            });
            var Internos = this.InternoService.CadastrarMedicamentoNoInterno(internoViewModel);
            return Ok(Internos);
        }*/
    }
}

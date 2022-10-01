using InstituicaoEnsinoABC.Services.Interface.services;
using InstituicaoEnsinoABC.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InstituicaoEnsinoABC.Controllers
{
    [Route("api/[controller]")]
    [ApiController, Authorize]
    public class DocumentoController : ControllerBase
    {
        private readonly IDocumentoService _documentoService;

        public DocumentoController(IDocumentoService documentoService)
        {
            _documentoService = documentoService;
        }

        [HttpGet]
        public IActionResult ReadDocumentos()
        {
            return Ok(_documentoService.ReadDocumentos());
        }

        [HttpPost]
        public IActionResult CreateDocumento(DocumentoViewModel documentoViewModel)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var documentos = _documentoService.CreateDocumento(documentoViewModel);
            return Ok(documentos);
        }

        [HttpGet("{id}")]
        public IActionResult ReadDocumentoPorAlunoId(int id)
        {
            var Documentos = _documentoService.ReadDocumentosPorAlunoId(id);

            return Ok(Documentos);
        }

        [HttpPut]
        public IActionResult UpdateDocumento(DocumentoViewModel documentoViewModel)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var Documentos = _documentoService.UpdateDocumento(documentoViewModel);
            return Ok(Documentos);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteDocumento(int id)
        {
            var documentoViewModel = new DocumentoViewModel
            {
                IdDocumento = id
            };

            var DocumentoFoiDeletado = _documentoService.DeleteDocumento(documentoViewModel);
            return Ok(DocumentoFoiDeletado);
        }
    }
}

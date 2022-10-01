using DataLayer.Context;
using DataLayer.Models;
using InstituicaoEnsinoABC.Services.Interface.services;
using InstituicaoEnsinoABC.ViewModels;
using Nancy;
using System.Collections.Generic;
using System.Linq;

namespace InstituicaoEnsinoABC.Services
{
    public class DocumentoService : IDocumentoService
    {
        private readonly InstituicaoEnsinoABCDbContext _db;

        public DocumentoService(InstituicaoEnsinoABCDbContext db)
        {
            _db = db;
        }

        public DocumentoViewModel CreateDocumento(DocumentoViewModel documentoViewModel)
        {
            var documento = new Documento
            {
                IdAluno = documentoViewModel.IdAluno,
                Arquivo = documentoViewModel.Arquivo,
                NomeDocumento = documentoViewModel.NomeDocumento,
                MimeType = documentoViewModel.MimeType,
                Descricao = documentoViewModel.Descricao
            };

            _db.Documentos.Add(documento);
            _db.SaveChanges();
            documentoViewModel.IdDocumento = documento.IdDocumento;

            return documentoViewModel;
        }

        public bool DeleteDocumento(DocumentoViewModel documentoViewModel)
        {
            try
            {
                var documento = _db.Documentos.Find(documentoViewModel.IdDocumento);
                _db.Documentos.Remove(documento);
                _db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool DeleteDocumentoPorIdAluno(int idAluno)
        {
            try
            {
                var documentos = _db.Documentos.Where(x => x.IdAluno == idAluno);

                foreach (var documento in documentos)
                {
                    _db.Documentos.Remove(documento);
                }
                _db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public List<DocumentoViewModel> ReadDocumentosPorAlunoId(int idAluno)
        {
            var documentos = _db.Documentos.Where(x => x.IdAluno == idAluno).ToList();

            var listDocumentoViewModel = new List<DocumentoViewModel>();

            foreach (var documento in documentos)
            {
                listDocumentoViewModel.Add(DataTransferObject.DocumentoDTO(documento));
            }

            return listDocumentoViewModel;
        }

        public DocumentoViewModel ReadDocumentoPorIdDocumento(int idDocumento)
        {
            var documento = _db.Documentos.FirstOrDefault(x => x.IdDocumento == idDocumento);

            return DataTransferObject.DocumentoDTO(documento);
        }

        public List<DocumentoViewModel> ReadDocumentos()
        {
            var listDocumentoViewModel = new List<DocumentoViewModel>();

            var documentos = _db.Documentos.ToList();

            foreach (var documento in documentos)
            {
                listDocumentoViewModel.Add(DataTransferObject.DocumentoDTO(documento));
            }

            return listDocumentoViewModel;
        }

        public DocumentoViewModel UpdateDocumento(DocumentoViewModel documentoViewModel)
        {
            var documento = _db.Documentos.Find(documentoViewModel.IdDocumento);

            documento.IdAluno = documentoViewModel.IdAluno;
            documento.Arquivo = documentoViewModel.Arquivo;
            documento.NomeDocumento = documentoViewModel.NomeDocumento;
            documento.MimeType = documentoViewModel.MimeType;
            documento.Descricao = documentoViewModel.Descricao;

            _db.SaveChanges();

            documentoViewModel.IdDocumento = documento.IdDocumento;

            return documentoViewModel;
        }
    }
}

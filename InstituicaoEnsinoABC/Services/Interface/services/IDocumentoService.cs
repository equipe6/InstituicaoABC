using InstituicaoEnsinoABC.ViewModels;
using System.Collections.Generic;

namespace InstituicaoEnsinoABC.Services.Interface.services
{
    public interface IDocumentoService
    {
        DocumentoViewModel CreateDocumento(DocumentoViewModel documentoViewModel);
        bool DeleteDocumento(DocumentoViewModel documentoViewModel);
        bool DeleteDocumentoPorIdAluno(int idAluno);
        List<DocumentoViewModel> ReadDocumentosPorAlunoId(int id);
        List<DocumentoViewModel> ReadDocumentos();
        DocumentoViewModel UpdateDocumento(DocumentoViewModel documentoViewModel);
    }
}

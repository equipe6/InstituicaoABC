using DataLayer.Models;
using InstituicaoEnsinoABC.ViewModels;

namespace InstituicaoEnsinoABC.DTO
{
    public class DocumentoDTO
    {
        public static DocumentoViewModel PessoaDataTransferObject(Documento documento)
        {
            var documentoViewModel = new DocumentoViewModel
            {
                IdDocumento = documento.IdDocumento,
                IdAluno = documento.IdAluno,
                Arquivo = documento.Arquivo,
                NomeDocumento = documento.NomeDocumento,
                MimeType = documento.MimeType,
                Descricao = documento.Descricao
            };

            return documentoViewModel;
        }
    }
}

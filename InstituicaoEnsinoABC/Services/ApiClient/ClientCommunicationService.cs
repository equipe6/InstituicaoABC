using InstituicaoEnsinoABC.DTO.OpenPixDTOs.RequestsDTO;
using InstituicaoEnsinoABC.DTO.OpenPixDTOs.ResponsesDTO.CriarCobranca;
using InstituicaoEnsinoABC.DTO.OpenPixDTOs.ResponsesDTO.ObterCobranca;
using Newtonsoft.Json;
using System.Net;
using System.Threading.Tasks;

namespace InstituicaoEnsinoABC.Services.ApiClient
{
    public class ClientCommunicationService
    {
        private const string Auth = "Q2xpZW50X0lkX2FjNWEzODk0LWNhNjktNDM3My04ZTI0LWI3ZjkxYjJiMDcxNDpDbGllbnRfU2VjcmV0XzFjZ0U3Q0ZzRnY2SWVVQVFCUmFTeU85MHhuVE4wN0p1VlIyQm5ucUVKQTg9";
        private const string BaseUrl = "https://api.openpix.com.br/api/openpix/";
        public async Task<OpenPixCriarCobrancaResponseDTO> GerarCobrancaPix(OpenPixCriarCobrancaRequestDTO requestDTO)
        {
            var endPoint = "v1/charge";

            using (var webClient = new WebClient()) {
                webClient.BaseAddress = BaseUrl;
                webClient.Headers[HttpRequestHeader.Authorization] = Auth;
                webClient.Encoding = System.Text.Encoding.UTF8;

                var jsonRequest = JsonConvert.SerializeObject(requestDTO);
                var jsonResponse = string.Empty;

                try
                {
                    jsonResponse = await webClient.UploadStringTaskAsync(endPoint, jsonRequest);
                    return JsonConvert.DeserializeObject<OpenPixCriarCobrancaResponseDTO>(jsonResponse);
                }
                catch (WebException)
                {
                    return JsonConvert.DeserializeObject<OpenPixCriarCobrancaResponseDTO>(jsonResponse);
                }
            }
        }

        public async Task<ObterCobrancaResponseDTO> ObterParcelaPixPorcorrelationID(string correlationID)
        {
            var endPoint = "v1/charge/"+correlationID;

            using (var webClient = new WebClient())
            {
                webClient.BaseAddress = BaseUrl;
                webClient.Headers[HttpRequestHeader.Authorization] = Auth;
                webClient.Encoding = System.Text.Encoding.UTF8;

                var jsonResponse = string.Empty;

                try
                {
                    jsonResponse = await webClient.DownloadStringTaskAsync(endPoint);
                    return JsonConvert.DeserializeObject<ObterCobrancaResponseDTO>(jsonResponse);
                }
                catch (WebException)
                {
                    return JsonConvert.DeserializeObject<ObterCobrancaResponseDTO>(jsonResponse);
                }
            }
        }
    }
}
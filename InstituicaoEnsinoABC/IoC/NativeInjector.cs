using Application.Interfaces;
using Application.Services;
using DataLayer.Repositories;
using Domain.Interfaces;
using InstituicaoEnsinoABC.Services;
using InstituicaoEnsinoABC.Services.ApiClient;
using InstituicaoEnsinoABC.Services.Interface.services;
using Microsoft.Extensions.DependencyInjection;

namespace InstituicaoEnsinoABC.IoC
{
    public static class NativeInjector
    {
        public static void RegisterServices(IServiceCollection services)
        {
            #region Services

            services.AddScoped<IUsuarioService, UsuarioService>();
            services.AddScoped<IPessoaService, PessoaService>();
            services.AddScoped<IDocumentoService, DocumentoService>();
            services.AddScoped<ClientCommunicationService>();
            services.AddScoped<ContratoService>();
            services.AddScoped<AlunoService>();

            #endregion

            #region Repositories

            services.AddScoped<IUsuarioRepository, UsuarioRepository>();

            #endregion
        }
    }
}

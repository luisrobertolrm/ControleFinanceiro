using ControleFinanceiro.Core.Entity;
using ControleFinanceiro.Database;
using ControleFinanceiro.Negocio.Interface;
using ControleFinanceiro.Negocio.Servicos;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using SharpGrip.FluentValidation.AutoValidation.Mvc.Extensions;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using SharpGrip.FluentValidation.AutoValidation.Mvc.Results;
using ControleFinanceiro.Negocio.Validadores;
using FluentValidation;
using Microsoft.AspNetCore.Identity;
using ControleFinanceiro.Core.ViewModels;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using ControleFinanceiro.Jwt;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Options;
using System.Security.Cryptography;

namespace ControleFinanceiro.Negocio
{
    public static class IServiceCollectionExtension
    {
        public static void Configurar(this IServiceCollection services)
        {
            IConfiguration configuration = services.BuildServiceProvider().GetService<IConfiguration>();

            var typesInNamespace = Assembly
            .GetExecutingAssembly()
            .GetTypes()
            .Where(
                type =>
                    type.Namespace is not null
                    && type.Namespace.StartsWith("ControleFinanceiro.Negocio.Validadores")
                    && !type.IsAbstract
                    && !type.IsInterface
                    && type.Name.EndsWith("Validator")
            );

            // Iterate through the types and register them with the service collection
            foreach (var type in typesInNamespace)
            {
                // Find the implemented interface IValidator<T>
                var validatorInterface = type.GetInterfaces()
                    .FirstOrDefault(
                        i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IValidator<>)
                    );

                // If the type implements IValidator<T>, register it with the service collection
                if (validatorInterface is not null)
                {
                    var genericArgument = validatorInterface.GetGenericArguments()[0];
                    var serviceType = typeof(IValidator<>).MakeGenericType(genericArgument);
                    services.AddScoped(serviceType, type);
                }
            }

            services.AddFluentValidationAutoValidation(configuration =>
            {
                configuration.OverrideDefaultResultFactoryWith<CustomResultFactory>();
            });

            services.ConfigurarDatabase();
            services.AddScoped<IEntradaService, EntradaService>();
            services.AddScoped<IPeriodoService, PeriodoService>();
            services.AddScoped<ITipoSaidaService, TipoSaidaService>();
            services.AddScoped<ISaidaService, SaidaService>();
            services.AddScoped<TokenUtil, TokenUtil>(); 
            
            services.AddScoped<IValidator<EntradaInput>, EntradaInputValidator>();
        }

        
    }

    public class CustomResultFactory : IFluentValidationAutoValidationResultFactory
    {
        public IActionResult CreateActionResult(ActionExecutingContext context, ValidationProblemDetails? validationProblemDetails)
        {
            return new BadRequestObjectResult(new { Title = "Erros de Validacao", ValidationErrors = validationProblemDetails?.Errors });
        }
    }

    
}

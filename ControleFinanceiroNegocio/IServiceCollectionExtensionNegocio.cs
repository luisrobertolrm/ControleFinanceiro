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

namespace ControleFinanceiro.Negocio
{
    public static class IServiceCollectionExtensionNegocio
    {
        public static void Configurar(this IServiceCollection services)
        {
           
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
            services.AddAutoMapper(Assembly.GetAssembly(typeof(IServiceCollectionExtensionNegocio)));

            services.AddScoped<IValidator<EntradaInput>, EntradaInputValidator>();

            //services.AddFluentValidationAutoValidation(configuration =>
            //{
            //    // Disable the built-in .NET model (data annotations) validation.
            //    configuration.DisableBuiltInModelValidation = true;

            //    // Only validate controllers decorated with the `FluentValidationAutoValidation` attribute.
            //    configuration.ValidationStrategy = SharpGrip.FluentValidation.AutoValidation.Mvc.Enums.ValidationStrategy.Annotations;

            //    // Enable validation for parameters bound from `BindingSource.Body` binding sources.
            //    configuration.EnableBodyBindingSourceAutomaticValidation = true;

            //    // Enable validation for parameters bound from `BindingSource.Form` binding sources.
            //    configuration.EnableFormBindingSourceAutomaticValidation = true;

            //    // Enable validation for parameters bound from `BindingSource.Query` binding sources.
            //    configuration.EnableQueryBindingSourceAutomaticValidation = true;

            //    // Enable validation for parameters bound from `BindingSource.Path` binding sources.
            //    configuration.EnablePathBindingSourceAutomaticValidation = true;

            //    // Enable validation for parameters bound from 'BindingSource.Custom' binding sources.
            //    configuration.EnableCustomBindingSourceAutomaticValidation = true;

            //    // Replace the default result factory with a custom implementation.
            //    configuration.OverrideDefaultResultFactoryWith<CustomResultFactory>();
            //});
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

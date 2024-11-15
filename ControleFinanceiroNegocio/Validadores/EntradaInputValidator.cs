using ControleFinanceiro.Core.ViewModels;
using ControleFinanceiro.DataBase;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleFinanceiro.Negocio.Validadores
{
    public class EntradaInputValidator : AbstractValidator<EntradaInput>
    {
        #region exemplo contexto banco de dados
        //private readonly ControleFinanceiroContext _contexto;

        //public EntradaInputValidator(ControleFinanceiroContext contexto)
        //{
        //    _contexto = contexto;
        //}
        #endregion

        public EntradaInputValidator()
        {
            RuleFor(x => x.Ano)
                .NotNull().WithMessage("O ano é obrigatório")
                .GreaterThan(DateTime.Now.Year - 1).WithMessage("Valor deve ser maior que o ano atual menos 1");

            RuleFor(x => x.Mes)
                .NotNull().WithMessage("O Mês é obrigatório")
                .GreaterThan(0).WithMessage("Valor deve ser maior que zero")
                .LessThan(13).WithMessage("Valor não deve ser maior que doze");

            RuleFor(x => x.IdTipoEntrada)
                .NotNull().WithMessage("O Tipo de Entrada é obrigatório").WithSeverity(Severity.Warning);

            RuleFor(x => x.Data).Must( (model,field) =>
            {
                return model.DataProjetada.HasValue || model.Data.HasValue;

            }).WithMessage("A Data é obrigatória se a Data prevista não for informada").WithSeverity(Severity.Error);

            RuleFor(x => x.DataProjetada).Must((model, field) =>
            {
                return model.DataProjetada.HasValue || model.Data.HasValue;

            }).WithMessage("A Data Prevista é obrigatória se a Data não for informada").WithSeverity(Severity.Error);
        }
    }
}

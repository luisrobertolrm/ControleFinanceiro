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
    public class TipoEntradaInputValidator : AbstractValidator<TipoEntradaInput>
    {
        #region exemplo contexto banco de dados
        //private readonly ControleFinanceiroContext _contexto;

        //public EntradaInputValidator(ControleFinanceiroContext contexto)
        //{
        //    _contexto = contexto;
        //}
        #endregion

        public TipoEntradaInputValidator()
        {
            RuleFor(x => x.Nome)
                .NotNull().WithMessage("O Nome do Tipo de Entrada é obrigatório").WithSeverity(Severity.Warning)
                .MaximumLength(4);

        }
    }
}

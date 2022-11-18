using EntitiFreWork01.DTOs;
using FluentValidation;

namespace TRANSITO.Validations
{
    public class SancionesValidation : AbstractValidator<SancionesDTOs>
    {
        public SancionesValidation()
        {
            RuleFor(m => m.Fecha).Empty()
                .WithMessage("Numero de Matricula Esta Vacio");
            RuleFor(m => m.ConductorId).Empty()
                .WithMessage("Numero de Matricula Esta Vacio");
        }
    }
}

using EntitiFreWork01.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TRANSITO.Validations
{
    public class ConductorValidator : AbstractValidator<ConductorDTOs>
    {
       public ConductorValidator() 
        {
            RuleFor(n => n.Nombre)
                .Empty().WithMessage("El campo (Nombre) Esta Vacio");
            RuleFor(a => a.Apellidos)
                .Empty().WithMessage("El campo (Apellidos) Esta Vacio");

            RuleFor(x => x.Nombre).NotNull().DependentRules(() => {
                RuleFor(x => x.Nombre).MinimumLength(3);
            });
            RuleFor(t => t.Telefono).NotNull().DependentRules(() => {
                RuleFor(t => t.Telefono).MinimumLength(3);
            });
        }

    }
}

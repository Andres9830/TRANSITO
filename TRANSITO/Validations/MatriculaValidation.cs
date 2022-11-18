using EntitiFreWork01.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EntitiFreWork01.Validations
{
    public class MatriculaValidation : AbstractValidator<MatriculaDTOs>
    {
        public MatriculaValidation()
        {
            RuleFor(m => m.Numero).Empty()
                .WithMessage("Numero de Matricula Esta Vacio");
            RuleFor(m => m.Numero).Length(12)
                .WithMessage("Numero de Matricula debe contener 6 caracteres");
            

        }

        
    }
}

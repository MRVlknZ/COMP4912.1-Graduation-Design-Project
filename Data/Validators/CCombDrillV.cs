using Data.Models;
using FluentValidation;
using System;

namespace Data.Validators
{
    public class CCombDrillV : AbstractValidator<CCombDrill>
    {
        public CCombDrillV()
        {
            RuleFor(x => x.CommandCount)
                .GreaterThan(0)
                .LessThanOrEqualTo(20)
                .WithMessage("Command count must be between 1 and 20.");

            RuleFor(x => x.CommandList)
                .NotEmpty()
                .WithMessage("Command list cannot be empty.");


            RuleFor(x => x.CommandsPerCombination)
                .GreaterThan(0)
                .WithMessage("Commands per combination must be greater than 0.");



            RuleFor(x => x.TransitionSec)
                .GreaterThanOrEqualTo(0)
                .WithMessage("Transition time must be 0 or greater.");

            RuleFor(x => x.TotalDurationSec)
                .GreaterThan(0)
                .WithMessage("Total duration must be greater than 0 seconds.");

        }
    }
}

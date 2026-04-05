using Data.Models;
using FluentValidation;
using System;

namespace Data.Validators
{
    public class CTextDrillV : AbstractValidator<CTextDrill>
    {
        public CTextDrillV()
        {
            RuleFor(x => x.ExNames)
                .NotEmpty()
                .WithMessage("Exercise names cannot be empty.");

            RuleFor(x => x.ExDurationsSec)
                .NotEmpty()
                .WithMessage("Exercise durations cannot be empty.");


            RuleFor(x => x)
                .Must(x =>
                {
                    var names = x.ExNames.Split(',', StringSplitOptions.RemoveEmptyEntries);
                    var durations = x.ExDurationsSec.Split(',', StringSplitOptions.RemoveEmptyEntries);

                    return names.Length == durations.Length && names.Length > 0;
                })
                .WithMessage("The number of exercises must match the number of durations.");

            RuleFor(x => x)
                .Must(x =>
                {
                    var names = x.ExNames.Split(',', StringSplitOptions.RemoveEmptyEntries);
                    return names.Length <= 20;
                })
                .WithMessage("You can define at most 20 exercises.");

           
            RuleFor(x => x.RepeatCount)
                .GreaterThan(0)
                .WithMessage("Repeat count must be at least 1.");

            When(x => x.HasBreakBtwExs, () =>
            {
                RuleFor(x => x.BreakBtwExsSec)
                    .GreaterThan(0)
                    .WithMessage("Break time between exercises must be greater than 0 seconds.");
            });

         

            RuleFor(x => x.TotalDurationSec)
                .GreaterThan(0)
                .WithMessage("Total duration must be greater than 0 seconds.");
        }
    }
}

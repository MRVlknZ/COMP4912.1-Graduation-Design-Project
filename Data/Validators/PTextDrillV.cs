using Data.Models;
using FluentValidation;
using System;
using System.Linq;

namespace Data.Validators
{
    public class PTextDrillV : AbstractValidator<PTextDrill>
    {
        public PTextDrillV()
        {
            RuleFor(x => x.ExNames)
                .NotEmpty()
                .WithMessage("Exercise names must not be empty.");

            RuleFor(x => x.ExDurationsSec)
                .NotEmpty()
                .WithMessage("Exercise durations must not be empty.");

            RuleFor(x => x)
                .Must(x =>
                {
                    var names = x.ExNames.Split(',', StringSplitOptions.RemoveEmptyEntries);
                    var durations = x.ExDurationsSec.Split(',', StringSplitOptions.RemoveEmptyEntries);
                    return names.Length == durations.Length;
                })
                .WithMessage("The number of exercise names and durations must match.");

            RuleFor(x => x.TotalDurationSec)
                .GreaterThan(0)
                .WithMessage("Total duration must be greater than 0 seconds.");

            When(x => x.HasBreakBtwExs, () =>
            {
                RuleFor(x => x.BreakBtwExsSec)
                    .GreaterThan(0)
                    .WithMessage("Break time between exercises must be greater than 0 seconds.");
            });

          


        }
    }
}

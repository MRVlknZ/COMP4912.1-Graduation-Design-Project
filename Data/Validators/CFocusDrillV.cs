using Data.Models;
using FluentValidation;
using System;

namespace Data.Validators
{
    public class CFocusDrillV : AbstractValidator<CFocusDrill>
    {
        public CFocusDrillV()
        {

            RuleFor(x => x.TargetColors)
                .NotEmpty()
                .WithMessage("At least one target color must be selected.");

            RuleFor(x => x)
                .Must(x =>
                {
                    var targets = x.TargetColors
                        .Split(',', StringSplitOptions.RemoveEmptyEntries);

                    return targets.Length > 0 && targets.Length <= 20;
                })
                .WithMessage("You can define between 1 and 20 target colors.");


            RuleFor(x => x.ActionsForTargetColors)
                .NotEmpty()
                .WithMessage("Actions for target colors must be defined.");

            RuleFor(x => x.SwitchIntervalSec)
                .GreaterThan(0)
                .WithMessage("Switch interval must be greater than 0 seconds.");

            RuleFor(x => x.TotalDurationSec)
                .GreaterThan(0)
                .WithMessage("Total duration must be greater than 0 seconds.");

            RuleFor(x => x.DifficultyLevel)
                .NotEmpty()
                .Must(d => d == "Easy" || d == "Medium" || d == "Hard")
                .WithMessage("Difficulty level must be one of: Easy, Medium, or Hard.");

        }
    }
}

using Data.Models;
using FluentValidation;
using System;

namespace Data.Validators
{
    public class CColorDrillV : AbstractValidator<CColorDrill>
    {
        public CColorDrillV()
        {
            RuleFor(x => x.UserId)
            .GreaterThan(0)
            .WithMessage("User is required.");

            RuleFor(x => x.Name)
                .NotEmpty()
                .MaximumLength(200);

            RuleFor(x => x.TotalDurationSec)
                .GreaterThan(0)
                .WithMessage("Total duration must be greater than 0 seconds.");

            RuleFor(x => x.SwitchIntervalSec)
                .GreaterThan(0)
                .WithMessage("Switch interval must be greater than 0 seconds.");

            RuleFor(x => x.SwitchIntervalSec)
                .LessThan(x => x.TotalDurationSec)
                .WithMessage("Switch interval must be less than total duration.");

            RuleFor(x => x.SwitchIntervalSec)
                .LessThanOrEqualTo(x =>
                    x.ColorCount <= 0
                        ? x.TotalDurationSec
                        : x.TotalDurationSec / (double)x.ColorCount)
                .WithMessage("Switch interval cannot exceed TotalDurationSec / ColorCount.");

            RuleFor(x => x.ColorCount)
                .GreaterThan(0)
                .LessThanOrEqualTo(20)
                .WithMessage("At least one and max 20 colors must be selected.");

            RuleFor(x => x.DifficultyLevel)
                .NotEmpty()
                .Must(d => d == "Easy" || d == "Medium" || d == "Hard")
                .WithMessage("Difficulty level must be one of: Easy, Medium, or Hard.");

            RuleFor(x => x)
                .Must(x =>
                {
                    if (string.IsNullOrWhiteSpace(x.SelectedColorIds))
                        return false;

                    var ids = x.SelectedColorIds
                        .Split(',', StringSplitOptions.RemoveEmptyEntries);

                    return ids.Length == x.ColorCount;
                })
                .WithMessage("The number of selected colors must match the ColorCount value.");
        }
    }
}

using Data.Models;
using FluentValidation;
using System;

namespace Data.Validators
{
    public class PFocusDrillV : AbstractValidator<PFocusDrill>
    {
        public PFocusDrillV()
        {
            RuleFor(x => x.TargetColorCount)
                .InclusiveBetween(1, 7)
                .WithMessage("Target color count must be between 1 and 7.");

            RuleFor(x => x.TargetColors)
                .NotEmpty()
                .WithMessage("At least one target color must be selected.");

            RuleFor(x => x)
                .Must(x =>
                {
                    var colors = x.TargetColors.Split(',', StringSplitOptions.RemoveEmptyEntries);
                    return colors.Length == x.TargetColorCount;
                })
                .WithMessage("The number of selected colors must match TargetColorCount.");

            RuleFor(x => x.ActionsForTargetColors)
                .NotEmpty()
                .WithMessage("Each target color must have an assigned action.")
                .Must(s =>
                {
                    var pairs = s.Split(';', StringSplitOptions.RemoveEmptyEntries);
                    return pairs.All(p => p.Contains(':') && p.Split(':').Length == 2);
                })
                .WithMessage("ActionsForTargetColors must be formatted as 'Color:Action', separated by ';'.");

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

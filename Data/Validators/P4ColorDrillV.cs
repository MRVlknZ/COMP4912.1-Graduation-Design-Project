using Data.Models;
using FluentValidation;
using System;

namespace Data.Validators
{
    public class P4ColorDrillV : AbstractValidator<P4ColorDrill>
    {
        public P4ColorDrillV()
        {
            RuleFor(x => x.TotalDurationSec)
                .GreaterThan(0).WithMessage("Total duration must be greater than 0 seconds.");

            RuleFor(x => x.SwitchIntervalSec)
     .GreaterThan(0)
     .WithMessage("Switch interval must be greater than 0 seconds.");

            RuleFor(x => x.SwitchIntervalSec)
                .LessThan(x => x.TotalDurationSec)
                .WithMessage("Switch interval must be less than total duration.");

            RuleFor(x => x.SwitchIntervalSec)
                .LessThanOrEqualTo(x => x.TotalDurationSec / 4.0)
                .WithMessage("Switch interval cannot exceed one-fourth of total duration.");

            RuleFor(x => x.DifficultyLevel)
                .NotEmpty()
                .Must(d => d == "Easy" || d == "Medium" || d == "Hard")
                .WithMessage("Difficulty level must be one of: Easy, Medium, or Hard.");


            When(x => !string.IsNullOrWhiteSpace(x.ActionsPerColor), () =>
            {
                RuleFor(x => x.ActionsPerColor)
                    .Must(s =>
                    {
                        var pairs = s.Split(';', StringSplitOptions.RemoveEmptyEntries);
                        if (pairs.Length != 4) return false;

                        foreach (var p in pairs)
                        {
                            if (!p.Contains(':')) return false;

                            var parts = p.Split(':', StringSplitOptions.RemoveEmptyEntries);
                            if (parts.Length != 2) return false;

                            if (string.IsNullOrWhiteSpace(parts[0]) ||
                                string.IsNullOrWhiteSpace(parts[1]))
                                return false;
                        }
                        return true;
                    })
                    .WithMessage("ActionsPerColor must define exactly 4 'Color:Action' mappings separated by ';'.");
            });
        }
    }
}

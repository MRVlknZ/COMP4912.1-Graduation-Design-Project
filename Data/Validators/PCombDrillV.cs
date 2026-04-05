using Data.Models;
using FluentValidation;
using System;

namespace Data.Validators
{
    public class PCombDrillV : AbstractValidator<PCombDrill>
    {
        public PCombDrillV()
        {
            RuleFor(x => x.CommandCount)
                .GreaterThan(0)
                .LessThanOrEqualTo(7)
                .WithMessage("Command count must be between 1 and 7.");

            RuleFor(x => x.CommandList)
                .NotEmpty()
                .WithMessage("Command list cannot be empty.");

            RuleFor(x => x)
                .Must(x =>
                {
                    var commands = x.CommandList
                        .Split(',', StringSplitOptions.RemoveEmptyEntries);
                    return commands.Length == x.CommandCount;
                })
                .WithMessage("The number of commands must match the CommandCount value.");

            RuleFor(x => x.CommandsPerCombination)
                .GreaterThan(0)
                .WithMessage("Commands per combination must be greater than 0.");

            RuleFor(x => x.CombinationDisplaySec)
                .GreaterThan(0)
                .WithMessage("Combination display time must be greater than 0 seconds.");

            RuleFor(x => x.TransitionSec)
                .GreaterThanOrEqualTo(0)
                .WithMessage("Transition time must be zero or greater.");

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

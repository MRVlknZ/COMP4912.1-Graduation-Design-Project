using Data.Models;
using FluentValidation;
using System;

namespace Data.Validators
{
    public class CSoundDrillV : AbstractValidator<CSoundDrill>
    {
        public CSoundDrillV()
        {
            RuleFor(x => x.VoiceCommandCount)
                .GreaterThan(0)
                .LessThanOrEqualTo(20)
                .WithMessage("Voice command count must be between 1 and 20.");

            RuleFor(x => x.VoiceCommandList)
                .NotEmpty()
                .WithMessage("Voice command list cannot be empty.");

            RuleFor(x => x.CommandIntervalSec)
                .GreaterThan(0)
                .WithMessage("Command interval must be greater than 0 seconds.");

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

using Data.Models;
using FluentValidation;
using System.Text.RegularExpressions;

namespace Data.Validators
{
    public class UserV : AbstractValidator<User>
    {
        public UserV()
        {
            // FirstName
            RuleFor(x => x.FirstName)
                .NotEmpty().WithMessage("First name is required.")
                .MinimumLength(2).WithMessage("First name must be at least 2 characters.")
                .MaximumLength(20).WithMessage("First name cannot exceed 20 characters.")
                .Must(n => n?.Trim() == n).WithMessage("First name should not start or end with spaces.")
                .Matches("^[a-zA-ZçğıöşüÇĞİÖŞÜ]+$")
                    .WithMessage("First name can contain only letters.");

            // LastName
            RuleFor(x => x.LastName)
                .NotEmpty().WithMessage("Last name is required.")
                .MinimumLength(2).WithMessage("Last name must be at least 2 characters.")
                .MaximumLength(20).WithMessage("Last name cannot exceed 20 characters.")
                .Must(n => n?.Trim() == n).WithMessage("Last name should not start or end with spaces.")
                .Matches("^[a-zA-ZçğıöşüÇĞİÖŞÜ]+$")
                    .WithMessage("Last name can contain only letters.");

            // Email
            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email is required.")
                .EmailAddress().WithMessage("Email format is not valid.")
                .MaximumLength(200).WithMessage("Email cannot exceed 200 characters.")
                .Must(e => e?.Trim() == e).WithMessage("Email should not start or end with spaces.");

            // Password
            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Password is required.")
                .MinimumLength(6).WithMessage("Password must be at least 6 characters.")
                .MaximumLength(50).WithMessage("Password cannot exceed 50 characters.")
                .Must(HasStrongPassword)
                .WithMessage("Password must contain at least 1 uppercase, 1 lowercase letter and 1 digit.");
        }

        private bool HasStrongPassword(string? password)
        {
            if (string.IsNullOrWhiteSpace(password))
                return false;

            var hasUpper = password.Any(char.IsUpper);
            var hasLower = password.Any(char.IsLower);
            var hasDigit = password.Any(char.IsDigit);

            return hasUpper && hasLower && hasDigit;
        }
    }
}

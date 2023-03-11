using Entity.Concrete;
using FluentValidation;
using System.Text.RegularExpressions;

namespace Business.ValidationRules.FluentValidation
{
    public class TodoValidator : AbstractValidator<Todo>
    {
        public TodoValidator()
        {
            RuleFor(t => t.TodoName).MinimumLength(2).MaximumLength(50).WithMessage("Name should be between 2-50 characters");
            RuleFor(t => t.TodoName).NotEmpty().WithMessage("Name cannot be empty");
            RuleFor(t => t.TodoName).Must(IsStartWithAlphabethChar).WithMessage("First character of name must start with alphabeth");
        }

        private bool IsStartWithAlphabethChar(string arg)
        {
            Regex regex = new Regex("/^[A-Za-z]+$/"); // to be tested
            return regex.IsMatch(arg);
                   
        }
    }
}

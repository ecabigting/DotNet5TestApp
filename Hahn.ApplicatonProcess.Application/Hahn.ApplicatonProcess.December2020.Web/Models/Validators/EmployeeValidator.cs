using FluentValidation;
using Hahn.ApplicatonProcess.December2020.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hahn.ApplicatonProcess.December2020.Web.Models.Validators
{
    public class EmployeeValidator : AbstractValidator<Employee>
    {
        public EmployeeValidator() 
        {
            RuleFor(e => e.Name).NotNull().MaximumLength(5);
            RuleFor(e => e.FamilyName).NotNull().MaximumLength(5);
            RuleFor(e => e.Address).NotNull().MaximumLength(10);
            RuleFor(e => e.Address).NotNull();
            RuleFor(e => e.Email).NotNull().EmailAddress();
            RuleFor(e => e.Age).NotEmpty();
            RuleFor(e => e.Hired).NotNull();
        }
    }
}

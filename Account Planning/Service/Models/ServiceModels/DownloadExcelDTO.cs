using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Com.ACSCorp.AccountPlanning.Service.Models.ServiceModels
{
    public class DownloadExcelDTO
    {
        public int InnovaId { get; set; }
        public string UserName { get; set; }
        public string UserEmail { get; set; }
        public string Designation { get; set; }
        public string Role { get; set; }
        public string IsActive { get; set; }
    }

    public class UserDTOValidator : AbstractValidator<DownloadExcelDTO>
    {
        readonly Regex regOnlyLetters = new Regex("^[a-zA-Z ]+$");

        public UserDTOValidator()
        {
            RuleFor(x => x.InnovaId).Cascade(CascadeMode.Stop)
                .NotEqual(0).WithMessage("Innova Id cannot be empty or 0. ")
                .GreaterThanOrEqualTo(0).WithMessage("Innova Id is not valid. ");

            RuleFor(x => x.UserName).Cascade(CascadeMode.Stop)
                .NotNull().WithMessage("User Name cannot be empty. ")
                .Length(1, 200).WithMessage("User Name should not be more than 200 characters. ")
                .Matches(regOnlyLetters).WithMessage("User Name must contain only alphabets. ");

            RuleFor(x => x.UserEmail).Cascade(CascadeMode.Stop)
                .NotNull().WithMessage("User Email cannot be empty. ")
                .Must(x => x.EndsWith("@innovasolutions.com"))
                .WithMessage("User Email must end with '@innovasolutions.com'. ");

            When(x => x.Designation != null, () =>
            {
                RuleFor(x => x.Designation).Cascade(CascadeMode.Stop)
                .MaximumLength(200).WithMessage("Designation should not be more than 200 characters. ")
                .Matches(regOnlyLetters).WithMessage("Designation must contain only alphabets. ");

            });
            
            RuleFor(x => x.Role).Cascade(CascadeMode.Stop)
                .NotNull().WithMessage("Role cannot be empty. ")
                .Must(y => y.Equals("L1") || y.Equals("L2"))
                .WithMessage("Role should be either 'L1' for Delivery Manager or 'L2' for Leader. ");

            RuleFor(x => x.IsActive).Cascade(CascadeMode.Stop)
                .NotNull().WithMessage("IsActive cannot be empty. ")                
                .Must(y => y.Equals("Y") || y.Equals("N"))
                .WithMessage("IsActive should be either 'Y' for Active or 'N' for InActive. ");
        }
    }
}

using System;
using FluentValidation;
using FluentValidationExample.Models;

namespace FluentValidationExample.Validation
{
    public class ValidationUser : AbstractValidator<User>
    {
        public ValidationUser()
        {
            // 當規則遇到第一個錯誤就停止不繼續
            // 如果想要該欄位全部錯誤資訊請選擇CascadeMode.Continue
            CascadeMode = CascadeMode.StopOnFirstFailure;

            RuleFor(u => u.Name)
                .NotEmpty().WithMessage("{PropertyName} 必須輸入值");

            RuleFor(u => u.Email)
                .NotEmpty().WithMessage("{PropertyName} 必須輸入值")
                .EmailAddress().WithMessage("{PropertyName} 請填寫正確");

            // 如果邏輯太複雜可用Must拆出來，例如檢查身分證居留證等
            RuleFor(u => u.BirthdayTime)
                .Must(ValidateAge).WithMessage("{PropertyName} 必須滿足18");

            RuleFor(u => u.Password)
                .NotEmpty().WithMessage("{PropertyName} 必須輸入值")
                .Must(p => p?.Length >= 8).WithMessage("{PropertyName} 必須大於等於8");


            RuleFor(u => u.ConfirmPassword)
                .NotEmpty().WithMessage("{PropertyName} 必須輸入值")
                .Equal(x => x.Password).WithMessage("密碼輸入不一");

            RuleFor(u => u.Money)
                .GreaterThan(100).WithMessage("{PropertyName} 必須大於 100");

            // 當When條件成立才去檢查數值
            RuleFor(u => u.Age)
                .GreaterThan(100).WithMessage("當金額999 {PropertyName} 必須大於 100歲").When(u => u.Money == 999);
        }

        private bool ValidateAge(DateTime Age_)
        {
            DateTime Current = DateTime.Today;
            int age = Current.Year - Convert.ToDateTime(Age_).Year;

            return age >= 18;
        }
    }
}
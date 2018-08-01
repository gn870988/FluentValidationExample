using System;
using System.ComponentModel.DataAnnotations;

namespace FluentValidationExample.Models
{
    public class User
    {
        [Display(Name = "姓名")]
        public string Name { get; set; }

        [Display(Name = "信箱")]
        public string Email { get; set; }

        [Display(Name = "生日")]
        public DateTime BirthdayTime { get; set; }

        [Display(Name = "密碼")]
        public string Password { get; set; }

        [Display(Name = "確認密碼")]
        public string ConfirmPassword { get; set; }

        [Display(Name = "金額")]
        public int Money { get; set; }

        [Display(Name = "年齡")]
        public int Age { get; set; }
    }
}
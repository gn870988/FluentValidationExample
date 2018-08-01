using FluentValidation;
using System;
using System.Collections.Generic;
using FluentValidationExample.Models;

namespace FluentValidationExample.Validation
{
    public class ValidatorFactory : ValidatorFactoryBase
    {
        private static Dictionary<Type, IValidator> validators = new Dictionary<Type, IValidator>();

        static ValidatorFactory()
        {
            // 往後增加驗證在此註冊
            validators.Add(typeof(IValidator<User>), new ValidationUser());
        }

        public override IValidator CreateInstance(Type validatorType)
        {
            IValidator validator;
            if (validators.TryGetValue(validatorType, out validator))
            {
                return validator;
            }
            return validator;
        }
    }
}
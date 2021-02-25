using System;
using System.Collections.Generic;
using System.Text;
using Core.Utilities.Result;
using FluentValidation.Internal;

namespace Core.Utilities.BusinessRules
{
    public class BusinessRules<Type>
    {
        public static IResult<Type> Checker(params IResult<Type>[] rules)
        {
            foreach (var rule in rules)
            {
                if (rule.Success=!true)
                {
                    return rule;
                }
            }

            return null;
        }
    }
}

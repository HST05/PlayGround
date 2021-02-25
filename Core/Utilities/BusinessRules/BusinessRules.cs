using System;
using System.Collections.Generic;
using System.Text;
using Core.Utilities.Result;
using FluentValidation.Internal;

namespace Core.Utilities.BusinessRules
{
    public class BusinessRules<Type>
    {
        public static List<IResult<Type>> Checker(params IResult<Type>[] rules)
        {
            List<IResult<Type>> errors = new List<IResult<Type>>();
            foreach (var rule in rules)
            {
                if (rule.Success=!true)
                {
                    errors.Add(rule);
                }
            }

            if (errors.Count==0)
            {
                return null;
            }

            return errors;
        }
    }
}

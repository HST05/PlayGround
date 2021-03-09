using System;
using System.Collections.Generic;
using System.Text;
using Core.Utilities.Result;
using FluentValidation.Internal;

namespace Core.Utilities.BusinessRules
{
    public class BusinessRules<T>
    {
        public static List<IResult<T>> Checker(params IResult<T>[] rules)
        {
            List<IResult<T>> errors = new List<IResult<T>>();
            foreach (var rule in rules)
            {
                if (rule.Success!=true)
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

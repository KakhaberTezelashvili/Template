using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Collections.Generic;
using System.Linq;

namespace Template.API.Filters
{
    public class ModelStateFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                var allErrors = context.ModelState.Where(i => i.Value.Errors.Count() > 0)
                    .ToDictionary(i => i.Key, i => i.Value.Errors.Select(x => x.ErrorMessage))
                    .ToArray();

                var errorList = new List<ErrorModel>();

                foreach (var errorItem in allErrors)
                {
                    foreach (var error in errorItem.Value)
                        errorList.Add(new ErrorModel(errorItem.Key, error));
                }

                context.Result = new BadRequestObjectResult(new { ErrorList = errorList });
            }
        }

        public class ErrorModel
        {
            public ErrorModel(string fieldName, string errorDescription)
            {
                FieldName = fieldName;
                ErrorDescription = errorDescription;
            }

            public string FieldName { get; }
            public string ErrorDescription { get; }
        }
    }
}
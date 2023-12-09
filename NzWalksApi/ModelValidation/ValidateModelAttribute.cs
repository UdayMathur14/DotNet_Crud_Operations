using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace NzWalksApi.ModelValidation
{
    public class ValidateModelAttribute:ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext context)
        {
            //go to controller and and remove the model.isvalid and all the [ValidateModel]
            if(!context.ModelState.IsValid)
            {
                context.Result = new  BadRequestResult();

            }
        }
    }
}

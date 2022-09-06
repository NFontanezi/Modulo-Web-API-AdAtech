using Microsoft.AspNetCore.Mvc.Filters;

namespace APIPessoa.Filters
{
    public class LogResourceFilter : IResourceFilter
    {
        public void OnResourceExecuted(ResourceExecutedContext context)
        {   
        }

        public void OnResourceExecuting(ResourceExecutingContext context)
        {   
            //hash unico para trackear log e troubleshooting 
            if (!context.HttpContext.Request.Headers.Keys.Contains("Code"))
            {
                context.HttpContext.Request.Headers.Keys.Add(Guid.NewGuid().ToString());
            }
            
        }
    }
}

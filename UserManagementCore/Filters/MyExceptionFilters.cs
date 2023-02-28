using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserManagementCore.Filters
{
    public class MyExceptionFilters : ExceptionFilterAttribute
    {
        private readonly ILogger<MyExceptionFilters> logger;
        public MyExceptionFilters(ILogger<MyExceptionFilters> logger) 
        {
            this.logger = logger;
        }

        public override void OnException(ExceptionContext context)
        {
            logger.LogError(context.Exception,context.Exception.Message);
            base.OnException(context);
        }
    }
}

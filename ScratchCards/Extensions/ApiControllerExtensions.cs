using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScratchCards.Extensions
{
    public static class ApiControllerExtensions
    {
        public static IActionResult Json<T>(this ControllerBase controller, T model)
        {
            return new ObjectResult(model);
        }

        public static IActionResult BadRequest<T>(this ControllerBase controller)
        {
            BadRequestResult res = new BadRequestResult();

            return res;
        }
    }
}

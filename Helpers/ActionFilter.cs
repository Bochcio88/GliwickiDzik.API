using System;
using System.Reflection.Metadata;
using System.Security.Claims;
using System.Threading.Tasks;
using GliwickiDzik.API.Data;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.DependencyInjection;

namespace GliwickiDzik.API.Helpers
{
    public class ActionFilter : IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var resultContext = await next();

            var repository = resultContext.HttpContext.RequestServices.GetService<IUserRepository>();

            var userId = int.Parse(resultContext.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value);

            var user = await repository.GetUserByIdAsync(userId);

            user.LastActive = DateTime.Now;

            await repository.SaveAllAsync();
        }
    }
}
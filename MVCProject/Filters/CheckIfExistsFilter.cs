using InterviewMVCProject.Models;
using Microsoft.AspNetCore.Mvc.Filters;
using MVCProject.Exceptions;
using MVCProject.Interfaces;

namespace MVCProject.Filters
{
    public class CheckIfExistsFilter<TEntity> : IAsyncActionFilter
    {
        private readonly IServiceProvider _serviceProvider;

        public CheckIfExistsFilter(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {

            string idParameterName = GetIdParameterName<TEntity>();

            if (!context.ActionArguments.ContainsKey(idParameterName))
            {
                throw new ArgumentException($"The ID parameter '{idParameterName}' was not found in the action arguments.");
            }

            var id = (int)context.ActionArguments[idParameterName];

            var entityService = _serviceProvider.GetService(typeof(IEntityService<TEntity>)) as IEntityService<TEntity>;

            if (entityService == null)
            {
                throw new InvalidOperationException($"Service for {typeof(TEntity).Name} not found.");
            }

            var entity = await entityService.GetByIdAsync(id);

            if (entity == null)
            {
                throw new NotFoundException($"{typeof(TEntity).Name} with ID {id} not found.");
            }
            await next();
        }

        private string GetIdParameterName<TEntity>()
        {
            if (typeof(TEntity) == typeof(Player))
            {
                return "playerId";
            }
            if (typeof(TEntity) == typeof(Item))
            {
                return "itemId";
            }
            return "id";
        }
    }
}

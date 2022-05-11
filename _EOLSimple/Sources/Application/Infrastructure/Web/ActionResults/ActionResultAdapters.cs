using Microsoft.AspNetCore.Mvc;
using Mmu.CleanDddSimple.Infrastructure.CrossCutting.Errors;
using Mmu.CleanDddSimple.Infrastructure.CrossCutting.LanguageExtensions.Types.Eithers;
using Mmu.CleanDddSimple.Infrastructure.CrossCutting.LanguageExtensions.Types.Maybes;
using Mmu.CleanDddSimple.Infrastructure.CrossCutting.LanguageExtensions.Types.Maybes.Implementation;
using Mmu.CleanDddSimple.Infrastructure.Web.Dtos;

namespace Mmu.CleanDddSimple.Infrastructure.Web.ActionResults
{
    public static class ActionResultAdapters
    {
        public static IActionResult ToActionResult(this Maybe<ServerError> err)
        {
            if (err is None<ServerError>)
            {
                return new OkResult();
            }

            return CreateBadRequest(err.ReduceThrow());
        }

        public static IActionResult ToActionResult<T>(this Maybe<T> maybe)
        {
            return maybe
                .Map<T, IActionResult>(f => new OkObjectResult(f))
                .Reduce(() => new NoContentResult());
        }

        public static IActionResult ToActionResult<TRight>(this Either<ServerError, TRight> either)
        {
            return either
                .MapRight(obj => (IActionResult)new OkObjectResult(obj))
                .ReduceRight(CreateBadRequest);
        }

        private static BadRequestObjectResult CreateBadRequest(ServerError err)
        {
            return new BadRequestObjectResult(new ErrorDto
            {
                Message = err.ToDescription()
            });
        }
    }
}
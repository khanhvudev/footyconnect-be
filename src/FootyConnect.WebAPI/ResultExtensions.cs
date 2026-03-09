using FootyConnect.Application.Common.Results;
using Microsoft.AspNetCore.Mvc;

namespace FootyConnect.WebAPI;

public static class ResultExtensions
{
    public static ActionResult ToActionResult(this Result result)
    {
        if (!result.IsSuccess)
        {
            return MapErrorResponse(result.Error, result);  
        }

        return new OkObjectResult(result);
    }

    public static ActionResult ToActionResult<T>(this Result<T> result, bool created = false, string ? uri = null)
    {
        if (!result.IsSuccess)
        {
            return MapErrorResponse(result.Error, result);
        }

        if (created && uri != null)
        {
            return new CreatedResult(uri, result.Value);
        }

        return new OkObjectResult(result);
    }

    private static ActionResult MapErrorResponse(Error error, Result result)
    {
        return error.Code switch
        {
            ErrorTypeConstant.ValidationError => new BadRequestObjectResult(result),
            ErrorTypeConstant.NotFoundError => new NotFoundObjectResult(result),
            ErrorTypeConstant.InternalServerError => new ObjectResult(result) { StatusCode = 500 },
            ErrorTypeConstant.Forbidden => new ForbidResult(),
            ErrorTypeConstant.UnauthorizedError => new UnauthorizedResult(),
            _ => new ObjectResult(result) { StatusCode = 500 }
        };
    }
}

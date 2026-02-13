using Application.Common;
using Core;
using Microsoft.AspNetCore.Mvc;

namespace SPQatar2027.Common;

public static class ResultExtension
{
    public static IActionResult ToActionResult<T>(this Result<T> result)
    {
        if (result.IsSuccess)
        {
            return new OkObjectResult(result.Value);
        }

        if (result.Error == ApplicationErrors.NotFound)
        {
            return new NotFoundObjectResult(result.Error);
        }

        return new BadRequestObjectResult(result.Error);
    }

}

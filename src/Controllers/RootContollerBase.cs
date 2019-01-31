using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CqrsSample.Helper;
using Microsoft.AspNetCore.Mvc;
using CSharpFunctionalExtensions;


namespace CqrsSample.Controllers
{
    public class RootContollerBase : ControllerBase
    {
        protected new IActionResult Ok()
        {
            return base.Ok(Envelope.Ok());
        }

        protected IActionResult Ok<T>(T result)
        {
            return base.Ok(Envelope.Ok(result));
        }

        protected IActionResult Created<T>(string uri, T result)
        {
            return base.Created(uri, Envelope.Ok(result));
        }

        protected IActionResult Created<T>(Uri uri, T result)
        {
            return base.Created(uri, Envelope.Ok(result));
        }

        protected IActionResult Error(string errorMessage)
        {
            return BadRequest(Envelope.Error(errorMessage));
        }

        protected IActionResult FromResult(Result result)
        {
            return result.IsSuccess ? Ok() : Error(result.Error);
        }
    }
}

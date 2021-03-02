using Microsoft.AspNetCore.Mvc;
using System;
using JOSResult;

namespace JOS.Result.BlogExamples.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HamburgersController : ControllerBase
    {
        private readonly IGetHamburgerQuery _getHamburgerQuery;
        private readonly IGetHamburgerResultQuery _getHamburgerResultQuery;
        private readonly IGetHamburgerJosResultQuery _getHamburgerJosResultQuery;

        public HamburgersController(
            IGetHamburgerQuery getHamburgerQuery,
            IGetHamburgerResultQuery getHamburgerResultQuery,
            IGetHamburgerJosResultQuery getHamburgerJosResultQuery)
        {
            _getHamburgerQuery = getHamburgerQuery ?? throw new ArgumentNullException(nameof(getHamburgerQuery));
            _getHamburgerResultQuery = getHamburgerResultQuery ?? throw new ArgumentNullException(nameof(getHamburgerResultQuery));
            _getHamburgerJosResultQuery = getHamburgerJosResultQuery ?? throw new ArgumentNullException(nameof(getHamburgerJosResultQuery));
        }

        [HttpGet("{name}")]
        public ActionResult<Hamburger> Get(string name)
        {
            try
            {
                var hamburger = _getHamburgerQuery.Execute(name);
                return new OkObjectResult(hamburger);
            }
            catch (NotFoundException)
            {
                return new NotFoundResult();
            }
            catch
            {
                return new StatusCodeResult(500);
            }
        }

        [HttpGet("result/{name}")]
        public ActionResult<Hamburger> GetResult(string name)
        {
            var hamburgerResult = _getHamburgerResultQuery.Execute(name);
            if (hamburgerResult.Success)
            {
                return new OkObjectResult(hamburgerResult.Value);
            }

            if (hamburgerResult.Error.Equals($"Could not find any hamburger named '{name}'"))
            {
                return new NotFoundResult();
            }

            return new StatusCodeResult(500);
        }

        [HttpGet("jos-result/{name}")]
        public ActionResult<Hamburger> GetJosResult(string name)
        {
            var hamburgerResult = _getHamburgerJosResultQuery.Execute(name);
            return hamburgerResult switch
            {
                SuccessResult<Hamburger> successResult => new OkObjectResult(successResult.Data),
                NotFoundResult<Hamburger> notFoundResult => new NotFoundResult(),
                ErrorResult<Hamburger> errorResult => new StatusCodeResult(500),
                _ => new StatusCodeResult(500)
            };
        }
    }
}

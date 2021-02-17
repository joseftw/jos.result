using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace JOS.Result.BlogExamples.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HamburgersController : ControllerBase
    {
        private readonly IGetHamburgersQuery _getHamburgersQuery;
        private readonly IGetHamburgersResultQuery _getHamburgersResultQuery;
        private readonly IGetHamburgersJosResultQuery _getHamburgersJosResultQuery;

        public HamburgersController(
            IGetHamburgersQuery getHamburgersQuery,
            IGetHamburgersResultQuery getHamburgersResultQuery,
            IGetHamburgersJosResultQuery getHamburgersJosResultQuery)
        {
            _getHamburgersQuery = getHamburgersQuery ?? throw new ArgumentNullException(nameof(getHamburgersQuery));
            _getHamburgersResultQuery = getHamburgersResultQuery ?? throw new ArgumentNullException(nameof(getHamburgersResultQuery));
            _getHamburgersJosResultQuery = getHamburgersJosResultQuery ?? throw new ArgumentNullException(nameof(getHamburgersJosResultQuery));
        }

        [HttpGet]
        public ActionResult<IEnumerable<Hamburger>> Get()
        {
            try
            {
                var hamburgers = _getHamburgersQuery.Execute();
                return new OkObjectResult(hamburgers);
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

        [HttpGet("result")]
        public ActionResult<IEnumerable<Hamburger>> GetResult()
        {
            var hamburgersResult = _getHamburgersResultQuery.Execute();
            if (hamburgersResult.Success)
            {
                return new OkObjectResult(hamburgersResult.Value);
            }

            if (hamburgersResult.Error.Equals("Could not find any hamburgers"))
            {
                return new NotFoundResult();
            }

            return new StatusCodeResult(500);
        }

        [HttpGet("jos-result")]
        public ActionResult<IEnumerable<Hamburger>> GetJosResult()
        {
            var hamburgersResult = _getHamburgersJosResultQuery.Execute();
            return hamburgersResult switch
            {
                SuccessResult<IReadOnlyCollection<Hamburger>> successResult => new OkObjectResult(successResult.Data),
                NotFoundResult<IReadOnlyCollection<Hamburger>> notFoundResult => new NotFoundResult(),
                ErrorResult<IReadOnlyCollection<Hamburger>> errorResult => new StatusCodeResult(500),
                _ => new StatusCodeResult(500)
            };
        }
    }
}

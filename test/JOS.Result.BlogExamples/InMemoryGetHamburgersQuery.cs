using System.Collections.Generic;
using System.Linq;

namespace JOS.Result.BlogExamples
{
    public class InMemoryGetHamburgersQuery : IGetHamburgersQuery
    {
        private static readonly IReadOnlyCollection<Hamburger> Hamburgers = new List<Hamburger>
        {
            new Hamburger("Double Cheese"),
            new Hamburger("Big Mac"),
            new Hamburger("Hamburger")
        };

        public IReadOnlyCollection<Hamburger> Execute()
        {
            var allHamburgers = Hamburgers;

            if (allHamburgers == null || !allHamburgers.Any())
            {
                throw new NotFoundException();
            }

            return allHamburgers;
        }
    }

    public class InMemoryGetHamburgersResultQuery : IGetHamburgersResultQuery
    {
        private static readonly IReadOnlyCollection<Hamburger> Hamburgers = new List<Hamburger>
        {
            new Hamburger("Double Cheese"),
            new Hamburger("Big Mac"),
            new Hamburger("Hamburger")
        };

        public Vladimir.Result<IReadOnlyCollection<Hamburger>> Execute()
        {
            var allHamburgers = Hamburgers;

            if (allHamburgers == null || !allHamburgers.Any())
            {
                return Vladimir.Result.Fail<IReadOnlyCollection<Hamburger>>("Could not find any hamburgers");
            }

            return Vladimir.Result.Ok<IReadOnlyCollection<Hamburger>>(allHamburgers);
        }
    }

    public class InMemoryGetHamburgersJosResultQuery : IGetHamburgersJosResultQuery
    {
        private static readonly IReadOnlyCollection<Hamburger> Hamburgers = new List<Hamburger>
        {
            new Hamburger("Double Cheese"),
            new Hamburger("Big Mac"),
            new Hamburger("Hamburger")
        };

        public Result<IReadOnlyCollection<Hamburger>> Execute()
        {
            var allHamburgers = Hamburgers;

            if (allHamburgers == null || !allHamburgers.Any())
            {
                return new NotFoundResult<IReadOnlyCollection<Hamburger>>("Could not find any hamburgers");
            }

            return new SuccessResult<IReadOnlyCollection<Hamburger>>(allHamburgers);
        }
    }
}

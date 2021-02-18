using System;
using System.Collections.Generic;
using System.Linq;

namespace JOS.Result.BlogExamples
{
    public class InMemoryGetHamburgerQuery : IGetHamburgerQuery
    {
        private static readonly IReadOnlyCollection<Hamburger> Hamburgers = new List<Hamburger>
        {
            new Hamburger("Double Cheese"),
            new Hamburger("Big Mac"),
            new Hamburger("Hamburger")
        };

        public Hamburger Execute(string name)
        {
            var hamburger = Hamburgers.FirstOrDefault(x => x.Name.Equals(name, StringComparison.OrdinalIgnoreCase));

            if (hamburger == null)
            {
                throw new NotFoundException();
            }

            return hamburger;
        }
    }

    public class InMemoryGetHamburgerResultQuery : IGetHamburgerResultQuery
    {
        private static readonly IReadOnlyCollection<Hamburger> Hamburgers = new List<Hamburger>
        {
            new Hamburger("Double Cheese"),
            new Hamburger("Big Mac"),
            new Hamburger("Hamburger")
        };

        public Vladimir.Result<Hamburger> Execute(string name)
        {
            var hamburger = Hamburgers.FirstOrDefault(x => x.Name.Equals(name, StringComparison.OrdinalIgnoreCase));

            if (hamburger == null)
            {
                return Vladimir.Result.Fail<Hamburger>($"Could not find any hamburger named '{name}'");
            }

            return Vladimir.Result.Ok<Hamburger>(hamburger);
        }
    }

    public class InMemoryGetHamburgerJosResultQuery : IGetHamburgerJosResultQuery
    {
        private static readonly IReadOnlyCollection<Hamburger> Hamburgers = new List<Hamburger>
        {
            new Hamburger("Double Cheese"),
            new Hamburger("Big Mac"),
            new Hamburger("Hamburger")
        };

        public Result<Hamburger> Execute(string name)
        {
            var hamburger = Hamburgers.FirstOrDefault(x => x.Name.Equals(name, StringComparison.OrdinalIgnoreCase));

            if (hamburger == null)
            {
                return new NotFoundResult<Hamburger>("Could not find any hamburgers");
            }

            return new SuccessResult<Hamburger>(hamburger);
        }
    }
}

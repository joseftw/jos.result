using System.Collections.Generic;

namespace JOS.Result.BlogExamples
{
    public interface IGetHamburgersQuery
    {
        IReadOnlyCollection<Hamburger> Execute();
    }

    public interface IGetHamburgersResultQuery
    {
        Vladimir.Result<IReadOnlyCollection<Hamburger>> Execute();
    }

    public interface IGetHamburgersJosResultQuery
    {
        Result<IReadOnlyCollection<Hamburger>> Execute();
    }
}

namespace JOS.Result.BlogExamples
{
    public interface IGetHamburgerQuery
    {
        Hamburger Execute(string name);
    }

    public interface IGetHamburgerResultQuery
    {
        Vladimir.Result<Hamburger> Execute(string name);
    }

    public interface IGetHamburgerJosResultQuery
    {
        Result<Hamburger> Execute(string name);
    }
}

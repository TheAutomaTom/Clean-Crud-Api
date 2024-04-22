namespace ZZ.Core.Plumbing.Exceptions
{
  public class NotFoundException : Exception
  {
    public NotFoundException(string name, object obj)
        : base($"{name} ({obj}) is not found")
    {
    }
  }
}

namespace CCA.Core.Infra.Models.Search
{
  public class Paging
  {

    public Paging(int page, int countPer)
    {
      Page = page;
      CountPer = countPer;
    }

    public int Page { get; } = 1;
    public int CountPer { get; } = 100;
    public int Skip { get => (Page - 1) * CountPer;}
  }
}

namespace Minimal.Domain.Core.Pagination
{
    public class PaginatedList<T>
    {
        public IList<T> Itens { get; set; }
        public int Total { get; set; }
        public int? Page { get; set; }
        public int? Limit { get; set; }

        public PaginatedList()
        {
            Itens = new List<T>();
        }
    }
}

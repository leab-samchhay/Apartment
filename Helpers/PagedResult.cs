namespace APARTMENT_API.Helpers
{
    public class PagedResult<T>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int TotalRecords { get; set; }
        public int TotalPages { get; set; }
        public List<T> Data { get; set; } = [];

        //List<T> គឺជា Collection ដែលអាចផ្ទុកទិន្នន័យច្រើន។
        //T គឺជា Generic Type មានន័យថា អាចជាប្រភេទអ្វីក៏បាន។
    }
}

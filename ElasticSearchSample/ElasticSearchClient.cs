using Nest;
using System;

namespace ElasticSearchSample
{
    public class ElasticSearchContext
    {
        public static string Url { get; set; } = "http://localhost:9200";
        private ElasticClient Client { get; set; }
        public ElasticSearchContext()
        {
            Client = new ElasticClient(new Uri(Url));
        }
        public IndexResponse Insert<T>(T doc, string index) where T : class
        {
            return Client.Index(doc, f => f.Index(index));
        }
        public ISearchResponse<T> Search<T>(Func<SearchDescriptor<T>, ISearchRequest> selector = null) where T : class
        {
            return Client.Search(selector);
        }
    }
}

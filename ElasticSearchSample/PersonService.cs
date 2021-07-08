using Nest;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ElasticSearchSample
{
    class PersonService
    {
        private ElasticSearchContext Context;
        public PersonService(ElasticSearchContext context)
        {
            Context = context;
        }
        public List<Person> Search(Func<SearchDescriptor<Person>, ISearchRequest> selector = null)
        {
            if (selector == null)
                selector = s => s.Index("person_data");

            var searchDecriptor = new SearchDescriptor<Person>();
            searchDecriptor.Index("person_data");
            var request = selector(searchDecriptor);

            var result = Context.Search<Person>(s => request);
            return result.Documents.ToList();
        }
    }
}

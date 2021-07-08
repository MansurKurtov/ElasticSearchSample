namespace ElasticSearchSample
{
    class Program
    {
        static void Main(string[] args)
        {
            var context = new ElasticSearchContext();
            var person = new Person()
            {
                Id = 1,
                Name = "First person",
                Email = "Email1"
            };
            context.Insert(person, "person_data");

            var personInDoc = new PersonService(context).Search(s=>s.From(0).Size(10));

            /*
            var docs = _eventService.Search(s => s
            .From(filter.Size * (filter.Page - 1))
            .Size(filter.Size)
            .Query(q =>
                (
                    q.Term(t => t.Field(f => f.EventType).Value(filter.EventType)) &&
                    q.DateRange(d => d.Field(f => f.Date)
                        .GreaterThanOrEquals(filter.BeginDate.ToUtcKind())
                        .LessThanOrEquals(filter.EndDate.ToUtcKind()))
                )
                &&
                (
                    q.Terms(t => t.Field(f => f.InfokioskOwnerId).Terms(filter.Owners)) ||
                    q.Terms(t => t.Field(f => f.InfokioskGroupId).Terms(filter.Groups)) ||
                    q.Terms(t => t.Field(f => f.InfokioskId).Terms(filter.Kiosks))
                )
            ));
             */
        }
    }
}

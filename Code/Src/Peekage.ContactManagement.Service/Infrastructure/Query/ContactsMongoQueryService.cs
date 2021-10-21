using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using Peekage.ContactManagement.Service.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Peekage.ContactManagement.Service.Infrastructure.Query
{
    public interface IContactsQueryService
    {
        Task<IReadOnlyList<SearchContactQueryResponse>> Search(
            SearchContactQuery query);
    }

    public class ContactsMongoQueryService : IContactsQueryService
    {
        IMongoDatabase _mongodb;
        public ContactsMongoQueryService(IMongoDatabase mongodb)
        {
            _mongodb = mongodb;
        }

        public async Task<IReadOnlyList<SearchContactQueryResponse>> Search(
            SearchContactQuery query)
        {
            var filterBuilder = Builders<BsonDocument>.Filter;
            var filter = filterBuilder.Eq($"{nameof(Contact.Deleted)}", false);

            foreach (var prop in query.GetType().GetProperties())
            {
                var value = query.GetType().GetProperty(prop.Name).GetValue(query, null);

                if (value != null)
                {
                    filter = filter & filterBuilder.Eq(prop.Name, value);
                }
            }

            var bsonDocs = await GetCollection().Find(filter).ToListAsync();
            var contacts = new List<SearchContactQueryResponse>();
            bsonDocs.ForEach(a =>
            {
                var contact = BsonSerializer.Deserialize<SearchContactQueryResponse>(a);
                contacts.Add(contact);
            });
            return contacts;
        }

        IMongoCollection<BsonDocument> GetCollection()
        {
            return _mongodb.GetCollection<BsonDocument>(typeof(Contact).Name);
        }
    }
}

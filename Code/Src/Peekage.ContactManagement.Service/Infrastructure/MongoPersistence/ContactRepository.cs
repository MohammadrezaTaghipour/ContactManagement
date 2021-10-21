using MongoDB.Driver;
using Peekage.ContactManagement.Service.Domain.Models;
using Peekage.ContactManagement.Service.Domain.Models.Contacts;
using System;
using System.Threading.Tasks;

namespace Peekage.ContactManagement.Service.Infrastructure.MongoPersistence
{
    public class ContactRepository : IContactRepository
    {
        readonly IMongoDatabase _mongodb;
        public ContactRepository(IMongoDatabase mongodb)
        {
            _mongodb = mongodb;
        }

        public async Task Add(Contact contact)
        {
            var option = new InsertOneOptions { BypassDocumentValidation = true };
            await GetCollection().InsertOneAsync(contact, option);
        }

        public async Task<Contact> GetById(Guid id)
        {
            var filter = new FilterDefinitionBuilder<Contact>().Eq(f => f.Id, id);
            return await GetCollection().Find(filter).FirstOrDefaultAsync();
        }

        IMongoCollection<Contact> GetCollection()
        {
            return _mongodb.GetCollection<Contact>(typeof(Contact).Name);
        }
    }
}

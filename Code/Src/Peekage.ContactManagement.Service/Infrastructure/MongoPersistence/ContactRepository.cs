using MongoDB.Driver;
using Peekage.ContactManagement.Service.Domain.Models;
using Peekage.ContactManagement.Service.Domain.Models.Contacts;
using System;
using System.Threading.Tasks;

namespace Peekage.ContactManagement.Service.Infrastructure.MongoPersistence
{
    public class ContactRepository : IContactRepository
    {
        IMongoDatabase _mongodb;
        public ContactRepository(IMongoDatabase mongodb)
        {
            _mongodb = mongodb;
        }

        public async Task Add(Contact contact)
        {
            try
            {
                var option = new InsertOneOptions { BypassDocumentValidation = true };
                await GetCollection().InsertOneAsync(contact, option);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw ex;
            }
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

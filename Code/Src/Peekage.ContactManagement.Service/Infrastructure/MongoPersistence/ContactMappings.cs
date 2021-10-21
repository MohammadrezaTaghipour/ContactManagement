using MongoDB.Bson.Serialization;
using Peekage.ContactManagement.Service.Domain.Models;

namespace Peekage.ContactManagement.Service.Infrastructure.MongoPersistence
{
    public class ContactMappings
    {
        public void Register()
        {
            BsonClassMap.RegisterClassMap<Contact>(cm =>
            {
                cm.AutoMap();
                cm.MapIdMember(c => c.Id);
                //cm.MapField("_githubRepositories")
                //.SetElementName("GithubRepositories");
            });

            if (!BsonClassMap.IsClassMapRegistered(typeof(GithubRepository)))
            {
                BsonClassMap.RegisterClassMap<GithubRepository>(cm =>
                {
                    cm.AutoMap();
                });
            }
        }
    }
}

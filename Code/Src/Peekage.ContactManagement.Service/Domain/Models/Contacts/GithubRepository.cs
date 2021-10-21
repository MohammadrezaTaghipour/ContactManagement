namespace Peekage.ContactManagement.Service.Domain.Models
{
    public class GithubRepository
    {
        public GithubRepository(string name)
        {
            Name = name;
        }
        public string Name { get; }
    }
}

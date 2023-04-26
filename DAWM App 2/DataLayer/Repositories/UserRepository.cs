using DataLayer.Entities;
using DataLayer.Enums;
using Microsoft.EntityFrameworkCore;

namespace DataLayer.Repositories
{
    public class UserRepository : RepositoryBase<User>
    {
        private readonly AppDbContext dbContext;

        public UserRepository(AppDbContext dbContext) : base(dbContext)
        {
            this.dbContext = dbContext;
        }

        public User GetUserByCredentials(string username, string password)
        {
            var rezult = dbContext.Users
                .FirstOrDefault(e => e.Username == username && e.Password == password , null);

            return rezult;
        }
    }
}

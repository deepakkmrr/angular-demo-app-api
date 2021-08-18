using Demo.Database.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Demo.Database.Repositories
{
    public interface IUserRepository
    {
        Task<User> GetActiveUserByEmail(string emailId);
    }

    public class UserRepository : IUserRepository
    {
        private readonly Demo_Context DemoContext;
        public UserRepository(Demo_Context demoContext)
        {
            this.DemoContext = demoContext;
        }
        public async Task<User> GetActiveUserByEmail(string emailId)
        {
            try
            {
                var dbUser = await this.DemoContext.Users.Where(c => c.Email == emailId).SingleOrDefaultAsync();
                return dbUser;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}

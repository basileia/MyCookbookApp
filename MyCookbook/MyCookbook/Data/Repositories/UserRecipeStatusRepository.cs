using MyCookbook.Data.Contracts.Repositories;
using MyCookbook.Data.Models;

namespace MyCookbook.Data.Repositories
{
    public class UserRecipeStatusRepository : BaseRepository<UserRecipeStatus>, IUserRecipeStatusRepository
    {
        public UserRecipeStatusRepository(ApplicationDbContext context) : base(context)
        {
        }


    }
}

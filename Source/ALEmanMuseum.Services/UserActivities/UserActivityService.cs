using System.Threading.Tasks;
using ALEmanMuseum.Core.Domain;
using ALEmanMuseum.Services.ServicesResponse;

namespace ALEmanMuseum.Services.UserActivities
{
    public class UserActivityService : IUserActivityService
    {
        public Task<ServiceResponse<UserActivityErrors>> DeleteEntityAsync(int entityId)
        {
            throw new System.NotImplementedException();
        }

        public Task<EntitiesResponse<UserActivity, UserActivityErrors>> FindEntitiesAsync(string searchTerm = null, int pageNumber = 0, int pageSize = 10)
        {
            throw new System.NotImplementedException();
        }

        public Task<EntitiesResponse<UserActivity, UserActivityErrors>> GetAllEntitiesAsync()
        {
            throw new System.NotImplementedException();
        }

        public Task<int> GetEntitiesCountAsync()
        {
            throw new System.NotImplementedException();
        }

        public Task<EntityResponse<UserActivity, UserActivityErrors>> GetEntityByIdAsync(int entityId)
        {
            throw new System.NotImplementedException();
        }

        public Task<EntityResponse<UserActivity, UserActivityErrors>> InsertEntityAsync(UserActivity entity)
        {
            throw new System.NotImplementedException();
        }

        public Task<EntityResponse<UserActivity, UserActivityErrors>> UpdateEntityAsync(UserActivity entity)
        {
            throw new System.NotImplementedException();
        }
    }
}

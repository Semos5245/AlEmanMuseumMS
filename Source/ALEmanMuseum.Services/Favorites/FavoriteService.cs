using ALEmanMuseum.Core.Domain;
using ALEmanMuseum.Services.ServicesResponse;
using System;
using System.Threading.Tasks;

namespace ALEmanMuseum.Services.Favorites
{
    public class FavoriteService : IFavoriteService
    {
        public Task<ServiceResponse<FavoriteErrors>> DeleteEntityAsync(int entityId)
        {
            throw new NotImplementedException();
        }

        public Task<EntitiesResponse<Favorite, FavoriteErrors>> FindEntitiesAsync(string searchTerm = null, int pageNumber = 0, int pageSize = 10)
        {
            throw new NotImplementedException();
        }

        public Task<EntitiesResponse<Favorite, FavoriteErrors>> GetAllEntitiesAsync()
        {
            throw new NotImplementedException();
        }

        public Task<int> GetEntitiesCountAsync()
        {
            throw new NotImplementedException();
        }

        public Task<EntityResponse<Favorite, FavoriteErrors>> GetEntityByIdAsync(int entityId)
        {
            throw new NotImplementedException();
        }

        public Task<EntityResponse<Favorite, FavoriteErrors>> InsertEntityAsync(Favorite entity)
        {
            throw new NotImplementedException();
        }

        public Task<EntityResponse<Favorite, FavoriteErrors>> UpdateEntityAsync(Favorite entity)
        {
            throw new NotImplementedException();
        }
    }
}

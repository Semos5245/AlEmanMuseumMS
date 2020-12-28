using System.Threading.Tasks;
using ALEmanMuseum.Core.Domain;
using ALEmanMuseum.Services.ServicesResponse;

namespace ALEmanMuseum.Services.RentNotes
{
    public class RentNoteService : IRentNoteService
    {
        public Task<ServiceResponse<RentNoteErrors>> DeleteEntityAsync(int entityId)
        {
            throw new System.NotImplementedException();
        }

        public Task<EntitiesResponse<RentNote, RentNoteErrors>> FindEntitiesAsync(string searchTerm = null, int pageNumber = 0, int pageSize = 10)
        {
            throw new System.NotImplementedException();
        }

        public Task<EntitiesResponse<RentNote, RentNoteErrors>> GetAllEntitiesAsync()
        {
            throw new System.NotImplementedException();
        }

        public Task<int> GetEntitiesCountAsync()
        {
            throw new System.NotImplementedException();
        }

        public Task<EntityResponse<RentNote, RentNoteErrors>> GetEntityByIdAsync(int entityId)
        {
            throw new System.NotImplementedException();
        }

        public Task<EntityResponse<RentNote, RentNoteErrors>> InsertEntityAsync(RentNote entity)
        {
            throw new System.NotImplementedException();
        }

        public Task<EntityResponse<RentNote, RentNoteErrors>> UpdateEntityAsync(RentNote entity)
        {
            throw new System.NotImplementedException();
        }
    }
}

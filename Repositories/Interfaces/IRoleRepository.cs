using APARTMENT_API.Model;

namespace APARTMENT_API.Repositories.Interfaces
{
    public interface IRoleRepository
    {
        Task<List<ApplicationRole>> GetAllAsync();
        Task<ApplicationRole?> GetByIdAsync(int id);
        Task<ApplicationRole?> GetByNameAsync(string name);
        Task<bool> ExistsByNameAsync(string name);
        Task<bool> ExistsByNameAsync(string name, int excludeId);
        Task AddAsync(ApplicationRole role);

        void Update(ApplicationRole role);
        void Delete(ApplicationRole role);
        Task<bool> HasUsersAsync(int rolseId);
        Task<int> SaveChangesAsync();

    }
}

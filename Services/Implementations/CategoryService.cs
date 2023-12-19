using ApiAB202.Dtos;
using ApiAB202.Repositories.Interfaces;
using ApiAB202.Services.Interfaces;

namespace ApiAB202.Services.Implementations
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _repository;


        public CategoryService(ICategoryRepository repository)
        {
            _repository = repository;

        }

        public async Task<GetCategoryDo> GetAsync(int Id)
        {
            Category category = await _repository.GetByIdAsync(Id);

            if (category == null) throw new Exception(" NOT FOUND");

            return new GetCategoryDo
            {
                id = category.Id,
                Name = category.Name,
            };
        }

     

        public async Task Create(CreateCategoryDto dto)
        {

            await _repository.AddAsync(new Category
            {
                Name = dto.Name
            });

            await _repository.SaveChangesAsync();
        }

        public async Task UpdateAsync(int id, string name)
        {

            Category exist = await _repository.GetByIdAsync(id);

            if (exist == null) throw new Exception("NOT FOUND");

            exist.Name = name;

            _repository.Update(exist);

            await _repository.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {

            Category exist = await _repository.GetByIdAsync(id);

            if (exist == null) throw new Exception("NOT FOUND");

            _repository.Delete(exist);

            await _repository.SaveChangesAsync();
        }

        public async Task<ICollection<GetCategoryDo>> GetAllAsync(int page, int take)
        {
            ICollection<Category> categories = await _repository.GetAllAsync(page: (page - 1) * take, take: take).ToListAsync();

            ICollection<GetCategoryDo> dtos = new List<GetCategoryDo>();

            foreach (var category in categories)
            {
                dtos.Add(new GetCategoryDo
                {
                    id = category.Id,
                    Name = category.Name
                });
            }

            return dtos;
        }
    }
}

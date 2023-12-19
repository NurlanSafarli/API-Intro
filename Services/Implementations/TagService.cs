using ApiAB202.Dtos;
using ApiAB202.Repositories.Implementations;
using ApiAB202.Repositories.Interfaces;
using ApiAB202.Services.Interfaces;

namespace ApiAB202.Services.Implementations
{
    public class TagService : ITagService
    {
        private readonly ITagRepository _repository;

        public TagService(ITagRepository repostory)
        {
            _repository = repostory;
        }

        public async Task Create(CreateTagDto dto)
        {
            await _repository.AddAsync(new Tag
            {
                TagName = dto.Name

            });
            await _repository.SaveChangesAsync();

        }

        public async Task DeleteAsync(int id)
        {
            Tag exist = await _repository.GetByIdAsync(id);
            if (exist != null) throw new Exception("NOT FOUND");
            _repository.Delete(exist);
            await _repository.SaveChangesAsync();
        }

        public async Task<ICollection<GetTagDto>> GetAllAsync(int page, int take)
        {
            ICollection<Tag> tags = await _repository.GetAllAsync(skip: (page - 1) * take, take: take).ToListAsync();
            ICollection<GetTagDto> dtos = new List<GetTagDto>();
            foreach (var tag in tags)
            {
                dtos.Add(new GetTagDto
                {
                   id = tag.Id,
                    Name = tag.TagName
                });
            }
            return dtos;
        }

        public async Task<GetTagDto> GetAsync(int Id)
        {
            Tag tag = await _repository.GetByIdAsync(Id);
            if (tag == null) throw new Exception("NOT FOUND");
            return new GetTagDto
            {
                id = tag.Id,
                Name = tag.TagName
            };
        }

        public async Task UpdateAsync(int id, string name)
        {
            Tag exist = await _repository.GetByIdAsync(id);
            if (exist == null) throw new Exception("NOT FOUND");
            exist.TagName = name;
            _repository.Update(exist);
            await _repository.SaveChangesAsync();

        }
    }
}
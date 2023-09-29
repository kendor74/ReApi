namespace ReApi.Models.FoodCatigory
{
    public class CatigoryHandler : IRepo<Catigory , CatigoryDto>
    {
        private readonly ReDbContext _db;

        public CatigoryHandler(ReDbContext dbContext)
        {
            _db = dbContext;
        }


        public async Task<Catigory> Add(CatigoryDto catigoryDto)
        {
            Catigory catigory = new Catigory
            {
                Name = catigoryDto.Name,
            };
            await _db.Catigorys.AddAsync(catigory);
            await _db.SaveChangesAsync();
            return catigory;
        }

        public async Task<bool> Delete(int id)
        {
            var catigory = await FindById(id);

            if (!await IsExist(id))
                return false;

            _db.Catigorys.Remove(catigory);
            await _db.SaveChangesAsync();
            return true;

        }

        public async Task<IEnumerable<Catigory>> GetAll()
        {
            return await _db.Catigorys.ToListAsync();
        }

        public async Task<Catigory> GetById(int id)
        {
            return await FindById(id);
        }

        public async Task<Catigory> Update(CatigoryDto catigoryDto , int id)
        {
            var catigory = await _db.Catigorys.FindAsync(id);
            
            catigory.Name = catigoryDto.Name;

            _db.Catigorys.Update(catigory);
            await _db.SaveChangesAsync();
            return catigory;
        }






        public async Task<int> Count()
        {
            return await _db.Catigorys.CountAsync();
        }
        public async Task<bool> IsExist(int id)
        {
            return await _db.Catigorys.AnyAsync(i => id == i.Id);
        }
        public async Task<Catigory> FindById(int id)
        {
            return await _db.Catigorys.FindAsync(id);
        }

    }
}

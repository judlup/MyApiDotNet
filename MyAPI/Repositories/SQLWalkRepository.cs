using Microsoft.EntityFrameworkCore;
using MyAPI.Data;
using MyAPI.Models.Domain;

namespace MyAPI.Repositories {
  public class SQLWalkRepository : IWalkRepository {
    private readonly MyAPIDBContext _dbcContext;

    public SQLWalkRepository(MyAPIDBContext dbcContext) {
      this._dbcContext = dbcContext;
    }

    public async Task<Walk> CreateAsync(Walk walk) {
      await _dbcContext.Walks.AddAsync(walk);
      await _dbcContext.SaveChangesAsync();
      return walk;
    }


    public async Task<List<Walk>> GetAllAsync() {
      return await _dbcContext.Walks.Include("Difficulty").Include("Region").ToListAsync();
    }

    public async Task<Walk?> GetByIdAsync(Guid id) {
      return await _dbcContext.Walks
          .Include("Difficulty")
          .Include("Region")
          .FirstOrDefaultAsync(w => w.Id == id);
    }

    public async Task<Walk?> UpdateAsync(Guid id, Walk walk) {
      var existingWalk = await _dbcContext.Walks.FirstOrDefaultAsync(w => w.Id == id);
      if (existingWalk == null) {
        return null;
      }

      existingWalk.Name = walk.Name;
      existingWalk.Description = walk.Description;
      existingWalk.LengthKm = walk.LengthKm;
      existingWalk.WalkImageUrl = walk.WalkImageUrl;
      existingWalk.DifficultyId = walk.DifficultyId;
      existingWalk.RegionId = walk.RegionId;

      await _dbcContext.SaveChangesAsync();
      return existingWalk;
    }
  }
}

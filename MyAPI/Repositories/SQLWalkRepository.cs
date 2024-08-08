using Microsoft.EntityFrameworkCore;
using MyAPI.Data;
using MyAPI.Models.Domain;

namespace MyAPI.Repositories
{
  public class SQLWalkRepository : IWalkRepository
  {
    private readonly MyAPIDBContext _dbcContext;

    public SQLWalkRepository(MyAPIDBContext dbcContext)
    {
      this._dbcContext = dbcContext;
    }

    public async Task<Walk> CreateAsync(Walk walk)
    {
      await _dbcContext.Walks.AddAsync(walk);
      await _dbcContext.SaveChangesAsync();
      return walk;
    }

    public async Task<Walk?> DeleteAsync(Guid id)
    {
      var existingWalk = await _dbcContext.Walks.FirstOrDefaultAsync(w => w.Id == id);
      if (existingWalk == null)
      {
        return null;
      }
      _dbcContext.Remove(existingWalk);
      await _dbcContext.SaveChangesAsync();
      return existingWalk;
    }

    public async Task<List<Walk>> GetAllAsync(string? filterOn = null, string? filterQuery = null, string? sortBy = null, bool? isAcending = true, int pageNumber = 1, int pageSize = 1000)
    {
      var walks = _dbcContext.Walks.Include("Difficulty").Include("Region").AsQueryable();

      // Filtering
      if (string.IsNullOrWhiteSpace(filterOn) == false && string.IsNullOrWhiteSpace(filterQuery) == false)
      {
        if (filterOn.Equals("Name", StringComparison.OrdinalIgnoreCase))
        {
          walks = walks.Where(w => w.Name.Contains(filterQuery));
        }
      }

      // Sorting
      if (string.IsNullOrWhiteSpace(sortBy) == false)
      {
        if (sortBy.Equals("Name", StringComparison.OrdinalIgnoreCase))
        {
          walks = isAcending == true ? walks.OrderBy(w => w.Name) : walks.OrderByDescending(w => w.Name);
        }
        else if (sortBy.Equals("Length", StringComparison.OrdinalIgnoreCase))
        {
          walks = isAcending == true ? walks.OrderBy(w => w.LengthKm) : walks.OrderByDescending(w => w.LengthKm);
        }
      }

      // Pagination
      var skipResults = (pageNumber - 1) * pageSize;

      return await walks.Skip(skipResults).Take(pageSize).ToListAsync();
    }

    public async Task<Walk?> GetByIdAsync(Guid id)
    {
      return await _dbcContext.Walks
          .Include("Difficulty")
          .Include("Region")
          .FirstOrDefaultAsync(w => w.Id == id);
    }

    public async Task<Walk?> UpdateAsync(Guid id, Walk walk)
    {
      var existingWalk = await _dbcContext.Walks.FirstOrDefaultAsync(w => w.Id == id);
      if (existingWalk == null)
      {
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

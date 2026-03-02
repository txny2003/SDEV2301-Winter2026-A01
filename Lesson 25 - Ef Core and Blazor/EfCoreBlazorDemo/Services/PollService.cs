using EfCoreBlazorDemo.Data;
using EfCoreBlazorDemo.Models;
using Microsoft.EntityFrameworkCore;

namespace EfCoreBlazorDemo.Services
{
    public class PollService
    {
        private readonly IDbContextFactory<AppDbContext> _dbContextFactory;
        public PollService(IDbContextFactory<AppDbContext> dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }
        public async Task<List<Poll>> ListPollsAsync()
        {
            using var context = _dbContextFactory.CreateDbContext();

            return await context.Polls.ToListAsync();
        }

        public async Task<Poll> AddPollAsync(Poll p)
        {
            ArgumentNullException.ThrowIfNull(p);

            using var context = _dbContextFactory.CreateDbContext();
            context.Polls.Add(p);
            await context.SaveChangesAsync();

            return p;
        }
        public async Task<List<(string? Candidate, int Votes)>> GetVoteCounts()
        {
            using var context = _dbContextFactory.CreateDbContext();
            var result = await context.Polls.GroupBy(p => p.Candidate)
                                  .Select(group => new
                                  { 
                                      Candidate = group.Key,
                                      Votes = group.Count()
                                  })
                                  .OrderByDescending(v => v.Votes)
                                  .ThenBy(v => v.Candidate)
                                  .ToListAsync();

            return result.Select(p => (p.Candidate, p.Votes)).ToList();
        }
    }
}

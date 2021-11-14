using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Server.Database;
using Server.Dto;
using Server.Exceptions;
using Server.Model;

namespace Server.Services
{
    public interface ITrackService
    {
        Task<IList<TrackDto>> GetTracks(string partName = null);
        Task CreateTrack(TrackDto trackInfo);
        Task DeleteTrack(string trackInfo);
    }
    
    public class TrackService : ITrackService
    {
        private readonly ApplicationDbContext _dbContext;

        public TrackService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IList<TrackDto>> GetTracks(string partName = null)
        {
            var tracks = await TrackInfoQuery().ToListAsync();
            
            return partName == null ? tracks : tracks.Where(x => x.ToString().Contains(partName)).ToList();
        }

        public async Task CreateTrack(TrackDto trackInfo)
        {
            await _dbContext.Tracks.AddAsync(new TrackRecord
            {
                Author = trackInfo.Author,
                Composition = trackInfo.Composition
            });
            
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteTrack(string trackInfo)
        {
            var tracks = _dbContext.Tracks.ToList();
            var trackToDelete = tracks.FirstOrDefault(x => x.ToString() == trackInfo);

            if (trackToDelete == null)
                throw new TrackNotFoundException("Track to delete not found!");

            _dbContext.Tracks.Remove(trackToDelete);
            await _dbContext.SaveChangesAsync();
        }

        private IQueryable<TrackDto> TrackInfoQuery() =>
            _dbContext.Tracks.Select(x => new TrackDto(x.Author, x.Composition));
    }
}
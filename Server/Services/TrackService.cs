using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dto;
using Microsoft.EntityFrameworkCore;
using Server.Database;
using Server.Exceptions;
using Server.Model;

namespace Server.Services
{
	public interface ITrackService
	{
		Task<IList<TrackDto>> GetTracks(string partName, string userName);
		Task CreateTrack(TrackDto trackInfo, string userName);
		Task DeleteTrack(string trackInfo, string userName);
	}

	public class TrackService : ITrackService
	{
		private readonly ApplicationDbContext _dbContext;

		public TrackService(ApplicationDbContext dbContext)
		{
			_dbContext = dbContext;
		}

		public async Task<IList<TrackDto>> GetTracks(string partName, string userName)
		{
			var tracks = TrackInfoQuery().ToListAsync().Result.Where(t => t.CreatedBy.Equals(userName)).ToList();

			return partName == null
				? tracks
				: tracks.Where(x => x.ToString().Contains(partName))
					.ToList();
		}

		public async Task CreateTrack(TrackDto trackInfo, string userName)
		{
			await _dbContext.Tracks.AddAsync(new TrackRecord
			{
				Author = trackInfo.Author,
				Composition = trackInfo.Composition,
				CreatedBy = _dbContext.Users.First(u => u.Name.Equals(userName))
			});
			await _dbContext.SaveChangesAsync();
		}

		public async Task DeleteTrack(string trackInfo, string userName)
		{
			var trackToDelete = _dbContext.Tracks
				.Where(x => x.CreatedBy.Name.Equals(userName))
				.ToList()
				.FirstOrDefault(x => x.ToString().Equals(trackInfo));
			if (trackToDelete == null)
				throw new TrackNotFoundException("Track to delete not found!");

			_dbContext.Tracks.Remove(trackToDelete);
			await _dbContext.SaveChangesAsync();
		}

		private IQueryable<TrackDto> TrackInfoQuery() =>
			_dbContext.Tracks.Select(x => new TrackDto
			{
				Author = x.Author,
				Composition = x.Composition,
				CreatedBy = x.CreatedBy.Name
			});
	}
}

using System;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Dto;
using Microsoft.AspNetCore.Mvc;
using Server.Services;

namespace Server.Controllers
{
	[Route("api/v1/tracks")]
	public class TrackController : BaseAuthenticatedController
	{
		private readonly ITrackService _trackService;

		public TrackController(ITrackService trackService)
		{
			_trackService = trackService;
		}

		[Route("all"), HttpGet]
		public async Task<IActionResult> List()
		{
			if (!CheckCredentials())
			{
				return Unauthorized("Please, login first");
			}

			return Ok(await _trackService.GetTracks(null, User.Identity.Name));
		}

		[HttpPost]
		public async Task<IActionResult> Add([FromBody] TrackDto track)
		{
			if (!CheckCredentials())
			{
				return Unauthorized("Please, login first");
			}

			if (track == null)
				return BadRequest("Bad track info");

			try
			{
				await _trackService.CreateTrack(track, User.Identity.Name);
			}
			catch (Exception e)
			{
				return BadRequest(e.Message);
			}

			return Ok();
		}

		[HttpDelete]
		public async Task<IActionResult> Delete([FromQuery(Name = "fullName")] string fullName)
		{
			if (!CheckCredentials())
			{
				return Unauthorized("Please, login first");
			}

			if (fullName == null)
				return BadRequest("No search parameter to delete track");

			try
			{
				await _trackService.DeleteTrack(fullName, User.Identity.Name);
			}
			catch (Exception e)
			{
				return BadRequest(e.Message);
			}

			return Ok();
		}

		[HttpGet]
		public async Task<IActionResult> Search([FromQuery(Name = "partName"), Required] string trackInfo)
		{
			if (!CheckCredentials())
			{
				return Unauthorized("Please, login first");
			}

			if (trackInfo == null)
				return BadRequest("Bad track info");
			var tracks = await _trackService.GetTracks(trackInfo, User.Identity.Name);

			return tracks.Count == 0 ? BadRequest("No one item was found by this criteria.") : Ok(tracks);
		}
	}
}

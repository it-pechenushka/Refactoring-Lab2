using System;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Server.Dto;
using Server.Services;

namespace Server.Controllers
{
    [Route("api/v1/tracks")]
    public class TrackController : Controller
    {
        private readonly ITrackService _trackService;

        public TrackController(ITrackService trackService)
        {
            _trackService = trackService;
        }
        
        [Route("all"), HttpGet]
        public async Task<IActionResult> List() => Ok(await _trackService.GetTracks());
        
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] TrackDto track)
        {
            if (track == null)
                return BadRequest("Bad track info");

            try
            {
                await _trackService.CreateTrack(track);
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
            if (fullName == null)
                return BadRequest("No search parameter to delete track");

            try
            {
                await _trackService.DeleteTrack(fullName);
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
            if (trackInfo == null)
                return BadRequest("Bad track info");

            var tracks =  await _trackService.GetTracks(trackInfo);

            return tracks.Count == 0 ? BadRequest("No one item was found by this criteria.") : Ok(tracks);
        }
    }
}
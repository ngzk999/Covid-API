using Covid.Dtos;
using Covid.Entities;
using Covid.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Covid.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    
    public class DataController : ControllerBase
    {
        private readonly RetrieveService _retrieveService;

        public DataController()
        {
            _retrieveService = new RetrieveService();
        }

        [HttpGet("state")]
        public ActionResult<State> GetStateData(StateDto stateDto)
        {
            State stateData = _retrieveService.GetCovidDataByStateAndDate(stateDto);
            return stateData;
        }

        [HttpGet("malaysia")]
        public ActionResult<Malaysia> GetMalaysiaData(MalaysiaDto malaysiaDto)
        {
            Malaysia malaysiaData = _retrieveService.GetMalaysiaCovidDataByDate(malaysiaDto);
            return malaysiaData;
        }

        [HttpGet("stateLatestCases")]
        public ActionResult<List<State>> GetLatestStateCases()
        {
            List<State> latestStateData = _retrieveService.GetLatestStateCovidData();
            return latestStateData;
        }

        [HttpGet("malaysiaLatestCases")]
        public ActionResult<Malaysia> GetLatestMalaysiaCases()
        {
            Malaysia latestMalaysiaData = _retrieveService.GetLatestMalaysiaCasesData();
            return latestMalaysiaData;
        }

        [HttpGet("malaysiaLatestDeath")]
        public ActionResult<Death> GetLatestMalaysiaDeathData()
        {
            Death latestMalaysiaDeathData = _retrieveService.GetLatestMalaysiaDeath();
            return latestMalaysiaDeathData;
        }

        [HttpGet("stateLatestDeath")]
        public ActionResult<List<Death>> GetLatestStateDeathData()
        {
            List<Death> latestStateDeathData = _retrieveService.GetLatestStateDeath();
            return latestStateDeathData;
        }

        [HttpGet("stateLatestData")]
        public ActionResult<List<ReturnDto>> GetLatestStateData()
        {
            List<ReturnDto> latestStateData = _retrieveService.GetLatestStateData();
            return latestStateData;
        }

        [HttpGet("malaysiaLatestData")]
        public ActionResult<ReturnDto> GetLatestMalaysiaData()
        {
            ReturnDto latestMalaysiaData = _retrieveService.GetLatestMalaysiaData();
            return latestMalaysiaData;
        }

    }
}

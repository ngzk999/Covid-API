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


    }
}

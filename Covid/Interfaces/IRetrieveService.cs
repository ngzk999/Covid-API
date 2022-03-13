using Covid.Dtos;
using Covid.Entities;

namespace Covid.Interfaces
{
    public interface IRetrieveService
    {
        public State GetCovidDataByStateAndDate(StateDto stateDto);
        public Malaysia GetMalaysiaCovidDataByDate(MalaysiaDto malaysiaDto);
        public List<State> GetLatestStateCovidData();
        public Malaysia GetLatestMalaysiaCasesData();
        public Death GetLatestMalaysiaDeath();
        public List<Death> GetLatestStateDeath();
        public ReturnDto GetLatestMalaysiaData();
        public List<ReturnDto> GetLatestStateData();

    }
}

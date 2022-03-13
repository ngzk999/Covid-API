using Covid.Dtos;
using Covid.Entities;

namespace Covid.Interfaces
{
    public interface IRetrieveService
    {
        public State GetCovidDataByStateAndDate(StateDto stateDto);
        public Malaysia GetMalaysiaCovidDataByDate(MalaysiaDto malaysiaDto);
        public List<State> GetLatestStateCovidData();
        public Malaysia GetLatestMalaysiaCovidData();
        public Death GetLatestMalaysiaDeath();
        public List<Death> GetLatestStateDeath();

    }
}

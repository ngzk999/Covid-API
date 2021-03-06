using Covid.Dtos;
using Covid.Entities;
using Covid.Interfaces;
using HtmlAgilityPack;
using System.Globalization;

namespace Covid.Services
{
    public class RetrieveService : IRetrieveService
    {
        private readonly string stateUrl = "https://github.com/MoH-Malaysia/covid19-public/blob/main/epidemic/cases_state.csv";
        private readonly string malaysiaUrl = "https://github.com/MoH-Malaysia/covid19-public/blob/main/epidemic/cases_malaysia.csv";
        private readonly string stateDeathUrl = "https://github.com/MoH-Malaysia/covid19-public/blob/main/epidemic/deaths_state.csv";
        private readonly string malaysiaDeathUrl = "https://github.com/MoH-Malaysia/covid19-public/blob/main/epidemic/deaths_malaysia.csv";
        private List<State> stateList = new();
        private List<Malaysia> myList = new();

        private List<Death> stateDeathList = new();
        private List<Death> myDeathList = new();

        private Malaysia currentMy = new Malaysia();
        private Death currentMyDeath = new Death();
        //private List<State> currentState = new List<State>;
        //private List<Death> currentStateDeath = new List<Death>;
        public RetrieveService()
        {
            HtmlWeb webSite = new();

            HtmlDocument stateDocument = webSite.Load(this.stateUrl);
            var stateDocumentList = stateDocument.DocumentNode.SelectNodes("//td[@class='blob-code blob-code-inner js-file-line']").ToList();
            for (int i = 1; i < stateDocumentList.Count; i++)
            {
                string[] stateDataTextArray = stateDocumentList[i].InnerText.Split(",");

                State state = new State()
                {
                    Date = stateDataTextArray[0],
                    StateName = stateDataTextArray[1],
                    NewCases = stateDataTextArray[2],
                    ImportedCases = stateDataTextArray[3],
                    RecoveredCases = stateDataTextArray[4],
                    ActiveCases = stateDataTextArray[5],
                    ClusterCases = stateDataTextArray[6],
                    UnvaxCases = stateDataTextArray[7],
                    PartialVaxCases = stateDataTextArray[8],
                    FullyVaxCases = stateDataTextArray[9],
                    BoostedVaxCases = stateDataTextArray[10],
                    ChildCases = stateDataTextArray[11],
                    AdolescentCases = stateDataTextArray[12],
                    AdultCases = stateDataTextArray[13],
                    ElderlyCases = stateDataTextArray[14],
                    Cases_0_4 = stateDataTextArray[15],
                    Cases_5_11 = stateDataTextArray[16],
                    Cases_12_17 = stateDataTextArray[17],
                    Cases_18_29 = stateDataTextArray[18],
                    Cases_30_39 = stateDataTextArray[19],
                    Cases_40_49 = stateDataTextArray[20],
                    Cases_50_59 = stateDataTextArray[21],
                    Cases_60_69 = stateDataTextArray[22],
                    Cases_70_79 = stateDataTextArray[23],
                    Cases_80 = stateDataTextArray[24]
                };

                this.stateList.Add(state);
            }

            HtmlDocument myDocument = webSite.Load(this.malaysiaUrl);
            var myDocumentList = myDocument.DocumentNode.SelectNodes("//tr[@class='js-file-line']").ToList();
            for (int i = 1; i < myDocumentList.Count; i++)
            {
                string[] myDataTextArray = myDocumentList[i].InnerText.Split("\n");
                Malaysia malaysia = new Malaysia()
                {
                    Date = myDataTextArray[2].Trim(),
                    NewCases = myDataTextArray[3].Trim(),
                    ImportedCases = myDataTextArray[4].Trim(),
                    RecoveredCases = myDataTextArray[5].Trim(),
                    ActiveCases = myDataTextArray[6].Trim(),
                    ClusterCases = myDataTextArray[7].Trim(),
                    UnvaxCases = myDataTextArray[8].Trim(),
                    PartialVaxCases = myDataTextArray[9].Trim(),
                    FullyVaxCases = myDataTextArray[10].Trim(),
                    BoostedVaxCases = myDataTextArray[11].Trim(),
                    ChildCases = myDataTextArray[12].Trim(),
                    AdolescentCases = myDataTextArray[13].Trim(),
                    AdultCases = myDataTextArray[14].Trim(),
                    ElderlyCases = myDataTextArray[15].Trim(),
                    Cases_0_4 = myDataTextArray[16].Trim(),
                    Cases_5_11 = myDataTextArray[17].Trim(),
                    Cases_12_17 = myDataTextArray[18].Trim(),
                    Cases_18_29 = myDataTextArray[19].Trim(),
                    Cases_30_39 = myDataTextArray[20].Trim(),
                    Cases_40_49 = myDataTextArray[21].Trim(),
                    Cases_50_59 = myDataTextArray[22].Trim(),
                    Cases_60_69 = myDataTextArray[23].Trim(),
                    Cases_70_79 = myDataTextArray[24].Trim(),
                    Cases_80 = myDataTextArray[25].Trim(),
                    ImportCluster = myDataTextArray[26].Trim(),
                    ReligiousCluster = myDataTextArray[27].Trim(),
                    CommunityCluster = myDataTextArray[28].Trim(),
                    HighRiskCluster = myDataTextArray[29].Trim(),
                    EducationCluster = myDataTextArray[30].Trim(),
                    DetentionCentreCluster = myDataTextArray[31].Trim(),
                    WorkplaceCluster = myDataTextArray[32].Trim()
                };

                this.myList.Add(malaysia);
            }

            HtmlDocument stateDeathDocument = webSite.Load(this.stateDeathUrl);
            var stateDeathDocumentList = stateDeathDocument.DocumentNode.SelectNodes("//tr[@class='js-file-line']").ToList();
            for (int i = 1; i < stateDeathDocumentList.Count; i++)
            {
                string[] stateDeathDataTextArray = stateDeathDocumentList[i].InnerText.Split("\n");
                Death stateDeath = new Death()
                {
                    Date = stateDeathDataTextArray[2].Trim(),
                    StateName = stateDeathDataTextArray[3].Trim(),
                    NewDeath = stateDeathDataTextArray[4].Trim(),
                    BidDeath = stateDeathDataTextArray[5].Trim(),
                    DodDeath = stateDeathDataTextArray[6].Trim(),
                    BidDodDeath = stateDeathDataTextArray[7].Trim(),
                    UnvaxDeath = stateDeathDataTextArray[8].Trim(),
                    PartialVaxDeath = stateDeathDataTextArray[9].Trim(),
                    FullyVaxDeath = stateDeathDataTextArray[10].Trim(),
                    BoostedVaxDeath = stateDeathDataTextArray[11].Trim(),
                    TatDeath = stateDeathDataTextArray[12].Trim()
                };

                this.stateDeathList.Add(stateDeath);
            }

            HtmlDocument myDeathDocument = webSite.Load(this.malaysiaDeathUrl);
            var myDeathDocumentList = myDeathDocument.DocumentNode.SelectNodes("//tr[@class='js-file-line']").ToList();
            for (int i = 1; i < myDeathDocumentList.Count; i++)
            {
                string[] myDeathDataTextArray = myDeathDocumentList[i].InnerText.Split("\n");
                Death myDeath = new Death()
                {
                    Date = myDeathDataTextArray[2].Trim(),
                    StateName = "",
                    NewDeath = myDeathDataTextArray[3].Trim(),
                    BidDeath = myDeathDataTextArray[4].Trim(),
                    DodDeath = myDeathDataTextArray[5].Trim(),
                    BidDodDeath = myDeathDataTextArray[6].Trim(),
                    UnvaxDeath = myDeathDataTextArray[7].Trim(),
                    PartialVaxDeath = myDeathDataTextArray[8].Trim(),
                    FullyVaxDeath = myDeathDataTextArray[9].Trim(),
                    BoostedVaxDeath = myDeathDataTextArray[10].Trim(),
                    TatDeath = myDeathDataTextArray[11].Trim()
                };

                this.myDeathList.Add(myDeath);
            }

            currentMy = myList[myList.Count - 1];
            currentMyDeath = myDeathList[myDeathList.Count - 1];
        }

        public State GetCovidDataByStateAndDate(StateDto stateDto)
        {
            State result = stateList.FirstOrDefault(x => x.StateName == stateDto.StateName && x.Date == stateDto.Date);
            return (result ?? null) ;
        }

        public Malaysia GetMalaysiaCovidDataByDate(MalaysiaDto malaysiaDto)
        {
            Malaysia result = myList.FirstOrDefault(x => x.Date == malaysiaDto.Date);
            return (result ?? null);
        }

        public List<State> GetLatestStateCovidData()
        {
            List<State> stateData = new List<State>();
            for (int i = stateList.Count-16; i < stateList.Count; i++)
            {
                stateData.Add(stateList[i]);
            }
            return stateData;
        }

        public Malaysia GetLatestMalaysiaCasesData()
        {
            Malaysia result = myList[myList.Count - 1];
            return result;
        }

        public Death GetLatestMalaysiaDeath()
        {
            Death result = myDeathList[myDeathList.Count - 1];
            return result;
        }

        public List<Death> GetLatestStateDeath()
        {
            List<Death> stateDeathData = new List<Death>();
            for (int i = stateDeathList.Count - 16; i < stateDeathList.Count; i++)
            {
                stateDeathData.Add(stateDeathList[i]);
            }
            return stateDeathData;
        }

        public ReturnDto GetLatestMalaysiaData()
        {
            ReturnDto result = new ReturnDto()
            {
                Date = currentMy.Date,
                StateName = "",
                NewCases = currentMy.NewCases,
                RecoveredCases = currentMy.RecoveredCases,
                DeathCases = currentMyDeath.NewDeath
            };

            return result;
        }

        public List<ReturnDto> GetLatestStateData()
        {
            List<ReturnDto> results = new List<ReturnDto>();

            for (int i = stateList.Count - 16; i < stateList.Count; i++)
            {
                ReturnDto result = new ReturnDto()
                {
                    Date = stateList[i].Date,
                    StateName = stateList[i].StateName,
                    NewCases = stateList[i].NewCases,
                    RecoveredCases = stateList[i].RecoveredCases,
                    DeathCases = stateDeathList
                                    .FirstOrDefault(x => x.Date == stateList[i].Date && x.StateName == stateList[i].StateName).NewDeath
                };

                results.Add(result);
            }

            return results;
        }
    }
}

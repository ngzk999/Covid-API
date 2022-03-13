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
        private List<State> stateList = new();
        private List<Malaysia> myList = new();
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

        public Malaysia GetLatestMalaysiaCovidData()
        {
            Malaysia result = myList[myList.Count - 1];
            return result;
        }
    }
}

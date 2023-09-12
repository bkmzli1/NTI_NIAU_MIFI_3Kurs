using System.Collections;

namespace Lab3;

 class ResearchTeamCollection:IEnumerable
    {
        private List<ResearchTeam> SomeResearchTeams = new List<ResearchTeam>();

        public void AddDefaults() {
            for (int i=0;i<3;i++) {
                SomeResearchTeams.Add(new ResearchTeam());
            }
        }
        public void AddResearchTeams(params ResearchTeam[] AdditionalTeams) {
            SomeResearchTeams.AddRange(AdditionalTeams);
        }
        public override string ToString()
        {
            string ResTeamString = "";
            foreach (ResearchTeam team in SomeResearchTeams) {
                ResTeamString += team.ToString();
            }
            return ResTeamString;
        }

        public string ToShortString()
        {
            string ResTeamString = "";
            foreach (ResearchTeam team in SomeResearchTeams)
            {
                ResTeamString += team.ToShortString();
            }
            return ResTeamString;
        }
        public void ToSortByRegistrNumber()
        {
            SomeResearchTeams.Sort((x,y)=>x.RegistrationNumber.CompareTo(y.RegistrationNumber));
        }
        public void SortByString() {
            SomeResearchTeams.Sort();
        }

        public void SortByPublications() {
            Res_Team_Comparer comp = new Res_Team_Comparer();
            SomeResearchTeams.Sort(comp);             
        }
        public int MinRegNumber {
            get {
                if (SomeResearchTeams.Count==0) {
                    return 0;
                }
               return SomeResearchTeams.Min(teams => teams.RegistrationNumber);
            }
        }

        public IEnumerable<ResearchTeam> TwoYearsLong {
            get {
                IEnumerable<ResearchTeam> TwoTearsL = SomeResearchTeams.Where(time=>time.ResDuration==TimeFrame.TwoYears);
                return TwoTearsL;
            }
        }

        public IEnumerator  GetEnumerator () {
            for (int i=0;i<SomeResearchTeams.Count;i++) {
                yield return SomeResearchTeams[i];
            }
        }
        public List<ResearchTeam> NGroup(int value) {
            IEnumerable<IGrouping<int, ResearchTeam>> someGroup = SomeResearchTeams.GroupBy(team=>team.ListOfParticipants.Count);

            foreach (IGrouping<int, ResearchTeam> teams in someGroup) {
                if (teams.Key == value)
                {
                    return teams.ToList<ResearchTeam>();
                }
                else {
                    throw new ArgumentNullException("There are no such number!");
                }
            }
            return null;
        }

       

       
    }
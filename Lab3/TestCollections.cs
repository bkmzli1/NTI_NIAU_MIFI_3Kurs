namespace Lab3;
using System.Collections.Generic;


    class TestCollections
    {
        private List<Team> ListOfTeam = new List<Team>();
        private List<string> ListOfString = new List<string>();
        private Dictionary<Team, ResearchTeam> Team_Rea_Dict = new Dictionary<Team, ResearchTeam>();
        private Dictionary<string, ResearchTeam> String_Rea_Dict = new Dictionary<string, ResearchTeam>();

        public List<Team> ListTeam { get { return ListOfTeam; } set { ListOfTeam = value; } }
        private List<string> ListString { get { return ListOfString; } set { ListOfString = value; } }
        private Dictionary<Team, ResearchTeam> Team_Re_Dict { get { return Team_Rea_Dict; } set { Team_Rea_Dict = value; } }
        private Dictionary<string, ResearchTeam> String_Re_Dict { get { return String_Rea_Dict; } set { String_Rea_Dict = value; } }

        public static ResearchTeam GenerateElement(int value) {
            ResearchTeam a = new ResearchTeam();
            a.RegistrationNumber = value;
            return a;
        }
        TestCollections(int Count) {
            for (int i=0;i<Count;i++) {
                ListOfTeam.Add(new Team());
                Team_Rea_Dict.Add(new Team(), new ResearchTeam());
                ListOfString.Add("");
                String_Rea_Dict.Add("",new ResearchTeam());

            }
        }

        public void TimeOfSearching(string str, Team team, ResearchTeam resT) {

            int time1 = Environment.TickCount;
            ListOfTeam.BinarySearch(team);
            Console.WriteLine((time1-Environment.TickCount).ToString());

            int time2 = Environment.TickCount;
            ListOfString.BinarySearch(str);
            Console.WriteLine((time2 - Environment.TickCount).ToString());

            int time3 = Environment.TickCount;
           ResearchTeam a= Team_Rea_Dict[team];
            Console.WriteLine((time3 - Environment.TickCount).ToString());

            int time4 = Environment.TickCount;
            ResearchTeam b = String_Rea_Dict[str];
            Console.WriteLine((time4 - Environment.TickCount).ToString());

        }
    }

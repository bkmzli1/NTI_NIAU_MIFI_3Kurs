using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3;

public class ResearchTeam : Team, IDateAndCopy,IComparable<ResearchTeam>,IComparable
    {
        private string Theme;

        private TimeFrame ResearchDuration;
        public TimeFrame ResDuration { get { return ResearchDuration; } }

        List<Person> ProjectParticipants = new List<Person>();
        List<Paper> Publications = new List<Paper>();

        public List<Paper> ListOfPublication { get { return Publications; } set { Publications = value; } }
        public ResearchTeam(string InvestigationTheme, string Organisation, int RegistrationNumber, TimeFrame InvestigationDuration)
        {
            ResearchDuration = InvestigationDuration;
            Theme = InvestigationTheme;
            _RegistrationNumber = RegistrationNumber;
            _Organisation = Organisation;
        }
        public ResearchTeam() : this("Chaos", "IRE", 13, TimeFrame.Year) { }

        public Paper LastPaper
        {
            get
            {
                if (Publications.Count == 0)
                {
                    return null;
                }
                int MaxIndex = 0;
                DateTime MaxDateTime = Publications[0]._TimeOfPublication;
                for (int i = 0; i < Publications.Count; i++)
                {
                    if (Publications[i]._TimeOfPublication > MaxDateTime)
                    {
                        MaxIndex = i;
                        MaxDateTime = Publications[i]._TimeOfPublication;
                    }
                }
                return Publications[MaxIndex];
            }
        }
        public void AddPapers(params Paper[] AdditionalPapers)
        {
            Publications.AddRange(AdditionalPapers);
        }
        public override string ToString()
        {
            string stringListOfPublications = "";
            foreach (Paper pap in Publications)
            {
                stringListOfPublications += pap.ToString() + "\r\n";
            }
            string stringListOfParticipants = "";
            foreach (Person pers in ProjectParticipants)
            {
                stringListOfParticipants += pers.ToString() + "\r\n";
            }
            return base.ToString() + string.Format("\r\n Theme: {0}, Duration: {1} \r\n Participants: {2} \r\n Publications: {3}", Theme, ResearchDuration, stringListOfParticipants, stringListOfPublications);
        }
        public string ToShortString()
        {
            return base.ToString() + string.Format("\r\n Theme: {0}, Duration: {1} \r\n ", Theme, ResearchDuration);
        }
       public List<Person> ListOfParticipants { get { return ProjectParticipants; } set { ProjectParticipants = value; } }
        public void AddMembers(params Person[] AdditionalMembers)
        {
            ProjectParticipants.AddRange(AdditionalMembers);
        }
        public Team getTeamType
        {
            get
            {
                return new Team(Organisation, RegistrationNumber);
            }
            set
            {
                this.Organisation = value.Organisation;
                this.RegistrationNumber = value.RegistrationNumber;
            }
        }

        public string Name
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public override object DeepCopy()
        {
            ResearchTeam CopyTeam = new ResearchTeam(this.Theme, this.Organisation, this.RegistrationNumber, this.ResearchDuration);
            CopyTeam.ListOfParticipants = ListOfParticipants;
            CopyTeam.ListOfPublication = ListOfPublication;
            return CopyTeam;

        }

        public DateTime Date { get; set; }

        public IEnumerable<Person> MembersWithoutPublications()
        {

            ArrayList AutorsWithoutP = new ArrayList();
            bool someBool;
            foreach (Person pers in ProjectParticipants)
            {
                someBool = true;
                foreach (Paper pap in Publications)
                {
                    if (pap._Author == pers)
                    {
                        someBool = false;
                        break;
                    }
                }
                if (someBool)
                {
                    AutorsWithoutP.Add(pers);
                    //Console.WriteLine(pers.ToShortString());
                }

            }
            for (int i = 0; i < AutorsWithoutP.Count; i++)
            {
                yield return (Person)AutorsWithoutP[i];
                //Console.Write(((Person)AutorsWithoutP[i]).ToShortString());
            }

        }
        public IEnumerable<Paper> LastPapers(int N_years)
        {
            for (int i = 0; i < Publications.Count; i++)
            {
                if (((Paper)Publications[i])._TimeOfPublication.Year >= DateTime.Now.Year - N_years)
                {
                    yield return (Paper)Publications[i];
                    //Console.Write(((Paper)Publications[i]).ToString());
                }
            }
        }

        public int CompareTo(ResearchTeam other)
        {
            if (other == null) {
                throw new ArgumentException("Wrong argument!");
                }
            return Theme.CompareTo(other.Theme);
        }

        delegate int KeySelector<TKey>(ResearchTeam rt);
    }

using System.Diagnostics;
using Lab3;


public  enum TimeFrame { Year, TwoYears, Long }
class Program
{
    static void Main(string[] args)
    {
        ResearchTeamCollection MyCollection = new ResearchTeamCollection();
        MyCollection.AddResearchTeams(new ResearchTeam("Chaos","IRE",23,TimeFrame.TwoYears));
        MyCollection.AddResearchTeams(new ResearchTeam("Resonators", "IRE", 17, TimeFrame.Year));
        MyCollection.AddResearchTeams(new ResearchTeam("Phylosophy", "IRE", 18, TimeFrame.Year));
        MyCollection.AddResearchTeams(new ResearchTeam("English", "IRE", 20, TimeFrame.Year));

        foreach (ResearchTeam t in MyCollection) {
            Console.WriteLine(t.ToShortString());
        }
        MyCollection.ToSortByRegistrNumber();
        Console.WriteLine("Sorted by RegistrNumber");
        foreach (ResearchTeam t in MyCollection)
        {
            Console.WriteLine(t.ToShortString());
        }
        MyCollection.SortByString();
        Console.WriteLine("Sorted by String");
        foreach (ResearchTeam t in MyCollection)
        {
            Console.WriteLine(t.ToShortString());
        }
        MyCollection.SortByPublications();
        Console.WriteLine("Sorted by Bublications");
        foreach (ResearchTeam t in MyCollection)
        {
            Console.WriteLine(t.ToShortString());
        }
        Console.WriteLine();
        Console.WriteLine(MyCollection.MinRegNumber.ToString());
        Console.WriteLine(MyCollection.TwoYearsLong.ToString());
        Console.ReadKey();

    }
}
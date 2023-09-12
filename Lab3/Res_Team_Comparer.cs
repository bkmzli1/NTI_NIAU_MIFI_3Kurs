namespace Lab3;

public  class Res_Team_Comparer:IComparer<ResearchTeam>
{
    public int Compare(ResearchTeam l_Team, ResearchTeam R_Team)
    {
        return l_Team.ListOfPublication.Count.CompareTo(R_Team.ListOfPublication.Count);
    }

       

        

       
}
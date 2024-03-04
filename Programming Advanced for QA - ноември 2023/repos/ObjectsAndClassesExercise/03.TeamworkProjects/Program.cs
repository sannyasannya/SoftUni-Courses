namespace _03.TeamworkProjects
{
    public class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<string, Team> teams = new Dictionary<string, Team>();


            for (int i = 0; i < n; i++) 
            {
                string teamData = Console.ReadLine();
                string[] data = teamData.Split("-");
                string creator = data[0];
                string teamName = data[1];

                if (teams.ContainsKey(teamName))
                {
                    Console.WriteLine($"Team {teamName} was already created!");
                }                    
                else if (teams.Any(t => t.Value.Creator == creator))
                {
                    Console.WriteLine($"{creator} cannot create another team!");
                }                  
                else
                {
                    Team team = new Team(teamName, creator);
                    teams.Add(teamName, team);
                    Console.WriteLine($"Team {teamName} has been created by {creator}!");
                }                

            }
            string command = Console.ReadLine();

            while (command != "end of assignment")
            {
                string memberJoin = command.Split("->")[0];
                string teamJoining = command.Split("->")[1];

                if (!teams.ContainsKey(teamJoining))
                {
                    Console.WriteLine($"Team {teamJoining} does not exist!");
                    command = Console.ReadLine();
                    continue;

                }
                var userIsCreator = teams[teamJoining].Creator == memberJoin;
                var userAlreadyMember = teams.Values.Any(t => t.Members.Contains(memberJoin));

                if (userIsCreator || userAlreadyMember)
                {
                    Console.WriteLine($"Member {memberJoin} cannot join team {teamJoining}!");
                    command = Console.ReadLine();
                    continue;
                }

                teams[teamJoining].Members.Add(memberJoin);

                command = Console.ReadLine();
            }

            foreach (var team in teams.Where(team => team.Value.Members.Count > 0)
                        .OrderByDescending(team => team.Value.Members.Count)
                        .ThenBy(team => team.Key))
            {
                Console.WriteLine(team.Key);
                Console.WriteLine($"- {team.Value.Creator}");

                foreach (string member in team.Value.Members.OrderBy(m => m))
                {
                    Console.WriteLine($"-- {member}");
                }
            }

            Console.WriteLine("Teams to disband: ");
            foreach (var team in teams.Where(team => team.Value.Members.Count == 0))
            {
                Console.WriteLine(team.Key);
            }
        }
    }
}
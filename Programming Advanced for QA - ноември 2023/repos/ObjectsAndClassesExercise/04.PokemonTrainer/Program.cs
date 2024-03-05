namespace _04.PokemonTrainer
{
    public class Program
    {
        static void Main(string[] args)
        {
            string command = Console.ReadLine();
            List<Trainer> trainers = new List<Trainer>();

            while (command != "Tournament")
            {
                string[] data = command.Split().ToArray();
                Pokemon currentP = new Pokemon(data[1], data[2], int.Parse(data[3]));

                bool trainerExists = false;
                Trainer existingTrainer = new Trainer();

                foreach (Trainer trainer in trainers)
                {
                    if (data[0] == trainer.Name)
                    {
                        trainerExists = true;
                        existingTrainer = trainer;
                    }

                }
                if (trainerExists)
                {
                    existingTrainer.Pokemon.Add(currentP);
                }
                else
                {
                    Trainer currentTr = new Trainer(data[0]);
                    currentTr.Pokemon.Add(currentP);
                    trainers.Add(currentTr);
                }

                command = Console.ReadLine();
            }

            string command2 = Console.ReadLine();
            while (command2 != "End")
            {
                for (int i = 0; i < trainers.Count; i++)
                {
                    bool hasPokemon = false;

                    foreach (Pokemon pokemon in trainers[i].Pokemon)
                    {
                        if (command2 == pokemon.Element)
                            hasPokemon = true;
                    }

                    if (hasPokemon)
                        trainers[i].Badges++;
                    else
                        trainers[i].Pokemon.ForEach(p => { p.Health -= 10; });

                    trainers[i].Pokemon.RemoveAll(x => x.Health <= 0);
                }

                command2 = Console.ReadLine();
            }

            List<Trainer> sortedList = trainers.OrderByDescending(x => x.Badges).ToList();
            foreach (Trainer t in sortedList)
            {
                Console.WriteLine($"{t.Name} {t.Badges} {t.Pokemon.Count}");
            }
        }
    }
}


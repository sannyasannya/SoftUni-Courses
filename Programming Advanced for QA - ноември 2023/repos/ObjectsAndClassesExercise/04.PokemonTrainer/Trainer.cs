using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.PokemonTrainer
{
    public class Trainer
    {
        public string Name { get; set; }

        public int Badges { get; set; }

        public List<string> Pokemon {  get; set; }

        public Trainer() { }

        public Trainer(string name)
        {
            this.Name = name;
            this.Badges = 0;
            this.Pokemon = new List<string>();
        }

    }
}

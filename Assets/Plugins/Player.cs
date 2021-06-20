using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Plugins
{
    public class Player: IEquatable<Player>
    {
        private string name;
        private int points;

        public Player(string num, int po)
        {
            this.name = num;
            this.points = po;
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                this.name = value;
            }
        }

        public int Points
        {
            get
            {
                return this.points;
            }
            set
            {
                this.points = value;
            }
        }

        public bool Equals(Player other)
        {
            if (this.name.Equals(other.Name))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}

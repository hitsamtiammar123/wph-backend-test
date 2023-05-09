using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace backend_test
{
    internal class Player
    {
        private int _health;
        private string _name;
            
        public Player(string name)
        {
            this._name = name;
            this._health = 3;
        }

        public void ReduceHealth()
        {
            this._health--;
        }

        public int Health { get { return this._health; } }
        public string Name { get { return this._name; } }

    }
}

using UnityEngine;

namespace GameSystem.Directions
{
    public class Up : Direction {

        public Up() {
            this.position = new Vector3(0, 0.8f, 0);
            this.rowIncrement = -1;
        }
    
    }
}

using UnityEngine;

namespace GameSystem.Directions
{
    public class Right : Direction {
        public Right() {
            this.position = new Vector3(0.8f, 0, 0);
            this.columnIncrement = 1;
        }
    }
    
}

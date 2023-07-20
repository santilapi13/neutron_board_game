using UnityEngine;

namespace GameSystem.Directions
{
    public class UpRight : Direction {
        public UpRight() {
            this.position = new Vector3(0.5f, 0.5f, 0);
            this.rowIncrement = -1;
            this.columnIncrement = 1;
        }

    }
}

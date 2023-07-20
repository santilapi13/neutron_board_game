using UnityEngine;

namespace GameSystem.Directions
{
    public class DownLeft : Direction {
        public DownLeft() {
            this.position = new Vector3(-0.5f, -0.5f, 0);
            this.rowIncrement = 1;
            this.columnIncrement = -1;
        }
    }
}

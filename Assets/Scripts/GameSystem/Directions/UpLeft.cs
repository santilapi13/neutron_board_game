using UnityEngine;

namespace GameSystem.Directions
{
    public class UpLeft : Direction {
        public UpLeft() {
            this.position = new Vector3(-0.5f, 0.5f, 0);
            this.rowIncrement = -1;
            this.columnIncrement = -1;
        }

    }
}

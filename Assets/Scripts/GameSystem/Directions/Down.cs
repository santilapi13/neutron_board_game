using UnityEngine;

namespace GameSystem.Directions
{
    public class Down : Direction {
        public Down() {
            this.position = new Vector3(0, -0.8f, 0);
            this.rowIncrement = 1;
        }

    }
}

using UnityEngine;

namespace GameSystem.Directions {
    public class Left : Direction {
        // Start is called before the first frame update
        public Left() {
            this.position = new Vector3(-0.8f, 0, 0);
            this.columnIncrement = -1;
        }
    }
}

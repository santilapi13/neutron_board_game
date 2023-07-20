using UnityEngine;

namespace GameSystem.Directions
{
    public abstract class Direction {

        protected Vector3 position;
        protected int rowIncrement = 0;
        protected int columnIncrement = 0;

        public Vector3 GetPosition() {
            return position;
        }
        
        public int GetRowIncrement() {
            return rowIncrement;
        }
        
        public int GetColumnIncrement() {
            return columnIncrement;
        }
    }
}

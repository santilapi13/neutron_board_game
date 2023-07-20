using UnityEngine;

namespace GameSystem
{
    public class Tile : MonoBehaviour {
    
        [SerializeField] private Token content = null;
        private GameObject tileGO;
        private int row;
        private int column;
    
        public void SetContent(Token token) {
            this.content = token;
        }

        public Token GetContent() {
            return content;
        }

        public void SetTileGO(GameObject o) {
            this.tileGO = o;
        }
        
        public void SetRow(int row) {
            this.row = row;
        }
        
        public void SetColumn(int column) {
            this.column = column;
        }
        
        public int GetRow() {
            return this.row;
        }
        
        public int GetColumn() {
            return this.column;
        }

        public void Empty() {
            this.content = null;
        }

        public GameObject GetTileGO() {
            return this.tileGO;
        }

        void OnMouseOver() {
            tileGO.GetComponent<Renderer>().material.color = Color.yellow;
        }

        void OnMouseExit() {
            tileGO.GetComponent<Renderer>().material.color = Color.gray;
        }

        public void KillTile() {
            if (this.content != null)
                this.content.KillToken();
            Destroy(this.tileGO);
        }

    }
}

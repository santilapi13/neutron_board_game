using GameSystem.Directions;
using UnityEngine;
using UnityEngine.PlayerLoop;

namespace GameSystem
{
    public class Table : MonoBehaviour {

        [SerializeField] private Tile[,] table = new Tile[5,5];
        [SerializeField] private float quadSide = 0.25f;
        private Token neutron;
        [SerializeField] private Token selectedPiece;
        private static Table instance = null;
        private MovementArrow[] movementArrows = new MovementArrow[8];
        private Direction[] directions = new Direction[8];

        public static Table GetInstance() {
            if (instance == null) {
                instance = FindObjectOfType<Table>();
            }
            return instance;
        }
        
        void Start() {
            directions[0] = new Up();
            directions[1] = new UpRight();
            directions[2] = new Right();
            directions[3] = new DownRight();
            directions[4] = new Down();
            directions[5] = new DownLeft();
            directions[6] = new Left();
            directions[7] = new UpLeft();
            BuildTiles();
            BuildTokens();
            GameControl.BeginGame();
        }

        private void BuildTiles() {
            for (var i = 0; i < 5; i++) {
                for (var j = 0; j < 5; j++) {
                    this.table[i,j] = TileFactory.CreateTile(i, j, quadSide);
                }
            }
        }

        public void ResetTable() {
            for (var i = 0; i < 5; i++) {
                for (var j = 0; j < 5; j++) {
                    table[i, j].KillTile();
                }
            }
            this.BuildTiles();
            this.BuildTokens();
        }
                
        private void BuildTokens() {
            for (var i = 0; i < 5; i++) {
                this.table[0,i].SetContent(TokenFactory.CreateToken("black", this.table[0,i].GetTileGO()));
                this.table[4,i].SetContent(TokenFactory.CreateToken("white", this.table[4,i].GetTileGO()));
            }

            this.table[2,2].SetContent(TokenFactory.CreateToken("green", this.table[2,2].GetTileGO()));
            neutron = this.table[2, 2].GetContent();
        }
     
        public Tile[,] GetTable() {
            return this.table;
        }

        public Token GetNeutron() {
            return neutron;
        }

        public void SetSelectedPiece(Token piece) {
            this.selectedPiece = piece;
        }
        
        public Token GetSelectedPiece() {
            return this.selectedPiece;
        }

        public void AddMovementArrow(MovementArrow arrow, int i) {
            this.movementArrows[i] = arrow;
        }
        
        public int GetMovementArrowsLength() {
            return this.movementArrows.Length;
        }
        
        public Direction[] GetDirections() {
            return this.directions;
        }
        
        public void EraseMovementArrows() {
            foreach (var arrow in this.movementArrows) {
                if (arrow != null) {
                    arrow.Erase();
                }
            }
            for (int i = 0; i < movementArrows.Length; i++)
                movementArrows[i] = null;
        }

        public bool IsBlocked(Direction direction, int row, int column) {
            row += direction.GetRowIncrement();
            column += direction.GetColumnIncrement();
            
            return row < 0 || column < 0 || row >= 5 || column >= 5 || table[row,column].GetContent() != null;
        }

        public void MoveSelectedPiece(Direction direction) {
            var row = selectedPiece.GetRow();
            var column = selectedPiece.GetColumn();
            while (!IsBlocked(direction, row, column)) {
                row += direction.GetRowIncrement();
                column += direction.GetColumnIncrement();
            }

            var tile = table[row, column];
            this.selectedPiece.Move(tile);
            tile.SetContent(selectedPiece);
        }
    }
}

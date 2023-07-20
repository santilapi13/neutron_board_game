using UnityEngine;

namespace GameSystem
{
    public static class TileFactory {
        public static Tile CreateTile(int x, int y, float quadSide) {
            // Creates GameObject
            var tileGO = GameObject.CreatePrimitive(PrimitiveType.Quad);
            tileGO.name = "Tile (" + x + ", " + y + ")";
            tileGO.transform.position = new Vector3(-0.5f + y*quadSide, 1.45f - x * quadSide, -9);
            tileGO.transform.localScale = new Vector3(quadSide-0.01f, quadSide-0.01f, 1f);
            tileGO.GetComponent<Renderer>().material.color = Color.gray;
            tileGO.transform.parent = Table.GetInstance().transform;
            
            // Creates MonoBehaviour
            tileGO.AddComponent<Tile>();
            var tile = tileGO.GetComponent<Tile>();
            tile.SetRow(x);
            tile.SetColumn(y);
            tile.SetTileGO(tileGO);

            return tile;
        }
    }
}

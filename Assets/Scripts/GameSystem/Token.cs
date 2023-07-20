using System;
using System.Collections;
using System.Collections.Generic;
using GameSystem;
using GameSystem.Directions;
using Unity.VisualScripting;
using UnityEngine;

public class Token : MonoBehaviour {
    [SerializeField] private GameObject tokenGO;
    private Renderer tokenRenderer;
    private Color color;
    [SerializeField] private Tile tile;

    public void SetTokenGO(GameObject o) {
        this.tokenGO = o;
        this.tokenRenderer = o.GetComponent<Renderer>();
    }
    
    public GameObject GetTokenGO() {
        return this.tokenGO;
    }

    public void SetColor(Color color) {
        this.color = color;
    }
    
    public void SetTile(Tile tile) {
        this.tile = tile;
        this.tokenGO.transform.parent = tile.GetTileGO().transform;
    }
    
    public Tile GetTile() {
        return this.tile;
    }

    public int GetRow() {
        return this.tile.GetRow();
    }
    
    public int GetColumn() {
        return this.tile.GetColumn();
    }
    
    void OnMouseOver() {
        tokenRenderer.material.color = Color.yellow;
    }

    void OnMouseExit() {
        tokenRenderer.material.color = this.color;
    }

    private void OnMouseDown() {
        if (GameControl.ActualPhase == Phase.Token && ((GameControl.ActualTurn == Turn.White && this.color == Color.white) || (GameControl.ActualTurn == Turn.Black && this.color == Color.black))) {
            if (Table.GetInstance().GetMovementArrowsLength() > 0)
                Table.GetInstance().EraseMovementArrows();
            Table.GetInstance().SetSelectedPiece(this);
            this.DisplayMovementArrows();
        }
    }

    public void DisplayMovementArrows() {
        for (var i = 0; i < 8; i++) {
            var direction = Table.GetInstance().GetDirections()[i];
            if (!Table.GetInstance().IsBlocked(direction, this.GetRow(), this.GetColumn())) {
                Table.GetInstance().AddMovementArrow(MovementArrowFactory.CreateMovementArrow(this.tokenGO, direction, i), i);
            }
        }
    }
    

    public void Move(Tile tile) {
        // TODO: Movement animation
        this.tokenGO.transform.position = tile.GetTileGO().transform.position;
        this.tile.Empty();
        this.SetTile(tile);
    }

    public void KillToken() {
        Destroy(this.tokenGO);
    }
    
}

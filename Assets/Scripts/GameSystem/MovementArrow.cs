using System.Collections;
using System.Collections.Generic;
using GameSystem;
using GameSystem.Directions;
using UnityEngine;

public class MovementArrow : MonoBehaviour {
    private GameObject arrowBodyGO;
    private GameObject arrowHeadGO;
    private Renderer arrowBodyRenderer;
    private Renderer arrowHeadRenderer;
    private Direction direction;

    void Start() {
        arrowBodyGO.transform.localPosition = direction.GetPosition();
    }
    
    public void SetMovementArrowGO(GameObject arrowBodyGO, GameObject arrowHeadGO) {
        this.arrowBodyGO = arrowBodyGO;
        this.arrowBodyRenderer = arrowBodyGO.GetComponent<Renderer>();
        this.arrowHeadGO = arrowHeadGO;
        this.arrowHeadRenderer = arrowHeadGO.GetComponent<Renderer>();
    }
    
    public void SetDirection(Direction direction) {
        this.direction = direction;
    }
    
    void OnMouseOver() {
        arrowBodyRenderer.material.color = Color.yellow;
        arrowHeadRenderer.material.color = Color.yellow;
    }

    void OnMouseExit() {
        var color = GameControl.ActualTurn == Turn.White ? Color.white : Color.black;
        arrowBodyRenderer.material.color = color;
        arrowHeadRenderer.material.color = color;
    }
    
    void OnMouseDown() {
        var color = GameControl.ActualTurn == Turn.White ? Color.white : Color.black;
        arrowBodyRenderer.material.color = color;
        arrowHeadRenderer.material.color = color;
        Table.GetInstance().MoveSelectedPiece(direction);
        Table.GetInstance().EraseMovementArrows();
        if (GameControl.ActualPhase == Phase.Token) {
            GameControl.ActualPhase = Phase.Neutron;
            GameControl.SetActualTurn(GameControl.ActualTurn == Turn.White ? Turn.Black : Turn.White);
        }
        else {
            GameControl.GetInstance().ChangeToTokenPhase();
        }
    }

    public void Erase() {
        Destroy(this.arrowBodyGO);
        Destroy(this.arrowHeadGO);
    }
    
}

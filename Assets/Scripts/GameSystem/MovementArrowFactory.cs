using System.Collections;
using System.Collections.Generic;
using GameSystem;
using GameSystem.Directions;
using UnityEngine;

public static class MovementArrowFactory {
    
    public static MovementArrow CreateMovementArrow(GameObject tokenGO, Direction direction, int i)
    {
        // Creates GameObject
        var arrowBodyGO = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
        var arrowHeadGO = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        arrowHeadGO.transform.parent = arrowBodyGO.transform;
        arrowBodyGO.transform.parent = tokenGO.transform;
        arrowBodyGO.name = "Arrow (" + direction + ")";

        arrowBodyGO.transform.localScale = new Vector3(0.1f, 0.5f, 0.05f);
        arrowHeadGO.transform.localPosition = new Vector3(0.02f, 0.96f, -0.08f);
        arrowHeadGO.transform.localScale = new Vector3(1.5f, 1f, 1);
        arrowHeadGO.GetComponent<SphereCollider>().enabled = false;
        arrowBodyGO.GetComponent<CapsuleCollider>().height += 2;
        arrowBodyGO.GetComponent<CapsuleCollider>().radius += 2;
        
        arrowBodyGO.transform.Rotate(0,0, -45 * i);
        
        arrowBodyGO.GetComponent<Renderer>().material.color = GameControl.ActualTurn == Turn.White ? Color.white : Color.black;
        arrowHeadGO.GetComponent<Renderer>().material.color = GameControl.ActualTurn == Turn.White ? Color.white : Color.black;
        
        // Creates MonoBehaviour
        arrowBodyGO.AddComponent<MovementArrow>();
        var arrow = arrowBodyGO.GetComponent<MovementArrow>();
        arrow.SetMovementArrowGO(arrowBodyGO, arrowHeadGO);
        arrow.SetDirection(direction);

        return arrow;
    }
}

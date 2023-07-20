using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TurnPointer : MonoBehaviour {

    private static TurnPointer instance = null;
    private bool goingForward = false;
    
    public static TurnPointer GetInstance() {
        if (instance == null) {
            instance = FindObjectOfType<TurnPointer>();
        }
        return instance;
    }

    // Update is called once per frame
    void Update() {
        MovePointer();
    }

    public void SetPosition(Turn turn) {
        transform.position = turn == Turn.White ? new Vector3(-1.45f, 0.061f, -8.1f) : new Vector3(-1.45f, 1.926f, -8.1f);
    }

    private void MovePointer() {
        if (!goingForward) {
            if (transform.position.x >= -1.7f)
                transform.position -= new Vector3(Time.deltaTime*0.7f, 0, 0);
            else
                goingForward = true;
        }
        else {
            if (transform.position.x <= -1.45f)
                transform.position += new Vector3(Time.deltaTime*0.7f, 0, 0);
            else
                goingForward = false;
        }
    }
    
}

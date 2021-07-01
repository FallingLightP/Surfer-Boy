using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{

    bool isStacked = false;

    bool active = true;

    private void OnCollisionEnter(Collision other) {
        if(other.gameObject.tag == "Player" && !isStacked || other.gameObject.tag == "Box" && !isStacked)
        {
            PlayerStack.myStack.AddBox(gameObject);
            isStacked = true;
        }

        if(other.gameObject.tag == "Wall" && active)
        {
            PlayerStack.myStack.StackUpdate(gameObject);
            active = false;
        }
    }
}

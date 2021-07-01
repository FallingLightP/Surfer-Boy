using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StackTrail : MonoBehaviour
{
    [SerializeField]Transform capsule;

    private void Update() {
        transform.position = new Vector3(capsule.position.x,transform.position.y, capsule.position.z);
    }
}

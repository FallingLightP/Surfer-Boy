using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DriftParticle : MonoBehaviour
{
    [SerializeField]Transform capsule;

    void Update(){
        transform.position = new Vector3(capsule.position.x,transform.position.y, capsule.position.z);
    }
}

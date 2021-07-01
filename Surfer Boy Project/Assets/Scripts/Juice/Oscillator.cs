using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oscillator : MonoBehaviour
{
   float timeCounter;

   [SerializeField]float speed = 1f;
   [SerializeField]float width = 1f;
   [SerializeField]float height = 1f;

   private void Update()
   {
       timeCounter += Time.deltaTime * speed;

       float x = Mathf.Cos(timeCounter) * height;
       float z = Mathf.Sin(timeCounter) * width;

       transform.localPosition = new Vector3(x,0,z);
   }
}

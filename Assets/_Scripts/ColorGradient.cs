using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorGradient : MonoBehaviour
{
  // public Color color = Color.black;
   void Awake()
   {
      GetComponent<Renderer>().material.color = Random.ColorHSV(0f, 1f, 0.01f, 0.02f, 0.01f, 0.05f);
      
   }
}

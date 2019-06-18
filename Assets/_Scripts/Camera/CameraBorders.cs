using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBorders : MonoBehaviour
{

    private Vector3 translateVector = new Vector3(7f, -1.5f, 0.0f);
    public float MinOffset;
    public float MaxOffset;

    void FixedUpdate()
    {
        Vector3 newPosition = this.transform.position + translateVector;

        if (newPosition.x >= MinOffset && newPosition.x <= MaxOffset)
        {
            this.transform.Translate(translateVector);
        }
    }
}

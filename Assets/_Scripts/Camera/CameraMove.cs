using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    private Camera _camera;

    private Vector3 newPos;

    private float minX = -1f;
    private float maxX = 1f;
    private float minY = -5f;
    private float maxY = 5f;

    void Update()
    {
        _camera.transform.position = new Vector3();
        if (newPos.x > minX && newPos.x < maxX && newPos.y > minY && newPos.y < maxY)
            _camera.transform.position = newPos;

     
        
    }


}

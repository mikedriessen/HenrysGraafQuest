﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class MovingBackground : MonoBehaviour
{
    // public Image Background;


    // Vector3 rotationRate = Input.gyro.rotationRate;


    // Faces for 6 sides of the cube
    private GameObject[] quads = new GameObject[6];

    // Textures for each quad, should be +X, +Y etc
    // with appropriate colors, red, green, blue, etc
    public Texture[] labels;
    
    Gyroscope m_gyroscope;

    void Start()
    {
        //Set up and enable the gyroscope (check your device has one)
        m_gyroscope = Input.gyro;
        m_gyroscope.enabled = true;
        
        // make camera solid colour and based at the origin
        GetComponent<Camera>().backgroundColor = new Color(49.0f / 255.0f, 77.0f / 255.0f, 121.0f / 255.0f);
        GetComponent<Camera>().transform.position = new Vector3(0, 0, 0);
        GetComponent<Camera>().clearFlags = CameraClearFlags.SolidColor;


        // create the six quads forming the sides of a cube
        GameObject quad = GameObject.CreatePrimitive(PrimitiveType.Quad);

        quads[0] = createQuad(quad, new Vector3(0.5f, 0, 0), new Vector3(0, 90, 0), "plus x",
            new Color(0.20f, 0.10f, 0.10f, 1), labels[0]);
        quads[1] = createQuad(quad, new Vector3(0, 0.5f, 0), new Vector3(-90, 0, 0), "plus y",
            new Color(0.20f, 0.10f, 0.10f, 1), labels[1]);
        quads[2] = createQuad(quad, new Vector3(0, 0, 0.5f), new Vector3(0, 0, 0), "plus z",
            new Color(0.20f, 0.10f, 0.10f, 1), labels[2]);
        quads[3] = createQuad(quad, new Vector3(-0.5f, 0, 0), new Vector3(0, -90, 0), "neg x",
            new Color(0.20f, 0.10f, 0.10f, 1), labels[3]);
        quads[4] = createQuad(quad, new Vector3(0, -0.5f, 0), new Vector3(90, 0, 0), "neg y",
            new Color(0.20f, 0.10f, 0.10f, 1), labels[4]);
        quads[5] = createQuad(quad, new Vector3(0, 0, -0.5f), new Vector3(0, 180, 0), "neg z",
            new Color(0.20f, 0.10f, 0.10f, 1), labels[5]);
     

        GameObject.Destroy(quad);
    }

    // make a quad for one side of the cube
    GameObject createQuad(GameObject quad, Vector3 pos, Vector3 rot, string name, Color col, Texture t)
    {
        Quaternion quat = Quaternion.Euler(rot);
        GameObject GO = Instantiate(quad, pos, quat);
        GO.name = name;
        GO.GetComponent<Renderer>().material.color = col;
        GO.GetComponent<Renderer>().material.mainTexture = t;
        GO.transform.localScale += new Vector3(0.25f, 0.25f, 0.25f);
        return GO;
    }

    protected void Update()
    {
        GyroModifyCamera();
    }

    protected void OnGUI()
    {
        GUI.skin.label.fontSize = Screen.width / 40;

        GUILayout.Label("Orientation: " + Screen.orientation);
        GUILayout.Label("input.gyro.attitude: " + Input.gyro.attitude);
        GUILayout.Label("Phone width/font: " + Screen.width + " : " + GUI.skin.label.fontSize);
        
                
        GUILayout.Label("Gyroscope attitude : " + m_gyroscope.attitude);    
        GUILayout.Label("Gyroscope gravity : " + m_gyroscope.gravity);    
        GUILayout.Label("Gyroscope rotationRate : " + m_gyroscope.rotationRate);    
        GUILayout.Label("Gyroscope rotationRateUnbiased : " + m_gyroscope.rotationRateUnbiased);    
        GUILayout.Label("Gyroscope updateInterval : " + m_gyroscope.updateInterval);    
        GUILayout.Label("Gyroscope userAcceleration : " + m_gyroscope.userAcceleration);
    }

    /********************************************/

    // The Gyroscope is right-handed.  Unity is left handed.
    // Make the necessary change to the camera.
    void GyroModifyCamera()
    {
        transform.rotation = GyroToUnity(Input.gyro.attitude);
    }

    private static Quaternion GyroToUnity(Quaternion q)
    {
        return new Quaternion(q.x, q.y, -q.z, -q.w);
    }
    

}
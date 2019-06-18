using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Singleton : MonoBehaviour
{
  public static Singleton Brain;
         
  //private Button _button;
  private Button _settings;
  private Text _text;

  private bool enableSettings;
  private Texture settingsTexture;

  public Texture[] btnTextures;
  
  //Music volume
  public float musicSliderValue = 0.0F;
  
  public static class ResourceExt
  {
         static Dictionary<string, Texture> loadedTextures = new Dictionary<string, Texture>();
 
         /// <summary>
         /// Find texture by name, if the path is unknown. Warning: It is a slow process and uses a lot of memory.
         /// </summary>
         public static Texture FindTexture(string name)
         {
                Texture result;
                if (loadedTextures.TryGetValue(name, out result))
                {
                       return result; //Already loaded the texture
                }
                else
                {
                       //Search in all the textures that been loaded by unity
                       Texture[] allTextures = Resources.FindObjectsOfTypeAll<Texture>();
                       foreach (Texture tex in allTextures)
                       {
                              if (tex.name == name)
                              {
                                     loadedTextures.Add(name, tex); //Store the found texture
                                     return tex;
                              }
                       }
 
                       //Final trying to search the files and load everything
                       allTextures = Resources.LoadAll<Texture>("");
                       //Resources.LoadAll<Texture>("*" + name + ".*") or ("*" + name) or (name) doesn't work;
 
                       foreach (Texture tex in allTextures)
                       {
                              if (tex.name == name)
                              {
                                     loadedTextures.Add(name, tex); //Store the found texture
                                     return tex;
                              }
                       }
 
                       loadedTextures.Add(name, null);
                       Debug.LogError("Could not find texture: " + name);
                       return null;
                }
         }
  }
  
         void Awake()
         {
                enableSettings = false;
                //_text = Text.GetComponent<Text>().enabled = false;
               // _button = GameObject.Find("Button").GetComponent<Button>();
                
                _settings = GameObject.Find("SettingsButton").GetComponent<Button>();
                settingsTexture = ResourceExt.FindTexture("settingsTexture");
                
                //_text = GameObject.Find("Loading").GetComponent<Text>();
              //  _text.GetComponent<Text>().enabled = false;
                
                
               if(Singleton.Brain == null)
               {
                      Singleton.Brain = this;
                      DontDestroyOnLoad(gameObject);
               }
               else
               {
                      Destroy(gameObject);
               }
         }

         private void Update()
         {
                //_button.onClick.AddListener(StartClicked);
                _settings.onClick.AddListener(EnableSettingsGUI);
         }
/*
         void StartClicked()
         {
                _text.GetComponent<Text>().enabled = true;
                _button.GetComponent<Button>().enabled = false;
                SceneManager.LoadScene(1, LoadSceneMode.Single);

         }
         */

         private void EnableSettingsGUI()
         {
                enableSettings = true;
         }
         
         

         void OnGUI()
         {
                if (enableSettings)
                {
                       GUI.backgroundColor = new Color(0, 0, 0, 0);
                       Debug.Log("Tried to open Settings");
                       
                       GUI.DrawTexture(new Rect(100, 100, 900, 1800),settingsTexture , ScaleMode.ScaleToFit, true, 0.0F);
                       
                       if (GUI.Button(new Rect(150, 200, 128, 128), btnTextures[0]))
                            //  Debug.Log("Clicked the button with an Image1");
                       enableSettings = false;
                       //enableSettings = false;
                       GUIStyle guiStyle = new GUIStyle();
                       guiStyle.normal.textColor = Color.white;
                       guiStyle.fontSize = 100;
                       GUI.Box(new Rect (100,100,500,300), "Speed", guiStyle);
                       musicSliderValue = GUI.HorizontalSlider(new Rect(100, 100, 200, 150), musicSliderValue, 0.0F, 10.0F);
                }   
         }

 


}

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class playerMove : MonoBehaviour
{
    public float xRight = 1f;
    public float xLeft = -1f;
    public float yUp = 1f;
    public float yDown = -1f;

    private bool canMove;

    private int ropeAmt;
    public Text ropeText;
    private RaycastHit hit_Info;
    private GameObject other;
    public Texture[] btnTextures;
    public Texture[] btnTextures2;

    public Renderer rend;
    
    //GUI
    public Texture aTexture;
    public Texture aTexture2;
    
    private bool openShop;
    private bool openMuseum;
    
    //Can still move on rope
    private bool RopeMove = false;
    
   // private bool canSwipe = false;
   //Vertical Slider
   private int textureIndex = 0;
   public Texture[] sliderTextures;
   
   public float vSliderValue = 5.5f;


    private void Start()
    {
        //canSwipe = true;
        canMove = true;
        ropeAmt = 12;
        ropeText.text = ropeAmt.ToString();

        openShop = false;
        openMuseum = false;
    }



    public void swipeUp()
    {
        if (canMove)
        {
            Debug.DrawRay(transform.position, transform.up * 0.8f);

            Ray ray = new Ray(this.transform.position, this.transform.up);
            if (Physics.Raycast(ray, out hit_Info, 0.8f))
            {
                if (hit_Info.collider.tag == "Dirt" || hit_Info.collider.tag == "Destroyed")
                {
                    if ( hit_Info.collider.tag == "Destroyed")
                    {
                        RopeMove = true;
                    }
                    Debug.Log("Does it work?!??");

                    if (ropeAmt > 0 ||  RopeMove)
                    {
                        if (hit_Info.collider.tag == "Dirt" )
                        {
                            ropeAmt--;
                            XPSlider.Brain.AddXP();
                        }
                        ropeText.text = ropeAmt.ToString();
                        this.transform.Translate(0, yUp, 0);
                        RopeMove = false;

                    }
         
                }
              }
            }
        Debug.DrawRay(transform.position, transform.up * 0.8f);

        Ray rayy= new Ray(this.transform.position, this.transform.up);
        if (Physics.Raycast(rayy, out hit_Info, 0.8f))
        {
            if (hit_Info.collider.tag == "Shop")
            {

                Shop();
              
            }
         else if (hit_Info.collider.tag == "Museum")
            {

                Museum();
              
            }
        }
    }


    public void swipeDown()
    {
        if (canMove)
        {
            Debug.DrawRay(transform.position,transform.up*-1f * 5f);
            
            Ray ray = new Ray(this.transform.position, transform.up * -1f);
            if (Physics.Raycast(ray,out hit_Info,0.8f))
            {
                if (hit_Info.collider.tag == "Dirt" || hit_Info.collider.tag == "Destroyed"  && !openShop)
                {
                    if ( hit_Info.collider.tag == "Destroyed")
                    {
                        RopeMove = true;
                    }
                    openShop = false;  
                    Debug.Log("Does it work?!??");
                    if (ropeAmt > 0 ||  RopeMove && openShop)
                    {
                        openShop = false;  
                    }
                    if (ropeAmt > 0 ||  RopeMove && !openShop)
                    {     
                        if (hit_Info.collider.tag == "Dirt" )
                        {
                            ropeAmt--;
                            XPSlider.Brain.AddXP();
                        }
                        ropeText.text = ropeAmt.ToString();
                        this.transform.Translate(0, yDown, 0);
                        RopeMove = false;
                    }
                  
                    
                }
            }
        }
    }

    public void swipeLeft()
    {
        if (canMove)
        {
            Debug.DrawRay(transform.position,transform.right*-1f* 5f);
            
            Ray ray = new Ray(this.transform.position, transform.right * -1f );
            if (Physics.Raycast(ray,out hit_Info,1f))
            {
                if (hit_Info.collider.tag == "Dirt" || hit_Info.collider.tag == "Destroyed" )
                {
                    if ( hit_Info.collider.tag == "Destroyed")
                    {
                        RopeMove = true;
                    }
                    
                    Debug.Log("Does it work?!??");
                    if (ropeAmt > 0 ||  RopeMove && openShop)
                    {
                        openShop = false;  
                    }
                    
                    if (ropeAmt > 0 || RopeMove)
                    {  
                        if (hit_Info.collider.tag == "Dirt" )
                        {
                            ropeAmt--;
                            XPSlider.Brain.AddXP();
                        }
                        ropeText.text = ropeAmt.ToString();
                        this.transform.Translate(xLeft, 0, 0);
                        openShop = false;
                        RopeMove = false;

                    }
                }
            }
        }
    }

    public void swipeRight()
    {
        if (canMove)
        {
            Debug.DrawRay(transform.position,transform.right* 5f);
            
            Ray ray = new Ray(this.transform.position, transform.right);
            if (Physics.Raycast(ray,out hit_Info,1f))
            {
                if (hit_Info.collider.tag == "Dirt" || hit_Info.collider.tag == "Destroyed" )
                {
                    if ( hit_Info.collider.tag == "Destroyed")
                    {
                        RopeMove = true;
                    }
                    
                    if (ropeAmt > 0 || RopeMove && openShop)
                    {
                        openShop = false;  
                    }
                    Debug.Log("Does it work?!??");
                    
                    if (ropeAmt > 0 || RopeMove)
                    {  
                        if (hit_Info.collider.tag == "Dirt" )
                        {
                            ropeAmt--;
                            XPSlider.Brain.AddXP();
                        }
                        ropeText.text = ropeAmt.ToString();
                        this.transform.Translate(xRight, 0, 0);
                        openShop = false;
                        RopeMove = false;

                    }
                    
                }
            }
        }
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.collider.CompareTag("Dirt"))
        {
            other.gameObject.tag = "Destroyed";
            other.gameObject.GetComponent<Renderer>().enabled = false;
            canMove = true;
            //Destroy(other.gameObject);
            Debug.Log("Tried to destroy");
        }
        /*
        else
        {
            canMove = false;
        }
        */
    }

   void Shop()
   {
       openShop = true;
   }

   void Museum()
   {
       openMuseum = true;
   }

   void OnGUI()
   {
       if (openShop)
       {
           GUI.backgroundColor = new Color(0,0,0,0);
           GUI.DrawTexture(new Rect(100, 100, 900, 2000), aTexture, ScaleMode.ScaleToFit, true, 0.0F);

           if (GUI.Button(new Rect(250, 390, 128, 128), btnTextures[0]))
               addRope(6); 
               if (GUI.Button(new Rect(400, 390, 128, 128), btnTextures[1]))
                   Debug.Log("Clicked the button with an Image1");
               if (GUI.Button(new Rect(550, 390, 128, 128), btnTextures[2]))
                   Debug.Log("Clicked the button with an Image1");
               if (GUI.Button(new Rect(700, 390, 128, 128), btnTextures[3]))
                   Debug.Log("Clicked the button with an Image1");
           

        
               if (GUI.Button(new Rect(250, 740, 128, 128), btnTextures[4]))
                   Debug.Log("Clicked the button with an Image1");
               if (GUI.Button(new Rect(400, 740, 128, 128), btnTextures[5]))
                   Debug.Log("Clicked the button with an Image1");
               if (GUI.Button(new Rect(550, 740, 128, 128), btnTextures[6]))
                   Debug.Log("Clicked the button with an Image1");
               if (GUI.Button(new Rect(700, 740, 128, 128), btnTextures[7]))
                   Debug.Log("Clicked the button with an Image1");
           

          
               if (GUI.Button(new Rect(250, 1100, 128, 128), btnTextures[8]))
                   Debug.Log("Clicked the button with an Image1");
               if (GUI.Button(new Rect(400, 1100, 128, 128), btnTextures[9]))
                   Debug.Log("Clicked the button with an Image1");
               if (GUI.Button(new Rect(550, 1100, 128, 128), btnTextures[10]))
                   Debug.Log("Clicked the button with an Image1");
               if (GUI.Button(new Rect(700, 1100, 128, 128), btnTextures[11]))
                   Debug.Log("Clicked the button with an Image1");
           
    
       }
        if (openMuseum)
       {
           GUI.backgroundColor = new Color(0,0,0,0);
           GUI.DrawTexture(new Rect(100, 100, 900, 2000), aTexture2, ScaleMode.ScaleToFit, true, 0.0F);
          
               if (GUI.Button(new Rect(250, 390, 128, 128), btnTextures2[0]))
                   Debug.Log("Clicked the button with an Image1");
               if (GUI.Button(new Rect(400, 390, 128, 128), btnTextures2[1]))
                   Debug.Log("Clicked the button with an Image1");
               if (GUI.Button(new Rect(550, 390, 128, 128), btnTextures2[2]))
                   Debug.Log("Clicked the button with an Image1");
               if (GUI.Button(new Rect(700, 390, 128, 128), btnTextures2[3]))
                   Debug.Log("Clicked the button with an Image1");
           

        
               if (GUI.Button(new Rect(250, 740, 128, 128), btnTextures2[4]))
                   Debug.Log("Clicked the button with an Image1");
               if (GUI.Button(new Rect(400, 740, 128, 128), btnTextures2[5]))
                   Debug.Log("Clicked the button with an Image1");
               if (GUI.Button(new Rect(550, 740, 128, 128), btnTextures2[6]))
                   Debug.Log("Clicked the button with an Image1");
               if (GUI.Button(new Rect(700, 740, 128, 128), btnTextures2[7]))
                   Debug.Log("Clicked the button with an Image1");
           

          
               if (GUI.Button(new Rect(250, 1100, 128, 128), btnTextures2[8]))
                   Debug.Log("Clicked the button with an Image1");
               if (GUI.Button(new Rect(400, 1100, 128, 128), btnTextures2[9]))
                   Debug.Log("Clicked the button with an Image1");
               if (GUI.Button(new Rect(550, 1100, 128, 128), btnTextures2[10]))
                   Debug.Log("Clicked the button with an Image1");
               if (GUI.Button(new Rect(700, 1100, 128, 128), btnTextures2[11]))
                   Debug.Log("Clicked the button with an Image1");
           
               //Slider
               //vSliderValue = GUI.HorizontalSlider(new Rect(25, 25, 100, 30), vSliderValue, 0.0f, 10.0f, btnTextures[1], btnTextures[2]);
               /*
               textureIndex =
                   (int)GUI.HorizontalSlider(
                       new Rect(25, 70, 100, 30),
                       textureIndex,
                       0,
                       sliderTextures.Length-1);
 
               GUI.DrawTexture(
                   new Rect(10, 10, 60, 60),
                   sliderTextures[textureIndex],
                   ScaleMode.ScaleToFit,
                   true,
                   10.0F);
                   */
    
       }

   }

   private void addRope(int amt)
   {
       ropeAmt = ropeAmt + amt;
       ropeText.text = ropeAmt.ToString();

   }
   
   


}


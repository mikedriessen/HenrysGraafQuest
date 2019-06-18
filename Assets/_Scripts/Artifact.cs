using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Artifact : MonoBehaviour
{

    public Text countText;
    public int count;

    private void Start()
    {
        countText.text =  count.ToString();
    }

    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                
                //nee

            if (hit.collider.CompareTag("Artifact"))
            {
                
                Debug.Log("ARTIFACT");
                hit.collider.gameObject.SetActive(false);
                count++;
                SetCountText();
            }
            }
        }
    }

    void SetCountText()
    {
        countText.text = count.ToString();
    }

    void Score()
    {
        if (count == 1)
        {
            Debug.Log("WOW MOOI MAN");
        }
    }
}
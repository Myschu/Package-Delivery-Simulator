using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Get_Position : MonoBehaviour
{

    private Canvas thisCanvas;
    private GameObject thisObject,anchorPoint, UI_Image_DOWN, UI_Image_UP, UI_Image_LEFT, UI_Image_RIGHT;
    private GameObject[] UI_Directions;
    private GameObject truck;
    private Vector3 original;
    
    // Start is called before the first frame update
    void Start()
    {


        


        truck = GameObject.FindGameObjectWithTag("Truck");

        if (truck!= null ) original = truck.transform.position;
        thisObject = GameObject.FindGameObjectWithTag("Map");
        anchorPoint = GameObject.FindGameObjectWithTag("Node");
        UI_Directions = GameObject.FindGameObjectsWithTag("UI_Directions");
        Debug.Log(UI_Directions.Length);

       


        foreach (GameObject e in UI_Directions)
        {
            
            if (e.name == "Right Arrow") { UI_Image_RIGHT = e;
                Debug.Log("Success for " + e.name);
            }
            if (e.name == "Left Arrow") { UI_Image_LEFT = e;
                Debug.Log("Success for " + e.name);
            }
            if (e.name == "Up Arrow") { UI_Image_UP = e;
                Debug.Log("Success for " + e.name);
            }        
            if (e.name == "Down Arrow") { UI_Image_DOWN = e;
                Debug.Log("Success for " + e.name +" "+ e.transform.position);
            }

        }



        Debug.Log(thisObject.transform.position);

        if (truck != null)
        {
            Debug.Log("Made it here");
            thisObject.transform.position = truck.transform.position;
        }
        else
        {
            Debug.Log("Did not make it here");
            //thisObject.transform.position = anchorPoint.transform.position;
        }

        Debug.Log(thisObject.transform.position);
        Debug.Log(UI_Image_DOWN.transform.position);



        UI_Image_DOWN.transform.position = thisObject.transform.position + new Vector3(0, -60, 0);
        UI_Image_UP.transform.position = thisObject.transform.position + new Vector3(0, 60, 0);
        UI_Image_LEFT.transform.position = thisObject.transform.position + new Vector3(-60, 0, 0);
        UI_Image_RIGHT.transform.position = thisObject.transform.position + new Vector3(60, 0, 0);


        //Debug.Log(UI_Image_.transform.position);

    }


    // Update is called once per frame
    void Update()
    {
        if (truck != null)
        {
            if (!(truck.transform.Equals(original)) && truck.GetComponent<Rigidbody>().velocity.Equals(new Vector3(0, 0, 0)))
            {
                //Start();
            }
        }
    }
}

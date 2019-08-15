/*GetPosition
 * 
 * Handler for loading UI arrows into correct position
 * 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Get_Position : MonoBehaviour
{
    //Local variables
        private GameObject anchorPoint, UI_Image_DOWN, UI_Image_UP, UI_Image_LEFT, UI_Image_RIGHT;
        private GameObject[] UI_Directions;
    
    // Start is called before the first frame update
    void Start()
    {
        anchorPoint = GameObject.FindGameObjectWithTag("Node");
        UI_Directions = GameObject.FindGameObjectsWithTag("UI_Directions");

        //Assign each object
        foreach (GameObject e in UI_Directions)
        {
            if (e.name == "Right Arrow")
            {
                UI_Image_RIGHT = e;
                //Debug.Log("Success for " + e.name);
            }
            if (e.name == "Left Arrow")
            {
                UI_Image_LEFT = e;
                //Debug.Log("Success for " + e.name);
            }
            if (e.name == "Up Arrow")
            {
                UI_Image_UP = e;
               // Debug.Log("Success for " + e.name);
            }
            if (e.name == "Down Arrow")
            {
                UI_Image_DOWN = e;
                //Debug.Log("Success for " + e.name + " " + e.transform.position);
            }

        }

        UI_Image_DOWN.transform.position = anchorPoint.transform.position + new Vector3(0, -60, 0);
        UI_Image_UP.transform.position = anchorPoint.transform.position + new Vector3(0, 60, 0);
        UI_Image_LEFT.transform.position = anchorPoint.transform.position + new Vector3(-60, 0, 0);
        UI_Image_RIGHT.transform.position = anchorPoint.transform.position + new Vector3(60, 0, 0);

        /*Debugging 

        Debug.Log(UI_Directions.Length);
        
             */
    }


   
}

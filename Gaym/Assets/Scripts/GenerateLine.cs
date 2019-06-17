using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GenerateLine : MonoBehaviour
{

    private LineRenderer line_renderer;
    private float counter;
    private float distance;


    public Transform origin;
    public Transform destination;
    public GameObject button;

  

    void Start()
    {
        //Uncaching component
        //Essentially avoids overhead
        line_renderer = GetComponent<LineRenderer>();
        //        this.transform.SetPositionAndRotation(origin.position, new Quaternion());
        line_renderer.positionCount = 2;
        line_renderer.SetPosition(0, new Vector2(origin.position.x,origin.position.y));
        
       



    }

    // Start is called before the first frame update
    void Update()
    {
       
        if (button.GetComponent<Toggle>().isOn)
        //if (Input.GetKeyDown("space"))
         {
           // Debug.Log("Should be drawing this damn line");
            line_renderer.SetPosition(1, new Vector2(destination.position.x, destination.position.y));
        }
        else
        {
            line_renderer.SetPosition(1, new Vector2(origin.position.x, origin.position.y));
        }
        
        /*
        if(Input.GetKeyDown("space"))
        {
            //if (button.GetComponent<Toggle>().isOn) { Debug.Log("is on"); }
            //if (!(button.GetComponent<Toggle>().isOn)) { Debug.Log("is off"); }
            Debug.Log(origin.position.x);
            Debug.Log(origin.position.y);
            Debug.Log(origin.position.z);
            Debug.Log(destination.position.x);
            Debug.Log(destination.position.y);
            Debug.Log(destination.position.z);

        }
        */

    }



}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class pathMark : MonoBehaviour
{
    public GameObject Node1, Node2; //The two nodes surrounding path to be toggled
    public GameObject path; //Path that is being toggled

    //Upon method call checks if 3 objects exist, then if both nodes are active, then path gets toggled
    //(Pretty sure we need to work out the exact logic, since off the top of my head I can think of several cases where this won't work, but at least the groundwork is there)
    public void activate()
    {
        if (Node1 != null 
            && Node2 != null
            && path != null)
        {
            if (Node1.activeSelf && Node2.activeSelf)
            {
                bool isActive = path.activeSelf;

                path.SetActive(!isActive);
            }
        }
    }
}
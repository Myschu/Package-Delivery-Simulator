using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow_Click: MonoBehaviour
{


    public void OnClicked()
    {
        GameObject truck = GameObject.FindGameObjectWithTag("Truck");
        string direction = "";

        if (this.name == "Down Arrow") { direction = "down"; Debug.Log("down"); }
        if (this.name == "Up Arrow") direction = "up";
        if (this.name == "Left Arrow") direction = "left";
        if (this.name == "Right Arrow") direction = "right";



        if (truck != null)
        {
            if (PathFollow.count <= 1)
            {
                PathFollow.getDirection(direction);
            }
            else
            {
                Debug.Log("How many time am I printing");
            }
        }


    }
}

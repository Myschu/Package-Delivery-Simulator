using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow_Click: MonoBehaviour
{


    bool click = false;
    public void OnClicked()
    {
        
        GameObject truck = GameObject.FindGameObjectWithTag("Truck");
        Rigidbody2D movement = truck.GetComponent<Rigidbody2D>(); 
        string direction = "";

        if (this.name == "Down Arrow" && !click) {
            Debug.Log("Hey I'm trying to move this goddamn truck");
            click = true;
            movement.MovePosition(new Vector2(0, 60));

            Debug.Log("down"); }
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
        click = false; 

    }
}

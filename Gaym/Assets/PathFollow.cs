/**
 * Script containing logic for pathing of player game object (referred to as truck) 
 * 
 * 6-20-2019 : 
 *  -Added logic for retrieving the positions of a LineRenderer object that was generated a scene prior
 *  -Relies on the LineRenderer object being not destroyed over scene transition
 *  -Relies on there existing only one active LineRenderer object at any given time
 * 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFollow : MonoBehaviour
{

    private Vector3[] target;
    private int line_points;
    private LineRenderer Line; 

    //Might need to find some way to calculate this later on
    public float speed;


    //Counter that increments each node/position truck traverses
    private int current=0;

    
    //De-caches LineRenderer generated positions by creating an array of positions for truck to follow
    void Start()
    {
        //Local reference to LineRenderer object that was not deleted from scene transition
        Line = Object.FindObjectOfType<LineRenderer>();

        //# of points since GetPositions requires an array parameter with a specific size.
        line_points = Line.positionCount;

        //Local array for truck to follow
        target = new Vector3[line_points];

        //Method for retrieving positions of generated line
        Line.GetPositions(target);
    }
    
    // Update is called once per frame
    void Update()
    {
        //When truck reaches end of path
        if (current == target.Length) {
            speed = 0;
            //Any additional logic that needs to occur after truck reaches destination node goes here
        }
        //Converts vector3 positions to vector2. Vector3 positions don't work for some reason.
        else
        {
            Vector2 this_pos = new Vector2(transform.position.x, transform.position.y);
            Vector2 target_pos = new Vector2(target[current].x, target[current].y);
            if (this_pos != target_pos)
            {
                Vector2 pos = Vector2.MoveTowards(this_pos, target_pos, 10 * speed * Time.deltaTime);
                GetComponent<Rigidbody2D>().MovePosition(pos);
            }
            else current = (current + 1);
        }
    
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFollow : MonoBehaviour
{

    public Transform[] target;

    public float speed;

    private int current=0;

    
    
    // Update is called once per frame
    void Update()
    {
        if (current == target.Length) { speed = 0; }
        else
        {
            Vector2 this_pos = new Vector2(transform.position.x, transform.position.y);
            Vector2 target_pos = new Vector2(target[current].position.x, target[current].position.y);
            if (this_pos != target_pos)
            {
                Vector2 pos = Vector2.MoveTowards(this_pos, target_pos, 10 * speed * Time.deltaTime);
                GetComponent<Rigidbody2D>().MovePosition(pos);
            }
            else current = (current + 1);
        }
    
    }
}

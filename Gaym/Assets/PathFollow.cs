using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFollow : MonoBehaviour
{
    private GameObject Map;
    private List<GameObject> last_travelled_list;
    private List<Transform> target;

    public float speed;

    private int current=0;

    void Start()
    {
        Map = GameObject.FindGameObjectWithTag("Map");
        Map map = Map.GetComponent<Map>();
        last_travelled_list = map.LastSelected;
    }
    
    
    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < last_travelled_list.Count; i++)
        {
            target[i] = last_travelled_list[i].GetComponent<Transform>();
            
        }

        if (Input.GetKeyDown("space"))
        {
            int i = 0;
            foreach (Transform x in target){

                Debug.Log("Target[" + i + "] x pos = " + x.position.x);
                Debug.Log("Target[" + i + "] y pos = " + x.position.y);
                Debug.Log("Target[" + i + "] z pos = " + x.position.z);
                i++;
            }
        } 

        if (current == target.Count) { speed = 0; }
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

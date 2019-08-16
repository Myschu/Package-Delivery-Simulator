using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*PathTime
 * 
 * Estimates route travel time based on Nodes inside of LastSelected List created in "Map"
 * and places result into text box
 * 
 */

public class PathTime : MonoBehaviour
{
    
    public Text Time;
    private int time = 0;
    public GameObject Map;
    void Start()
    {
        Time = GetComponent<Text>();
        Map = GameObject.FindGameObjectWithTag("Map");
    }
    void Update()
    {
        time = 0;
        Map map = Map.GetComponent<Map>();
        if(map.LastSelected.Count == 0 || map.LastSelected.Count == 1)
        {
            Time.text = "Route not selected/valid"; //Routes of only 1 or no nodes does not count as a valid route
        }
        else
        {
            foreach (int index in map.LastSelected)
            {
                time += 30; //Each path traveled has a base time taken of 30 minutes (not including deliveries)
            }
            time -= 30;
            Time.text = "Route travel time (not including deliveries): " + time + " minutes";
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PathTime : MonoBehaviour
{
    /*
    public GameObject[] paths;
    public GameObject Map;
    public int time;
    void Start()
    {
        paths = GameObject.FindGameObjectsWithTag("Path");
    }

    // Update is called once per frame
    void Update()
    {
        Map map = Map.GetComponent<Map>();
    }
    */
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
            Time.text = "Route not selected/valid";
        }
        else
        {
            foreach (int index in map.LastSelected)
            {
                time += 30;
            }
            time -= 30;
            Time.text = "Route travel time (not including deliveries): " + time + " minutes";
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GenerateLine : MonoBehaviour
{

    private LineRenderer line_renderer;
    private float counter;
    private float distance;

    private GameObject Map;
    private List<GameObject> last_travelled_list;
    public string[] list_as_string;
    private bool sceneChanged = false;

    public Transform origin;
    //public Transform destination;
    //public GameObject button;

    public void sceneChange()
    {
        sceneChanged = true;
    }
  
    void Start()
    {
        line_renderer = GetComponent<LineRenderer>();
        line_renderer.SetPosition(0, origin.position);

    }

    // Start is called before the first frame update
    void Update()
    {
        if (!sceneChanged)
        {
            Map = GameObject.FindGameObjectWithTag("Map");
            Map map = Map.GetComponent<Map>();
            last_travelled_list = map.LastSelected;

            list_as_string = new string[last_travelled_list.Capacity];

            int p = 0;

            foreach (GameObject Node in last_travelled_list)
            {
                list_as_string[p++] = Node.name;
            }



            if (Input.GetKeyDown("k"))
            {
                for (int k = 0; k < list_as_string.Length; k++)
                {
                    Debug.Log(list_as_string[k]);

                }
            }


            //Uncaching component
            //Essentially avoids overhead

            //        this.transform.SetPositionAndRotation(origin.position, new Quaternion());
            line_renderer.positionCount = last_travelled_list.Count;
            int count = last_travelled_list.Count;

            if (Input.GetKeyDown("space")) Debug.Log("Number  = " + count);
            for (int i = 0; i < last_travelled_list.Count; i++)
            {
                if (last_travelled_list[i].GetComponent<Toggle>().isOn)
                {
                    line_renderer.SetPosition(i, last_travelled_list[i].transform.position);
                }

            }
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Houses : MonoBehaviour
{
    public string TagName = "House";
    public GameObject[] House_List;
    private void Start()
    {
        

        GameObject[] temp = GameObject.FindGameObjectsWithTag(TagName);
        House_List = new GameObject[temp.Length];
        int iterate = 0;
        while (iterate < House_List.Length)
        {
            foreach (GameObject node in temp)
            {
                if (node.GetComponent<House_Trigger>().order == iterate)
                {
                    House_List[iterate] = node;
                }
            }
            iterate++;
        }


        DontDestroyOnLoad(this);
    }
}

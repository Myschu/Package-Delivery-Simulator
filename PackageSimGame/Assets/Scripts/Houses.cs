using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Houses : MonoBehaviour
{
    public string TagName = "House";
    public GameObject[] House_List;
    private void Start()
    {
        House_List = GameObject.FindGameObjectsWithTag(TagName);
        DontDestroyOnLoad(this);
    }
}

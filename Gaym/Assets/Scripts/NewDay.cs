using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewDay : MonoBehaviour
{

    public Text Today;
    void Start()
    {
        Today = GetComponent<Text>();
        Today.text = "Day " + DayCount.Instance.Day;
    }

}

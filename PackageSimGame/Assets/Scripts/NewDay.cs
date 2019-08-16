using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Script linked to text box in "Today" to show current money balance

public class NewDay : MonoBehaviour
{

    public Text Today;
    void Start()
    {
        Today = GetComponent<Text>();
        Today.text = "Day " + DayCount.Instance.Day + "\n" + "Current Balance: " + Money.Instance.money;
    }

}

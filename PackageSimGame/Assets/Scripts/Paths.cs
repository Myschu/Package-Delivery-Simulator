using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paths : MonoBehaviour
{
    public int time_takes = 30;
    static string[] conditions = { "none", "traffic", "construction", "dogs"};
    public string condition;
    void Start()
    {
        int conditionRoll = roll_condition();
        condition = conditions[conditionRoll];
        if (condition == "traffic")
        {
            time_takes += 10;
        }
        else if (condition == "construction")
        {
            time_takes += 15;
        }
        else if (condition == "dogs")
        {
            time_takes += 5;
        }
    }
    private int roll_condition()
    {
        int roll = Random.Range(1, 101);
        if (roll < 71)
        {
            return 0;
        }
        else if (roll < 93)
        {
            return 1;
        }
        else if (roll < 96)
        {
            return 2;
        }
        else
        {
            return 3;
        }
    }
}

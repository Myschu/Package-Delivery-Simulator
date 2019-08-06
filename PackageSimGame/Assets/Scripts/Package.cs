using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Package
{

    static string[] types = { "letter", "package", "heavy package" };
    static string[] conditions = { "none", "requires signature", "is fragile", "requires signature and is fragile" };

    private string type;
    private string condition;
    private int cost = 0;
    private int extraTime = 0;
    private GameObject destination;


    public string getType()
    {
        return type;
    }
    public string getCondition()
    {
        return condition;
    }
    public int getCost()
    {
        return cost;
    }
    public int getExtraTime()
    {
        return extraTime;
    }


    public void Generate()
    {
        int typeRoll = roll_type();
        int conditionRoll = roll_condition(typeRoll);

        type = types[typeRoll];
        condition = conditions[conditionRoll];

        //destination = 
        if (type == "letter")
        {
            cost += 1;

        }
        else if (type == "package")
        {
            cost += 4;
        }
        else if (type == "heavy package")
        {
            cost += 10;
            extraTime += 15;
        }
        if (condition == "requires signature")
        {
            cost += 3;
            extraTime += 5;
        }
        else if (condition == "is fragile")
        {
            cost += 3;
            extraTime += 10;
        }
    }


    private int roll_type()
    {
        int roll = Random.Range(1, 101);

        if (roll < 71)
        {
            return 0;
        }
        else if (roll < 91)
        {
            return 1;
        }
        else
        {
            return 2;
        }
    }

    private int roll_condition(int type_roll)
    {
        int roll = Random.Range(1, 101);


        if (type_roll == 2)
        {
            return 3;
        }
        else if (roll < 61)
        {
            return 0;
        }
        else if (roll < 91)
        {
            return 1;
        }
        else
        {
            return 2;
        }
    }

    public string get_type()
    {
        return type;
    }
    public string get_condition()
    {
        return condition;
    }
    public string get_cost()
    {
        return cost.ToString();
    }
}

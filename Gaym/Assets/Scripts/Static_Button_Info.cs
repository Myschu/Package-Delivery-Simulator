using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Static_Button_Info 
{
    private static bool up, down, left, right;


    public static void setInfo(string name)
    {
        if (name == "up") up = true;
        if (name == "down") down = true;
        if (name == "left") left = true;
        if (name == "right") right = true;
    }


    public static bool Up
    {
        get { return up; }
        set { up = value; }
    }
    public static bool Down
    {
        get { return down; }
        set { down = value; }
    }
    public static bool Left
    {
        get { return left; }
        set { left = value; }
    }
    public static bool Right
    {
        get { return right; }
        set { right = value; }
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Static_Button_Info 
{
    private static bool up, down, left, right;


    public static void setInfo(string name)
    {
        if (name == "Up Arrow")
        {
            up = true;
            down = false;
            left = false;
            right = false;
        }
        if (name == "Down Arrow") {
            up = false;
            down = true;
            left = false;
            right = false;
        }
        if (name == "Left Arrow") {
            up = false;
            down = false;
            left = true;
            right = false;
        }
        if (name == "Right Arrow") {
            up = false;
            down = false;
            left = false;
            right = true;
        }
        if (name == "reset")
        {
            up = false;
            down = false;
            left = false;
            right = false;
        }
   

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

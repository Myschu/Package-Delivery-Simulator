using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Singleton used to keep track of the day, and used to signal certain checkpoints within the game (most notably the time limit)

public class DayCount : Singleton<DayCount>
{
    public int Day = 1;
}

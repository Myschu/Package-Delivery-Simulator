using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Singleton used to keep track of amount of money balance after gains/losses

public class Money : Singleton<Money>
{
    public int money = 100;
}

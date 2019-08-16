using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Code used to generate text on the "Game_Over" or "Winning" scene containing the amount of money lost/gained over the course of the run

public class End_Stats : MonoBehaviour
{
    public Text End;
    void Start()
    {
        End = GetComponent<Text>();
        End.text = "Total Rent Paid: " + Rent.Instance.rent + "\n" + "Total Daily Expenses Paid: " + Daily.Instance.daily_expenses + "\n" + "Final Balance: " + Money.Instance.money + "\n Total moves: " + Moves.Instance.moves ;
    }
}

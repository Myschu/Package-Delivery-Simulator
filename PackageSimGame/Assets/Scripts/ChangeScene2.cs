using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene2 : MonoBehaviour
{
    void Start()
    {
        GameObject text = GameObject.FindGameObjectWithTag("House_Pathing_Object");

        Object.Destroy(text);
        SceneManager.LoadScene("Reset_Button", LoadSceneMode.Additive);

        SceneManager.LoadScene("Moves", LoadSceneMode.Additive);
    }
    public void ChangeToScene(string SceneToChangeTo)
    {
        SceneManager.LoadScene(SceneToChangeTo, LoadSceneMode.Single);
        DayCount.Instance.Day += 1;
        Money.Instance.money -= 8;
        Rent.Instance.rent += 3;
        Daily.Instance.daily_expenses += 20;

        if (DayCount.Instance.Day % 7 == 0)
        {
            //Money.Instance.money -= 100;
            SceneManager.LoadScene("Game_Over", LoadSceneMode.Single);
        }


        if (Money.Instance.money <= 0)
        {
            SceneManager.LoadScene("Game_Over", LoadSceneMode.Single);
        }
        if (Money.Instance.money >= 150)
        {
            SceneManager.LoadScene("Winning", LoadSceneMode.Single);
        }
        Debug.Log(DayCount.Instance.Day);
    }
}
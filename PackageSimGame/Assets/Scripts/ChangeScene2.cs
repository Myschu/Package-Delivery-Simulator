using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene2 : MonoBehaviour
{
    public void ChangeToScene(string SceneToChangeTo)
    {
        SceneManager.LoadScene(SceneToChangeTo, LoadSceneMode.Single);
        DayCount.Instance.Day += 1;
        Money.Instance.money -= 20;
        if (DayCount.Instance.Day % 7 == 0)
        {
            Money.Instance.money -= 100;
        }
        Debug.Log(DayCount.Instance.Day);
        GenerateLine thisLine = Object.FindObjectOfType<GenerateLine>();
        Destroy(thisLine);
    }
}
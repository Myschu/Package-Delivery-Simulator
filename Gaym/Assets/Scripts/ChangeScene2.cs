using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene2 : MonoBehaviour
{
    public void ChangeToScene(string SceneToChangeTo)
    {
        SceneManager.LoadScene(SceneToChangeTo, LoadSceneMode.Single);
        GameObject.Destroy(GameObject.FindGameObjectWithTag("Map"));
        DayCount.Instance.Day += 1;
        Debug.Log(DayCount.Instance.Day);
        GenerateLine thisLine = Object.FindObjectOfType<GenerateLine>();
        Destroy(thisLine);
    }
}
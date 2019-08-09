using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{

    void Start()
    {
        
            SceneManager.LoadScene("Reset_Button", LoadSceneMode.Additive);
            SceneManager.LoadScene("Moves", LoadSceneMode.Additive);
        
    }

    private GenerateLine thisLine;
    private GameObject[] houses;
    public void ChangeToScene (string SceneToChangeTo)
    {
        //houses = GameObject.FindGameObjectsWithTag("House");
        //thisLine = Object.FindObjectOfType<GenerateLine>();
        //thisLine.sceneChange();
        //DontDestroyOnLoad(thisLine);
        /*
        foreach (GameObject x in houses)
        {
            DontDestroyOnLoad(x);
        }
        */
        GameObject housePathing = GameObject.FindGameObjectWithTag("House_Pathing_Object");
        DontDestroyOnLoad(housePathing);
        SceneManager.LoadScene(SceneToChangeTo, LoadSceneMode.Single); // Supposed to delete previous scene and load new one. Does not do so properly at the moment. Currently adds new scene on top of previous scene.

    }
}

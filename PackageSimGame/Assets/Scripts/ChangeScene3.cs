using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene3 : MonoBehaviour
{
    void Start()
    {
        bool resetExists = false;
        for (int i = 0; i < SceneManager.sceneCount; i++)
        {
            if (SceneManager.GetSceneAt(i).name == "Reset_Button")
            {
                resetExists = true;
            }
        }
        Debug.Log(resetExists);
        if (!resetExists)
        {
            SceneManager.LoadScene("Reset_Button", LoadSceneMode.Additive);
        }
    }
    public void ChangeToScene(string SceneToChangeTo)
    {
        SceneManager.LoadScene(SceneToChangeTo, LoadSceneMode.Single);
        //SceneManager.LoadScene("Houses_Planning", LoadSceneMode.Additive);
        
            SceneManager.LoadScene("Houses_Pathing", LoadSceneMode.Additive);
           // PackageList.hasList = true;
        
        
    }
}

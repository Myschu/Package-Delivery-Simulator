﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{

    //private GameObject LineRender;
    private GenerateLine thisLine;

    public void ChangeToScene (string SceneToChangeTo)
    {
        //LineRender = GameObject.FindGameObjectWithTag("Line");

        thisLine = Object.FindObjectOfType<GenerateLine>();
        thisLine.sceneChange();
        //DontDestroyOnLoad(LineRender);
        DontDestroyOnLoad(thisLine);
        SceneManager.LoadScene(SceneToChangeTo, LoadSceneMode.Single); // Supposed to delete previous scene and load new one. Does not do so properly at the moment. Currently adds new scene on top of previous scene.
    }
}

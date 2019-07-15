using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    private GenerateLine thisLine;
    //private PackageList package_list;
    private GenerateDeliveries deliveries;
    //private Map map;
    private Text text;

    public void ChangeToScene (string SceneToChangeTo)
    {
        //map = Object.FindObjectOfType<Map>();
        //package_list = Object.FindObjectOfType<PackageList>();
        text = Object.FindObjectOfType<Text>();

        Debug.Log("The text here is : "+text.text);
        thisLine = Object.FindObjectOfType<GenerateLine>();
        deliveries = Object.FindObjectOfType<GenerateDeliveries>();
        thisLine.sceneChange();
        DontDestroyOnLoad(text);
        DontDestroyOnLoad(thisLine);
        //DontDestroyOnLoad(package_list);
        DontDestroyOnLoad(deliveries);
        SceneManager.LoadScene(SceneToChangeTo, LoadSceneMode.Single); // Supposed to delete previous scene and load new one. Does not do so properly at the moment. Currently adds new scene on top of previous scene.
    }
}

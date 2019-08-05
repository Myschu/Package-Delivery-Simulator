using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Return : MonoBehaviour
{
    public void OnClick(string SceneName)
    {
        SceneManager.UnloadSceneAsync(SceneName);
    }

    public void loadScene(string SceneName)
    {
        SceneManager.LoadScene(SceneName, LoadSceneMode.Additive);

    }
}

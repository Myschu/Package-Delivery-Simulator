using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DirectionalArrows : MonoBehaviour
{
    public void ChangeToScene(string toChange)
    {
        SceneManager.LoadScene(toChange, LoadSceneMode.Additive);
    }
}

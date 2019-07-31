using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadArrows : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        SceneManager.LoadScene("Choose_Direction", LoadSceneMode.Additive);
        SceneManager.LoadScene("Houses_Pathing", LoadSceneMode.Additive);
    }

}

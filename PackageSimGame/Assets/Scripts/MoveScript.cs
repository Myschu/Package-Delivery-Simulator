using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoveScript : MonoBehaviour
{

    public Text moves;

    void Start()
    {
        //DontDestroyOnLoad(moves);
    }
    void Update()
    {
        moves.text = "Total Moves:\n" + Moves.Instance.moves;
    }

}

/*MoveScript
 * 
 * Updates move counter to show player how many moves they have made
 * 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoveScript : MonoBehaviour
{

    public Text moves;
    
    void Update()
    {
        moves.text = "Total Moves:\n" + Moves.Instance.moves;
    }

}

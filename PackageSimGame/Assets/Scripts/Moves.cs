/*Moves
 * 
 * Singleton used to count total number of moves player has made over course of game
 * 
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moves : Singleton<Moves>
{
    public int moves = 0;
   
}

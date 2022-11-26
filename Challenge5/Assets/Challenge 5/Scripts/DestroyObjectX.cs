/* 
 * Zach Wilson
 * Assignment 8
 * This script manages the destruction of partilces
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObjectX : MonoBehaviour
{
    void Start()
    {
        Destroy(gameObject, 2); // destroy particle after 2 seconds
    }


}

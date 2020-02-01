using 
    System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager
{
    public static bool IsValidKey()
    {
        if(Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Q) ||
            Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.E) ||
            Input.GetKeyDown(KeyCode.R) || Input.GetKeyDown(KeyCode.T) ||
            Input.GetKeyDown(KeyCode.Y) || Input.GetKeyDown(KeyCode.U) ||
            Input.GetKeyDown(KeyCode.I))
        {
            return true;
        }

        return false;
    }
}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Rough class to allow unfocusing/focussing mouse cursor easier
public class GameWindowFocus : MonoBehaviour
{
    bool outOfFocusMode;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        if (outOfFocusMode || Input.GetKeyDown(KeyCode.Escape))
        {
            outOfFocusMode = true;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            // wait until mouse click reactivate
            if (Input.GetMouseButtonDown(0))
            {
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
            }

        }
    }

    void OnApplicationFocus(bool hasFocus)
    {
        if (hasFocus)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = true;
            outOfFocusMode = false;
        }
        else
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }
}

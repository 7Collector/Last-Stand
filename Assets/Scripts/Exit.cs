using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exit : MonoBehaviour
{
    public void ExitGame()
    {
        // Quit the application (only works in standalone builds, not in the Unity editor)
        Application.Quit();
    }
}

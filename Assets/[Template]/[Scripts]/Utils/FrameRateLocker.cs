using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrameRateLocker : MonoBehaviour
{
    
    public int TargetFrameRate = 240;
    public int TargetRefreshRate = 240;
    private void Awake()
    {
        Screen.SetResolution(Screen.height, Screen.width, FullScreenMode.FullScreenWindow, TargetRefreshRate);
        Application.targetFrameRate = TargetFrameRate;
    }
}

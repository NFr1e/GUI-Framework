using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrameRateLocker : MonoBehaviour
{
    
    public int TargetFrameRate = 240;

    private void Awake()
    {
        Application.targetFrameRate = TargetFrameRate;
    }
}

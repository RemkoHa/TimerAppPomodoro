using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowedResolution : MonoBehaviour {

    void Awake()
    {
        Screen.SetResolution(320, 320, false);
    }
}

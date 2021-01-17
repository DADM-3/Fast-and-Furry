using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Gyroscope gyroscope;

    private void Awake()
    {
        //gyroscope.enabled = true;
    }

    void Start()
    {

    }

    void Update()
    {
        Debug.Log(SystemInfo.supportsGyroscope);
    }
}

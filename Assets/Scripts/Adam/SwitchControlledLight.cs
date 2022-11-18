using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Scripts;

public class SwitchControlledLight : MonoBehaviour, ISwitch
{
    [SerializeField] private Animator keyLight;

    public void Switch(bool inLight)
    {
        Debug.Log("Light Switch Trigger");
        keyLight.SetBool("SwitchState", inLight);
    }

    /*private void FixedUpdate()
    {
        var switchState = keyLight.GetBool("SwitchState");

        if (switchState)
        {
            keyLight.SetBool("SwitchState", false);
        }
    }*/


    /*private void FixedUpdate()
    {
        if (inLight)
        {
            Debug.Log("Player in light");
        }
        else
        {
            Debug.Log("Player dead");
        }

        inLight = false;
    }*/
}


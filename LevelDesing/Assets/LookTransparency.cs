﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookTransparency : MonoBehaviour
{
    public GameObject FrontObject;


    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag == "Player")
            FrontObject.gameObject.SetActive(false);    
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
            FrontObject.gameObject.SetActive(true);
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    public void OnTriggerEnter(Collider other)
    {
        Destroy(GameObject.FindGameObjectWithTag("mob"));
    }
}
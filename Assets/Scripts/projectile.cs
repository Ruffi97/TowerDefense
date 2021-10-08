using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectile : MonoBehaviour
{
    public void OnTriggerEnter(Collider other)
    {
        Destroy(GameObject.FindGameObjectWithTag("mob"));
        Destroy(this);
    }
}

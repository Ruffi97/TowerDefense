using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private GameObject target;
    private float speed = 50f;

    void Update()
    {
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }
        Vector3 dir = target.transform.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = lookRotation.eulerAngles;
        transform.rotation = Quaternion.Euler(0f, rotation.y, 0f);
        float DistancePerFrame = speed * Time.deltaTime;

        if(dir.magnitude <= DistancePerFrame)
        {
            Hit();
            return;
        }

        transform.Translate(dir.normalized * DistancePerFrame, Space.World);
    }
    public void ResearchTarget(GameObject _target)
    {
        target = _target;
    }

    private void Hit()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
    }
}
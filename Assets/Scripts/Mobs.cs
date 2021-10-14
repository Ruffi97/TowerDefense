using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Mobs : MonoBehaviour
{
    GameObject _goal;
    private Vector3 _dest;
    public NavMeshAgent agent;
    private int health = 4;
    void Start()
    {
        _goal = GameObject.FindGameObjectWithTag("goal");
        _dest = _goal.transform.position;
        
    }
    
    void Update()
    {
        agent.destination = _dest;
        if(health <= 0)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        health--;
    }
}
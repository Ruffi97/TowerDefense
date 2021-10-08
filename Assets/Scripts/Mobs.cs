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
    void Start()
    {
        _goal = GameObject.FindGameObjectWithTag("goal");
        _dest = _goal.transform.position;
        
    }

    
    void Update()
    {
        agent.destination = _dest;
    }
    
}

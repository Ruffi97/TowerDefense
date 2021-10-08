using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    private GameObject _target;
    public GameObject projectile;
    private int _ShootingRange;
    private int _targetDistance;
    static List<GameObject> _projectiles = new List<GameObject>();
    
    void Start()
    {
       // _target = GameObject.FindGameObjectWithTag("mob");
       
    }

    
    void Update()
    {
        if (InRange())
        {
            Fire();
        }
        
    }

    public bool InRange()
    {
        if ( _targetDistance <= _ShootingRange)
        {
            return true;
        }
        return false;
    }
    public void Fire()
    {
        _projectiles.Add(Instantiate(projectile, transform.position, Quaternion.identity));
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField]
    private GameObject _target;
    public float range = 20f;
    private float speedRotation = 3f;
    private float fireRate = 1f;
    private float fireCountDown = 0f;
    public GameObject projectile;
    public Transform SpawnPointProjectile;
    
    void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
    }
    
    void Update()
    {
        if (_target == null)
        {
            return;
        }

        Vector3 dir = _target.transform.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = Quaternion.Lerp(transform.rotation, lookRotation, Time.deltaTime * speedRotation).eulerAngles;
        transform.rotation = Quaternion.Euler(0f, rotation.y, 0f);

        if(fireCountDown <= 0f) 
        {
            Fire();
            fireCountDown = 1 / fireRate;
        }
        fireCountDown -= Time.deltaTime;
    }

    void UpdateTarget()
    {
        GameObject[] mobs = GameObject.FindGameObjectsWithTag("mob");
        float shortestTargetDistance = Mathf.Infinity;
        GameObject nearestTarget = null;

        foreach (GameObject mob in mobs)
        {
            float distanceToTarget = Vector3.Distance(transform.position, mob.transform.position);
            if(distanceToTarget < shortestTargetDistance)
            {
                shortestTargetDistance = distanceToTarget;
                nearestTarget = mob;
            }
        }
        if(nearestTarget != null && shortestTargetDistance <= range)
        {
            _target = nearestTarget;
        }
        else { _target = null; }
    }
    public void Fire()
    {
        GameObject GO = Instantiate(projectile, SpawnPointProjectile.transform.position, Quaternion.identity);
        Projectile _projectile = GO.GetComponent<Projectile>();

        if(_projectile != null)
        {
            _projectile.ResearchTarget(_target);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
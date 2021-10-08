using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    private float _timer = 0f;
    public float spawnTime = 3f;
    public GameObject mob;
    static List<GameObject> presentMobs = new List<GameObject>();
    
    void Start()
    {
        
    }

    
    void Update()
    {
        _timer += Time.deltaTime;
        
        if (_timer >= spawnTime)
        {
            presentMobs.Add(Instantiate(mob, this.transform.position, Quaternion.identity));
            _timer = 0;
        }
        
        
    }
}

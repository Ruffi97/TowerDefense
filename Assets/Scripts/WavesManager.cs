using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WavesManager : MonoBehaviour
{
    public GameObject mob;
    private float timeBetweenWaves = 20f;
    private float CountDown = 5f;
    private int waveNumber = 1;
    public static List<GameObject> _presentMobs = new List<GameObject>();
    private Vector3 firstSpawnerPosition;
    private Vector3 secondSpawnerPosition;
    public GameObject firstSpawner;
    public GameObject secondSpawner;
    [SerializeField]
    private Text CountDownText;

    void Start()
    {
        firstSpawnerPosition = firstSpawner.transform.position;
        secondSpawnerPosition = secondSpawner.transform.position;
    }
    void Update()
    {
        if(CountDown <= 0f)
        {
            StartCoroutine(SpawnWave());
            CountDown = timeBetweenWaves;
        }
        CountDown -= Time.deltaTime;
        CountDownText.text = Mathf.Floor(CountDown).ToString();
    }

    IEnumerator SpawnWave()
    {
        for (int i = 0; i < waveNumber; i++)
        {
            SpawnMob();
            yield return new WaitForSeconds(1.5f);
        }
        waveNumber++;
    }

    private void SpawnMob()
    {
        _presentMobs.Add(Instantiate(mob, firstSpawnerPosition, Quaternion.identity));
        _presentMobs.Add(Instantiate(mob, secondSpawnerPosition, Quaternion.identity));
    }
}

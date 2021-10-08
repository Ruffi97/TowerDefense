using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceTower : MonoBehaviour
{
    public GameObject towerPrefab;
    private GameObject _tower;

    private bool CanPlaceTower()
    {
        return _tower == null;
    }
    
    void OnMouseUp()
    {
        if (CanPlaceTower())
        {
            _tower = (GameObject) 
                Instantiate(towerPrefab, transform.position, Quaternion.identity);
        }
        else if (CanUpgradeMonster())
        {
            _tower.GetComponent<TowerLevel>().IncreaseLevel();
        }
    }
    
    private bool CanUpgradeMonster()
    {
        if (_tower != null)
        {
            TowerLevel towerLevel = _tower.GetComponent<TowerLevel>();
            Leveling nextLevel = towerLevel.GetNextLevel();
            if (nextLevel != null)
            {
                return true;
            }
        }
        return false;
    }
}
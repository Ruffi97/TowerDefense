using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

[System.Serializable]
public class Leveling
{
    public int cost;
    public Material visual;
}
public class TowerLevel : MonoBehaviour
{
    public List<Leveling> levels;
    private Leveling currentLevel;

    public Leveling CurrentLevel
    {
        get
        {
            return currentLevel;
        }
        set
        {
            currentLevel = value;
            int currentLevelIndex = levels.IndexOf(currentLevel);

            Material levelVisual = levels[currentLevelIndex].visual;
            for (int i = 0; i < levels.Count; i++)
            {
                if (levelVisual != null)
                {
                    if (i == currentLevelIndex)
                    {
                        this.GetComponent<Renderer>().material = new Material(currentLevel.visual);
                    }
                    else
                    {
                        
                    }
                }
            }
        }
    }
}



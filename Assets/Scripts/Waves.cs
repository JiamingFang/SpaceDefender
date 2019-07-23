using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Wave config")]

public class Waves : ScriptableObject
{
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] GameObject pathPrefab;
    [SerializeField] float spawnTime = 0.5f;
    [SerializeField] int enemyNum = 10;
    [SerializeField] float movementSpeed = 2f;

    public List<Transform> getWayPoints()
    {
        var wayPoints = new List<Transform>();
        foreach(Transform points in pathPrefab.transform)
        {
            wayPoints.Add(points);
        }
        return wayPoints;
    }

    public GameObject getEnemyPrefab()
    {
        return enemyPrefab;
    }

    public GameObject getPathPrefab()
    {
        return pathPrefab;
    }

    public float getSpawnTime()
    {
        return spawnTime;
    }

    public int getEnemyNum()
    {
        return enemyNum;
    }

    public float getMovementSpeed()
    {
        return movementSpeed;
    }
}

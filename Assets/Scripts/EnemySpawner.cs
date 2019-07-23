using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] List<Waves> waves;
    int index = 0;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnAll());
        StartCoroutine(Spawn(waves[index]));
    }

    private IEnumerator SpawnAll()
    {
        for(int i = 0; i < waves.Count; i++)
        {
            yield return StartCoroutine(Spawn(waves[i]));
        }
    }

    private IEnumerator Spawn(Waves waveConfig)
    {
        for (int i = 0; i < waveConfig.getEnemyNum();i++) 
        {
            yield return new WaitForSeconds(waveConfig.getSpawnTime());
            var enemy = Instantiate(waveConfig.getEnemyPrefab(), waveConfig.getWayPoints()[0].transform.position, Quaternion.identity);
            enemy.GetComponent<PathFinder>().setWaves(waveConfig);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

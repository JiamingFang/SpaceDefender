using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFinder : MonoBehaviour
{

    List<Transform> path;
    [SerializeField] Waves waves;
    int index = 0;
    // Start is called before the first frame update
    void Start()
    {
        path = waves.getWayPoints();
        transform.position = path[index].transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(index < path.Count)
        {
            var des = path[index].transform.position;
            var speed2 = waves.getMovementSpeed() * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, des, speed2);
            if(transform.position == path[index].transform.position)
            {
                index++;
            } 
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void setWaves(Waves wave)
    {
        this.waves = wave;
    }
}

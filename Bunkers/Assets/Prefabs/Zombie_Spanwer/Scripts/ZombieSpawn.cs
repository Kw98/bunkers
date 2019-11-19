using UnityEngine;
using System.Collections;

public class ZombieSpawn : MonoBehaviour
{
    public Object zombie;
    public float spawninterval;
    public float nextspawn;
    private int count;

    void Start()
    {
        count = 0;
        nextspawn = Time.time + spawninterval;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > nextspawn)
        {
            nextspawn = Time.time + spawninterval;
            if (count < 10)
                SpawnZombie();
        }
    }

    void SpawnZombie()
    {
        count += 1;
        Instantiate(zombie, transform.position, transform.rotation); 
    }
}
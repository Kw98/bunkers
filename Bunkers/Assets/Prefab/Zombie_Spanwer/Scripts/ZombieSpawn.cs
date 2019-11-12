using UnityEngine;
using System.Collections;

public class ZombieSpawn : MonoBehaviour
{
    public Object zombie;
    public float spawninterval;
    public float nextspawn;

    void Start()
    {
        nextspawn = Time.time + spawninterval;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > nextspawn)
        {
            nextspawn = Time.time + spawninterval;
            SpawnZombie();
        }
    }

    void SpawnZombie()
    {
        Instantiate(zombie, transform.position, transform.rotation); 
    }
}
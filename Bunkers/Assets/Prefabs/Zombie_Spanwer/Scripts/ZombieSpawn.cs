using UnityEngine;
using System.Collections;

public class ZombieSpawn : MonoBehaviour
{
    public Object zombie;
    public float spawninterval;
    public float nextspawn;
    private GameObject player;

    void Start()
    {
        nextspawn = Time.time + spawninterval;
        player = GameObject.FindWithTag("player");


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
        if (player != null)
        {
            var dist = transform.position - player.transform.position;
            print("Player Position: X = " + dist.y);
            if (dist.y < 3)
            {
                Instantiate(zombie, transform.position, transform.rotation);
            }
        }
    }
}
using UnityEngine;
using System.Collections;

public class ZombieSpawn : MonoBehaviour
{
    public Object zombie;
    public float spawninterval;
    public float nextspawn;
    private int count;
    private int MaxCount;
    private bool activated;

    private void SetCount() {
        int day = GameObject.Find("HUD").GetComponent<ScoreHandler>().score.day;
        int scaling = 1;
        if (PlayerPrefs.GetString("DIFFICULTY", "easy") == "easy")
            MaxCount = 5;
        else if (PlayerPrefs.GetString("DIFFICULTY") == "normal")
            MaxCount = 10;
        else if (PlayerPrefs.GetString("DIFFICULTY") == "hard") {
            MaxCount = 15;
            scaling = 2;
        } else if (PlayerPrefs.GetString("DIFFICULTY") == "hell") {
            MaxCount = 15;
            scaling = 4;
        }
        for (int i = 1; i < day; i++)
            MaxCount += scaling;
    }

    void Start()
    {
        activated = true;
        SetCount();
        count = 0;
        nextspawn = Time.time + spawninterval;
    }

    // Update is called once per frame
    void Update()
    {
        float hour = GameObject.Find("HUD").GetComponent<ScoreHandler>().score.hour;
        if (hour >= 7f && hour < 22f && activated == true) {
            activated = false;
            return;
        } else if (hour >= 22f && activated == false) {
            count = 0;
            activated = true;
            SetCount();
        }
        if (Time.time > nextspawn)
        {
            nextspawn = Time.time + spawninterval;
            if (count < MaxCount)
                SpawnZombie();
        }
    }

    void SpawnZombie()
    {
        count += 1;
        Instantiate(zombie, transform.position, transform.rotation); 
    }
}
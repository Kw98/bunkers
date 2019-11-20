using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderCamera : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] Player;
    public GameObject[] TileMap;

    void Update()
    {
        for (int i = 0; i < TileMap.Length; i++)
        {
            float minDist = 15;
            foreach (GameObject p in Player) {
                if (!p)
                    continue;
                float d = Vector3.Distance(p.transform.position, TileMap[i].transform.position);
                if (d < minDist)
                    minDist = d;
            }
            if (minDist < 15)
                TileMap[i].SetActive(true);
            else
                TileMap[i].SetActive(false);
        }
    }
}

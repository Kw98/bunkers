using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderCamera : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform Player;
    public GameObject[] TileMap;
    public int Size;

    void Awake()
    {
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < Size; i++)
        {
            float dist = Vector3.Distance(Player.position, TileMap[i].transform.position);
            if (dist < 8)
            {
                TileMap[i].SetActive(true);
            }
            else
            {
                TileMap[i].SetActive(false);
            }
        }
    }
}

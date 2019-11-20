using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderCamera : MonoBehaviour
{
    // Start is called before the first frame update
    public float    distPrint;
    public GameObject[] Player;
    private List<GameObject> TileMap;

    private void Awake() {
        TileMap = new List<GameObject>();
        foreach (Transform child in transform)
            TileMap.Add(child.gameObject);
    }

    void Update()
    {
        foreach (GameObject pref in TileMap) {
            float minDist = 15;
            foreach (GameObject p in Player) {
                if (!p)
                    continue;
                float d = Vector3.Distance(p.transform.position, pref.transform.position);
                if (d < minDist)
                    minDist = d;
            }
            if (minDist < distPrint)
                pref.SetActive(true);
            else
                pref.SetActive(false);
        }
    }
}

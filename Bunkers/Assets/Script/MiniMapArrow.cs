using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniMapArrow : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject parent;
    void Start()
    {
        parent = transform.parent.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
       transform.rotation = parent.transform.rotation;
    }
}

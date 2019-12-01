using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniMapArrow : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject parent;
    private ZombieMvt zombieFct;

    void Start()
    {
        parent = transform.parent.gameObject;
        zombieFct = gameObject.GetComponentInParent<ZombieMvt>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = parent.transform.rotation;
       if (zombieFct && zombieFct.dead)
       {
            Destroy(gameObject);
       }
    }
}

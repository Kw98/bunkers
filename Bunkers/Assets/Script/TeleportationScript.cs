using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportationScript : MonoBehaviour
{
    public GameObject TeleportationDestination;
    public GameObject Boss;
    public bool active;
    private float time;
    private TeleportationScript otherTeleporteFunction;

    void Start()
    {
        active = true;
        otherTeleporteFunction = TeleportationDestination.GetComponent<TeleportationScript>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player" && active)
        {
            if (other.gameObject.name == "Unarmed")
                other.gameObject.transform.parent.transform.position = TeleportationDestination.transform.position;
            if (other.gameObject.name == "Equiped")
                other.gameObject.transform.parent.transform.parent.transform.position = TeleportationDestination.transform.position;
            otherTeleporteFunction.active = false;
            if (Boss)
            {
                Boss.GetComponent<Collider2D>().enabled = true;
                Boss.GetComponent<BossMvmt>().enabled = false;
            }
        }
    }

   private void OnTriggerExit2D(Collider2D other)
    {
        // Revert the cube color to white.
        if (other.gameObject.tag == "Player")
        {
            active = true;
            
        }
    }
}

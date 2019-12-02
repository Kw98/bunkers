using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;

public class ArrowDestination : MonoBehaviour
{
    public GameObject Destination;
    public GameObject Player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 toPosition = Destination.transform.position;
        Vector3 fromPosition = Player.transform.position;

        fromPosition.z = 0f;
        Vector3 dir = (toPosition - fromPosition).normalized;
        float angle = UtilsClass.GetAngleFromVectorFloat(dir);
        transform.localEulerAngles = new Vector3(0, 0, angle);
    }
}

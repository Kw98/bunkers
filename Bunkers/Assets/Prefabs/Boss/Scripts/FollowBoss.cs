using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowBoss : MonoBehaviour
{
    public Transform BossPosition;

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(
                BossPosition.position.x,
                BossPosition.position.y + 0.2f,
                BossPosition.position.z
            );
    } 
}

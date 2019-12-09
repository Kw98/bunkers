using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealthBar : MonoBehaviour
{
    public Boss boss;
    private Transform HealthBarSize;

    private void Awake()
    {
        HealthBarSize = transform;
        print(transform.localScale);
    }

    private void Update()
    {
        if (boss.MaxHealth != boss.CurrentHealth)
        {
            transform.localScale = new Vector3(boss.CurrentHealth / boss.MaxHealth, 1f);
        }
    }
}

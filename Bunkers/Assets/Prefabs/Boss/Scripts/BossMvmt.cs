using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMvmt : MonoBehaviour
{
    public float speed;
    public Weapon weaponDrop;
    public Charger chargerDrop;
    public int nbOfCharger;
    public int nbOfBullets;
    private bool moving = true;
    private List<GameObject> ChildOfBoxMovement;
    private List<GameObject> CheckPoints;
    private GameObject Zombie;
    private GameObject DestinationCheckpoint;
    private Vector3 targetDirection;
    private float time;
    private float timeHit;

    // Start is called before the first frame update
    void Start()
    {
        ChildOfBoxMovement = new List<GameObject>();
        CheckPoints = new List<GameObject>();
        foreach (Transform child in transform)  
            ChildOfBoxMovement.Add(child.gameObject);
        Zombie = ChildOfBoxMovement[0];
        Zombie.GetComponent<Rigidbody2D>().mass = 1.0f;
        Zombie.GetComponent<Rigidbody2D>().simulated = true;
        Zombie.transform.rotation = Quaternion.EulerAngles(0f, 0f, 0f);
        Zombie.GetComponent<Animator>().enabled = true;
        foreach (Transform child in ChildOfBoxMovement[1].transform)
            CheckPoints.Add(child.gameObject);
        findCheckPointDestination();
    }

    void findCheckPointDestination()
    {
        GameObject OldDestination = DestinationCheckpoint;
        int rand = Random.Range(0, 2);
        if (rand == 0)
        {
            GameObject Player = GameObject.Find("Player");
            DestinationCheckpoint = Player;
        }
        else if (rand == 1)
        {
            rand = Random.Range(0, CheckPoints.Count);
            DestinationCheckpoint = CheckPoints[rand];
        }
        targetDirection = DestinationCheckpoint.transform.position - Zombie.transform.position;
        if (DestinationCheckpoint == OldDestination)
            findCheckPointDestination();
    }   

    // Update is called once per frame
    void Update()
    {
        time = time + Time.deltaTime;
        if (moving)
        {
            Vector3 v_diff;
            float atan2;
            if (time - timeHit > 1.2)
            {
                timeHit = time;
                findCheckPointDestination();
            }
            Zombie.transform.position += targetDirection * speed * Time.deltaTime;
            v_diff = (DestinationCheckpoint.transform.position - Zombie.transform.position);
            atan2 = Mathf.Atan2(v_diff.y, v_diff.x);
            Zombie.transform.rotation = Quaternion.Euler(0f, 0f, atan2 * Mathf.Rad2Deg);
        }
    }

    void DisperseWeapons()
    {
        if (weaponDrop)
        {
            float rand = Random.Range(-0.2f, 0.2f);
            float rand2 = Random.Range(-0.2f, 0.2f);
            weaponDrop.transform.position = new Vector3(Zombie.transform.position.x + rand, Zombie.transform.position.y + rand2, 0.0f);
            Instantiate(weaponDrop);
        }
        for (int i = 0; i < nbOfCharger; i++)
        {
            float rand = Random.Range(-0.2f, 0.2f);
            float rand2 = Random.Range(-0.2f, 0.2f);
            chargerDrop.transform.position = new Vector3(Zombie.transform.position.x + rand, Zombie.transform.position.y + rand2, 0.0f);
            Instantiate(chargerDrop);
        }
    }

    void OnDestroy()
    {
        DisperseWeapons();
    }
}

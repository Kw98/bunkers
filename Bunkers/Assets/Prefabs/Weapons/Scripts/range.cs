using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class range : MonoBehaviour
{
    public int  damage;
    public float    reloadTime;
    public float       fireRate;
    public Transform   firePoint;
    public GameObject   bulletPrefab;
    public int  maxCharger;
    public List<GameObject>   chargers;
    private bool    isFiring;
    private float      fireTime;
    public AudioClip shootsong;
    private AudioSource audioSource;
    private GameObject ReloadText;



    void Start()
    {
        isFiring = false;
        fireTime = 0;
        audioSource = CreateAudioSource(shootsong, false);
        ReloadText = GameObject.FindWithTag("ReloadText");
        ReloadText.GetComponent<UnityEngine.UI.Text>().text = "";
    }

    public void    Updater() {
        if (Input.GetMouseButtonDown(0))
            isFiring = true;
        if (Input.GetMouseButtonUp(0))
            isFiring = false;
        if (Input.GetKeyDown(KeyCode.R))
            StartCoroutine(reload());
    }

    private void FixedUpdate() {
        if (isFiring) {
            fireTime -= Time.deltaTime;
            if (fireTime <= 0) {
                fireTime = fireRate;
                shoot();
            }
        } else
            fireTime = 0;
    }

    private void    shoot() {
        if (chargers.Count > 0 && chargers[0].GetComponent<Charger>().useBullet()) {

            GameObject b = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            audioSource.Play();
            b.GetComponent<Bullet>().damages = damage;
        }
        else
            ReloadText.GetComponent<UnityEngine.UI.Text>().text = "Press R for reload";
    }
    private AudioSource CreateAudioSource(AudioClip audioClip,
        bool startPlayingImmediately)
    {
        GameObject audioSourceGO = new GameObject();
        audioSourceGO.transform.parent = transform;
        audioSourceGO.transform.position = transform.position;
        AudioSource newAudioSource =
        audioSourceGO.AddComponent<AudioSource>() as AudioSource;
        newAudioSource.clip = audioClip;
        if (!newAudioSource.isPlaying)
            newAudioSource.Play();

        return newAudioSource;
    }


    private IEnumerator reload() {
        yield return new WaitForSeconds(reloadTime);
        if (chargers.Count > 0) {
            GameObject  c = chargers[0];
            chargers.RemoveAt(0);
            if (c.GetComponent<Charger>().actualNbOfBullets <= 0) {
                Destroy(c);
            } else if (chargers.Count > 1 && c.GetComponent<Charger>().actualNbOfBullets > 0)
                chargers.Add(c);
        }
        Debug.Log("reloaded");
        ReloadText.GetComponent<UnityEngine.UI.Text>().text = "";
    }
}


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
    private float      nextFire;
    public AudioClip shootsong;
    private AudioSource audioSource;
    private GameObject ReloadText;
    private GameObject ReloadedText;



    void Start()
    {
        isFiring = false;
        nextFire = 0;
        audioSource = CreateAudioSource(shootsong, false);
        ReloadText = GameObject.Find("HUD").GetComponent<HUDHandler>().ReloadTxt;
        ReloadedText = GameObject.Find("HUD").GetComponent<HUDHandler>().ReloadedTxt;
    }

    public void    Updater() {
        if (Input.GetMouseButtonDown(0))
            isFiring = true;
        if (Input.GetMouseButtonUp(0))
            isFiring = false;
        if (isFiring && Time.time > nextFire) {
            shoot();
            nextFire = Time.time + fireRate;
        }
        if (Input.GetKeyDown(KeyCode.R))
            StartCoroutine(reload());
    }

    private void    shoot() {
        ReloadText.SetActive(false);
        if (chargers.Count > 0 && chargers[0].GetComponent<Charger>().useBullet()) {
            GameObject b = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            audioSource.Play();
            b.GetComponent<Bullet>().damages = damage;
        }
        else
            StartCoroutine(ShowReload(1f));
    }

    private IEnumerator ShowReload(float time) {
        ReloadText.SetActive(true);
        yield return new WaitForSeconds(time);
        ReloadText.SetActive(false);
    }

    private IEnumerator ShowReloaded(float time) {
        ReloadedText.SetActive(true);
        yield return new WaitForSeconds(time);
        ReloadedText.SetActive(false);
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
        return newAudioSource;
    }


    private IEnumerator reload() {
        yield return new WaitForSeconds(reloadTime);
        if (chargers.Count > 0) {
            GameObject  c = chargers[0];
            chargers.RemoveAt(0);
            if (c.GetComponent<Charger>().actualNbOfBullets <= 0) {
                Destroy(c);
            } else if (chargers.Count > 0 && c.GetComponent<Charger>().actualNbOfBullets > 0)
                chargers.Add(c);
            if (chargers.Count > 0)
                StartCoroutine(ShowReloaded(0.5f));
        }
    }
}


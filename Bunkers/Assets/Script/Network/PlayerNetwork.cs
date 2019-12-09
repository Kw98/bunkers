using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerNetwork : MonoBehaviour
{
    private PhotonView photonView;
    private int nbPlayer;
    private GameObject  spawner;

    private void Awake() {
        photonView = GetComponent<PhotonView>();
        SceneManager.sceneLoaded += OnSceneFinishedLoading;
    }

    private void    OnSceneFinishedLoading(Scene scene, LoadSceneMode mode) {
        if (scene.name == "Alex") {
            if (PhotonNetwork.isMasterClient)
                MasterLoadedGame(scene.name);
            else
                NonMasterLoadedGame();
        }
    }

    private void MasterLoadedGame(string name) {
        nbPlayer = 1;
        print(name);
        // 
        int i = 1;
        string spawn = "Spawner_";
        foreach (PhotonPlayer player in PhotonNetwork.playerList) {
            photonView.RPC("RPC_SpawnPoints", player, spawn + i);
            i++;
        }
        photonView.RPC("RPC_LoadedGameScene", PhotonTargets.MasterClient);
        photonView.RPC("RPC_LoadGameOthers", PhotonTargets.Others, name);
    }

    private void NonMasterLoadedGame() {
        photonView.RPC("RPC_LoadedGameScene", PhotonTargets.MasterClient);
    }

    [PunRPC]
    private void RPC_LoadGameOthers(string name) {
        PhotonNetwork.LoadLevel(name);
    }

    [PunRPC]
    private void RPC_LoadedGameScene() {
        nbPlayer++;
        if (nbPlayer == PhotonNetwork.playerList.Length) {
            photonView.RPC("RPC_CreatePlayer", PhotonTargets.All);
        }
    }

    [PunRPC]
    private void RPC_CreatePlayer() {
        GameObject cam = GameObject.Find("Camera");
        GameObject p = PhotonNetwork.Instantiate("Player", spawner.transform.position, Quaternion.identity, 0);
        if (cam) {
            cam.SetActive(true);
            cam.GetComponent<CameraFollow>().enabled = true;
            cam.GetComponent<CameraFollow>().player = p;
        }
    }

    [PunRPC]
    private void RPC_SpawnPoints(string spawnerName) {
        spawner = GameObject.Find(spawnerName);
    }

}

    // [SerializeField] private GameObject    playerCamera;
    // [SerializeField] private MonoBehaviour[]  scriptsToIgnore;
    // private PhotonView  photonView;
    // void Start()
    // {
    //     photonView = GetComponent<PhotonView>();
    //     if (photonView.isMine) {

    //     } else {
    //         playerCamera.SetActive(false);
    //         foreach (MonoBehaviour mb in scriptsToIgnore)
    //             mb.enabled = false;
    //     }
    // }
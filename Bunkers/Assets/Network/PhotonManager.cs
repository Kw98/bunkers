using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhotonManager : Photon.MonoBehaviour
{
    public GameObject   mainCamera;
    public GameObject   spawnPoint;
    // Start is called before the first frame update
    void Start()
    {
        PhotonNetwork.ConnectUsingSettings("1.0");
    }

    void    OnJoinedLobby() {
        PhotonNetwork.JoinOrCreateRoom("room", new RoomOptions(){MaxPlayers = 4}, TypedLobby.Default);
    }

    void OnJoinedRoom() {
        GameObject player = PhotonNetwork.Instantiate("Player", spawnPoint.transform.position, Quaternion.identity, 0);
        mainCamera.GetComponent<CameraFollow>().player = player;
        player.GetComponent<PlayerAction>().camera = mainCamera.GetComponent<Camera>();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LobbyManager : Photon.PunBehaviour
{
    public GameObject   RoomLister;
    public GameObject   roomObjPrefab;
    public Text roomName;

    // Start is called before the first frame update
    void Start()
    {
        if (!PhotonNetwork.connected) {
            PhotonNetwork.playerName = PlayerPrefs.GetString("PlayerName", "Player#" + Random.Range(1000, 9999));
            PhotonNetwork.automaticallySyncScene = false;
            PhotonNetwork.autoJoinLobby = false;
            PhotonNetwork.ConnectUsingSettings("v1");
        }
    }

    public override void OnConnectedToMaster() {
        print("Connected to master!");
        PhotonNetwork.JoinLobby();
    }

    public override void OnJoinedLobby() {
        print("Connected to Lobby");
    }


    public override void OnReceivedRoomListUpdate() {
        print("RoomListUpdate received!");
        RoomReceived();
    }

    public void OnClick_CreateRoom() {
        PhotonNetwork.CreateRoom(roomName.text, new RoomOptions() { MaxPlayers = 4}, null);
        print("creating room: " + roomName.text);
    }

    public void OnClick_JoinRoom(string roomName) {
        PhotonNetwork.JoinRoom(roomName);
    }

    private void RoomReceived() {
        RoomInfo[]  roomList = PhotonNetwork.GetRoomList();

        foreach (RoomInfo room in roomList) {
            if (room.IsOpen && room.PlayerCount <= room.MaxPlayers && room.PlayerCount > 0) {
                Transform child = RoomLister.transform.Find(room.Name);
                if (!child) {
                    GameObject roomJoiner = Instantiate(roomObjPrefab);
                    roomJoiner.name = room.Name;
                    RoomJoinUI rju = roomJoiner.GetComponent<RoomJoinUI>();
                    rju.InitName(room.Name);
                    rju.Join.onClick.AddListener(delegate {OnClick_JoinRoom(room.Name);});
                    roomJoiner.transform.SetParent(RoomLister.transform);
                }
            } else {
                Transform child = RoomLister.transform.Find(room.Name);
                if (child)
                    Destroy(child.gameObject);
            }
        }

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoomManager : Photon.PunBehaviour
{
    [SerializeField] private Text   mode;
    [SerializeField] private GameObject PlayerPrefab;
    [SerializeField] private GameObject PlayerLister;
    [SerializeField] private GameObject Lobby;
    [SerializeField] private GameObject Room;
    [SerializeField] private GameObject Menu;

    // void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info) {
    // }

    public override void    OnJoinedRoom() {
        UpdatePlayerList();
        Lobby.SetActive(false);
        Room.SetActive(true);
    }

    public override void OnPhotonPlayerConnected(PhotonPlayer newPlayer) {
        UpdatePlayerList();
    }

    public override void OnPhotonPlayerDisconnected(PhotonPlayer otherPlayer) {
        Transform p = PlayerLister.transform.Find(otherPlayer.NickName);
        if (p)
            Destroy(p.gameObject);
    }

    private void    UpdatePlayerList() {
        PhotonPlayer[]  playerList = PhotonNetwork.playerList;

        foreach (PhotonPlayer player in playerList) {
            Transform child = PlayerLister.transform.Find(player.NickName);
            if (!child) {
                GameObject  playerS = Instantiate(PlayerPrefab);
                playerS.name = player.NickName;
                PlayerRoomPrefabNetwork ppn = playerS.GetComponent<PlayerRoomPrefabNetwork>();
                ppn.InitName(player.NickName);
                ppn.transform.SetParent(PlayerLister.transform);
            }
        }
    }

    public void OnClick_StartGame() {
        if (PhotonNetwork.isMasterClient && PhotonNetwork.room.PlayerCount >= 2) {
            if (mode.text == "Classic")
                PhotonNetwork.LoadLevel("Alex");
            // else if (mode.text == "BattleRoyal")
            //     PhotonNetwork.LoadLevel("BattleRoyal");
            PhotonNetwork.room.IsVisible = false;
            PhotonNetwork.room.IsOpen = false;
        }
    }

    public void OnClick_BackToMenu() {
        GameObject  t = new GameObject();
        foreach (Transform child in PlayerLister.transform) 
            child.SetParent(t.transform);
        Destroy(t);
        PhotonNetwork.LeaveRoom(false);
        Room.SetActive(false);
        Menu.SetActive(true);
    }

    public void OnClick_LeaveRoom() {
        GameObject  t = new GameObject();
        foreach (Transform child in PlayerLister.transform) 
            child.SetParent(t.transform);
        Destroy(t);
        PhotonNetwork.LeaveRoom(false);
        Room.SetActive(false);
        Lobby.SetActive(true);
    }
}

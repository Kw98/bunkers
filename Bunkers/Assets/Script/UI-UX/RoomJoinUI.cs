using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoomJoinUI : MonoBehaviour
{
   [SerializeField] private Text mainT;
   [SerializeField] private Text secondT;
   [SerializeField] private Text thirdT;

   public Button  Join;

   public void InitName(string roomName) {
      mainT.text = roomName;
      secondT.text = roomName;
      thirdT.text = roomName;
   }
}

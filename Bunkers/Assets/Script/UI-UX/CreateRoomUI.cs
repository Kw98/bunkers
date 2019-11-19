using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CreateRoomUI : MonoBehaviour {
    [SerializeField] private Text   createRoomInputMain;
    [SerializeField] private Text   createRoomInputSecond;
    [SerializeField] private Text   createRoomInputThird;
    [SerializeField] private InputField   createRoomInputField;

    private void Awake() {
        var se = new InputField.OnChangeEvent();
        se.AddListener(OnCreateRoomTextInputChanged);
        createRoomInputField.onValueChanged = se;
    }

    private void    OnCreateRoomTextInputChanged(string text) {
        createRoomInputSecond.text = text;
        createRoomInputThird.text = text;
    }
}

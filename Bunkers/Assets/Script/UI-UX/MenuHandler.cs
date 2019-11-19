using UnityEngine;

public class MenuHandler : MonoBehaviour
{
    [SerializeField] private GameObject MainMenu;
    [SerializeField] private GameObject SoloMenu;
    [SerializeField] private GameObject OptionMenu;
    [SerializeField] private GameObject MultiplayerMenu;

    private GameObject  current;

    private void Start() {
        current = MainMenu;
    }

    public void goToMainMenu() {
        current.SetActive(false);
        MainMenu.SetActive(true);
        current = MainMenu;
    }

    public void gotToOptionMenu() {
        current.SetActive(false);
        OptionMenu.SetActive(true);
        current = OptionMenu;
    }

    public void gotToSoloMenu() {
        current.SetActive(false);
        SoloMenu.SetActive(true);
        current = SoloMenu;
    }

    public void gotToMultiplayerMenu() {
        current.SetActive(false);
        MultiplayerMenu.SetActive(true);
        current = MultiplayerMenu;
    }
}

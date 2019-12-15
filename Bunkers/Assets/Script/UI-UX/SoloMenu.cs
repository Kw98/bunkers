using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SoloMenu : MonoBehaviour {
    [SerializeField] private string SoloGameSceneName;
    [SerializeField] private Picker Difficultypicker;
    private string[]    difficulty = {"easy", "normal", "hard", "hell"};

    private void Awake() {
        Difficultypicker.SetPicker(difficulty, 0);
    }

    public void    LaunchSolo() {
        PlayerPrefs.SetString("DIFFICULTY", difficulty[Difficultypicker.GetCurrent()]);
        SceneManager.LoadScene(SoloGameSceneName, LoadSceneMode.Single);
    }
}

using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SoloMenu : MonoBehaviour {
    [SerializeField] private string SoloGameSceneName;

    public void    LaunchSolo() {
        SceneManager.LoadScene(SoloGameSceneName, LoadSceneMode.Single);
    }
}

using UnityEngine;

public class DDOS : MonoBehaviour {
    private void Awake() {
        DontDestroyOnLoad(this);
    }
}

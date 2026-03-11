using UnityEngine;

public class ShowResolution : MonoBehaviour {
    void OnGUI() {
        GUI.Label(new Rect(10, 10, 300, 30),
            Screen.width + " x " + Screen.height);
    }
}
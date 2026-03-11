using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditsHandler : MonoBehaviour {

    public void BackToMainMenu() {
        SceneManager.LoadScene(0);
    }

    public void RedirectToLinkidn() {
        Application.OpenURL("https://www.linkedin.com/in/samarth-mali-bb8745343/");
    }

    public void RedirectToItch() {
        Application.OpenURL("https://debuggeddream.itch.io/");
    }

}
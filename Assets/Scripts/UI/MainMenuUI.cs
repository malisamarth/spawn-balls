using UnityEngine;

public class MainMenuUI : MonoBehaviour {

    private void Awake() {
        GameUtilities.ResumeTime();
    }

    public void PlayGame() {
        GameUtilities.LoadScene(Scene.Levels);
    }

    public void QuitGame() {
        GameUtilities.QuitGame();
    }

    public void RedirectToGithub() {
        GameUtilities.RedirectToURL("https://github.com/malisamarth/spawn-balls");
    }

    public void RedirectToCreditSection() {
        GameUtilities.LoadScene(Scene.Credits);
    }

    public void RedirectToAboutSection() {
        GameUtilities.LoadScene(Scene.About);
    }


}

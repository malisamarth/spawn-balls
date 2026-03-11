using UnityEngine;
using UnityEngine.UI;

public class PauseAndResume : MonoBehaviour {

    [SerializeField] private GameObject PauseGameobject;
    [SerializeField] private GameObject ResumeGameobject;
    [SerializeField] private Button FastForwardButton;

    private CurrentFastForwardState currentFastForwardState;

    private void Start() {
        currentFastForwardState = CurrentFastForwardState.FALSE;
    }

    public void OnFastForward() {

        if (currentFastForwardState == CurrentFastForwardState.TRUE) {
            Time.timeScale = 1.0f;
            currentFastForwardState = CurrentFastForwardState.FALSE;
            SetFastForwardBtnWhiteColor();
            DeactivateResumeSprite();
            ActivatePauseSprite();
        } else if(currentFastForwardState == CurrentFastForwardState.FALSE) {
            Time.timeScale = 2.0f;
            currentFastForwardState = CurrentFastForwardState.TRUE;
            SetFastForwardBtnGrayColor();
            DeactivateResumeSprite();
            ActivatePauseSprite();
        }
    }

    public void OnPause() {
        DeactivatePauseSprite();
        ActivateResumeSprite();
        SetFastForwardBtnWhiteColor();
        Time.timeScale = 0f;
    }

    public void OnResume() {
        DeactivateResumeSprite();
        ActivatePauseSprite();
        SetFastForwardBtnWhiteColor();
        Time.timeScale = 1f;
    }

    private void ActivatePauseSprite() {
        PauseGameobject.SetActive(true);
    }

    private void DeactivatePauseSprite() {
        PauseGameobject.SetActive(false);
    }

    private void ActivateResumeSprite() {
        ResumeGameobject.SetActive(true);
    }

    private void DeactivateResumeSprite() {
        ResumeGameobject.SetActive(false);
    }

    private void SetFastForwardBtnGrayColor() {

        FastForwardButton.GetComponent<Image>().color = Color.gray;

    }

    private void SetFastForwardBtnWhiteColor() {
        FastForwardButton.GetComponent<Image>().color = Color.white;
    }


    public enum CurrentFastForwardState {
        TRUE, FALSE
    }

}
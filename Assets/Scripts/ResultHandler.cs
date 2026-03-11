using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResultHandler : MonoBehaviour {
    [SerializeField] private GameObject WinWindow;
    [SerializeField] private GameObject LostWindow;

    private LevelOneManager levelOneManager;
    private Timer timerObject;

    [SerializeField] private TextMeshProUGUI FailConditions;

    void Awake() {
        ResumeGame();
    }

    private void Start() {
        timerObject = Timer.Instance;
        levelOneManager = LevelOneManager.Instance;

        levelOneManager.OnWinConditionCheck += LevelOneManager_OnWinConditionCheck1;
;
        timerObject.OnTimeLimitReached += TimerObject_OnTimeLimitReached;

        levelOneManager.OnPlayerLost += LevelOneManager_OnPlayerLost;
        levelOneManager.OnPlayerWon += LevelOneManager_OnPlayerWon;
    }



    private void OnDestroy() {
        if (timerObject != null) { 
            timerObject.OnTimeLimitReached -= TimerObject_OnTimeLimitReached;
        }

        if (levelOneManager != null) {
            levelOneManager.OnPlayerLost -= LevelOneManager_OnPlayerLost;
            levelOneManager.OnPlayerWon -= LevelOneManager_OnPlayerWon;
        }
    }

    private void LevelOneManager_OnPlayerWon(object sender, System.EventArgs e) {
        PlayerWon();
    }

    private void LevelOneManager_OnPlayerLost(object sender, System.EventArgs e) {
        //PlayerLost();

        //FailConditions.text = "Rectangle is not formed.";
        //FailConditions.text += "Balls are moving!!";

    }

    private void TimerObject_OnTimeLimitReached(object sender, System.EventArgs e) {
        //PlayerLost();
        //FailConditions.text = "Not enough Balls";
        //FailConditions.text += "Generate more!!!";
    }

    private void LevelOneManager_OnWinConditionCheck1(object sender, LevelOneManager.OnWinConditionCheckEventArgs e) {
        SetConditionalText(e.failCondition);
    }

    private void PlayerWon() {
        PauseGame();
        LostWindow.SetActive(false);
        WinWindow.SetActive(true);
    }

    private void PlayerLost() {
        PauseGame();
        LostWindow.SetActive(true);
        WinWindow.SetActive(false);
    }

    public void RestartLevel() {
        ResumeGame();
        SceneManager.LoadScene(2);
    }

    public void OnBackToMainMenu() {
        ResumeGame();
        SceneManager.LoadScene(0);
    }

    private void PauseGame() {
        Time.timeScale = 0f;
    }

    private void ResumeGame() {
        Time.timeScale = 1f;
    }

    private void SetConditionalText(string conditionalText) {
        FailConditions.text = conditionalText;
    }

}
using TMPro;
using UnityEngine;

public class IncreaseScore : MonoBehaviour {

    public static IncreaseScore Instance { get; private set; }

    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI currentRadius;

    private StartAndRestart startAndRestart;
    private CircleEdge circleEdge;

    private int score = 0;

    private void Awake() {
        Instance = this;
    }

    private void Start() {
        circleEdge = CircleEdge.Instance.GetComponent<CircleEdge>();
        startAndRestart = StartAndRestart.Instance.GetComponent<StartAndRestart>();
        startAndRestart.OnGameStarted += StartAndRestart_OnGameStarted;
    }

    private void StartAndRestart_OnGameStarted(object sender, System.EventArgs e) {
        IncreaseScoreToTmp();
    }



    private void Update() {
        SetCurrentRadiusText(circleEdge.GetCurrentRadius());
    }

    public void IncreaseScoreToTmp() {

        score++;

        scoreText.text = score.ToString();

    }

    public void SetCurrentRadiusText(float currentRadius) {

        currentRadius = Mathf.Round(currentRadius * 100) / 100;

        this.currentRadius.text = (currentRadius.ToString());
    }

    public int GetTotalScore() {
        return score;
    }

}
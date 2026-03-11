using System;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour {

    public static Timer Instance { get; private set; }

    public event EventHandler OnTimeLimitReached;

    private StartAndRestart StartAndRestart;

    [SerializeField] private Image TimerImage;

    [SerializeField] private float timerLimit = 60f; // 1 minute

    private float elapsedTime = 0f;

    private bool isGoButtonPressed = false;

    private void Awake() {
        if (Instance == null) {
            Instance = this;
        } else {
            Destroy(Instance);
        }
    }

    private void Start() {
        StartAndRestart = StartAndRestart.Instance;
        StartAndRestart.OnGameStarted += StartAndRestart_OnGameStarted;
    }

    private void StartAndRestart_OnGameStarted(object sender, EventArgs e) {
        isGoButtonPressed = true;
    }

    private void Update() {

        if (isGoButtonPressed) {
            elapsedTime += Time.deltaTime;

            float remainingTime = timerLimit - elapsedTime;

            TimerImage.fillAmount = remainingTime / timerLimit;

            SetColor(remainingTime);

            if (remainingTime <= 0f) {

                OnTimeLimitReached?.Invoke(this, EventArgs.Empty);

                TimerImage.fillAmount = 0f;
                Debug.Log("Time Up!");
            }

            //Debug.Log(elapsedTime);

        }


    }

    private void SetColor(float timeRemaining) {
        if (timeRemaining > 40f) {
            TimerImage.color = new Color32(161, 217, 152, 255); // pastel green
        }
        else if (timeRemaining > 20f) {
            TimerImage.color = new Color32(247, 231, 158, 255); // pastel yellow
        }
        else {
            TimerImage.color = new Color32(244, 163, 163, 255); // pastel red
        }
    }

}
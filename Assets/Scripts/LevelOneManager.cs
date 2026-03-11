using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class LevelOneManager : MonoBehaviour {

    public static LevelOneManager Instance { get; private set; }

    public event EventHandler OnPlayerWon;
    public event EventHandler OnPlayerLost;

    public event EventHandler<OnWinConditionCheckEventArgs> OnWinConditionCheck;
    public class OnWinConditionCheckEventArgs : EventArgs {

        public string failCondition;

        public OnWinConditionCheckEventArgs(string failConditionString) {
            failCondition = failConditionString;
        }


    }

    [SerializeField] private Toggle WinCheckToggle;
    [SerializeField] private GameObject DemoWindow;

    private IncreaseScore IncreaseScore;
    private CircleEdge CircleEdge;

    private List<BallScript> TotalBallsList;

    private int TotalValidBall = 0;

    private bool isValidBallCount = false;

    [SerializeField] private Toggle WinToggle;

    private void Awake() {

        if (Instance == null) {
            Instance = this;
        } else {
            Destroy(Instance);
        }

    }

    private void Start() {
        IncreaseScore = IncreaseScore.Instance;
        CircleEdge = CircleEdge.Instance;
    }

    public void OnCheckWinPressed() {
        StartCoroutine(CheckWinRoutine());
    }

    private IEnumerator CheckWinRoutine() {

        if (IncreaseScore.GetTotalScore() <= 2000) {
            NotEnoughBallsCondition();
        } else {
            Time.timeScale = 0f;

            yield return null; // wait one frame

            bool result = HasPlayerWon();

            Time.timeScale = 1f;

            if (result) {
                PlayerWonCondition();
            }
            else {
                WinConditionFailed();
            }
        }

        WinCheckToggle.isOn = false;
    }

    private bool HasPlayerWon() {

        List<BallScript> balls = CircleEdge.GetTotalBallsList();

        if (balls.Count < 2000)
            return false;

        List<float> xs = new List<float>();
        List<float> ys = new List<float>();

        for (int i = 0; i < balls.Count; i++) {
            Vector2 pos = balls[i].transform.position;
            xs.Add(pos.x);
            ys.Add(pos.y);
        }

        xs.Sort();
        ys.Sort();

        int trim = balls.Count / 20; // remove 5% outliers

        float minX = xs[trim];
        float maxX = xs[xs.Count - trim - 1];

        float minY = ys[trim];
        float maxY = ys[ys.Count - trim - 1];

        float width = maxX - minX;
        float height = maxY - minY;

        float ratio = width / height;



        return ratio > 0.5f && ratio < 2f;

    }

    private void WinConditionFailed() {
        OnWinConditionCheck?.Invoke(this, new OnWinConditionCheckEventArgs("Balls are moving, it isn't rectangle"));
        Debug.Log("Calculation failed!");
    }

    private void NotEnoughBallsCondition() {
        OnWinConditionCheck?.Invoke(this, new OnWinConditionCheckEventArgs("Not enough balls generated!!"));
        Debug.Log("Can't Calculate...");
    }

    private void PlayerWonCondition() {
        OnPlayerWon?.Invoke(this, EventArgs.Empty);
        OnWinConditionCheck?.Invoke(this, new OnWinConditionCheckEventArgs("You Won!!"));
        Debug.Log("Player Won!");
    }


    public void HideDemoWindow() {
        DemoWindow.SetActive(false);
    }

}
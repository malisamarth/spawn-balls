using System;
using Unity.VectorGraphics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartAndRestart : MonoBehaviour {

    public static StartAndRestart Instance { get; private set; }

    public event EventHandler OnGameStarted;

    private CircleEdge circleEdge;

    [SerializeField] private GameObject StartButton;

    private void Awake() {
        if (Instance == null) {
            Instance = this;
        } else {
            Destroy(gameObject);
        }
    }

    private void Start () {
        circleEdge = CircleEdge.Instance.GetComponent<CircleEdge>();
    }

    public void StartTheGame() {
        circleEdge.SpwanBallOnCollision();
        StartButton.SetActive(false);
        OnGameStarted?.Invoke(this, EventArgs.Empty);   
    }

    public void RestartGame() {
        SceneManager.LoadScene(2);
    }

}
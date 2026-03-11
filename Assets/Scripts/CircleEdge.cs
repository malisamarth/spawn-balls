using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(EdgeCollider2D))]
public class CircleEdge : MonoBehaviour {

    public static CircleEdge Instance { get; private set; }

    public event EventHandler OnBallInstantiated;

    public int segments = 50;
    public float radius = 5f;
    private float lastRadios = 0;

    private SpwaningState spwaningState = SpwaningState.Spwaning;

    [SerializeField] private GameObject SpwanBall;
    [SerializeField] private GameObject SpwanPoint;
    [SerializeField] private AudioClip SwapnSfx;
    [SerializeField] private Slider CirlceRadius;

    private bool isSpwaningStopped = false;

    public List<BallScript> TotalBallsInScene = new List<BallScript>();

    private void Awake() { 

        radius = CirlceRadius.value;

        if (Instance == null) {
            Instance = this;
        } else {
            Destroy(gameObject);
        }

            EdgeCollider2D edge = GetComponent<EdgeCollider2D>();
        Vector2[] points = new Vector2[segments + 1];

        for (int i = 0; i <= segments; i++) {
            float angle = i * Mathf.PI * 2 / segments;
            points[i] = new Vector2(
                Mathf.Cos(angle) * radius,
                Mathf.Sin(angle) * radius
            );
        }

        edge.points = points;

        lastRadios = radius;
    }

    public void SpwanBallOnCollision() {

        if(!isSpwaningStopped /*&& TotalBallsInScene.Count() <= 2000*/) {
            Instantiate(SpwanBall, SpwanPoint.transform.position, Quaternion.identity);
            OnBallInstantiated?.Invoke(this, EventArgs.Empty);
            AudioSource.PlayClipAtPoint(SwapnSfx, Camera.main.transform.position);
            //Debug.Log("Ball Instantiated!!");
        }

    }

    
    void Update() {


        //Debug.Log("From main, Ball reached - " + TotalBallsInScene.Count());

        radius = CirlceRadius.value;

        if (lastRadios != radius) {

            EdgeCollider2D edge = GetComponent<EdgeCollider2D>();
            Vector2[] points = new Vector2[segments + 1];

            for (int i = 0; i <= segments; i++) {
                float angle = i * Mathf.PI * 2 / segments;
                points[i] = new Vector2(
                    Mathf.Cos(angle) * radius,
                    Mathf.Sin(angle) * radius
                );
            }

            edge.points = points;

            lastRadios = radius;
        } else {
            //Debug.Log("No change in the radius!!");
        }
    }

    public float GetCurrentRadius() {
        return radius;
    }

    public void ToggleSpwaning() {
        
        if (spwaningState == SpwaningState.Spwaning) {
            spwaningState = SpwaningState.Stopped;
            isSpwaningStopped = true;
        }
        else if (spwaningState == SpwaningState.Stopped) {
            spwaningState = SpwaningState.Spwaning;
            isSpwaningStopped = false;
        }

    }

    private enum SpwaningState {
        Spwaning,
        Stopped
    }


    public void AddBallToList(BallScript gameObject) {
        TotalBallsInScene.Add(gameObject);
    }

    public List<BallScript> GetTotalBallsList() {
        return TotalBallsInScene;
    }

    public int GetGetTotalBallsListCount() {
        return TotalBallsInScene.Count();
    }

}
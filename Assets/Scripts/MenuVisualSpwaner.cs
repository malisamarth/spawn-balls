using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class MenuVisualSpwaner : MonoBehaviour {

    [SerializeField] private List<GameObject> SpwanPoints = new List<GameObject>();

    [SerializeField] private GameObject SpwanBalls;

    [SerializeField] private float spwanedAfterTimeLimit = 0.5f;
    private float timeElapsed = 0f;

    private void Start() {
        SpwanRandomBalls();
    }

    private void Update() {

        if (timeElapsed > spwanedAfterTimeLimit) {
            SpwanRandomBalls();
            timeElapsed = 0f;

            Debug.Log("Generated new ball with random color and direction.");

        }
        else {
            timeElapsed += Time.deltaTime;
        }

        Debug.Log("Time elapsed: " + timeElapsed);
    }

    private void SpwanRandomBalls() {

        foreach (var spwanPoint in SpwanPoints) {
            var randomBall = Instantiate(SpwanBalls, spwanPoint.transform.position, Quaternion.identity);
            //randomBall.GetComponent<Rigidbody>().velocity = new Vector3(Random.Range(-5f, 5f), Random.Range(-5f, 5f), 0);
        }

    }


}
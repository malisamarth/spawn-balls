using System.Collections.Generic;
using UnityEngine;

public class LevelSceneVisual : MonoBehaviour {

    [SerializeField] private GameObject spawnBallPrefab;
    [SerializeField] private GameObject spawnPoint;

    [SerializeField] private float spawnAfterTimeLimit = 0.001f;
    [SerializeField] private float ballSpeed = 5f;
    [SerializeField] private float sprayAngle = 60f; 

    private float timeElapsed = 0f;

    private void Start() {

        SpawnBallWithRandomAngle();
    }

    private void Update() {

        MoveSpawnPointToMousePosition();
        HandleBallSpawning();
        HandleBallOutOfView();

    }

    private void HandleBallSpawning() {

        if (timeElapsed > spawnAfterTimeLimit) {
            SpawnBallWithRandomAngle();
            timeElapsed = 0f;
        }
        else {
            timeElapsed += Time.deltaTime;
        }

    }

    private void MoveSpawnPointToMousePosition() {

        spawnPoint.transform.position = GameUtilities.GetMouseWorldPosition();

    }


    private void HandleBallOutOfView() {

        if (GameUtilities.IsObjectOutOfView(transform.position)) {
            Destroy(gameObject);
        }

    }

    private void SpawnBallWithRandomAngle() {

        GameObject generatedBall = Instantiate(spawnBallPrefab, spawnPoint.transform.position, Quaternion.identity);

        Rigidbody2D generatedBallRigidbody = generatedBall.GetComponent<Rigidbody2D>();

        float angle = Random.Range(-sprayAngle / 2f, sprayAngle / 2f);

        Vector2 direction = Quaternion.Euler(0, 0, angle) * spawnPoint.transform.up;

        generatedBallRigidbody.linearVelocity = direction * ballSpeed;

    }

}
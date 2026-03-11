using Unity.Mathematics;
using UnityEngine;

public class CirclePerimeter : MonoBehaviour {

    [SerializeField] private EdgeCollider2D edgeCollider;

    [SerializeField] private GameObject pointPrefab; // Sprite to spawn
    [SerializeField] private float radius = 5f;
    [SerializeField] private int numberOfPoints = 50;
    [SerializeField] private Vector3 center = Vector3.zero;

    private float lastRadius = 0f;

    private void Awake() {
        
        //edgeCollider.pointCount = numberOfPoints;

    }

    private void Update() {

        if (radius != lastRadius) {
            GenerateCircle();
            lastRadius = radius;
        } else {
            Debug.Log("Radius has not changed, skipping circle generation.");
        }

        
    }

    private void GenerateCircle() {
        float angleStep = 2 * Mathf.PI / numberOfPoints;

        for (int i = 0; i < numberOfPoints; i++) {
            float angle = i * angleStep;

            float x = center.x + radius * Mathf.Cos(angle);
            float y = center.y + radius * Mathf.Sin(angle);
            float z = center.z; // Z locked

            Vector3 spawnPosition = new Vector3(x, y, z);

            Instantiate(pointPrefab, spawnPosition, Quaternion.identity);
        }
    }
}
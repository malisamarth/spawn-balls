using UnityEngine;
using UnityEngine.UI;

public class CircleBoundaryVisual : MonoBehaviour {
    [SerializeField] private Slider circleRadius;
    [SerializeField] private Transform circleVisual;

    private float originalDiameter;

    private void Awake() {
        // Get original world diameter of sprite
        SpriteRenderer sr = circleVisual.GetComponent<SpriteRenderer>();
        originalDiameter = sr.bounds.size.x;
    }

    private void OnEnable() {
        circleRadius.onValueChanged.AddListener(UpdateCircleSize);
        UpdateCircleSize(circleRadius.value); // Set initial size
    }

    private void OnDisable() {
        circleRadius.onValueChanged.RemoveListener(UpdateCircleSize);
    }

    private void UpdateCircleSize(float radius) {
        float desiredDiameter = radius * 2f;
        float scale = desiredDiameter / originalDiameter;

        scale += 0.20f;

        circleVisual.localScale = new Vector3(scale, scale, 1f);
    }
}
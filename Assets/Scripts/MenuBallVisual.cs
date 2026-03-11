using UnityEngine;

public class MenuBallVisual : MonoBehaviour {

    [SerializeField] private float speed = 5f;
    [SerializeField] SpriteRenderer spwanedBallSpriteRenderer;
    [SerializeField] Rigidbody2D spwanedBallRigidbody2D;

    private void Start() {
        SetRandomColor();
        spwanedBallRigidbody2D.linearVelocity = SetRandomDirection();
    }

    private void Update() {

        if (IsOutOfView()) {
            Destroy(gameObject);
        }

    }

    private Vector2 SetRandomDirection() {
        Vector2 direction = Random.insideUnitCircle.normalized;

        direction.x = -Mathf.Abs(direction.x); // force negative
        direction.y = Mathf.Abs(direction.y);  // force positive

        return direction * speed;
    }

    private void SetRandomColor() {
        float r = Random.value; // 0–1
        float g = Random.value;
        float b = Random.value;

        spwanedBallSpriteRenderer.color = new Color(r, g, b);
    }

    bool IsOutOfView() {
        Vector3 viewportPos = Camera.main.WorldToViewportPoint(transform.position);

        return viewportPos.x < 0 || viewportPos.x > 1 ||
               viewportPos.y < 0 || viewportPos.y > 1;
    }

}
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BallScript : MonoBehaviour {

    //public static BallScript Instance { get; set; }

    [SerializeField] private float speed = 2f;

    [SerializeField] private BallDataSO BallDataSO;

    private Rigidbody2D Rigidbody2d;

    [SerializeField] CircleEdge circleEdge;
    [SerializeField] IncreaseScore increaseScore;

    [SerializeField] SpriteRenderer spriteRenderer;

    private int SpwanAbilityLimit = 1;

    private void Awake() {
        Rigidbody2d = GetComponent<Rigidbody2D>();

    }

    private void Start() {


        SetRandomColor();

        Rigidbody2d.linearVelocity = RandomDirection();
        //circleEdge = GetComponent<CircleEdge>();

        circleEdge = CircleEdge.Instance.GetComponent<CircleEdge>();
        increaseScore = IncreaseScore.Instance.GetComponent<IncreaseScore>();

        circleEdge.AddBallToList(this);
    }

    private void Update() {
        Rigidbody2d.gravityScale = BallDataSO.gravity;

        float localScaleValue = BallDataSO.MIN_BALL_SIZE * BallDataSO.ballSizeMultiplier;

        transform.localScale = new Vector3(localScaleValue, localScaleValue, 1f);

        if (BallDataSO.isRandomHighVelocityEnabled) {
            ManualRandomHighForce();
            //BallDataSO.isRandomVelocityEnabled = false;
        }

    }

    private void OnCollisionEnter2D(Collision2D collision) {

        if (collision.gameObject.TryGetComponent(out CirclePerimeter circlePerimeter)) {
            Rigidbody2d.linearVelocity = RandomDirection();

            if (SpwanAbilityLimit > 0) {
                circleEdge.SpwanBallOnCollision();
                increaseScore.IncreaseScoreToTmp();

                //SpwanAbilityLimit--;
            }

        }

        if (collision.gameObject.TryGetComponent(out Abyss Abyss)) {
            Rigidbody2d.linearVelocity = RandomDirection();
        }

    }

    private Vector2 RandomDirection() {
        // Get random direction in 360 degrees
        Vector2 direction = Random.insideUnitCircle.normalized;

        return direction * speed;
    }

    private void SetRandomColor() {
        float r = Random.value; // 0–1
        float g = Random.value;
        float b = Random.value;

        spriteRenderer.color = new Color(r, g, b);
    }

    private void ManualRandomHighForce() {

        float highSpeed = 10f;

        Vector2 direction = Random.insideUnitCircle.normalized;

        Rigidbody2d.linearVelocity = direction * highSpeed;
    }



}
using UnityEngine;

[CreateAssetMenu(fileName = "BallDataSO", menuName = "ScriptableObjects/Creat a new Ball Data SO", order = 1)]
public class BallDataSO : ScriptableObject {

    public float gravity;
    public float ballSizeMultiplier;
    public bool isRandomHighVelocityEnabled;

    public const float MIN_BALL_SIZE = 0.10f;

}

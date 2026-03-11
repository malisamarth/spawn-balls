using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SizeSlider : MonoBehaviour {

    [SerializeField] private BallDataSO BallDataSO;
    [SerializeField] Slider BallSizeSlider;



    private void Update() {
        BallDataSO.ballSizeMultiplier = BallSizeSlider.value;
    }

}
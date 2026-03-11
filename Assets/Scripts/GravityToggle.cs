using UnityEngine;

public class GravityToggle : MonoBehaviour {

    [SerializeField] private BallDataSO BallDataSO;

    private GravityState gravityState = GravityState.Disabled;

    private void Start() {
        OnGravityDisabled();
    }

    public void ToggleGravity() {
        if (gravityState == GravityState.Disabled) {
            OnGravityEnabled();
        }
        else if (gravityState == GravityState.Enabled) {
            OnGravityDisabled();
        }
    }

    private void OnGravityEnabled() {
        BallDataSO.gravity = 1f;
        gravityState = GravityState.Enabled;
    }

    private void OnGravityDisabled() {
        BallDataSO.gravity = 0f;
        gravityState = GravityState.Disabled;
    }

    private enum GravityState {
        Enabled,
        Disabled
    }
}
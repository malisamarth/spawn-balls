
using UnityEngine;

public class UnstableMotion : MonoBehaviour {

    [SerializeField] private BallDataSO BallDataSO;

    private IsUnstableState CurrentUnstableState = IsUnstableState.Deactivated;

    public void ToggleUnstableMotion() {

        if (CurrentUnstableState == IsUnstableState.Deactivated) {
            CurrentUnstableState = IsUnstableState.Active;
            BallDataSO.isRandomHighVelocityEnabled = true;
        } else if (CurrentUnstableState == IsUnstableState.Active) {
            CurrentUnstableState = IsUnstableState.Deactivated;
            BallDataSO.isRandomHighVelocityEnabled = false;
        }

    }

    private enum IsUnstableState {
        Active, Deactivated
    }

}
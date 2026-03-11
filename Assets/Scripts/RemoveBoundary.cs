using UnityEngine;

public class RemoveBoundary : MonoBehaviour {

    [SerializeField] private GameObject CircleBoundary;

    private CircleBoundaryState circleBoundaryState = CircleBoundaryState.Active;

    public void ToggleCircleBoundary() {

        if (circleBoundaryState == CircleBoundaryState.Active) {
            CircleBoundary.SetActive(false);
            circleBoundaryState = CircleBoundaryState.Inactive;
        }
        else {
            CircleBoundary.SetActive(true);
            circleBoundaryState = CircleBoundaryState.Active;
        }

    }

    private enum CircleBoundaryState {
        Active,
        Inactive
    }   
}
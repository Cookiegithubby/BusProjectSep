using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Inputs.Readers;

public class Oliver : PassangerInteraction
{
    [SerializeField] private XRInputValueReader<Vector3> rightHandVelocity;
    [SerializeField] private XRInputValueReader<Vector3> leftHandVelocity;
    [SerializeField] private float forceNeeded;

    protected override void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag != "Controller") { return; }

        Vector3 rightVelo = rightHandVelocity.ReadValue();
        Vector3 leftVelo = leftHandVelocity.ReadValue();
        float maxVelo = Mathf.Max(rightVelo.magnitude, leftVelo.magnitude);

        if (maxVelo >= forceNeeded && passanger.state == currentState.Task)
        {
            passanger.state = currentState.MoveToWindow;
        }

        base.OnTriggerEnter(other);
    }
}

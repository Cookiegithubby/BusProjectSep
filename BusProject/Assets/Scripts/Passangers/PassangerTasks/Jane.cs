using UnityEngine;

public class Jane : PassangerInteraction
{
    [SerializeField] Transform headPhones;
    private Transform initialHeadphoneTransform;

    private void Start()
    {
        initialHeadphoneTransform.position = headPhones.position;
    }

    protected override void TaskInteract()
    {
        if (headPhones.position != initialHeadphoneTransform.position)
            passanger.state = currentState.MoveToWindow;

        base.TaskInteract();
    }
}

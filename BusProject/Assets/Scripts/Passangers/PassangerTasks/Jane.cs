using UnityEngine;

public class Jane : PassangerInteraction
{
    [SerializeField] Transform headPhones;
    private Transform initialHeadphoneTransform;
    [SerializeField] float headphoneDist;

    private void Start()
    {
        initialHeadphoneTransform.position = headPhones.position;
    }

    protected override void TaskInteract()
    {
        if (Mathf.Abs(headPhones.position.x - initialHeadphoneTransform.position.x) > headphoneDist ||
            Mathf.Abs(headPhones.position.y - initialHeadphoneTransform.position.y) > headphoneDist ||
            Mathf.Abs(headPhones.position.z - initialHeadphoneTransform.position.z) > headphoneDist)
            passanger.state = currentState.MoveToWindow;

        base.TaskInteract();
    }
}

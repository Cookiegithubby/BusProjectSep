using UnityEngine;

public class Jane : PassangerInteraction
{
    [SerializeField] float headphoneDist;
    private bool headphonesMoved;

    protected override void TaskInteract()
    {
        if (headphonesMoved && passanger.state == currentState.Task)
            passanger.state = currentState.MoveToWindow;

        base.TaskInteract();
    }

    public void HeadPhonesMoved() { headphonesMoved = true; }
}

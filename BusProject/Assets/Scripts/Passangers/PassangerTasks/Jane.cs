using UnityEngine;

public class Jane : PassangerInteraction
{
    public void HeadPhonesMoved() { passanger.state = currentState.MoveToWindow; PlayerInteraction(); }
}

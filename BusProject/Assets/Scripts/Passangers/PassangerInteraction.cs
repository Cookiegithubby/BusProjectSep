using UnityEngine;

public abstract class PassangerInteraction : MonoBehaviour 
{
    [SerializeField] protected PassangerManager manager;
    [SerializeField] protected Passanger passanger;

    protected virtual void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag != "Controller") return;

        PlayerInteraction();
    }

    protected void PlayerInteraction()
    {
        switch(passanger.state)
        {
            case currentState.Task:
                TaskInteract(); break;
            case currentState.MoveToWindow:
                MoveToWindow(); break;
            case currentState.WaitingByWindow:
                WaitByWindow(); break;
            case currentState.Evacuate:
                Evacuate(); break;
        }
    }

    //Spiller har ikke opnået npc'ens krævede task for flytning til vindue
    protected virtual void TaskInteract() { passanger.ShowDialogue(); }

    protected virtual void MoveToWindow() { passanger.GetUpAndMoveToWinodw(); }

    protected virtual void WaitByWindow() { passanger.ShowDialogue(); }

    protected virtual void Evacuate() { passanger.Evacuate(); }

}

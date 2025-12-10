using System.Threading.Tasks;
using UnityEngine;

public abstract class Passanger : MonoBehaviour
{
    public bool readyToEvacuate;
    [SerializeField] private int scoreValue;
    private currentState state = currentState.Task;

    [SerializeField] private GameObject Dialogue;
    [SerializeField] private Animator Animator;
    [SerializeField] private Transform windowPos;
    [SerializeField] private PassangerManager passangerManager;

    public void MoveToWindow()
    {
        transform.position = windowPos.position;
    }

    public bool Evacuate()
    {
        //Tjek om glass er smadret gennem passanger manager og state = Evacuate,
        //derefter add score til scoremanager og disable gameobject

        if (passangerManager.glassBroken && state == currentState.Evacuate)
        {
            passangerManager.addScore(scoreValue);
            return true;
        }

        return false;
    }

    public abstract void CompleteTask();

    public void ShowDialogue()
    {
        Dialogue.SetActive(true);
    }

    public void HideDialogue()
    {
        Dialogue.SetActive(false);
    }
}



public enum currentState
{
    Task,
    MoveToWindow,
    Evacuate
}

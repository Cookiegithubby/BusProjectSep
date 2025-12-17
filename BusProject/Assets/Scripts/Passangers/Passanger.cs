using System.Collections;
using System.Linq;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;

public class Passanger : MonoBehaviour
{
    public bool readyToEvacuate;
    [SerializeField] private int scoreValue;
    public currentState state = currentState.Task;

    [SerializeField] private GameObject Dialogue;
    [SerializeField] private string windowDialogue;
    [SerializeField] private Animator animator;
    [SerializeField] private Transform windowPos;
    [SerializeField] private PassangerManager passangerManager;

    public void GetUpAndMoveToWinodw(){ animator.SetTrigger("Stand"); StartCoroutine(MoveToWindow()); }

    private IEnumerator MoveToWindow() //Kaldes gennem animator events
    {
        yield return new WaitForSeconds(3);
        changeDialogue(windowDialogue);

        state = currentState.WaitingByWindow;
        transform.localPosition = windowPos.localPosition;
        transform.localRotation = windowPos.localRotation;
        if (passangerManager.glassBroken) { state = currentState.Evacuate; }
    }

    public void changeDialogue(string msg)
    {
        if (Dialogue.TryGetComponent<TextMeshProUGUI>(out TextMeshProUGUI dialogueText))
        {
            dialogueText.text = msg;
        }
    }

    public void Evacuate()
    {
        if (state != currentState.Evacuate) return;

        passangerManager.addScore(scoreValue, true);
        this.gameObject.SetActive(false);

    }

    public void CompleteTask() 
    {
        if (state != currentState.Task) return;
        
        state = currentState.MoveToWindow;
    }


    private bool dialogueShown;
    public void ShowDialogue()
    {
        Dialogue.SetActive(true);
        if (!dialogueShown) 
        StartCoroutine(HideDialogue());
        else
        {
            StopAllCoroutines();
            StartCoroutine(HideDialogue());
        }
    }

    private IEnumerator HideDialogue()
    {
        dialogueShown = true;
        yield return new WaitForSeconds(4);
        Dialogue.SetActive(false);
        dialogueShown = false;
    }
}

public enum currentState
{
    Task,
    MoveToWindow,
    WaitingByWindow,
    Evacuate
}

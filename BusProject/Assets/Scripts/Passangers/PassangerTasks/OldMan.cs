using UnityEngine;

public class OldMan : PassangerInteraction
{
    [SerializeField] private GameObject stok;
    [SerializeField] private string stokDialogue;
    override protected void OnTriggerEnter(Collider other)
    {
        //Stok check
        if (other.gameObject.tag == "Stok" && passanger.state == currentState.Task)
        {
            passanger.state = currentState.MoveToWindow;
            stok.SetActive(false);
            StokDialogue();
        }

        base.OnTriggerEnter(other); //Player interaction check
    }

    private void StokDialogue()
    {
        passanger.changeDialogue(stokDialogue);
        passanger.ShowDialogue();
    }
}

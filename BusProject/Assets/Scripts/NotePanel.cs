using UnityEngine;

public class NotePanel : MonoBehaviour
{
    [SerializeField] private GameObject noteCanvas;

    private void Awake()
    {
        if (noteCanvas != null)
            noteCanvas.SetActive(false);   // skjul noten fra start
    }

    // Bruges hvis du manuelt vil toggle via events/knapper
    public void ToggleNote()
    {
        Debug.Log("ToggleNote KALDT");

        if (noteCanvas == null) return;
        noteCanvas.SetActive(!noteCanvas.activeSelf);
    }

    // Vises automatisk, når controlleren går ind i triggeren
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Controller") && noteCanvas != null)
        {
            Debug.Log("Controller ENTER note-trigger");
            noteCanvas.SetActive(true);
        }
    }

    // Skjules igen, når controlleren forlader triggeren
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Controller") && noteCanvas != null)
        {
            Debug.Log("Controller EXIT note-trigger");
            noteCanvas.SetActive(false);
        }
    }
}

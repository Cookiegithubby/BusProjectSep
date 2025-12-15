using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR.Interaction.Toolkit;

public class GameOverController : MonoBehaviour
{
    [Header("XR Movement (disable on Game Over)")]
    [SerializeField] private Behaviour[] movementToDisable;

    private bool isShown = false;

    public void Show()
    {
        if (isShown) return;
        isShown = true;

        // Slå bevægelse fra
        foreach (var m in movementToDisable)
        {
            if (m != null)
                m.enabled = false;
        }

        gameObject.SetActive(true);
    }

    public void Restart()
    {
        // Slå bevægelse til igen
        foreach (var m in movementToDisable)
        {
            if (m != null)
                m.enabled = true;
        }

        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.buildIndex);
    }

    public void Quit()
    {
        Application.Quit();
    }
}

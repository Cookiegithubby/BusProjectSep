using UnityEngine;

public class PlaceCanvasInFrontOfXRCamera : MonoBehaviour
{
    [SerializeField] private float distance = 2.0f;
    [SerializeField] private Vector3 localScale = new Vector3(0.002f, 0.002f, 0.002f);

    private void Start()
    {
        var cam = Camera.main != null ? Camera.main.transform : null;
        if (cam == null)
        {
            Debug.LogError("Ingen Camera.main fundet i GameOverScene. Tjek Main Camera tag = MainCamera.");
            return;
        }

        transform.SetParent(cam, false);
        transform.localPosition = new Vector3(0f, 0f, distance);
        transform.localRotation = Quaternion.identity;
        transform.localScale = localScale;
    }
}

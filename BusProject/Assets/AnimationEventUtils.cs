using UnityEngine;

public class AnimationEventUtils : MonoBehaviour
{
    public Transform[] parents;

    private GameObject spawnedObject;

    public void Spawn(Object obj)
    {
        if (spawnedObject != null)
            return;

        spawnedObject = Instantiate(obj) as GameObject;
    }

    public void Despawn()
    {
        if (spawnedObject == null)
            return;

        Destroy(spawnedObject);
    }

    public void SetParent(int index)
    {
        if (index > parents.Length - 1)
            return;

        var parent = parents[index];

        if (spawnedObject.transform.parent == parent)
            return;

        spawnedObject.transform.parent = parent;
        spawnedObject.transform.localPosition = Vector3.zero;
        spawnedObject.transform.localRotation = Quaternion.identity;
    }

}

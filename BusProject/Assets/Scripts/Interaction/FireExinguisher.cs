using UnityEngine;

public class FireExinguisher : MonoBehaviour
{
    public Transform foamSpot;
    public Transform foamParticles;
    public void setFoamToPos() 
    {
        foamParticles.rotation = foamSpot.rotation;
        foamParticles.position = foamSpot.position;
    }

}

using UnityEngine;

public class Busmovescript : MonoBehaviour
{
    public float speed = 5f;
    public float speedcap = 15f;
    public float speedinc = 0.5f;
    public float rotspeed = 0.1f;
    public float rotspeedinc;
    public float rotspeedcap = 5f;
    public bool turnright = false;
    float upperanglecap = 195f;
    float loweranglecap = 165f;
    // Update is called once per frame
    void Update()
    {

        transform.position += new Vector3(speed * Time.deltaTime, 0, 0);

        if (turnright)
        {
            transform.Rotate(0, rotspeed * Time.deltaTime, 0);
            if (transform.eulerAngles.y >= upperanglecap)
            {
                upperanglecap = Random.Range(185f, 210f);
                turnright = false;
            }
                
        }
        else
        {
            transform.Rotate(0, -rotspeed * Time.deltaTime, 0);
            if (transform.eulerAngles.y <= loweranglecap)
            {
                loweranglecap = Random.Range(170f, 155f);
                turnright = true;
            }
        }

        rotspeed += rotspeedinc * Time.deltaTime;
        if (rotspeed >= rotspeedcap)
            rotspeed = rotspeedcap;

        speed += speedinc * Time.deltaTime;
        if (speed >= speedcap)
            speed = speedcap;
    }

}

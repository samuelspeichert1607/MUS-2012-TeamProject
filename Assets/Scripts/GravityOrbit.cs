using UnityEngine;

public class GravityOrbit : MonoBehaviour
{
    public float gravity;

    public bool FixedDirection; //if the gravity of this section is only pushing the player down

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<GravityCtrl>())
        {
            //if this object has a gravity script, set this as the planet
            other.GetComponent<GravityCtrl>().gravityOrbit = this.GetComponent<GravityOrbit>();
        }
    }
}

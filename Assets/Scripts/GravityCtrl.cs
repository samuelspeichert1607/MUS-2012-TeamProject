using UnityEngine;
using UnityEngine.SceneManagement;

public class GravityCtrl : MonoBehaviour
{
    public GravityOrbit gravityOrbit;
    private Rigidbody rb;

    public float rotationSpeed = 20;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    
    private void FixedUpdate()
    {
        if (SceneManager.GetActiveScene().name == "Space_Level")
        {
            if (gravityOrbit == null)
            {
                gravityOrbit = GameObject.Find("PlanetA").GetComponentInChildren<GravityOrbit>();
            }
            else if (gravityOrbit)
            {
                Vector3 gravityUp = Vector3.zero;

                if (gravityOrbit.FixedDirection)
                {
                    gravityUp = gravityOrbit.transform.up;
                }
                else
                {
                    gravityUp = (transform.position - gravityOrbit.transform.position).normalized;
                }

                Vector3 localUp = transform.up;

                Quaternion targetRotation = Quaternion.FromToRotation(localUp, gravityUp) * transform.rotation;

                //Ajouté selon les commentaires
                rb.rotation = targetRotation;

                transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

                //transform.up = Vector3.Lerp(transform.up, gravityUp, rotationSpeed * Time.deltaTime);

                //Push down
                rb.AddForce((-gravityUp * gravityOrbit.gravity) * rb.mass);

                
            }
        }
    }
}

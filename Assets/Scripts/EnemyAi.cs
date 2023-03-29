using UnityEngine;

public class EnemyAi : MonoBehaviour
{
    public Vector3 initialPosition;

    public Vector3 destinationPosition;

    public Vector3 moveDirection;

    private Rigidbody rb;


    private bool grounded;

    public bool Grounded { get => grounded; private set => grounded = value; }

    public LayerMask whatIsGround;

    public int enemyHeight;

    public float groundDrag;


    public int moveSpeed;

    public Transform orientation;

    //Patroling
    public Vector3 walkPoint;
    private bool walkPointSet;
    public float walkPointRange;


    private void Awake()
    {
        initialPosition = gameObject.transform.position;
        rb = GetComponent<Rigidbody>();
        SetNewDestination();
    }
    
    private void Update()
    {

        // ground check
        Grounded = Physics.Raycast(transform.position, Vector3.down, enemyHeight * 0.5f + 0.3f, whatIsGround);



        if (Grounded)
        {
            if (transform.position != destinationPosition)
            {
                rb.AddForce(moveDirection.normalized * moveSpeed * 5f, ForceMode.Force);
            }
            else if (transform.position == destinationPosition)
            {
                SetNewDestination();
            }
        }

        
    }

    private void SetNewDestination()
    {

        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);

        // calculate movement direction
        moveDirection = transform.position + (orientation.forward * randomZ + orientation.right * randomX);
        moveDirection.y = 0;
        destinationPosition = new Vector3(transform.position.x + moveDirection.x, 0, transform.position.z + moveDirection.z);
    }


    /*private void Patroling()
    {
        if (!walkPointSet)
        {
            SearchWalkPoint();
        }

        if (walkPointSet)
        {
            //wagent.SetDestination(walkPoint);
        }

        Vector3 distanceToWalkPoint = transform.position - walkPoint;

        //Walkpoint reached
        if (distanceToWalkPoint.magnitude < 1f)
            walkPointSet = false;
    }*/


    private void SearchWalkPoint()
    {
        //Calculate random point in range
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);

        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

        if (Physics.Raycast(walkPoint, -transform.up, 2f, whatIsGround))
            walkPointSet = true;
    }

}

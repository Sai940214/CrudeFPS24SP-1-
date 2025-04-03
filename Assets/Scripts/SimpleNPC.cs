using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SimpleNPC : MonoBehaviour
{
    [SerializeField] Transform target;

    [SerializeField] float walkSpeed = 3.5f;
    [SerializeField] float runSpeed = 10f;

    [SerializeField] LayerMask navigableLayers;

    //Time related
    private NavMeshAgent agent;
    private Animator animator;

    //Components
    private float wanderTimer;
    [SerializeField] float wanderDelay = 5f;
    [SerializeField] float wanderDistance = 10f;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }

    private void Start()
    {
        if (!target)
        {
            target = GameObject.FindGameObjectWithTag("Player").transform;
        }
        agent.SetDestination(RandomNavSphere(wanderDistance));
    }

    private void Update()
    {
        //agent.SetDestination(target.position);


        //set Initial speed
        agent.speed = walkSpeed;

        //===ANIMATION===
        float remappedSpeed = Utils.Remap01(agent.velocity.magnitude, 0, runSpeed);
        animator.SetFloat("Speed", remappedSpeed);

        // === Distance Check ===
        // Is the agent close to the player?
        if (Vector3.Distance(target.position, transform.position) < 10f) 
        { 
            agent.speed = runSpeed;
            agent.SetDestination(target.position); 
            wanderTimer = 0f;
            return; //wont go any further with code
        }




        // === Wander Timer ===
        wanderTimer += Time.deltaTime; //Add time to timer
        if (wanderTimer >= wanderDelay)
        {
            agent.SetDestination(RandomNavSphere(wanderDistance)); //set new destination
            wanderTimer = 0f; //reset the timer
        }


        //agent.SetDestination(target.position);
       // agent.SetDestination(RandomNavSphere(10f));
    }

    private Vector3 RandomNavSphere(float distance)
    { 
        Vector3 randomDirection = Random.insideUnitSphere * distance;
        randomDirection += transform.position;

        // Find the nearest
        NavMeshHit hit;
        NavMesh.SamplePosition(randomDirection, out hit, distance, -1);

        return hit.position;
    }
}   

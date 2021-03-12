using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;

public class EnemyAi : MonoBehaviour
{
    public NavMeshAgent agent;

    public Transform player;

    public LayerMask whatIsGround, whatIsPlayer, whatIsEnemy;

    public float health;

    //Patroling
    public Vector3 walkPoint;
    bool walkPointSet;
    public float walkPointRange;

    //States
    public float sightRange;
    public bool playerInSightRange;
    

    //See the ON or OFF of my pj
    Transform light;
    LightChange scriptLight;
    public bool EnemyIsInLightRange;
    public float LightRange;

    public int EstadoPersonaje;
    private void Awake()
    {
        player = GameObject.Find("Player").transform;
        agent = GetComponent<NavMeshAgent>();
        light = GameObject.Find("LightN").transform;
        scriptLight = light.GetComponent<LightChange>();
        LightRange = scriptLight.myLight.range;
        
    }

    private void Update()
    {
        //Check for sight and attack range
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        EnemyIsInLightRange = Physics.CheckSphere(light.position, LightRange, whatIsEnemy);
        if (!playerInSightRange) 
            Patroling();
        if (playerInSightRange) 
            ChasePlayer();
        if (EnemyIsInLightRange && scriptLight.status == true)
            escapePlayer();
            
    }

    public void Patroling()
    {
        agent.speed = 3.0f;
        if (!walkPointSet) SearchWalkPoint();

        if (walkPointSet)
            agent.SetDestination(walkPoint);

        Vector3 distanceToWalkPoint = transform.position - walkPoint;

        //Walkpoint reached
        if (distanceToWalkPoint.magnitude < 1f)
            walkPointSet = false;
        EstadoPersonaje = 0;
    }
    private void SearchWalkPoint()
    {
        //Calculate random point in range
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);

        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

        if (Physics.Raycast(walkPoint, -transform.up, 2.0f, whatIsGround))
            walkPointSet = true;
        EstadoPersonaje = 1;
    }

    public void ChasePlayer()
    {
        agent.speed = 3.5f;
        agent.SetDestination(player.position);
        EstadoPersonaje = 1;
    }

    public void escapePlayer()
    {
        agent.speed = 5.0f;
        agent.SetDestination(walkPoint);
    }
    public void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0) Invoke(nameof(DestroyEnemy), 0.5f);
    }
    private void DestroyEnemy()
    {
        Destroy(gameObject);
    }

    private void OnDrawGizmosSelected()
    {
        
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, sightRange);

        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, walkPointRange);

       // Gizmos.color = Color.blue;
       // Gizmos.DrawWireSphere(light.position, LightRange);



    }

}

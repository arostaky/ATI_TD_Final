using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class Enemy : MonoBehaviour
{
    public int health = 100;
    public GameObject deathEffect;
    public NavMeshAgent agent;
    public Transform player;
    public LayerMask whatIsGround, whatIsPlayer;
    //Patroling:

    public Vector3 walkPoint;
    bool walkPointSet;
    public float walkPointRange;

    //Attacking
    public float timeBetweenAttacks;
    private bool alreadyAttacked;

    //States:
    public float sightRange, attackRange;
    public bool playerInSightRange, playerInAttackRange;

    //damage to player:
    public int damage = 20;
    public int Speed = 10;

    private void Awake(){
        player = GameObject.Find("FraiseBoy").transform;
        agent = GetComponent<NavMeshAgent>();
    }
    private void Update() {
        // Check for sight and attack range
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);
        if(!playerInSightRange && !playerInAttackRange) Patroling();
        if(playerInSightRange && !playerInAttackRange) ChasePlayer();
        if(playerInAttackRange && playerInSightRange) AttackPlayer();

    }
    private void Patroling(){
        if(!walkPointSet) SearchWalkPoint();
        if(walkPointSet){
            agent.SetDestination(walkPoint);
        }
        Vector3 distanceToWalkPoint = transform.position - walkPoint;

        // Walkpoint reached:
        if(distanceToWalkPoint.magnitude < 1f){
            walkPointSet = false;
        }

    }
    private void SearchWalkPoint(){
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        //float randomY = Random.Range(-walkPointRange, walkPointRange);
        walkPoint =  new Vector3(transform.position.x, transform.position.y, transform.position.z);
        if(Physics.Raycast(walkPoint,transform.forward, 2f, whatIsGround)){
            walkPointSet = true;
        }
    }
    private void ChasePlayer(){
        agent.SetDestination(player.position);
    }
    private void AttackPlayer(){
        EnemyWeapon enemyWeapon = gameObject.GetComponent<EnemyWeapon>();
        agent.SetDestination(transform.position);
        transform.LookAt(player);
        if(!alreadyAttacked){
            enemyWeapon.Shoot();
            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
        }
    }
    private void ResetAttack(){
        alreadyAttacked = false;
    }

    public void TakeDamage(int damage){
        health-= damage;
        if(health<=0){
            Die();
        }
    }
    void Die(){
        Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
    private void OnDrawGizmos() {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, sightRange);
    }
    // private void Fire(){
    //      Rigidbody rb = Instantiate(projectile, transform.position, Quaternion.identity).GetComponent<Rigidbody>();
    //      Instantiate(rb, transform.position, transform.rotation);
    //      rb.AddForce(transform.forward * 32f, ForceMode.Impulse);
    // }
    void OnTriggerEnter(Collider hitInfo) {
        MeatBoy player = hitInfo.GetComponent<MeatBoy>();
        Debug.Log(hitInfo);
         if (player != null){
             player.TakeDamage(damage);
         }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using TMPro;

public class ZombieScript : MonoBehaviour
{
    public TMP_Text healthtext;
    public GameManager gameManager;
    public Transform Player;
    public NavMeshAgent Agent;
    public float ZHealth;
    public float ZMaxHealth = 100f;
    public Animator anime;
    public bool isAttacked = false;
    public bool isDead = false;
    public bool isInRange = false;
    public bool isCoroutineRunning = false;
    public float rotationSpeed = 5f;

    void Start()
    {
        ZHealth = ZMaxHealth;
        anime = GetComponent<Animator>();
        healthtext.text = ZHealth.ToString();
    }
    // Update is called once per frame
    void Update()
    {   
        if (isCoroutineRunning == false && isInRange == true && isDead == false)
        {
            StartCoroutine("AttackWait");
        }
        //if not dead nor attacking, moves towards player
        if (isAttacked == false && isDead == false)
        {
            anime.SetBool("Walking", true);
            Agent.SetDestination(Player.position);
        }
        else
        {
            anime.SetBool("Walking", false);
        }
        //checks health
        if (ZHealth <=  0)
        {
            ZomDead();
            //ragdoll?
        }

            // Calculate the direction from the zombie to the player
            Vector3 directionToPlayer = Player.position - transform.position;
            directionToPlayer.y = 0;  // Keep the rotation on the horizontal plane

            // Get the target rotation
            Quaternion targetRotation = Quaternion.LookRotation(directionToPlayer);

            // Smoothly rotate towards the player
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }
    public void ZomDead()
    {
        //set death flag
        isDead = true;
        //death animation
        anime.SetBool("Dead", true);
        StartCoroutine("DeadDespawn");
        Agent.isStopped = true;
        
    }
    public void BulletHit()
    {   
        if (ZHealth > 0)
        {
            healthtext.text = ZHealth.ToString();
        }
        else if (ZHealth <= 0)
        {
            healthtext.text = "DEAD";
        }
    }

    void OnTriggerStay(Collider stay)
    {
        //if close enough to player, begins attack
        if (stay.gameObject.CompareTag("PreHit"))
        {
            if (isInRange == false)
            {isInRange = true;
            }
        }
        
        if (stay.gameObject.CompareTag("HitBox"))
        {
            if (isAttacked == true)
            {
                //damage player
                gameManager.PlayerHealth -= 1; 
                gameManager.PlayerDamage();
                Debug.Log(gameManager.PlayerHealth);
                isAttacked = false;
            }
        }

    }
    void OnTriggerExit(Collider exit)
    {
        if (exit.CompareTag("PreHit"))
        {
            isInRange = false;
        }
    }

    IEnumerator AttackWait()
    {   
        isCoroutineRunning = true;

        //start animation     
        anime.SetTrigger("AttackAni");
        //wait 
        yield return new WaitForSeconds(1);
        //stop navigation for attack 
        isAttacked = true;
         
        yield return new WaitForSeconds(1);
        isAttacked = false;
        isCoroutineRunning = false;

    }
    IEnumerator DeadDespawn()
    {
        yield return new WaitForSeconds(10);
        Destroy(gameObject);
    }
}

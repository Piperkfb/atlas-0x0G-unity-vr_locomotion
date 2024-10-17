using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{   
    public GameObject BloodPart;
    private GameObject BloodSplatter;
    public ZombieScript ZombieScript;



    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerEnter(Collider Trigger)
    {
         //what did it collide with
        GameObject collider = Trigger.gameObject;
        if (collider.CompareTag("Zombie Head"))
        {
            //headshot
            Debug.Log("HeadShot");
            //send damage data
            ZombieScript.ZHealth -= 50f;
            ZombieScript.BulletHit();
            //blood effect from location of bullet //want instantize
            Transform location = transform;
            BloodSplatter = Instantiate(BloodPart, location.position, Quaternion.identity);
            //delete bullet
            Destroy(BloodSplatter, 1f);
            Destroy(gameObject);
            
             
        }
        else if (collider.CompareTag("Zombie Body"))
        {
            //body shot
            Debug.Log("BodyShot");
            //Send damage data
            ZombieScript.ZHealth -= 10f;
            ZombieScript.BulletHit();
            //blood effect from location of bullet
            Transform location = transform;
            BloodSplatter = Instantiate(BloodPart, location.position, Quaternion.identity);
            //delete bullet
            Destroy(BloodSplatter, 1f);
            Destroy(gameObject);
        }
    }
    void OnCollisionEnter(Collision collision)      
    {
        GameObject collider = collision.gameObject;
        {   
            if(!collider.CompareTag("Gun"))
            {
                Debug.Log(collision.gameObject.name);
                //regular effect 
                Debug.Log("Other collide");
                //delete bullet
                Destroy(gameObject);
            }
            
        }
    }
}

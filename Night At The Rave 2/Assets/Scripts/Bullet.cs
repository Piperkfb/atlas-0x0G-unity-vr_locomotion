using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{   
    public GameObject BloodPart;
    private GameObject BloodSplatter;
    //public ZombieScript ZombieScript;



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
            ZombieScript ZomScript = collider.GetComponentInParent<ZombieScript>();
            //headshot
            Debug.Log("HeadShot");
            //send damage data
            ZomScript.ZHealth -= 50f;
            ZomScript.BulletHit();
            //blood effect from location of bullet //want instantize
            Transform location = transform;
            BloodSplatter = Instantiate(BloodPart, location.position, Quaternion.identity);
            //delete bullet
            Destroy(BloodSplatter, 1f);
            Destroy(gameObject);
            
             
        }
        else if (collider.CompareTag("Zombie Body"))
        {
            ZombieScript ZomScript = collider.GetComponentInParent<ZombieScript>();
            //body shot
            Debug.Log("BodyShot");
            //Send damage data
            ZomScript.ZHealth -= 10f;
            ZomScript.BulletHit();
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

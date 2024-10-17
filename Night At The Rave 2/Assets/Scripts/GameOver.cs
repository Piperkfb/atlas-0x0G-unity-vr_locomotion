using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    public Transform vrCam;
    public float Distance = 5f;
    public Vector3 Offset = Vector3.zero;
    public void SpawnCanvas()
    {
        gameObject.SetActive(true);
        // Position the canvas in front of the player's face
        transform.position = vrCam.position + vrCam.forward * Distance + Offset;

        // Rotate the canvas to always face the player
        transform.rotation = Quaternion.LookRotation(transform.position - vrCam.position);
    }
    public void DisableCanvas()
    {
        gameObject.SetActive(false);
    }
}

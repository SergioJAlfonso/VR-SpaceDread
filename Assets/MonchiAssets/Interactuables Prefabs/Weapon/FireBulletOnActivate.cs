/*
 * Simple Shot Functionality
 * Monchi Master
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class FireBulletOnActivate : MonoBehaviour
{
    public GameObject bullet_;
    public Transform spawnPoint_;
    public float fireSpeed = 20;

    public void FireBullet(ActivateEventArgs arg)
    {
        GameObject spawnedBullet = Instantiate(bullet_);
        spawnedBullet.SetActive(true);
        spawnedBullet.transform.position = spawnPoint_.position;
        spawnedBullet.GetComponent<Rigidbody>().velocity = spawnPoint_.forward * fireSpeed;
        Destroy(spawnedBullet, 5);
    }

}


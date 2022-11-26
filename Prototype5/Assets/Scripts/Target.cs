/* 
 * Zach Wilson
 * Assignment 8
 * This script manages target prefabs
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    //public values
    public int pointValue = 1;
    public ParticleSystem explosionParticle;

    //private variables and references
    private GameManager gm;
    private Rigidbody targetRb;
    private float minSpeed = 12;
    private float maxSpeed = 16;
    private float torqueRange = 10;
    private float xRange = 4;
    private float ySpawnPos = -6;

    // Start is called before the first frame update
    void Start()
    {
        targetRb = GetComponent<Rigidbody>();

        //add a force upwards multiplied by a randomized speed
        targetRb.AddForce(RandomForce(), ForceMode.Impulse);

        //add a torque (rotational force) with randomized xyz values
        targetRb.AddTorque(RandomTorque(), RandomTorque(), RandomTorque(), ForceMode.Impulse);

        //set the position with a randomized X value
        transform.position = RandomSpawnPos();

        //get the GameManager
        gm = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }

    private Vector3 RandomSpawnPos()
    {
        return new Vector3(Random.Range(-xRange, xRange), ySpawnPos);
    }

    private float RandomTorque()
    {
        return Random.Range(-torqueRange, torqueRange);
    }

    private Vector3 RandomForce()
    {
        return Vector3.up * Random.Range(minSpeed, maxSpeed);
    }

    private void OnMouseDown()
    {
        if(!gm.b_GameOver)
        {
            //add points for object
            gm.UpdateScore(pointValue);
            //explosion particles
            Instantiate(explosionParticle, transform.position, explosionParticle.transform.rotation);
            //destroy game object
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        //what to do if the object was good and gets destroyed by the collider
        if(pointValue >= 0 && !gm.b_GameOver)
        {
            gm.UpdateScore(-pointValue);
            gm.GameOver();
        }

        //destory object
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

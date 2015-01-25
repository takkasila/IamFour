using UnityEngine;
using System.Collections;

public class SimpleParticle : MonoBehaviour {

    public GameObject particle;
    public float spawn_rate;
    float spawn_rate_counter;
    public Vector2 spawn_vel_max;
    public float lifeTime;
    float lifeTime_counter;


	
	// Update is called once per frame
	void Update () {
        lifeTime_counter += Time.deltaTime;

        if(lifeTime_counter<= lifeTime)
        {
            spawn_rate_counter += Time.deltaTime;
            if(spawn_rate_counter>=spawn_rate)
            {
                spawn_rate_counter = 0;
                GameObject spawnParticle = (GameObject) Instantiate(particle, transform.position,Quaternion.identity);
                spawnParticle.rigidbody2D.velocity = new Vector2(Random.Range(0, spawn_vel_max.x *2) - spawn_vel_max.x
                    , Random.Range(0, spawn_vel_max.y*2) - spawn_vel_max.y);

            }
        }
        else
        {
            Destroy(gameObject);

        }
	
	}
}

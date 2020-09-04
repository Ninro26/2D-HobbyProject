using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyableObjects : MonoBehaviour {

    public float health;
    public ParticleSystem destructionparticle;
    public Transform Object;
    public GameObject healthbar;

    // Use this for initialization
    void Start()
    {

        //healthbar = transform.localScale;

    }

    // Update is called once per frame
    void Update()
    {
        if (health < 0)
        {
            Instantiate(destructionparticle, Object.position, Object.rotation);
            Destroy(gameObject);

        }


        healthbar.transform.localScale = new Vector3(health / 100, 1, 1);
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
    }
}

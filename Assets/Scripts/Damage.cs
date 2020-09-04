using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour {

    [SerializeField] int damage;
    
	// Use this for initialization
	void Start () {
		
	}
 
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<PlayerMove>().TakeDamage(damage);
        }
    }
    // Update is called once per frame
    void Update () {
		
	}
}

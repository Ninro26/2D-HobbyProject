using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bow : MonoBehaviour {

    public Transform firepoint;
    public GameObject arrow;
    [SerializeField] float offset;
    
    private float TimebtwShots;
    public float StartTimeBtwShots;

	// Use this for initialization
	void Start () {
        
    }
	
	// Update is called once per frame
	private void Update () {

        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float rotZ = Mathf.Atan2(difference.y, difference.x ) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotZ + offset);


        if (TimebtwShots <= 0)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                Instantiate(arrow, firepoint.position, transform.rotation);
                TimebtwShots = StartTimeBtwShots;
            }

        }
        else
        {
            TimebtwShots -= Time.deltaTime;
        }

	}
 



}

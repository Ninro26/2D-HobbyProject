using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pedestal : MonoBehaviour {

    public GameObject bow;
    public Transform weaponSpawn;
    public GameObject sword;
    public GameObject hunterPanel;
    public GameObject swordPanel;
    public bool weaponChosen;
    public bool entered;
    public GameObject pedestalSword;
    public GameObject pedestalBow;
 
	// Use this for initialization
	void Start () {
		
	}

    // Update is called once per frame
    void Update () {

        if (weaponChosen == true)
        {
            
            Destroy(pedestalBow);
            Destroy(pedestalSword);
           
        }
        

     

	}

    public void chooseBow()
    {
        if (weaponChosen == false)
        {
            Instantiate(bow, weaponSpawn.position, transform.rotation, weaponSpawn);
            weaponChosen = true;
         
        }
    }

    public void chooseSword()
    {
        if (weaponChosen == false)
        {
            Instantiate(sword, weaponSpawn.position, transform.rotation, weaponSpawn);
            weaponChosen = true;
            
        }

    }

   
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            entered = true;
        }

        if (entered == true && weaponChosen == false && collision.tag == "Player" && gameObject.name == "Sword")
        {
            swordPanel.SetActive(true);
        }
        if (entered == true && weaponChosen == false && collision.tag == "Player" && gameObject.name == "Bow")
        {
            Debug.Log("bow");
            hunterPanel.SetActive(true);
        }
      
    }
    
    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            entered = false;
        }

        if (entered == false)
        {
            swordPanel.SetActive(false);
        }

        if (entered == false)
        {
            hunterPanel.SetActive(false);
            Debug.Log("exit");
        }

    }
}

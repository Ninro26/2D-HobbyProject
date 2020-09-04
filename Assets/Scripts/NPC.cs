using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour {


  //public GameObject playerInvetory;
    public GameObject npcShop;
    public GameObject Ebutton;
    public GameObject textbubble;
    public bool Entered;
    Animator anim;
	// Use this for initialization
	void Start () {
        Entered = false;
        anim = GetComponent<Animator>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
       

        if (collision.tag == "Player")
        {
            Ebutton.SetActive(true);
            textbubble.SetActive(true);

            Entered = true;
        }
    }
    // Update is called once per frame
    void Update () {


       
        if (Entered == true && Input.GetKeyDown(KeyCode.E))
        {
            anim.GetComponent<Animator>().enabled = false;
            //playerInvetory.SetActive(true);
            npcShop.SetActive(true);
            Debug.Log("menu");
        }
        if (Entered == false /*|| Input.GetKeyDown(KeyCode.E)*/)
        {
           // playerInvetory.SetActive(false);
            npcShop.SetActive(false);
            anim.GetComponent<Animator>().enabled = true;

        }

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Ebutton.SetActive(false);
            Debug.Log("exit");
            Entered = false;
            textbubble.SetActive(false);


        }



    }   

    


}

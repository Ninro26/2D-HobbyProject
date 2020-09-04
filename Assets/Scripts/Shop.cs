using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Shop : MonoBehaviour {
  
    SpriteRenderer spriteRenderer;
    

    // Use this for initialization
    void Start () {
      
      
        
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();

    }
	
	// Update is called once per frame
	void Update () {
		
	}

     public void change(Sprite differentSprite)
    {
        GameObject thePlayer = GameObject.Find("Character");
        PlayerMove playerScript = thePlayer.GetComponent<PlayerMove>();
        if (playerScript.Gold > 9)

        {
            spriteRenderer.sprite = differentSprite;
        }
        
    }

}

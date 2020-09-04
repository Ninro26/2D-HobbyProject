using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    public float experiencePoints;
    public float health;
    public ParticleSystem Bloodspatter;
    public Transform enemy;
    public Transform player;
    public GameObject healthbar;
    public AudioSource impact;
    private Rigidbody2D rb;
    public PlayerMove playerMove;
    public GameObject remainingBlood;
    // Use this for initialization
    void Start() {

        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        rb = this.GetComponent<Rigidbody2D>();
        //healthbar = transform.localScale;
        Chase();

    }

    


    

    IEnumerator SlimeJump()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(1, 2));
            if (enemy.position.x < player.transform.position.x)
            {


                transform.localScale = new Vector3(-1, 1, 1);
                rb.AddForce(new Vector2(5, 15), ForceMode2D.Impulse);

            }
           else if (enemy.position.x > player.transform.position.x)
            
            {
                transform.localScale = new Vector3(1, 1, 1);

                rb.AddForce(new Vector2(-5, 15), ForceMode2D.Impulse);
                

            }
            yield return new WaitForSeconds(2);
        }
    }

    void Chase()
    {
        StartCoroutine(SlimeJump());
    }
    // Update is called once per frame
    void Update () {
		if (health < 0)
        {
            
            Instantiate(remainingBlood, enemy.position, Quaternion.Euler(new Vector3(Random.Range(0, 30), Random.Range(0, 50), Random.Range(0, 50))));
            Instantiate(Bloodspatter, enemy.position, enemy.rotation);
            playerMove.currentExperience += experiencePoints;

            Destroy(gameObject);

        }

    

        healthbar.transform.localScale = new Vector3(health / 100, 1, 1);
    }
    public IEnumerator Knockback(float knockDur, float knockPwr, Vector3 knockbackDir)
    {
        float timer = 0;
        rb.velocity = new Vector2(rb.velocity.x, 0);
        while (knockDur > timer)
        {
            timer += Time.deltaTime;
            rb.AddForce(new Vector3(knockbackDir.x * -100, knockbackDir.y * knockPwr, transform.position.z));

        }
        yield return 0;
    }


    public void TakeDamage(float damage)
    {
      //  rb.AddForce(new Vector2(10, 10));
       // rb.AddForce(new Vector2(5, 0), ForceMode2D.Impulse);
        impact.Play();
        health -= damage;
        StartCoroutine(this.Knockback(0.02f, 350, this.transform.position));
    }

  
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sword : MonoBehaviour {

    private float TimebtwSwings;
    [SerializeField] float StartTimeBtwSwings;
   
    public Transform attackPos;
    public float attackRange;
    public int damage;
    public LayerMask whatIsEnemies;
    private GameObject character;
    public Animator attackAnim;
    
    // Use this for initialization
    void Start()
    {

       // character = GameObject.Find("Character");
       // attackAnim = character.GetComponent<Animator>();

    }

    // Update is called once per frame
    private void Update()
    {

       
      
      

        if (TimebtwSwings <= 0)
        {
            if (Input.GetButtonDown("Fire1"))

            {
                
                attackAnim.SetBool("SwordAttack", true);
                Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPos.position, attackRange, whatIsEnemies);
                for (int i = 0; i <enemiesToDamage.Length; i++)
                {
                    enemiesToDamage[i].GetComponent<Enemy>().TakeDamage(damage);
                }
                TimebtwSwings = StartTimeBtwSwings;
            }
            

        }
        else
        {
            TimebtwSwings -= Time.deltaTime;
        }
        if (Input.GetButtonUp("Fire1"))
        {
            attackAnim.SetBool("SwordAttack", false);
        }

    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPos.position, attackRange); 
    }



}
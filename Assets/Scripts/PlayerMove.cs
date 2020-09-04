using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class PlayerMove : MonoBehaviour
{
    public GameObject dustEffect;
    public Animator animator;
    public int Gold = 60;
    public Text text;
    public static PlayerMove instance;
    public float currentExperience;

    public float speed;
    private float movementInput;
    private Rigidbody2D rb;
    private int extraJumps;
    private LayerMask platform;
    private bool facingRight;
    private BoxCollider2D boxCollider2d;
    [SerializeField] private LayerMask Ground;
    [SerializeField] float Health;
    [SerializeField] Image healthbar;
    [SerializeField] Image experienceBar;
    private float healthbarFillamount;
    private float experiencebarFillamount;
    
    int level = 1;
    public TMP_Text levelText;
    // Use this for initialization
    

    void Start()
    {
        instance = this;
        rb = GetComponent<Rigidbody2D>();
        boxCollider2d = transform.GetComponent<BoxCollider2D>();
        animator = GetComponent<Animator>();
        DontDestroyOnLoad(gameObject);
   

    }

    void Update()
    {
        healthbar.fillAmount = healthbarFillamount;
        // healthbar.fillAmount = Health;
        experienceBar.fillAmount = currentExperience / 100;
        healthbarFillamount = Health / 100;
        movementInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(movementInput * speed, rb.velocity.y);
        animator.SetFloat("speed", Mathf.Abs(movementInput));

        if (currentExperience > 99 )
        {
            currentExperience -= 100;
            level++;
          
            levelText.text = level.ToString();
        }
        if (Input.GetKeyDown("space") && isGrounded()) 
        {
            rb.AddForce(new Vector2(0, 10f), ForceMode2D.Impulse);
        }

        Vector3 mousePos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10);
        Vector3 playerPos = Camera.main.ScreenToWorldPoint(mousePos);
        playerPos = playerPos - transform.position;


        if (playerPos.x < 0 && !facingRight)
        {
            Flip();
        }
        if (playerPos.x > 0 && facingRight)
        {
            Flip();
        }
        text.text = Gold.ToString();
    }


    void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;

    }

    public void buy()
    {
        if (Gold > 0)
        {
            Gold -= 10;
        }

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(tag == "Enemy")
        {
            TakeDamage(5);
        }
    }

    public void TakeDamage(float damage)
    {
        rb.AddForce(new Vector2(5, 5), ForceMode2D.Impulse);


        Health -= damage;
        
    }

    private bool isGrounded()
    {
        float extraHeightText = 1f;
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider2d.bounds.center, boxCollider2d.bounds.size, 0f, Vector2.down, boxCollider2d.bounds.extents.y + extraHeightText, Ground);
        Color rayColor;
        if (raycastHit.collider != null)
        {
            rayColor = Color.green;
        } else {
            rayColor = Color.red;
        }

        return raycastHit.collider != null;
    }
}

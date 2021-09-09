using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playercontroller : MonoBehaviour
{
      private SpriteRenderer sr;
    private Animator animator;
    private Rigidbody2D rb2d;
    private float speed = 5;
    private bool muere = false;
   
    private int puntos=0;
    // Start is called before the first frame update
    void Start()
    {
        sr= GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();

        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rb2d.gravityScale = 25;
         if(muere==false){
            quieto();
            if(Input.GetKey(KeyCode.RightArrow))
            {
                sr.flipX = false;
                        
                rb2d.velocity = new Vector2(speed,rb2d.velocity.y);
                correr();
                 if(Input.GetKey(KeyCode.Space))
            {            
            saltarF();
            
            }
            }else if(Input.GetKey(KeyCode.LeftArrow))
            {
                sr.flipX = true;
            
                rb2d.velocity = new Vector2(-speed,rb2d.velocity.y);
                correr();
                 if(Input.GetKey(KeyCode.Space))
            {            
            saltarF();
            
            }
            }
            
         }
         else{
            morir();
           
         }
    }
    
    
    void OnCollisionEnter2D(Collision2D other){
       if(other.gameObject.layer == 6){// muere el player
             Destroy(this.gameObject);
            
             muere = true; 
          
        }
    }
       public void saltarF(){
        var upSpeed = 80f;
        rb2d.velocity = Vector2.up * upSpeed;
        saltar();
    }
    public void quieto(){
        animator.SetInteger("estado", 0);        
    }
     public void correr(){
        animator.SetInteger("estado", 1);        
    }
     public void saltar(){
        animator.SetInteger("estado", 2);        
    }
    public void morir(){
        animator.SetInteger("estado", 3);        
    }
    public void aumenta(){
         puntos +=1;
    }
}

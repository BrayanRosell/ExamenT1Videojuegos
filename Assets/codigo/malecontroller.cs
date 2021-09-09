using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class malecontroller : MonoBehaviour
{
    private Rigidbody2D rb2d;
    private SpriteRenderer sr;
    private bool limiteInicio =true;
     private bool limiteFin =false;
    // Start is called before the first frame update
    void Start()
    {
         sr= GetComponent<SpriteRenderer>();
         rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
       rb2d.gravityScale = 0;
       if(limiteInicio){
             sr.flipX = true;
            
            rb2d.velocity = new Vector2(rb2d.velocity.x,-10);  
        }
        if(limiteFin){
            sr.flipX = false;
             rb2d.velocity = new Vector2(rb2d.velocity.x,10);
        }
       
    }
    
    
     public void saltarF(){
        var upSpeed = 80f;
        rb2d.velocity = Vector2.up * upSpeed;
        
    }
    
    void OnCollisionEnter2D(Collision2D other){
        if(other.gameObject.layer == 7){
                limiteInicio = false;
                limiteFin = true;
        }
        if(other.gameObject.layer == 8){
                 
                limiteFin = false;
                limiteInicio = true;
        }
    }
}

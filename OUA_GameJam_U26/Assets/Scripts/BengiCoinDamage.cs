
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BengiCoinDamage : MonoBehaviour
{
    public float health = 3; //static olmasına gerek yok - özgür
    public bool dead = false;
    public LivesControl kirazkontrol ;
    private CoinManager _coinManager;
    private Rigidbody2D rb;
    
    //checkpoint - özgür
    private PlayerCheckpoint playerCheckpoint;
    public bool damageTaken;

    private DialogueManager _dialogueManager;
    //checkpoint - özgür

    private void Awake()
    {
        playerCheckpoint = GetComponent<PlayerCheckpoint>();
        rb = GetComponent<Rigidbody2D>();
        _coinManager = FindObjectOfType<CoinManager>();
        _dialogueManager = GetComponent<DialogueManager>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void getDamage(float damage)
    {
        //checkpoint - özgür
        damageTaken = true;
        //checkpoint - özgür
        
        kirazkontrol.kirazyokolma();
        if (health - damage >= 0)
        {
            health -= damage;
        }
        else
        {
            health = 0;
        }
        ifdead();
    }
    void ifdead()
    {
        if(health == 0)
        {
            GameObject.FindWithTag("Slider").GetComponent<Slider>().value += 2;
            dead = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
     
        if(col.CompareTag("Coin"))
        {
            _coinManager.PuanArtir(1,col.transform.position);
            _dialogueManager.showDialogue();
            Destroy(col.gameObject);
            
            //checkpoint - özgür
            playerCheckpoint.checkpoint = col.transform.position;
            //checkpoint - özgür
        }
    }
}

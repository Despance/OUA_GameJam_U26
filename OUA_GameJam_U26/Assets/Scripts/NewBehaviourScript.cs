
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public static float health = 3;
    public bool dead = false;
    public LivesControl kirazkontrol ;
    private CoinManager _coinManager;
    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        _coinManager = FindObjectOfType<CoinManager>();
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
            dead = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
     
        if(col.CompareTag("Coin"))
        {
            _coinManager.PuanArtir(1,col.transform.position);
           
            Destroy(col.gameObject);
        }
    }
}

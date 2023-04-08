
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public static float health = 3;
    public bool dead = false;
    public LivesControl kirazkontrol ;

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
}

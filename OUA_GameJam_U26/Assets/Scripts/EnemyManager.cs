using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public float health;
    public float damage;
    public float hiz, deger;
    public Transform Git, Gel;
    bool PlayerCollider = false;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        
        //gameObject.transform.Translate(new Vector3(deger * hiz * Time.deltaTime, 0, 0));
        if (tag == "KarEnemy")
        {
            gameObject.transform.Translate(new Vector3(deger * hiz * Time.deltaTime, 0, 0));
        }

        else if  (tag == "YuvEnemy")
        {
            transform.Rotate(new Vector3(0, 0, Time.deltaTime * 150));
        }
        
        
        
            
    }
    public void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log(other.gameObject.name);
            other.gameObject.GetComponent<NewBehaviourScript>().getDamage(damage);
            
        }

       // if (other.gameObject.tag == "GitGel")
       // {
         //  deger *= -1;
           //gameObject.transform.localScale = new Vector3(-1 * deger, 1, 1);
        //}
    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "GitGel")
        {
            deger *= -1;
        }
            
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestOpener : MonoBehaviour
{
    public GameObject ChestClose,ChestOpen;

    private int totalCoins = 0;

    // Start is called before the first frame update
    void Start()
    {
        totalCoins = GameObject.FindGameObjectsWithTag("Coin").Length;
        ChestClose.SetActive(true);
        ChestOpen.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("TotalCoins: "+totalCoins);
        if (collision.CompareTag("Player"))
        {
            if (totalCoins == collision.transform.parent.GetComponentInChildren<CoinManager>().ToplamPuan)
            {
                collision.GetComponent<DialogueManager>().openChest();
                ChestClose.SetActive(false);
                ChestOpen.SetActive(true);
            }
        }
    }
    /*
    void OnTriggerExit2D(Collider2D collision)
    {
        ChestClose.SetActive(true);
        ChestOpen.SetActive(false);
    }
    */
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LivesControl : MonoBehaviour
{
    public void kirazyokolma()
    {
        switch (BengiCoinDamage.health)
        {
            case 3:
                gameObject.transform.GetChild(2).gameObject.SetActive(false);
                break;

            case 2:
                gameObject.transform.GetChild(2).gameObject.SetActive(false);
                gameObject.transform.GetChild(1).gameObject.SetActive(false);

                break;

            case 1:
                gameObject.transform.GetChild(2).gameObject.SetActive(false);
                gameObject.transform.GetChild(1).gameObject.SetActive(false);
                gameObject.transform.GetChild(0).gameObject.SetActive(false);

                break;

            default:
                break;


        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LivesControl : MonoBehaviour
{
    [Header("Assign")]
    [SerializeField] private BengiCoinDamage bengiCoinDamage;
    //health artık static olmadığı için düzenledim - özgür
    
    public void kirazyokolma()
    {
        switch (bengiCoinDamage.health) //health artık static olmadığı için düzenledim - özgür
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

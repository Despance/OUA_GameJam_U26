using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinManager : MonoBehaviour
{
    [SerializeField] private Transform hedef;
    [SerializeField] private GameObject CoinPrefab;
    [SerializeField] private TextMeshProUGUI CoinText;


    private int ToplamPuan;

    private Queue<GameObject> CoinKuyruk = new Queue<GameObject>();

    private Vector3 HedefPos;
    private void Awake()
    {
        HedefPos = hedef.position;
    }
    

    private void Start()
    {
        ToplamPuan = 0;
    }

    void CoinleriOlustur()
    {
        for (int i = 0; i < 7; i++)
        {
            GameObject coin = Instantiate(CoinPrefab);
            coin.transform.parent = transform;
            coin.SetActive(false);
            CoinKuyruk.Enqueue(coin); 
        }
    }
}

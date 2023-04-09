using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;

public class CoinManager : MonoBehaviour
{
    [SerializeField] private Transform hedef;
    [SerializeField] private GameObject CoinPrefab;
    [SerializeField] private TextMeshProUGUI CoinText;
    public AudioSource audiSource;
    public AudioClip[] voices;


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
        CoinleriOlustur();
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

    void CoinlereHareketVer(Vector3 ToplanacakPos, int adet)
    {
        for (int i = 0; i < adet; i++)
        {
            GameObject coin = CoinKuyruk.Dequeue();
            coin.transform.position = ToplanacakPos;
            coin.SetActive(true);

            coin.transform.DOMove(hedef.position,.5f).SetEase(Ease.OutBack).OnComplete(() =>
                {
                    coin.SetActive(false);
                    CoinKuyruk.Enqueue(coin);               
                });
        }

    }

    public void PuanArtir(int puan,Vector3 ToplanacakPos)
    {
        ToplamPuan += puan;
        audiSource.PlayOneShot(voices[0]);
        CoinText.text = ToplamPuan.ToString();
        CoinlereHareketVer(ToplanacakPos, 7);
    }


}

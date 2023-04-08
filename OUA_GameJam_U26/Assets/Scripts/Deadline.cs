using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;


public class Deadline : MonoBehaviour
{
    // Start is called before the first frame update

    private CinemachineImpulseSource _impulseSource;
    [Header("Movement Properties")]
    public int xSpeed = 5;
    public float jumpPower = 2;
    public float moveDuration = 0.5f;

    [Space(10)]
    [Header("Slider Properties")]
    [SerializeField] private Slider _slider;
    [SerializeField] private TextMeshProUGUI _sliderText;


    [Space(10)] [Header("Sound Properties")]
    public AudioClip[] footSteps;

    private AudioSource _audioSource;
    void Awake()
    {
        _impulseSource = GetComponent<CinemachineImpulseSource>();
        _audioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        
        _slider.value = 0;
        StartCoroutine(updateTime());
    }
    

    private IEnumerator updateTime()
    {
        yield return new WaitForSeconds(3f);
        DOTween.To(() => _slider.value, x => _slider.value = x, _slider.value + 1, 0.5f).SetEase(Ease.InFlash).OnComplete(
            () =>{
                _sliderText.text = (30 - _slider.value) + " days left to deadline";
            });

        if (_slider.value < 30)
        {
            if (_slider.value>=23)
            {
                deadLineMove();
            }
            StartCoroutine(updateTime());
        }
    }
    
    
    void deadLineMove()
    {
        
        transform.DOJump(new Vector3(transform.position.x+xSpeed,transform.position.y,0),jumpPower,1,moveDuration).SetEase(Ease.Flash).OnComplete(() =>
        {

            _audioSource.clip = footSteps[Random.Range(0, footSteps.Length)];
            _audioSource.Play();
            _impulseSource.GenerateImpulseWithForce(0.2f);
        }); 
    }
    
    
}

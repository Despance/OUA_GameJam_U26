using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public bool dialogueStarted = false;

    private RectTransform _transform;
    public Transform dialogueObject;

    public string dialogueText;
    public float textSpeed = 15f;
    private TextMeshProUGUI textBox; 
    void Start()
    {
        textBox = dialogueObject.GetComponentInChildren<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
           
    }

    public void showDialogue()
    {
        dialogueObject.DOScale(Vector3.one, 0.5f).SetEase(Ease.InOutExpo);
        showText();
    }
    
    public void showText()
    {
        string text = "";
        DOTween.To(() => text, x => text = x,dialogueText,dialogueText.Length/textSpeed).SetEase(Ease.Linear).OnUpdate(() =>
        {
            textBox.text = text;
        });
    }

    public void hideDialogue()
    {
        dialogueObject.DOScale(Vector3.zero, 0.5f).SetEase(Ease.InOutExpo);
    }
    
    
}


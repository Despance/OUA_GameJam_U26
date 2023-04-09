using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    [Header("Dialogue")]
    [SerializeField] private TextMeshProUGUI textBox;
    [SerializeField] private Transform dialogueObject;
    [SerializeField] private string dialogueText;
    [SerializeField] private float textSpeed;

    [Header("Fairy")]
    [SerializeField] private Transform fairy;
    [SerializeField] private float fairyPosition;
    [SerializeField] private float fairySpeed =1f;
    void Start()
    {
        dialogueObject.transform.localScale = Vector3.zero;
        fairy.DOLocalMove(fairy.position +new Vector3(0,fairyPosition,0),fairySpeed).SetLoops(-1, LoopType.Yoyo);
        dialogueObject.DOScale(Vector3.one, 0.5f).SetEase(Ease.InOutExpo).OnComplete(
            () =>
            {
                string text = "";
                DOTween.To(() => text, x => text = x, dialogueText, dialogueText.Length / textSpeed)
                    .SetEase(Ease.Linear)
                    .OnUpdate(() => { textBox.text = text; });
            });
        
        
    }

   
}

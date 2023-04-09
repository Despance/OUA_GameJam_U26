using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;
using UnityEngine.SceneManagement;

public class DialogueManager : MonoBehaviour
{
    public bool dialogueStarted = false;

    private RectTransform _transform;
    public Transform dialogueObject;

    private string dialogueText;
    public float textSpeed = 15f;
    private TextMeshProUGUI textBox;
    static int dialogueIndex = 0;

   
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
        if (!dialogueStarted)
        {
            dialogueStarted = true;
            string text = "";
            DOTween.To(() => text, x => text = x, dialogueText, dialogueText.Length / textSpeed).SetEase(Ease.Linear)
                .OnUpdate(() => { textBox.text = text; });
        }
        
        
    }

    public void hideDialogue()
    {
        dialogueObject.DOScale(Vector3.zero, 0.5f).SetEase(Ease.InOutExpo).OnComplete((() =>
        {
            dialogueText = dialogueStrings[++dialogueIndex];
            dialogueStarted = false;
        }));
        
    }

    public void winDialogue(int levelIndex)
    {
        dialogueStarted = true;
        string text = "";
        DOTween.To(() => text, x => text = x, winStrings[levelIndex], winStrings[levelIndex].Length / textSpeed).SetEase(Ease.Linear)
            .OnUpdate(() => { textBox.text = text; }).OnComplete(()=>{});
        SceneManager.LoadScene(levelIndex);
    }

    private string[] winStrings =
    {
        "kötü kalpli dinozorun testini geçtin. öğrendiklerini kullanarak yeni bir güç edindin: artık bir oyunda yer çekimi nasıl tersine çevrilir biliyorsun. öğrendiğin kodları yaz ve C tuşu ile yerçekimini tersine çevir.",
        "bölüm sonu akademi: seninle gurur duyuyorum. yerçekimini çok iyi öğrendin. öğrendiklerini kullanarak yeni bir güç daha edindin: artık bir oyunda nasıl koşulur onu biliyorsun. koşarken daha uzun mesafelere zıplayabilirsin.",
        "tüm bu akademi maceranda yeni bir gücün var. artık bir oyunda bir nesnenin boyutu nasıl ayarlanır biliyorsun. öğrendiğin kodları yaz ve R tuşu ile büyüyüp küçül.",
        "kötü kalpli dinozorun vakti dolmak üzere. eğitimlerinde çok başarılısın ve artık bir oyunda nasıl çift zıplanır biliyorsun. öğrendiğin kodları yaz ve havadayken space tuşuna basarak bir kez daha zıpla."
    };


    private string[] dialogueStrings =
    {
        "Prefabler aynı sahne veya proje içinde yeniden kullanılabilir oyun nesneleri oluşturmak için geliştirilmiş bir sistemdir.",
        "Bir scriptteki değişkenin erişim türünü public yapmak, onu inspector paneli veya diğer scriptlerden erişilebilmesini mümkün kılar.",
        "Kullanıcı tarafından yazılan kodun bilgisayar diline çevirilme işlemine compilation adı verilir.",
        "Console'da cümle içinde kesme işareti (') kullanabilmek için aşağıdaki ifadeyi yazabiliriz \n Console.Write(\"\\\'\");",
        "Kodumuzun içerisinde işlenmesini istemediğimiz metinleri belirtmemizi sağlayan, hem kendimiz hem de başkaları için notlar bırakabildiğimiz yapının adı \"Yorum Satırıdır\".",
        "namespaces, diğer scriptlerden namespace altındaki class\'ları kullanabilmek için kullanılır",
        "Boolean true false değerleri olan mantıksal veri tipidir.",
        "Bir fonksiyonu return edebilmek için fonksiyonun türü integer, boolean,string gibi operatörler olabilir.",
        "Switch case yapısında default Tanımlanmayan olasılık gerçekleştiğinde olacak durumu yazmamızı sağlar",
        "Unity hub kullanarak yeni bir 2D bir projesini sırasıyla Project>New > 2D > Create aşamları uygulayarak açabiliriz.",
        "Layout pencere düzenini istediğimiz gibi düzenlememizi sağlar.",
        "Unity package manager Unity'e paket eklemeyi veya varolan paketi güncellemeyi ve silebilmeyi sağlar.",
        "2D nesnemizin fizik özelliğine sahip olması ve diğer nesnelere çarpabilmesi için nesnemize Box Collider 2D ve Rigidbody 2D component'leri eklememiz gerekiyor.",
        "Sprite kullanarak animasyon oluşturduğumuzda nesnemizde Animator component kendiliğinden eklenir.",
        "2D bir oyun projemizde gökyüzü, platform ve karakter gibi nesnelerin sorting layer'ları şu şekilde olmalıdır: \n 1.Gökyüzü 2.Platform 3.Karakter",
        "Unity'de animasyonların biribirine bağlandığı,istenildiğinde koşullar eklendiği bölüme Animator:State Machine adı verilir.",
        "Oyunda karakterimin hız değişkenini \"w\" tuşuna basarak değiştirmek istiyorsak aşağıdaki kodu yazabiliriz \n Input.GetKeyDown(Keycode.W)",
        "Koşma animasyona geçiş yapmak için koşulum klavyede a,d ve sağ,sol tuşlarından en az birine basmış olmak ise if(Input.GetAxis(\"Horizontal\")!=0) kodunu kullanabiliriz.",
        "Animator içerisindeki bir integer parametrenin değerini değiştirmek için animator.SetInt() kodu kullanabiliriz.",
        "Unity'de karakterimizin fizik olaylarını Fixed Update() fonksiyonun içine yazmamız daha doğru olur.",
        "Karakterimizin konumunu kod üzerinden değiştirmek için karakterimizin Transform component'ine erişmemiz gerekiyor",
        "Late Update() kullanmak oyun kamerasının hareketlerini kontrol etmemizde yardımcı olur.",
        "Update fonksiyonlarının öncelik sıralaması aşağıda verilmiştir. \n 1.FixedUpdate() 2.Update() 3.LateUpdate()",
        "Awake ve Start fonksiyonları arasındaki temel fark Awake, oyunu çalıştırdığımızda; Start, script'i çalıştırdığımızda çalışır.",
        "Kullanılan assetin ücretsiz bir şekilde kullanılması ve dağıtılması için assetin lisansı CC0 olmalıdır.",
        "2D oyun için arkaplan tasarımını Tilemap kullanarak yapabiliriz.",
        "2D oyunda objelere collider ekleme Diğer objelerle temasa geçebilmesi için önemlidir.",
        "Machine State'te parametreler oluşturmanın amacı Oluşturulan parametrelere göre animasyon geçişlerine koşul eklemek.",
        "Arkaplanımızın kendini tekrar edecek şekilde genişlemesini istiyorsak Raw Mode'unu  Tile yapmamız gerekir.",
        "Unity projemizde Tile Palette'imize Window-2D-Tile Palette yolu ile ulaşabiliriz."
    };
    
}


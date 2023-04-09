using UnityEngine;

public class PlayerCheckpoint : MonoBehaviour
{
    [Header("Checkpoint")]
    public Vector2 checkpoint;

    [Header("Assign")]
    [SerializeField] private GameObject[] livesArray = new GameObject[3];

    private Vector2 startingPoint;
    private BengiCoinDamage bengiCoinDamage;

    private void Start()
    {
        bengiCoinDamage = GetComponent<BengiCoinDamage>();
        startingPoint = transform.position;
        checkpoint = startingPoint;
    }

    private void Update()
    {
        if (bengiCoinDamage.damageTaken)
        {
            transform.position = checkpoint;
            bengiCoinDamage.damageTaken = false;
        }
        
        if (bengiCoinDamage.dead)
        {
            transform.position = startingPoint;
            checkpoint = startingPoint;
            Revive();
        }
    }

    private void Revive()
    {
        bengiCoinDamage.dead = false;
        bengiCoinDamage.health = 3;

        foreach (GameObject item in livesArray)
        {
            item.SetActive(true);
        }
    }
}

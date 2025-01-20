using System.Collections;
using UnityEngine;

public class Bat : MonoBehaviour
{
    [SerializeField] private Transform[] movementPoints;
    [SerializeField] private float speedPatrol;
    [SerializeField] private float damageAttack;
    private Vector3 currentTarget;
    private int currentPoint = 0;


    
    void Start()
    {
        currentTarget = movementPoints[currentPoint].position;
        StartCoroutine(Patrol());
    }

 
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, movementPoints[currentPoint].position, speedPatrol * Time.deltaTime);
    }

    IEnumerator Patrol()
    {
        while(true)
        {
            while (transform.position != currentTarget)
            {
                transform.position = Vector3.MoveTowards(transform.position, currentTarget, speedPatrol * Time.deltaTime);
                yield return null;
            }
            SetNewDestination();
        }
    }

    private void SetNewDestination()
    {
        ++currentPoint;
        if (currentPoint >= movementPoints.Length)
        {
            currentPoint = 0;
        }
        currentTarget = movementPoints[currentPoint].position;
        FocusDestination();
    }

    private void FocusDestination()
    {
        if (currentTarget.x > transform.position.x)
        {
            transform.localScale = Vector3.one; // Escala original
        }
        else
        {
            transform.localScale = new Vector3(-1, 1, 1); // Escala invertida
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("PlayerDetection"))
        {
            Debug.Log("Player detected");
        }
        else if (collision.gameObject.CompareTag("PlayerHitBox"))
        {
            LifeSystem lifeSystem = collision.gameObject.GetComponent<LifeSystem>();
            lifeSystem.RecieveDamage(damageAttack);
            Debug.Log("Player Damaged by Bat!!!");
        }
    }

}

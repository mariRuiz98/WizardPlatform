using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] private float impulseFireBall;
    [SerializeField] private float lifeTime = 2f; 
    [SerializeField] private float damageShot = 10f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(transform.right * impulseFireBall, ForceMode2D.Impulse); // EJE X DERECHA
        Destroy(gameObject, lifeTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Detecta si la colisión es con el jugador
        if (collision.gameObject.CompareTag("PlayerHitBox"))
        {
            LifeSystem lifeSystem = collision.gameObject.GetComponent<LifeSystem>();
            if (lifeSystem != null)
            {
                lifeSystem.RecieveDamage(damageShot); // Aplica daño al jugador
                float actualLife = lifeSystem.GetLife();
                Debug.Log("Actual Player Life: " + actualLife);
            }

            Destroy(gameObject); // Destruye la bola de fuego al colisionar
        }
    }

    void Update()
    {
        
    }
}

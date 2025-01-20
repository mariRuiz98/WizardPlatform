using System.Collections;
using UnityEngine;

public class Wizard : MonoBehaviour
{
    [SerializeField] private GameObject fireBall;
    [SerializeField] private Transform firePoint;
    [SerializeField] private float timeAttack; // Tiempo entre ataques
    [SerializeField] private float damageAttack;
    [SerializeField] private Transform player; // Referencia al jugador
    private Vector3 currentTarget;
    private Animator anim;
    private bool playerInRange = false; // Indica si el jugador está en el área de detección
    private Coroutine attackRoutine; // Referencia a la rutina de ataque


    void Start()
    {
        anim = GetComponent<Animator>();
        //StartCoroutine(AttackRutine());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator AttackRutine()
    {
        while (playerInRange) // Solo ataca si detecta al player en el área de detección
        {
            anim.SetTrigger("atacar");
            yield return new WaitForSeconds(timeAttack);
        }
        attackRoutine = null; // Limpia la referencia cuando la rutina termina
    }

    private void LanzarBola()
    {
        Instantiate(fireBall, firePoint.position, transform.rotation); // With the rotation of the wizard
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("PlayerDetection"))
        {
            // Obtener la posición del jugador
            currentTarget = player.position;

            // Llamar a la función para enfocar al jugador
            FocusPlayer();
            playerInRange = true;
            if (attackRoutine == null) // Inicia la rutina de ataque si no está ya corriendo
            {
                attackRoutine = StartCoroutine(AttackRutine());
            }
        }
        else if (collision.CompareTag("PlayerHitBox"))
        {
            LifeSystem lifeSystem = collision.gameObject.GetComponent<LifeSystem>();
            lifeSystem.RecieveDamage(damageAttack);
            Debug.Log("Player Damaged by Wizard!!!");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("PlayerDetection"))
        {
            playerInRange = false;
            if (attackRoutine != null) // Detiene la rutina si el jugador sale del área
            {
                StopCoroutine(attackRoutine);
                attackRoutine = null;
            }
        }
    }

    private void FocusPlayer()
    {
        Debug.Log("currentTarget: " + currentTarget);
        Debug.Log("transform.position: " + transform.position);
        Vector3 newScale = transform.localScale;

        if (currentTarget.x > transform.position.x)
        {
            newScale.x = -1; // Escala original
        }
        else if (currentTarget.x < transform.position.x){
            newScale.x = 1; // Escala invertida
        }
        transform.localScale = newScale;
    }

}

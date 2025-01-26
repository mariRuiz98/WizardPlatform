using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MedPack : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Verificamos si el objeto que colisiona tiene el script LifeSystem
        LifeSystem lifeSystem = other.GetComponent<LifeSystem>();
        if (lifeSystem != null && other.CompareTag("PlayerHitBox")) // Asegúrate de que el jugador tenga el tag "PlayerHitBox"
        {
            lifeSystem.RestoreToFull();
            Destroy(gameObject);
            Debug.Log("MedPack usado. Vida restaurada al máximo.");
        }
    }
}

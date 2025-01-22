using UnityEngine;

public class LifeSystem : MonoBehaviour
{
    [SerializeField] private float life;
    [SerializeField] private GameObject damageContainerPrefab;

    public void RecieveDamage(float damage)
    {
        life -= damage;
        
        if (life <= 0)
        {
            Destroy(this.gameObject);
        }
        // Comprobar si el daño es para el jugador
        if (life > 0 && CompareTag("PlayerHitBox")) // Asegúrate de que el jugador tenga la etiqueta "Player"
        {
            ShowDamageEffect(); // Instanciar el prefab del DamageContainer
        }
    }
    
    public float GetLife()
    {
        return life;
    }

    private void ShowDamageEffect()
    {
        if (damageContainerPrefab != null)
        {
            // Instanciar el DamageContainer como hijo del Canvas
            GameObject canvas = GameObject.Find("Canvas"); // Asegúrate de que exista un Canvas llamado "Canvas"
            if (canvas != null)
            {
                // Instanciar el prefab en el Canvas
                Instantiate(damageContainerPrefab, canvas.transform);
                
            }
            else
            {
                Debug.LogError("No se encontró un Canvas en la escena.");
            }
        }
        else
        {
            Debug.LogError("Prefab de DamageContainer no asignado.");
        }
    }


}

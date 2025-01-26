using System.Data.Common;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LifeSystem : MonoBehaviour
{
    [SerializeField] private float life;
    [SerializeField] private float maxLife;
    [SerializeField] private GameObject damageContainerPrefab;



    public void RecieveDamage(float damage)
    {
        life -= damage;
        int pointsObtained = 0;
        

        if (life <= 0)
        {
            // Comprobar si el daño es para un Slime
            if (CompareTag("Slime")) pointsObtained += 10; // Asegúrate de que el Slime tenga la etiqueta "SlimeHitBox"
            else if (CompareTag("Bat")) pointsObtained += 20;
            else if (CompareTag("Wizard")) pointsObtained += 50;
            else if (CompareTag("PlayerHitBox")) SceneManager.LoadScene("GameOver");

            // Instanciar gameManager sumar el score por matar a un enemigo
            GameObject gameManager = GameObject.Find("GameManager");
            if (gameManager != null)
            {
                gameManager.GetComponent<GameManager>().AddScore(pointsObtained);
            }
            else
            {
                Debug.LogError("No se encontró un GameManager en la escena.");
            }
            
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

    public void RestoreToFull()
    {
        life = maxLife; // Restaura la vida al máximo
        Debug.Log("Vida restaurada al máximo.");
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

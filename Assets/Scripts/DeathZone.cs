using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathZone : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("PlayerHitBox")) 
        {
            RestartGame();
        }
    }

    private void RestartGame()
    {
        Debug.Log("El jugador cayó en la DeathZone. Reiniciando el juego...");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // Recarga la escena actual 
    }
}

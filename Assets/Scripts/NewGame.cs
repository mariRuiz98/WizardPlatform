using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewGame : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;  // El AudioSource del botón que se va a clickear
    [SerializeField] private AudioClip clickSound;     // El clip de sonido a reproducir
    [SerializeField] private string sceneToLoad;
    [SerializeField] private Animator transitionAnimator;
    [SerializeField] private float transitionTime = 1f;

    public void StartNewGame() {
        // Iniciar la corutina para reproducir el sonido y luego cargar la escena
        Debug.Log("Iniciando nuevo juego...");
        StartCoroutine(PlaySoundAndLoadScene());
        
    }

    private IEnumerator PlaySoundAndLoadScene()
    {
        // Reproducir el sonido
        audioSource.PlayOneShot(clickSound);

        // Esperar a que el sonido termine (usamos el tiempo del clip de audio)
        yield return new WaitForSeconds(clickSound.length);

        // Activar FadeIn
        transitionAnimator.SetTrigger("StartFadeIn");
        // Esperar a que termine la animación
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(sceneToLoad);
    }

}

using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class SceneTransitionManager : MonoBehaviour
{
    public Animator transitionAnimator;
    public float transitionTime = 1f;

    [SerializeField] private string sceneName;

    public void LoadScene(string sceneName)
    {
        StartCoroutine(Transition(sceneName));
    }

    private IEnumerator Transition(string sceneName)
    {
        // Activar FadeIn
        transitionAnimator.SetTrigger("StartFadeIn");

        // Esperar a que termine la animación
        yield return new WaitForSeconds(transitionTime);

        // Cargar la nueva escena
        SceneManager.LoadScene(sceneName);

        // Activar FadeOut
        transitionAnimator.SetTrigger("StartFadeOut");
    }
}

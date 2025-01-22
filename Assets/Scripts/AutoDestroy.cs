using UnityEngine;

public class AutoDestroy : MonoBehaviour
{
    [SerializeField] private float destroyDelay; // Tiempo antes de destruir el objeto

    void Start()
    {
        // Destruir este GameObject después de "destroyDelay" segundos
        Destroy(gameObject, destroyDelay);
    }
}

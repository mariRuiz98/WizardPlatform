using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pipe : MonoBehaviour
{
    private bool isInPipeArea = false;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
         // Verifica si el jugador está en el área y si presiona la tecla "E"
        if (isInPipeArea && Input.GetKeyDown(KeyCode.E))
        {
            SceneManager.LoadScene("EndGame");  
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {        
        if (other.CompareTag("PlayerHitBox")) 
        {
            Debug.Log("El player ha ENTRADO en la zona de meta.");
            isInPipeArea = true;
        }
    }

    // Este método se llama cuando el jugador sale del contacto con el objeto
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("PlayerHitBox"))
        {
            Debug.Log("El player ha SALIDO de la zona de meta.");
            isInPipeArea = false;  // El jugador ya no está encima de la tubería
        }
    }
}

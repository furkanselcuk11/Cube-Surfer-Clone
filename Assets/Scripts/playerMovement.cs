using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{    
    public float forwardSpeed;
    [SerializeField]
    private float horizontalSpeed;
    
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal") * horizontalSpeed*Time.deltaTime;    // Saða sola gitme yönünü belirler
        transform.Translate(horizontal, 0, forwardSpeed * Time.deltaTime);  // Karakter ileri gitmesini ve saða sola hareketini saðlar  
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Block")
        {
            Debug.Log("Game Over");
            Time.timeScale = 0f;            
        }        
    }

    
}

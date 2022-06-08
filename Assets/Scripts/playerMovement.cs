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
        float horizontal = Input.GetAxis("Horizontal") * horizontalSpeed*Time.deltaTime;    // Sa�a sola gitme y�n�n� belirler
        transform.Translate(horizontal, 0, forwardSpeed * Time.deltaTime);  // Karakter ileri gitmesini ve sa�a sola hareketini sa�lar  
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

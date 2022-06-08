using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collectedCube : MonoBehaviour
{
    bool isCollect; // toplandý mý toplanmadý mý
    int index; // Toplamýn posizyonu - Yüksekliðini belirtir
    public picker picker;   // Picker koduna eriþir
    void Start()
    {
        isCollect = false;
    }
    void Update()
    {
        if (isCollect == true)  // Eðer CollectCube toplanmýþsa
        {
            if (transform.parent != null) // Ve parenti varsa 
            {
                transform.localPosition = new Vector3(0, -index, 0);  // Toplanan her CollectCube PlayerCube'nin altýnda alt alta dizlimesi saðlar ve en son toplanan en alta yerleþir
            }
        }        
        
    }
    public bool GetIsCollect()
    {
        return isCollect;
    }
    public void Colletted()
    {
        isCollect = true;   // Toplanmýþ olduðunu belirtir
    }
    public void IndexSetting(int index)
    {
        this.index = index; // this.index(Global'deki index) - Global'daki index'i parametreden gelen index'e eþitle
        // Toplanan her CollectCube için "picker" kodundan gelen yükseklik deðeri index deðerine atanýr        
    }
    private void OnTriggerEnter(Collider other)
    {
        // Engellere temas edilince en alltaki Cube yok edilir
        if (other.gameObject.tag == "Block")
        {
            picker.HeightDecrease();    // Picker kodunun HeightDecrease methoduna eriþip yüksekliði 1 azalt
            transform.parent = null;    // Block'a çarpan CollectCube'ýn parenti null olur ve PlayerCube objesinin alt nesnesi olmaktan çýkar
            transform.position = new Vector3(transform.localPosition.x+0.1f, transform.position.y, transform.position.z+0.1f);    // Çarpþma sonrasý çarpan kutu 0.1f geriye gider
            GetComponent<BoxCollider>().enabled = false;    // CollectCube'nin BoxCollideri kapatýlýr
            other.gameObject.GetComponent<BoxCollider>().enabled = false;    // Çarpýlan Bloðun'un BoxCollideri kapatýlýr
            
        }
    }
}

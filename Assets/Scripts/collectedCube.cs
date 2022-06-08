using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collectedCube : MonoBehaviour
{
    bool isCollect; // topland� m� toplanmad� m�
    int index; // Toplam�n posizyonu - Y�ksekli�ini belirtir
    public picker picker;   // Picker koduna eri�ir
    void Start()
    {
        isCollect = false;
    }
    void Update()
    {
        if (isCollect == true)  // E�er CollectCube toplanm��sa
        {
            if (transform.parent != null) // Ve parenti varsa 
            {
                transform.localPosition = new Vector3(0, -index, 0);  // Toplanan her CollectCube PlayerCube'nin alt�nda alt alta dizlimesi sa�lar ve en son toplanan en alta yerle�ir
            }
        }        
        
    }
    public bool GetIsCollect()
    {
        return isCollect;
    }
    public void Colletted()
    {
        isCollect = true;   // Toplanm�� oldu�unu belirtir
    }
    public void IndexSetting(int index)
    {
        this.index = index; // this.index(Global'deki index) - Global'daki index'i parametreden gelen index'e e�itle
        // Toplanan her CollectCube i�in "picker" kodundan gelen y�kseklik de�eri index de�erine atan�r        
    }
    private void OnTriggerEnter(Collider other)
    {
        // Engellere temas edilince en alltaki Cube yok edilir
        if (other.gameObject.tag == "Block")
        {
            picker.HeightDecrease();    // Picker kodunun HeightDecrease methoduna eri�ip y�ksekli�i 1 azalt
            transform.parent = null;    // Block'a �arpan CollectCube'�n parenti null olur ve PlayerCube objesinin alt nesnesi olmaktan ��kar
            transform.position = new Vector3(transform.localPosition.x+0.1f, transform.position.y, transform.position.z+0.1f);    // �arp�ma sonras� �arpan kutu 0.1f geriye gider
            GetComponent<BoxCollider>().enabled = false;    // CollectCube'nin BoxCollideri kapat�l�r
            other.gameObject.GetComponent<BoxCollider>().enabled = false;    // �arp�lan Blo�un'un BoxCollideri kapat�l�r
            
        }
    }
}

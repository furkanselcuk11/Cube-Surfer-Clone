using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class picker : MonoBehaviour
{
    GameObject playerCubeObj;
    public ParticleSystem diamondEffect;
    int height; // Her CollectCube yakalad���mzda artan y�kseklik
    int score;
    public Transform cubeCollectText;
    public TextMeshProUGUI gameScoreTxt;
    
    void Start()
    {
        playerCubeObj = GameObject.Find("PlayerCube");
        score = 0;
        gameScoreTxt.text = score.ToString();
    }
    void Update()
    {
        playerCubeObj.transform.position = new Vector3(transform.position.x, height + 1, transform.position.z); // Toplanan her CollectCube'de  PlayerCube'�n y�ksekli�i +1 arts�n
        transform.localPosition = new Vector3(0, -height, 0);   // Picker (Toplay�c�) her zaman en allta kalmas� i�in y�ksekli�in artt��� kadar azals�n       
    }
    public void HeightDecrease()
    {
        height--;   // Y�kseklik azalt
        FindObjectOfType<audioController>().Play("Block");
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Collect" && other.gameObject.GetComponent<collectedCube>().GetIsCollect()==false)
        {
            height += 1;
            // Efekt ekle
            other.gameObject.GetComponent<collectedCube>().Colletted(); // Toplanm�� oldu�unu belirtir
            other.gameObject.GetComponent<collectedCube>().IndexSetting(height); // Her CollectCube yakaland���ndan yerden y�ksekli�ini +1 art�r
            other.gameObject.transform.parent = playerCubeObj.transform;    // Temas edilen CollectCube, PlayerCube'nin alt objesi olur
            FindObjectOfType<audioController>().Play("Coin");   // Cube al�nma sesi
            Instantiate(cubeCollectText, playerCubeObj.transform.localPosition, Quaternion.Euler(playerCubeObj.transform.localRotation.eulerAngles));    // Her Cube al�nd���nda +1 yazma
        }
        if (other.gameObject.tag == "LeftTurn")
        {
            FindObjectOfType<playerMovement>().transform.Rotate(0, -90, 0);
            Destroy(other.gameObject);
        }
        if (other.gameObject.tag == "RightTurn")
        {
            FindObjectOfType<playerMovement>().transform.Rotate(0, 90, 0);
            Destroy(other.gameObject);
        }
        if (other.gameObject.tag== "Diamondo")
        {
            score+=100;
            gameScoreTxt.text = score.ToString();
            FindObjectOfType<audioController>().Play("Diamond");
            diamondEffect.Play();
            Destroy(other.gameObject, 0.15f);            
        }
        if (other.gameObject.tag== "Finish")
        {
            Debug.Log("Oyun Tamamland�");
        }
        if (other.gameObject.tag== "LevelFinish")
        {
            Debug.Log("Level Sonu");
            //Time.timeScale = 0.01f;
            playerCubeObj.GetComponent<playerMovement>().forwardSpeed = 0;
        }
    }
}

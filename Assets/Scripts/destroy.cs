using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroy : MonoBehaviour
{
    public float liteTime;
    void Start()
    {
        Destroy(gameObject, liteTime);
    }
}

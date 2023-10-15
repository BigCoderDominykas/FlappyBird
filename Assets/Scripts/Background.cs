using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    public GameObject background1;
    public GameObject background2;

    void Start()
    {
        if (Random.Range(0, 2) == 0)
        {
            background1.SetActive(true);
        }
        else
        {
            background2.SetActive(true);
        }
    }
}

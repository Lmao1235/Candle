using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchChar : MonoBehaviour
{
    [SerializeField] GameObject Char1;
    [SerializeField] GameObject Char2;
    [SerializeField] GameObject Char3;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Alpha1))
        {
            Char1.SetActive(true);
            Char2.SetActive(false);
            Char3.SetActive(false);
        }

        if (Input.GetKey(KeyCode.Alpha2))
        {
            Char1.SetActive(false);
            Char2.SetActive(true);
            Char3.SetActive(false);
        }

        if (Input.GetKey(KeyCode.Alpha3))
        {
            Char1.SetActive(false);
            Char2.SetActive(false);
            Char3.SetActive(true);
        }
    }
}

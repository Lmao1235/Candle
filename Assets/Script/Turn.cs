using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turn : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (PauseMenu.IsPaused == false)
        {
            if (Input.GetKey(KeyCode.A))
            {
                Quaternion newRotation = Quaternion.Euler(0, 0, 0);

                transform.rotation = newRotation;

            }
            if (Input.GetKey(KeyCode.D))
            {
                Quaternion newRotation = Quaternion.Euler(0, 180, 0);

                transform.rotation = newRotation;

            }
        }
       
    }
}

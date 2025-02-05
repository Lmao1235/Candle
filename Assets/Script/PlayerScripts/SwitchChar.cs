using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchChar : MonoBehaviour
{
    public GameObject[] children; // Array to store child objects
    private int currentIndex = 0;

    void Start()
    {
        ActivateChild(currentIndex);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1)) ActivateChild(0);
        if (Input.GetKeyDown(KeyCode.Alpha2)) ActivateChild(1);
        if (Input.GetKeyDown(KeyCode.Alpha3)) ActivateChild(2);

        // Auto-switch if the current child is destroyed
        if (children[currentIndex] == null)
        {
            SwitchToNextAvailable();
        }

        if (transform.childCount == 1)
        {
            Destroy(gameObject); // Destroy parent
        }
    }

    void ActivateChild(int index)
    {
        // Ensure the selected index is valid and exists
        if (index < 0 || index >= children.Length || children[index] == null)
            return;

        currentIndex = index;

        for (int i = 0; i < children.Length; i++)
        {
            if (children[i] != null)
                children[i].SetActive(i == currentIndex);
        }
    }

    void SwitchToNextAvailable()
    {
        for (int i = 0; i < children.Length; i++)
        {
            int nextIndex = (currentIndex + 1 + i) % children.Length;
            if (children[nextIndex] != null)
            {
                ActivateChild(nextIndex);
                return;
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{

    void Update()
    {
        transform.Rotate(90 * Time.deltaTime, 0, 0);
    }
    private void OnTriggerEnter(Collider other)
    {

        switch (gameObject.tag)
        {
            case "Coin":
                Destroy(gameObject);
                break;
        }
    }
}

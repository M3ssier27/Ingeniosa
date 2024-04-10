using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minimapcamera : MonoBehaviour
{
    public Transform player; 

    private void LetUpdate()
    {
        Vector3 newPosition = player.position;

        newPosition.y = transform.position.y;

        transform.position = newPosition;
    }
}

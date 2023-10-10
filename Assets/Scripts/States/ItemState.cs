using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemState : MonoBehaviour
{
    public void OnPlayerInteraction () {
        Destroy(gameObject);
    }
}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructable : MonoBehaviour
{
    void DestroyGameObject()
    {
        Destroy(gameObject);
    }
}

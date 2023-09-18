using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveParent : MonoBehaviour
{
    private void Awake()
    {
        transform.parent = null;
    }
}

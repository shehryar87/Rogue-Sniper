using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelPosition : MonoBehaviour
{
    [SerializeField] private Vector3 position;

    private void Start()
    {
        transform.position = position;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateLightPositionTest : MonoBehaviour
{
    [SerializeField] private Material mat;
    
    void Update()
    {
        mat.SetVector("_LightPos", new Vector4(transform.position.x, transform.position.y, -transform.position.z, 0));    
    }
}

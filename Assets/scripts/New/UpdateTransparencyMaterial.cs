using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateTransparencyMaterial : MonoBehaviour
{
    [SerializeField] private Material tileMaterial;
    [SerializeField] private float innerRadius;
    [SerializeField] private float outerRadius;
    [SerializeField] [Range(0,1)] private float maxTransparency;
    
    void Update()
    {
        tileMaterial.SetVector("_PlayerPos", new Vector4(transform.position.x, transform.position.y, 0, 0));
        tileMaterial.SetFloat("_InnerRadius", innerRadius);
        tileMaterial.SetFloat("_OuterRadius", outerRadius);
        tileMaterial.SetFloat("_MaxTransparency", maxTransparency);
    }
}

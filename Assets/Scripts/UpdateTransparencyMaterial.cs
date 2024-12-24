using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateTransparencyMaterial : MonoBehaviour
{
    [SerializeField] private float innerRadius;
    [SerializeField] private float outerRadius;
    [SerializeField] [Range(0,1)] private float maxTransparency;
    [SerializeField] private int height;
    
    void Update()
    {
        Shader.SetGlobalVector("_PlayerPos", new Vector4(transform.position.x, transform.position.y, -transform.position.z, height));
        Shader.SetGlobalFloat("_InnerRadius", innerRadius);
        Shader.SetGlobalFloat("_OuterRadius", outerRadius);
        Shader.SetGlobalFloat("_MaxTransparency", maxTransparency);
    }
}

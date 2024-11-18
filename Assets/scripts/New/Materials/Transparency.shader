Shader "Custom/ProximityTransparency"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _PlayerPos ("Player Position", Vector) = (0, 0, 0, 0)
        _InnerRadius ("Inner Transparency Radius", Float) = 1.0
        _OuterRadius ("Outer Transparency Radius", Float) = 1.0
        _MaxTransparency ("Max Transparency", Float) = 0.5
    }
    SubShader
    {
        Tags { "Queue"="Transparent" "RenderType"="Transparent" }
        LOD 100

        Blend SrcAlpha OneMinusSrcAlpha

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
                float3 worldPos : TEXCOORD1;
            };

            sampler2D _MainTex;
            float4 _MainTex_ST;

            float4 _PlayerPos;
            float _InnerRadius;
            float _OuterRadius;
            float _MaxTransparency;

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                o.worldPos = mul(unity_ObjectToWorld, v.vertex).xyz; // Convert to world-space
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                // World-space tile position
                float3 tilePos = i.worldPos;

                // World-space player position
                float3 playerPos = _PlayerPos.xyz;

                // Calculate distance in world-space
                float dist = distance(tilePos.xy, playerPos.xy);

                // Calculate transparency using smoothstep
                float alpha = 1.0 - (floor(dist/_InnerRadius));
                if (dist < _InnerRadius)
                {
                    alpha = 1.0 - _MaxTransparency;
                }
                else
                {
                    alpha =1-(1-clamp(0,1,(dist-_InnerRadius)/(_OuterRadius-_InnerRadius)))*_MaxTransparency;
                }
                
                // Sample texture
                fixed4 col = tex2D(_MainTex, i.uv);

                // Apply transparency
                col.a *= alpha;

                return col;
            }
            ENDCG
        }
    }
    FallBack "Transparent/Cutout/Diffuse"
}
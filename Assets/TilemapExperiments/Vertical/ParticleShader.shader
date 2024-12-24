Shader "Custom/ParticleShader"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _Height ("Tilemap Height", Int) = 0
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

            uniform float4 _PlayerPos;
            uniform float _InnerRadius;
            uniform float _OuterRadius;
            uniform float _MaxTransparency;
            int _Height;

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
                float alpha = 1;
                if ( i.worldPos.z <= -_PlayerPos.z)
                {
                    float dist = distance(i.worldPos.xy, _PlayerPos.xy);
                    if (dist < _InnerRadius)
                    {
                        alpha = 1.0 - _MaxTransparency/5;
                    }
                    else
                    {
                        alpha =1-(1-clamp(0,1,(dist-_InnerRadius)/(_OuterRadius-_InnerRadius)))*_MaxTransparency/5;
                    }
                }
                
                fixed4 col = tex2D(_MainTex, i.uv);
                
                col.a *= alpha;

                return col;
            }
            ENDCG
        }
    }
    FallBack "Transparent/Cutout/Diffuse"
}
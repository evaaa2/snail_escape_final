
 Shader "Custom/SharpnessShader"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _Sharpness ("Sharpness", Range(0, 5)) = 0
        _Lightness ("Lightness", Range(0, 1)) = 0.5
    }

    SubShader
    {
        Tags { "Queue"="Transparent" "RenderType"="Transparent" }
        LOD 100
        ZWrite Off
        Blend SrcAlpha OneMinusSrcAlpha
        Cull Off

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"

            sampler2D _MainTex;
            float4 _MainTex_ST;
            float _Sharpness;
            float _Lightness;

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
            };

            v2f vert(appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                return o;
            }

            float4 frag(v2f i) : SV_Target
            {
                float2 uv = i.uv;
                float2 texelSize = float2(1.0 / 512.0, 1.0 / 512.0); // Adjust based on your texture size

                float4 center = tex2D(_MainTex, uv);
                float4 blur = float4(0, 0, 0, 0);

                // Simple 3x3 blur kernel
                for (int x = -1; x <= 1; x++)
                {
                    for (int y = -1; y <= 1; y++)
                    {
                        float2 offset = float2(x, y) * texelSize;
                        blur += tex2D(_MainTex, uv + offset);
                    }
                }

                blur /= 9.0;
                float4 sharpened = center + _Sharpness * (center - blur);

                // Apply lightness adjustment
                float3 baseColor = saturate(sharpened.rgb);
                float3 adjustedColor;

                if (_Lightness < 0.5)
                {
                    adjustedColor = lerp(0.0, baseColor, _Lightness * 2.0); // Black to normal
                }
                else
                {
                    adjustedColor = lerp(baseColor, 1.0, (_Lightness - 0.5) * 2.0); // Normal to white
                }

                return float4(adjustedColor, center.a); // Keep original alpha
            }
            ENDCG
        }
    }
}

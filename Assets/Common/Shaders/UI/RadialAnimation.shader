Shader "OS_Custom/Flexible/Radial animation"
{
    Properties
    {
        [PerRendererData] _MainTex ("Texture", 2D) = "white" {}
        _Radius ("Radius", float) = 1.0
        _Thickness ("Thikness", float) = 0.05
        _Segment ("Segment", float) = 0.5
        _RoundSpeed ("Round Speed", float) = 2
        _SizeMultiplier ("Size Multiplier", float) = 0.5
    }
    
    SubShader
    {
        Tags
        {
            "Queue"="Transparent"
            "IgnoreProjector"="True"
            "RenderType"="Transparent"
            "PreviewType"="Plane"
            "CanUseSpriteAtlas"="True"
        }
        
        Cull Off
        Lighting Off
        ZWrite Off
        Fog { Mode Off }   
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
                float4  color : COLOR;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                float2 center :TEXCOORD1;
                float4 vertex : SV_POSITION;
                float4 color    : COLOR;
            };

            sampler2D _MainTex;
            float4 _MainTex_ST;
            float _Radius;
            float _Thickness;
            float _Segment;
            float _RoundSpeed;
            float _SizeMultiplier;

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                o.center = float2(0.5, 0.5);
                o.color = v.color;
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                fixed4 col = tex2D(_MainTex, i.uv);
                col.rgb = i.color.rgb;
                col.a = 0;

                const float dist = distance(i.center, float2(i.uv.x, i.uv.y));
                const float inner_radius = _Radius - _Thickness;
                float a = sin(_Time.y);
                float b = cos(_Time.y) * _RoundSpeed;
                
                float2 floating_point = float2(a, b) * (_Radius / 0.5) * 0.5 + 0.5;

                if (dist >= inner_radius && dist <= _Radius)
                {
                    const float2 uv = i.uv - i.center;
                    floating_point -= i.center;
                    const float cos_a = dot(uv, floating_point) / (length(uv) * length(floating_point));

                    const float segment_final = _Segment / (abs(b) * _SizeMultiplier + 1); 
                    if (cos_a <= segment_final  && cos_a >= -segment_final) col.a = 1;
                }

                return col;
            }
            ENDCG
        }
    }
}

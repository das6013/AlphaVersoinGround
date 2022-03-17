Shader "Unlit/TerraForming"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _DisRate("Distornion Rate",Range(1,50)) = 30

        _DistortColor("Distor color", color) = (0, 0, 0, 0)
        _Color2("Main color", color) = (0, 0, 0, 0)
        _SubTex("Sub Texture",2D) = "white"{}
    }
    SubShader
    {
        Tags { "RenderType" = "Opaque" }
        LOD 100

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            // make fog work
            #pragma multi_compile_fog

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
            };
           
           
            

            sampler2D _MainTex;
            float4 _MainTex_ST;
            float4 _PointOffset;
            fixed4 _DistortColor;
            fixed4 _Color2;
            Texture2D  _SubTex;
            float _coordArray[10];
            fixed2 _vectorCoord[10];
            fixed4 _coolorArray[10];
            v2f vert(appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);

                return o;
            }
           
           float2 coord(float _coordArray)
           {
           }
            fixed4 frag(v2f i) : SV_Target
            {
                    
                    float2 uv = i.uv - 0.5;
                    
                    fixed4 col = tex2D(_MainTex, i.uv);
                    
                    for (int  j = 0;j<4;j++)
                    {
                        uv[0]+=_vectorCoord[j][0];
                        uv[1]+=_vectorCoord[j][1];
                        float2 distort = uv;
                        
                        float distance = length(distort);
                        float iter = smoothstep(0.1, 0.09, distance);
                      
                        distort *= iter;
                        col.rgb += _Color2;
                        col.rgb += (_DistortColor+_coolorArray[j]) * iter;
                        
                    }
                    
                    return col;
                
              
             
             
              
               


                
            }
            ENDCG
        }
    }
}

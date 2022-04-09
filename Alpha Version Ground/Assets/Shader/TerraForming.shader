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
            sampler2D  _SubTex;
            float2 uv;
            float iter=0;
            float _radius[300];
            float2 startuv;
            fixed2 _vectorCords[300];
            fixed4 _colorArray[300];
            
            v2f vert(appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);

                return o;
            }
           
        
            fixed4 frag(v2f i) : SV_Target
            {
                   
                    uv=i.uv-5;
                    fixed4 col = tex2D(_MainTex, i.uv);
                    for (int j=0;j<300;j++)
                    {
                   if (j==0){
                    uv[0]+=_vectorCords[j][0];
                    uv[1]+=_vectorCords[j][1];}
                    else
                    {
                     uv[0]+=_vectorCords[j][0]-_vectorCords[j-1][0];
                     uv[1]+=_vectorCords[j][1]-_vectorCords[j-1][1];
                    }
                    float2 distort = uv;
                    float distance = length(distort);
                    if (_radius[j]!=0)
                    {
                     iter = smoothstep(_radius[j],_radius[j]-0.1, distance);
                    }
                   
                    
                    col.rgb += _Color2;
                    col.rgb += (_DistortColor+_colorArray[j]*0.1) * iter;
                    }
                  
                    return col;         
            }
            ENDCG
        }
    }
}

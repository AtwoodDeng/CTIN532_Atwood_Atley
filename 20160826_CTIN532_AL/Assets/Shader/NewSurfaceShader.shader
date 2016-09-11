Shader "Custom/New Shader" {

	Properties {
		_MainTex ("Albedo (RGB)", 2D) = "white" {}
	}
  
  SubShader {
   
    Pass {
      
     CGPROGRAM

      #pragma vertex vert
      #pragma fragment frag

      // Use shader model 3.0 target, to get nicer looking lighting
      #pragma target 3.0

      #include "UnityCG.cginc"

      sampler2D _MainTex;

      struct VertexIn
      {
				 float4 position  : POSITION; 
				 float3 normal    : NORMAL; 
				 float4 texcoord  : TEXCOORD0; 
				 float4 tangent   : TANGENT;
      };

      struct VertexOut 
      {
        float4 pos    	: POSITION; 
        float3 normal 	: NORMAL; 
        float4 uv     	: TEXCOORD0; 
      };
    

      VertexOut vert(VertexIn v) 
      {
        
        VertexOut o;

        o.normal = v.normal;
        
        o.uv = v.texcoord;
        
        // Getting the position for actual position
        o.pos = mul( UNITY_MATRIX_MVP , v.position );
        
        return o;

      }

      // Fragment Shader
      fixed4 frag(VertexOut i) : COLOR 
      {
      	//float3 col = float3( 1 , 0, 0);
      	float3 col = float3(cos(i.uv.x *i.uv.y*50 +_Time.x*50), sin(i.uv.x *i.uv.y*75 +_Time.x*50), 2*tan(i.uv.x *i.uv.y*100 + _Time.x*100));

		    fixed4 color;
        color = fixed4( col , 1. );
        return color;
      }

      ENDCG
    }
  }

  FallBack "Diffuse"

}

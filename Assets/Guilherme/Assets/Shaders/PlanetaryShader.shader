Shader "Custom/PlanetaryShader" {
    Properties {
      _Color ("Main Color", Color) = (1.0, 0.6, 0.6, 1.0)
      _HeightMap ("Height Map", 2D) = "grey" {}
      _NormalMap ("Normal Map", 2D) = "grey" {}
      _Amount ("Extrusion Amount", Range(-2,2)) = 0.5
      _Effect ("Extrusion Effect", Range(0,1)) = 0.5
    }
    
    SubShader {
      Tags { "RenderType" = "Opaque" }
      CGPROGRAM
      #pragma surface surf Lambert vertex:vert
      #pragma target 3.0
      #pragma glsl
      
      struct Input {
      	  float2 uv_HeightMap;
          float2 uv_BumpMap;
      };
      
      float _Amount;
      float _Effect;
      sampler2D _HeightMap;
      void vert (inout appdata_full v) {
      	  float4 tex = tex2Dlod(_HeightMap, float4(v.texcoord.xy, 0, 0));
          v.vertex.xyz *= (tex.b * _Effect + _Amount);
      }
      
      float4 _Color;
      sampler2D _NormalMap;
      void surf (Input IN, inout SurfaceOutput o) {
          o.Albedo = tex2D (_HeightMap, IN.uv_HeightMap).rgb * _Color;
          o.Normal = UnpackNormal (tex2D (_NormalMap, IN.uv_BumpMap));
      }
      ENDCG
    } 
    Fallback "Diffuse"
  }
Shader "PostProcessing/Vignette" {
  Properties 
  {
    _MainTex("Texture", 2D) = "white" {}
	_VRadius("Vignette Radius", Range(0.0, 2.0)) = 1.0
	_VSoft("Vignette Softness", Range(0.0, 1.0)) = 0.5
  }

  SubShader 
  {
    Pass 
	{
      CGPROGRAM
      #pragma vertex vert_img
      #pragma fragment frag
      #include "UnityCG.cginc"

      // Properties
      sampler2D _MainTex;
	  float _VRadius;
	  float _VSoft;

      float4 frag(v2f_img input) : COLOR 
	  {
        // sample texture for color
        float4 base = tex2D(_MainTex, input.uv);

		float distFromCenter = distance(input.uv.xy, float2(0.5, 0.5));
				
		float vignette = smoothstep(_VRadius, _VRadius - _VSoft, distFromCenter);

		base = saturate(base * vignette);

		return base;
      }
      ENDCG
	}
  }	
}
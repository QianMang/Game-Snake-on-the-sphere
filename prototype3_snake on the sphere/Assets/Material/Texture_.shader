Shader "Custom/Texture_" {
	Properties{
		_Texture("texture",2D) = "white"{}
		_Color("Color",Color)=(1,1,1,1)
	}



		SubShader{
		CGPROGRAM
#pragma surface surf BlinnPhong
		float4 _Color;
		sampler2D _Texture;


		struct Input {
			float2 uv_Texture;

		};

	void surf(Input IN, inout SurfaceOutput o) {
		o.Albedo = tex2D(_Texture, IN.uv_Texture).rgb;
		
	}
	ENDCG

	}
		FallBack "Diffuse"
}
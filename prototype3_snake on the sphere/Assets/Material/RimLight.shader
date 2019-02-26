﻿Shader "Custom/RimLight" {
	Properties{
		_Color("Color",Color) = (1,1,1,1)
		_RimColor("Rim Color", Color) = (0,0,0,0)
		_RimPower("Rim Power",Range(0.6,8.0)) = 2.0
		_Spec("Specular",Range(0,1)) = 0.5
		_Gloss("Gloss",Range(0,1)) = 0.5
	}



		SubShader{
		CGPROGRAM
#pragma surface surf BlinnPhong
		float4 _Color;
		float4 _RimColor;
		float _RimPower;
		half _Spec;
		fixed _Gloss;
		struct Input {
		float3 viewDir;
		};

	void surf(Input IN, inout SurfaceOutput o) {
		o.Albedo = _Color.rgb;
		half rim = 1 - saturate(dot(normalize(IN.viewDir), o.Normal));
		o.Emission = _RimColor.rgb * pow(rim,_RimPower);
		o.Specular = _Spec;
		o.Gloss = _Gloss;
	}
	ENDCG

	}
		FallBack "Diffuse"
}
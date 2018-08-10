Shader "Custom/PortalShader" {
	Properties
	{
		_Color("Color", Color) = (1,1,1,1)
		_Radio("Radio", Range(-0.001 , 0.3)) = 0.22
		_Noise("Noise", 2D) = "white" {}
		_PortalTex("Texture", 2D) = "white" {}
	}
		SubShader
	{
		Tags{ "RenderType" = "Opaque" }
		LOD 200

		Pass
	{
		CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
		
			#include "UnityCG.cginc"

		struct appdata{
			float4 vertex : POSITION;
			float2 uv : TEXCOORD0;
		};

	struct v2f{
		float2 uv : TEXCOORD0;
		float4 vertex : SV_POSITION;
	};

	sampler2D _PortalTex;
	float4 _PortalTex_ST;

	sampler2D _Noise;

	half4 _Color;

	float _Radio;

	v2f vert(appdata v)
	{
		v2f o;
		o.vertex = UnityObjectToClipPos(v.vertex);
		o.uv = TRANSFORM_TEX(v.uv, _PortalTex);
		return o;
	}

	fixed4 frag(v2f i) : SV_Target
	{
		if (_Radio < 0) return _Color;

		float dist = distance(float2(0.5, 0.25), float2(i.uv.x, i.uv.y / 2));

		if (dist > _Radio) {
			half4 noise = tex2D(_Noise, i.uv/2 + (_Time.x/2));

			float rand =  noise*2;

			rand -= (dist - _Radio)*100;

			if (rand<0.5) return _Color;
		}
		
		return tex2D(_PortalTex, i.uv);
	}
		ENDCG
	}
	}
}

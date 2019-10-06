
////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
Shader "Custom/MiniLightning Shader"
{
	Properties {
	 _TintColor("Tint Color", Color) = (0.500000,0.500000,0.500000,0.500000)
	 _MainTex("Particle Texture", 2D) = "white" { }
	 _InvFade("Soft Particles Factor", Range(0.010000,20.000000)) = 20.000000
	}

	SubShader {
		Tags { "QUEUE" = "Transparent" "IGNOREPROJECTOR" = "true" "RenderType" = "Transparent" "PreviewType" = "Plane" }

		Pass {
			Tags { "QUEUE" = "Transparent" "IGNOREPROJECTOR" = "true" "RenderType" = "Transparent" "PreviewType" = "Plane" }
			ZWrite Off
			Cull Off
			Blend SrcAlpha One
			ColorMask RGB
		}
			//FallBack "Diffuse"
	 }
}

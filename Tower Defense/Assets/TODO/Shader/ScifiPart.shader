// Upgrade NOTE: upgraded instancing buffer 'NaraScifiPart' to new syntax.

// Made with Amplify Shader Editor
// Available at the Unity Asset Store - http://u3d.as/y3X 
Shader "Nara/ScifiPart"
{
	Properties
	{
		_Albedo("Albedo", 2D) = "white" {}
		_TextureSample0("Texture Sample 0", 2D) = "white" {}
		_MetalColor("MetalColor", Color) = (0,0,0,0)
		_TimeMultiplier("TimeMultiplier", Float) = 0
		_EmissiveTexture("EmissiveTexture", 2D) = "white" {}
		[HDR]_EmissiveColor("EmissiveColor", Color) = (1,1,1,0)
		[Toggle(_USECOLOR_ON)] _UseColor("UseColor", Float) = 0
		_Normal("Normal", 2D) = "white" {}
		_Specular("Specular", 2D) = "white" {}
		_Smoothness("Smoothness", Float) = 0
		_EmissionMultiplier("EmissionMultiplier", Float) = 0
		[HideInInspector] _texcoord( "", 2D ) = "white" {}
		[HideInInspector] __dirty( "", Int ) = 1
	}

	SubShader
	{
		Tags{ "RenderType" = "Opaque"  "Queue" = "Geometry+0" "IsEmissive" = "true"  }
		Cull Back
		CGPROGRAM
		#include "UnityShaderVariables.cginc"
		#pragma target 3.0
		#pragma multi_compile_instancing
		#pragma shader_feature _USECOLOR_ON
		#pragma surface surf Standard keepalpha addshadow fullforwardshadows 
		struct Input
		{
			float2 uv_texcoord;
		};

		uniform sampler2D _Normal;
		uniform float4 _Normal_ST;
		uniform sampler2D _Albedo;
		uniform float4 _Albedo_ST;
		uniform sampler2D _TextureSample0;
		uniform float4 _TextureSample0_ST;
		uniform sampler2D _EmissiveTexture;
		uniform float4 _EmissiveTexture_ST;
		uniform sampler2D _Specular;
		uniform float4 _Specular_ST;

		UNITY_INSTANCING_BUFFER_START(NaraScifiPart)
			UNITY_DEFINE_INSTANCED_PROP(float4, _EmissiveColor)
#define _EmissiveColor_arr NaraScifiPart
			UNITY_DEFINE_INSTANCED_PROP(float4, _MetalColor)
#define _MetalColor_arr NaraScifiPart
			UNITY_DEFINE_INSTANCED_PROP(float, _Smoothness)
#define _Smoothness_arr NaraScifiPart
			UNITY_DEFINE_INSTANCED_PROP(float, _EmissionMultiplier)
#define _EmissionMultiplier_arr NaraScifiPart
			UNITY_DEFINE_INSTANCED_PROP(float, _TimeMultiplier)
#define _TimeMultiplier_arr NaraScifiPart
		UNITY_INSTANCING_BUFFER_END(NaraScifiPart)

		void surf( Input i , inout SurfaceOutputStandard o )
		{
			float2 uv_Normal = i.uv_texcoord * _Normal_ST.xy + _Normal_ST.zw;
			o.Normal = UnpackNormal( tex2D( _Normal, uv_Normal ) );
			float2 uv_Albedo = i.uv_texcoord * _Albedo_ST.xy + _Albedo_ST.zw;
			float4 tex2DNode5 = tex2D( _Albedo, uv_Albedo );
			float4 _MetalColor_Instance = UNITY_ACCESS_INSTANCED_PROP(_MetalColor_arr, _MetalColor);
			float2 uv_TextureSample0 = i.uv_texcoord * _TextureSample0_ST.xy + _TextureSample0_ST.zw;
			float4 lerpResult8 = lerp( tex2DNode5 , _MetalColor_Instance , tex2D( _TextureSample0, uv_TextureSample0 ).r);
			#ifdef _USECOLOR_ON
				float4 staticSwitch25 = lerpResult8;
			#else
				float4 staticSwitch25 = tex2DNode5;
			#endif
			o.Albedo = staticSwitch25.rgb;
			float4 _EmissiveColor_Instance = UNITY_ACCESS_INSTANCED_PROP(_EmissiveColor_arr, _EmissiveColor);
			float2 uv_EmissiveTexture = i.uv_texcoord * _EmissiveTexture_ST.xy + _EmissiveTexture_ST.zw;
			float4 lerpResult17 = lerp( _EmissiveColor_Instance , float4(0,0,0,0) , (float4( 1,1,1,0 ) + (tex2D( _EmissiveTexture, uv_EmissiveTexture ) - float4( 0,0,0,0 )) * (float4( 0,0,0,0 ) - float4( 1,1,1,0 )) / (float4( 1,1,1,0 ) - float4( 0,0,0,0 ))).r);
			float _TimeMultiplier_Instance = UNITY_ACCESS_INSTANCED_PROP(_TimeMultiplier_arr, _TimeMultiplier);
			float temp_output_62_0 = ( _SinTime.w * _TimeMultiplier_Instance );
			float clampResult15 = clamp( ( 1.0 - temp_output_62_0 ) , 0.0 , 1.0 );
			float _EmissionMultiplier_Instance = UNITY_ACCESS_INSTANCED_PROP(_EmissionMultiplier_arr, _EmissionMultiplier);
			o.Emission = ( ( lerpResult17 * clampResult15 ) * _EmissionMultiplier_Instance ).rgb;
			float2 uv_Specular = i.uv_texcoord * _Specular_ST.xy + _Specular_ST.zw;
			float _Smoothness_Instance = UNITY_ACCESS_INSTANCED_PROP(_Smoothness_arr, _Smoothness);
			float clampResult31 = clamp( _Smoothness_Instance , 0.0 , 1.0 );
			float4 temp_output_30_0 = ( tex2D( _Specular, uv_Specular ) * clampResult31 );
			o.Metallic = temp_output_30_0.r;
			o.Smoothness = temp_output_30_0.r;
			o.Alpha = 1;
		}

		ENDCG
	}
	Fallback "Diffuse"
	CustomEditor "ASEMaterialInspector"
}
/*ASEBEGIN
Version=15401
200;257;1329;643;2164.881;-820.9418;1.6;True;True
Node;AmplifyShaderEditor.RangedFloatNode;11;-1688.504,1273.083;Float;False;InstancedProperty;_TimeMultiplier;TimeMultiplier;3;0;Create;True;0;0;False;0;0;1;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.SinTimeNode;65;-1495.422,1004.413;Float;True;0;5;FLOAT4;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;62;-1305.644,1343.665;Float;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SamplerNode;13;-842.0502,366.3676;Float;True;Property;_EmissiveTexture;EmissiveTexture;4;0;Create;True;0;0;False;0;None;5950c91a5519c2048b57cb0ed596229e;True;0;False;white;Auto;False;Object;-1;Auto;Texture2D;6;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.TFHCRemapNode;24;-493.3485,401.8359;Float;False;5;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;2;COLOR;1,1,1,0;False;3;COLOR;1,1,1,0;False;4;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.TexturePropertyNode;1;-1217.041,-47.83208;Float;True;Property;_Albedo;Albedo;0;0;Create;True;0;0;False;0;None;bd252d7bd8cb2464892c1f4c216c97b3;False;white;Auto;Texture2D;0;1;SAMPLER2D;0
Node;AmplifyShaderEditor.ColorNode;19;-1061.496,291.7882;Float;False;Constant;_Color0;Color 0;6;0;Create;True;0;0;False;0;0,0,0,0;0,0,0,0;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.ColorNode;16;-773.5258,170.4479;Float;False;InstancedProperty;_EmissiveColor;EmissiveColor;5;1;[HDR];Create;True;0;0;False;0;1,1,1,0;4,4,4,0;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.OneMinusNode;54;-950.5894,1253.644;Float;True;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.ClampOpNode;15;-468.9724,691.0041;Float;False;3;0;FLOAT;0;False;1;FLOAT;0;False;2;FLOAT;1;False;1;FLOAT;0
Node;AmplifyShaderEditor.ColorNode;6;-749.9105,-515.7668;Float;False;InstancedProperty;_MetalColor;MetalColor;2;0;Create;True;0;0;False;0;0,0,0,0;0.07573871,0.457194,0.6981132,0;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SamplerNode;4;-1124.537,-300.165;Float;True;Property;_TextureSample0;Texture Sample 0;1;0;Create;True;0;0;False;0;None;d2c3506199be5874699868411b6f00c7;True;0;False;white;Auto;False;Object;-1;Auto;Texture2D;6;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.LerpOp;17;-225.6902,268.588;Float;False;3;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;2;FLOAT;0;False;1;COLOR;0
Node;AmplifyShaderEditor.SamplerNode;5;-764.2325,-42.58224;Float;True;Property;_TextureSample1;Texture Sample 1;2;0;Create;True;0;0;False;0;None;None;True;0;False;white;Auto;False;Object;-1;Auto;Texture2D;6;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.RangedFloatNode;29;251.7279,640.9548;Float;False;InstancedProperty;_Smoothness;Smoothness;9;0;Create;True;0;0;False;0;0;0.63;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.SamplerNode;28;-38.11792,138.1765;Float;True;Property;_Specular;Specular;8;0;Create;True;0;0;False;0;None;685c7398ae10cda4fa55afc7d37c8e18;True;0;False;white;Auto;False;Object;-1;Auto;Texture2D;6;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.RangedFloatNode;33;-197.4416,634.3574;Float;False;InstancedProperty;_EmissionMultiplier;EmissionMultiplier;10;0;Create;True;0;0;False;0;0;10;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.LerpOp;8;-245.1743,-62.92653;Float;False;3;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;2;FLOAT;0;False;1;COLOR;0
Node;AmplifyShaderEditor.ClampOpNode;31;467.604,497.8882;Float;False;3;0;FLOAT;0;False;1;FLOAT;0;False;2;FLOAT;1;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;14;-71.46683,449.7188;Float;False;2;2;0;COLOR;0,0,0,0;False;1;FLOAT;0;False;1;COLOR;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;34;86.19483,607.8102;Float;False;2;2;0;COLOR;0,0,0,0;False;1;FLOAT;0;False;1;COLOR;0
Node;AmplifyShaderEditor.StaticSwitch;25;-65.28105,-375.5351;Float;False;Property;_UseColor;UseColor;6;0;Create;True;0;0;False;0;0;0;1;True;;Toggle;2;Key0;Key1;9;1;COLOR;0,0,0,0;False;0;COLOR;0,0,0,0;False;2;COLOR;0,0,0,0;False;3;COLOR;0,0,0,0;False;4;COLOR;0,0,0,0;False;5;COLOR;0,0,0,0;False;6;COLOR;0,0,0,0;False;7;COLOR;0,0,0,0;False;8;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;30;688.5757,440.2301;Float;False;2;2;0;COLOR;0,0,0,0;False;1;FLOAT;0;False;1;COLOR;0
Node;AmplifyShaderEditor.SamplerNode;27;-53.11792,-73.82349;Float;True;Property;_Normal;Normal;7;0;Create;True;0;0;False;0;None;5fc59ee60a259ff418f724b6f0a73a85;True;0;True;white;Auto;True;Object;-1;Auto;Texture2D;6;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;5;FLOAT3;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.FractNode;53;-1125.597,1480.212;Float;True;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.StandardSurfaceOutputNode;0;859.8177,48.77921;Float;False;True;2;Float;ASEMaterialInspector;0;0;Standard;Nara/ScifiPart;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;Back;0;False;-1;0;False;-1;False;0;False;-1;0;False;-1;False;0;Opaque;0.5;True;True;0;False;Opaque;;Geometry;All;True;True;True;True;True;True;True;True;True;True;True;True;True;True;True;True;True;0;False;-1;False;0;False;-1;255;False;-1;255;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;False;2;15;10;25;False;0.5;True;0;0;False;-1;0;False;-1;0;0;False;-1;0;False;-1;-1;False;-1;-1;False;-1;0;False;0;0,0,0,0;VertexOffset;True;False;Cylindrical;False;Relative;0;;-1;-1;-1;-1;0;False;0;0;False;-1;-1;0;False;-1;0;0;16;0;FLOAT3;0,0,0;False;1;FLOAT3;0,0,0;False;2;FLOAT3;0,0,0;False;3;FLOAT;0;False;4;FLOAT;0;False;5;FLOAT;0;False;6;FLOAT3;0,0,0;False;7;FLOAT3;0,0,0;False;8;FLOAT;0;False;9;FLOAT;0;False;10;FLOAT;0;False;13;FLOAT3;0,0,0;False;11;FLOAT3;0,0,0;False;12;FLOAT3;0,0,0;False;14;FLOAT4;0,0,0,0;False;15;FLOAT3;0,0,0;False;0
WireConnection;62;0;65;4
WireConnection;62;1;11;0
WireConnection;24;0;13;0
WireConnection;54;0;62;0
WireConnection;15;0;54;0
WireConnection;17;0;16;0
WireConnection;17;1;19;0
WireConnection;17;2;24;0
WireConnection;5;0;1;0
WireConnection;8;0;5;0
WireConnection;8;1;6;0
WireConnection;8;2;4;0
WireConnection;31;0;29;0
WireConnection;14;0;17;0
WireConnection;14;1;15;0
WireConnection;34;0;14;0
WireConnection;34;1;33;0
WireConnection;25;1;5;0
WireConnection;25;0;8;0
WireConnection;30;0;28;0
WireConnection;30;1;31;0
WireConnection;53;0;62;0
WireConnection;0;0;25;0
WireConnection;0;1;27;0
WireConnection;0;2;34;0
WireConnection;0;3;30;0
WireConnection;0;4;30;0
ASEEND*/
//CHKSM=0E4A961A977F4D71C57598BA48B511AF68738F14
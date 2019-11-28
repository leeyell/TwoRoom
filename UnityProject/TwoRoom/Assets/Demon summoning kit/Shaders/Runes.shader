// Made with Amplify Shader Editor
// Available at the Unity Asset Store - http://u3d.as/y3X 
Shader "Custom/Runes"
{
	Properties
	{
		[HideInInspector] __dirty( "", Int ) = 1
		_MaskClipValue( "Mask Clip Value", Float ) = 0
		_RunesAlpha("Runes Alpha", 2D) = "white" {}
		_Runescolor("Runes color", Color) = (1,0.2068965,0,0)
		_Colorpower("Color power", Range( 0 , 5)) = 1
		_Globalemissiveintensity("Global emissive intensity", Range( 0 , 2)) = 1
		[HideInInspector] _texcoord( "", 2D ) = "white" {}
	}

	SubShader
	{
		Tags{ "RenderType" = "Overlay"  "Queue" = "Overlay+0" "IsEmissive" = "true"  }
		Cull Back
		ZWrite Off
		Blend One One , One One
		BlendOp Add , Add
		CGPROGRAM
		#pragma target 3.0
		#pragma surface surf Lambert keepalpha  noshadow noambient novertexlights nolightmap  nodynlightmap nodirlightmap nofog nometa noforwardadd 
		struct Input
		{
			float2 uv_texcoord;
		};

		uniform sampler2D _RunesAlpha;
		uniform float4 _RunesAlpha_ST;
		uniform fixed4 _Runescolor;
		uniform fixed _Colorpower;
		uniform fixed _Globalemissiveintensity;
		uniform float _MaskClipValue = 0;

		void surf( Input i , inout SurfaceOutput o )
		{
			float2 uv_RunesAlpha = i.uv_texcoord * _RunesAlpha_ST.xy + _RunesAlpha_ST.zw;
			fixed4 tex2DNode1 = tex2D( _RunesAlpha,uv_RunesAlpha);
			o.Emission = ( ( tex2DNode1 + ( _Runescolor * ( tex2DNode1.a * _Colorpower ) ) ) * _Globalemissiveintensity ).rgb;
			o.Alpha = 1;
		}

		ENDCG
	}
	CustomEditor "ASEMaterialInspector"
}
/*ASEBEGIN
Version=6001
2567;29;1666;974;378.9998;234.1;1;True;True
Node;AmplifyShaderEditor.SamplerNode;1;-370,-184;Float;True;Property;_RunesAlpha;Runes Alpha;0;0;Assets/Demon summoning kit/Textures/Invocation 5.tga;True;0;False;white;Auto;False;Object;-1;Auto;Texture2D;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;1.0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1.0;False;FLOAT4;FLOAT;FLOAT;FLOAT;FLOAT
Node;AmplifyShaderEditor.RangedFloatNode;5;-295,72;Float;False;Property;_Colorpower;Color power;2;0;1;0;5;FLOAT
Node;AmplifyShaderEditor.ColorNode;3;-270.9998,-358.8005;Float;False;Property;_Runescolor;Runes color;1;0;1,0.2068965,0,0;COLOR;FLOAT;FLOAT;FLOAT;FLOAT
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;11;58.20007,33.49994;Float;False;0;FLOAT;0.0;False;1;FLOAT;0.0;False;FLOAT
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;8;391.0001,-131.3;Float;False;0;COLOR;0.0;False;1;FLOAT;0.0,0,0,0;False;COLOR
Node;AmplifyShaderEditor.SimpleAddOpNode;9;482.2,33.89999;Float;False;0;FLOAT4;0.0;False;1;COLOR;0.0,0,0,0;False;COLOR
Node;AmplifyShaderEditor.RangedFloatNode;13;290.0002,242.9;Float;False;Property;_Globalemissiveintensity;Global emissive intensity;3;0;1;0;2;FLOAT
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;12;586.0002,177.9;Float;False;0;COLOR;0.0;False;1;FLOAT;0.0;False;COLOR
Node;AmplifyShaderEditor.StandardSurfaceOutputNode;0;809.3998,-11.4;Fixed;False;True;2;Fixed;ASEMaterialInspector;Lambert;Custom/Runes;False;False;False;False;True;True;True;True;True;True;True;True;Back;2;0;False;0;100;Custom;0;True;False;0;True;Overlay;Overlay;All;True;True;True;True;True;True;True;True;True;True;True;True;True;True;True;True;True;False;0;255;255;7;7;0;0;False;0;4;10;25;False;0.5;False;4;One;One;4;One;One;Add;Add;0;False;0;0,0,0,0;VertexOffset;False;Cylindrical;0;FLOAT3;0,0,0;False;1;FLOAT3;0,0,0;False;2;FLOAT3;0,0,0;False;3;FLOAT;0.0;False;4;FLOAT;0.0;False;6;FLOAT3;0,0,0;False;7;FLOAT3;0,0,0;False;8;FLOAT;0.0;False;9;FLOAT;0.0;False;10;OBJECT;0.0;False;11;FLOAT3;0,0,0;False;12;FLOAT3;0,0,0;False;13;OBJECT;0.0;False;14;FLOAT4;0,0,0,0;False;15;FLOAT3;0,0,0;False
WireConnection;11;0;1;4
WireConnection;11;1;5;0
WireConnection;8;0;3;0
WireConnection;8;1;11;0
WireConnection;9;0;1;0
WireConnection;9;1;8;0
WireConnection;12;0;9;0
WireConnection;12;1;13;0
WireConnection;0;2;12;0
ASEEND*/
//CHKSM=C041D0952FA48CF6EEA6A05F13F93AB8D8CF87CA
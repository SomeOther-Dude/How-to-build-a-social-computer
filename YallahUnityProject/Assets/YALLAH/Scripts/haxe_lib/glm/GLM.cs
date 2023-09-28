// Generated by Haxe 3.4.7
using haxe.root;

#pragma warning disable 109, 114, 219, 429, 168, 162
namespace glm {
	public class GLM : global::haxe.lang.HxObject {
		
		static GLM() {
			global::glm.GLM.EPSILON = 0.0000001;
		}
		
		
		public GLM(global::haxe.lang.EmptyObject empty) {
		}
		
		
		public GLM() {
			global::glm.GLM.__hx_ctor_glm_GLM(this);
		}
		
		
		public static void __hx_ctor_glm_GLM(global::glm.GLM __hx_this) {
		}
		
		
		public static double EPSILON;
		
		public static double lerp(double a, double b, double t) {
			return ( a + ( t * (( b - a )) ) );
		}
		
		
		public static global::glm.Mat4 translate(global::glm.Vec3 translation, global::glm.Mat4 dest) {
			unchecked {
				{
					dest._00 = ((double) (1) );
					dest._10 = ((double) (0) );
					dest._20 = ((double) (0) );
					dest._30 = ((double) (0) );
					dest._01 = ((double) (0) );
					dest._11 = ((double) (1) );
					dest._21 = ((double) (0) );
					dest._31 = ((double) (0) );
					dest._02 = ((double) (0) );
					dest._12 = ((double) (0) );
					dest._22 = ((double) (1) );
					dest._32 = ((double) (0) );
					dest._03 = ((double) (0) );
					dest._13 = ((double) (0) );
					dest._23 = ((double) (0) );
					dest._33 = ((double) (1) );
				}
				
				dest._30 = translation.x;
				dest._31 = translation.y;
				dest._32 = translation.z;
				return dest;
			}
		}
		
		
		public static global::glm.Mat4 rotate(global::glm.Quat rotation, global::glm.Mat4 dest) {
			unchecked {
				double x2 = ( rotation.x + rotation.x );
				double y2 = ( rotation.y + rotation.y );
				double z2 = ( rotation.z + rotation.z );
				double xx = ( rotation.x * x2 );
				double xy = ( rotation.x * y2 );
				double xz = ( rotation.x * z2 );
				double yy = ( rotation.y * y2 );
				double yz = ( rotation.y * z2 );
				double zz = ( rotation.z * z2 );
				double wx = ( rotation.w * x2 );
				double wy = ( rotation.w * y2 );
				double wz = ( rotation.w * z2 );
				dest._00 = ( 1 - (( yy + zz )) );
				dest._10 = ( xy - wz );
				dest._20 = ( xz + wy );
				dest._30 = ((double) (0) );
				dest._01 = ( xy + wz );
				dest._11 = ( 1 - (( xx + zz )) );
				dest._21 = ( yz - wx );
				dest._31 = ((double) (0) );
				dest._02 = ( xz - wy );
				dest._12 = ( yz + wx );
				dest._22 = ( 1 - (( xx + yy )) );
				dest._32 = ((double) (0) );
				dest._03 = ((double) (0) );
				dest._13 = ((double) (0) );
				dest._23 = ((double) (0) );
				dest._33 = ((double) (1) );
				return dest;
			}
		}
		
		
		public static global::glm.Mat4 scale(global::glm.Vec3 amount, global::glm.Mat4 dest) {
			unchecked {
				{
					dest._00 = ((double) (1) );
					dest._10 = ((double) (0) );
					dest._20 = ((double) (0) );
					dest._30 = ((double) (0) );
					dest._01 = ((double) (0) );
					dest._11 = ((double) (1) );
					dest._21 = ((double) (0) );
					dest._31 = ((double) (0) );
					dest._02 = ((double) (0) );
					dest._12 = ((double) (0) );
					dest._22 = ((double) (1) );
					dest._32 = ((double) (0) );
					dest._03 = ((double) (0) );
					dest._13 = ((double) (0) );
					dest._23 = ((double) (0) );
					dest._33 = ((double) (1) );
				}
				
				dest._00 = amount.x;
				dest._11 = amount.y;
				dest._22 = amount.z;
				return dest;
			}
		}
		
		
		public static global::glm.Mat4 transform(global::glm.Vec3 translation, global::glm.Quat rotation, global::glm.Vec3 scale, global::glm.Mat4 dest) {
			unchecked {
				double x2 = ( rotation.x + rotation.x );
				double y2 = ( rotation.y + rotation.y );
				double z2 = ( rotation.z + rotation.z );
				double xx = ( rotation.x * x2 );
				double xy = ( rotation.x * y2 );
				double xz = ( rotation.x * z2 );
				double yy = ( rotation.y * y2 );
				double yz = ( rotation.y * z2 );
				double zz = ( rotation.z * z2 );
				double wx = ( rotation.w * x2 );
				double wy = ( rotation.w * y2 );
				double wz = ( rotation.w * z2 );
				dest._00 = ( (( 1 - (( yy + zz )) )) * scale.x );
				dest._01 = ( (( xy + wz )) * scale.x );
				dest._02 = ( (( xz - wy )) * scale.x );
				dest._03 = ((double) (0) );
				dest._10 = ( (( xy - wz )) * scale.y );
				dest._11 = ( (( 1 - (( xx + zz )) )) * scale.y );
				dest._12 = ( (( yz + wx )) * scale.y );
				dest._13 = ((double) (0) );
				dest._20 = ( (( xz + wy )) * scale.z );
				dest._21 = ( (( yz - wx )) * scale.z );
				dest._22 = ( (( 1 - (( xx + yy )) )) * scale.z );
				dest._23 = ((double) (0) );
				dest._30 = translation.x;
				dest._31 = translation.y;
				dest._32 = translation.z;
				dest._33 = ((double) (1) );
				return dest;
			}
		}
		
		
		public static global::glm.Mat4 lookAt(global::glm.Vec3 eye, global::glm.Vec3 centre, global::glm.Vec3 up, global::glm.Mat4 dest) {
			unchecked {
				global::glm.Vec3 dest1 = new global::glm.Vec3(default(global::haxe.lang.Null<double>), default(global::haxe.lang.Null<double>), default(global::haxe.lang.Null<double>));
				dest1.x = ( centre.x - eye.x );
				dest1.y = ( centre.y - eye.y );
				dest1.z = ( centre.z - eye.z );
				global::glm.Vec3 f = dest1;
				{
					double length = global::System.Math.Sqrt(((double) (( ( ( f.x * f.x ) + ( f.y * f.y ) ) + ( f.z * f.z ) )) ));
					double mult = ((double) (0) );
					if (( length >= global::glm.GLM.EPSILON )) {
						mult = ( 1 / length );
					}
					
					{
						f.x *= mult;
						f.y *= mult;
						f.z *= mult;
					}
					
				}
				
				global::glm.Vec3 dest2 = new global::glm.Vec3(default(global::haxe.lang.Null<double>), default(global::haxe.lang.Null<double>), default(global::haxe.lang.Null<double>));
				dest2 = new global::glm.Vec3(new global::haxe.lang.Null<double>(( ( f.y * up.z ) - ( f.z * up.y ) ), true), new global::haxe.lang.Null<double>(( ( f.z * up.x ) - ( f.x * up.z ) ), true), new global::haxe.lang.Null<double>(( ( f.x * up.y ) - ( f.y * up.x ) ), true));
				global::glm.Vec3 s = dest2;
				{
					double length1 = global::System.Math.Sqrt(((double) (( ( ( s.x * s.x ) + ( s.y * s.y ) ) + ( s.z * s.z ) )) ));
					double mult1 = ((double) (0) );
					if (( length1 >= global::glm.GLM.EPSILON )) {
						mult1 = ( 1 / length1 );
					}
					
					{
						s.x *= mult1;
						s.y *= mult1;
						s.z *= mult1;
					}
					
				}
				
				global::glm.Vec3 dest3 = new global::glm.Vec3(default(global::haxe.lang.Null<double>), default(global::haxe.lang.Null<double>), default(global::haxe.lang.Null<double>));
				dest3 = new global::glm.Vec3(new global::haxe.lang.Null<double>(( ( s.y * f.z ) - ( s.z * f.y ) ), true), new global::haxe.lang.Null<double>(( ( s.z * f.x ) - ( s.x * f.z ) ), true), new global::haxe.lang.Null<double>(( ( s.x * f.y ) - ( s.y * f.x ) ), true));
				global::glm.Vec3 u = dest3;
				{
					dest._00 = ((double) (1) );
					dest._10 = ((double) (0) );
					dest._20 = ((double) (0) );
					dest._30 = ((double) (0) );
					dest._01 = ((double) (0) );
					dest._11 = ((double) (1) );
					dest._21 = ((double) (0) );
					dest._31 = ((double) (0) );
					dest._02 = ((double) (0) );
					dest._12 = ((double) (0) );
					dest._22 = ((double) (1) );
					dest._32 = ((double) (0) );
					dest._03 = ((double) (0) );
					dest._13 = ((double) (0) );
					dest._23 = ((double) (0) );
					dest._33 = ((double) (1) );
				}
				
				dest._00 = s.x;
				dest._10 = s.y;
				dest._20 = s.z;
				dest._01 = u.x;
				dest._11 = u.y;
				dest._21 = u.z;
				dest._02 =  - (f.x) ;
				dest._12 =  - (f.y) ;
				dest._22 =  - (f.z) ;
				dest._30 =  - ((( ( ( s.x * eye.x ) + ( s.y * eye.y ) ) + ( s.z * eye.z ) ))) ;
				dest._31 =  - ((( ( ( u.x * eye.x ) + ( u.y * eye.y ) ) + ( u.z * eye.z ) ))) ;
				dest._32 = ( ( ( f.x * eye.x ) + ( f.y * eye.y ) ) + ( f.z * eye.z ) );
				return dest;
			}
		}
		
		
		public static global::glm.Mat4 perspective(double fovy, double aspectRatio, double near, double far, global::glm.Mat4 dest) {
			unchecked {
				double f = ( 1 / global::System.Math.Tan(((double) (( fovy / 2 )) )) );
				double nf = ( 1 / (( near - far )) );
				dest._00 = ( f / aspectRatio );
				dest._01 = ((double) (0) );
				dest._02 = ((double) (0) );
				dest._03 = ((double) (0) );
				dest._10 = ((double) (0) );
				dest._11 = f;
				dest._12 = ((double) (0) );
				dest._13 = ((double) (0) );
				dest._20 = ((double) (0) );
				dest._21 = ((double) (0) );
				dest._22 = ( (( far + near )) * nf );
				dest._23 = ((double) (-1) );
				dest._30 = ((double) (0) );
				dest._31 = ((double) (0) );
				dest._32 = ( ( ( 2 * far ) * near ) * nf );
				dest._33 = ((double) (0) );
				return dest;
			}
		}
		
		
		public static global::glm.Mat4 orthographic(double left, double right, double bottom, double top, global::haxe.lang.Null<double> near, global::haxe.lang.Null<double> far, global::glm.Mat4 dest) {
			unchecked {
				double __temp_far5 = ( ( ! (far.hasValue) ) ? (((double) (1) )) : ((far).@value) );
				double __temp_near4 = ( ( ! (near.hasValue) ) ? (((double) (-1) )) : ((near).@value) );
				double rl = ( 1 / (( right - left )) );
				double tb = ( 1 / (( top - bottom )) );
				double fn = ( 1 / (( __temp_far5 - __temp_near4 )) );
				dest._00 = ( 2 * rl );
				dest._10 = ((double) (0) );
				dest._20 = ((double) (0) );
				dest._30 = ( ( -1 * (( left + right )) ) * rl );
				dest._01 = ((double) (0) );
				dest._11 = ( 2 * tb );
				dest._21 = ((double) (0) );
				dest._31 = ( ( -1 * (( top + bottom )) ) * tb );
				dest._02 = ((double) (0) );
				dest._12 = ((double) (0) );
				dest._22 = ( -2 * fn );
				dest._32 = ( ( -1 * (( __temp_far5 + __temp_near4 )) ) * fn );
				dest._03 = ((double) (0) );
				dest._13 = ((double) (0) );
				dest._23 = ((double) (0) );
				dest._33 = ((double) (1) );
				return dest;
			}
		}
		
		
		public static global::glm.Mat4 frustum(double left, double right, double bottom, double top, global::haxe.lang.Null<double> near, global::haxe.lang.Null<double> far, global::glm.Mat4 dest) {
			unchecked {
				double __temp_far7 = ( ( ! (far.hasValue) ) ? (((double) (1) )) : ((far).@value) );
				double __temp_near6 = ( ( ! (near.hasValue) ) ? (((double) (-1) )) : ((near).@value) );
				double rl = ( 1 / (( right - left )) );
				double tb = ( 1 / (( top - bottom )) );
				double nf = ( 1 / (( __temp_near6 - __temp_far7 )) );
				dest._00 = ( ( __temp_near6 * 2 ) * rl );
				dest._01 = ((double) (0) );
				dest._02 = ((double) (0) );
				dest._03 = ((double) (0) );
				dest._10 = ((double) (0) );
				dest._11 = ( ( __temp_near6 * 2 ) * tb );
				dest._12 = ((double) (0) );
				dest._13 = ((double) (0) );
				dest._20 = ( (( right + left )) * tb );
				dest._21 = ( (( top + bottom )) * tb );
				dest._22 = ( (( __temp_far7 + __temp_near6 )) * nf );
				dest._23 = ((double) (-1) );
				dest._30 = ((double) (0) );
				dest._31 = ((double) (0) );
				dest._32 = ( ( ( __temp_far7 * __temp_near6 ) * 2 ) * nf );
				dest._33 = ((double) (0) );
				return dest;
			}
		}
		
		
	}
}



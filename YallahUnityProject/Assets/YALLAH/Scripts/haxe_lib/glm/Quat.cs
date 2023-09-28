// Generated by Haxe 3.4.7
using haxe.root;

#pragma warning disable 109, 114, 219, 429, 168, 162
namespace glm {
	public class Quat : global::haxe.lang.HxObject {
		
		public Quat(global::haxe.lang.EmptyObject empty) {
		}
		
		
		public Quat(global::haxe.lang.Null<double> x, global::haxe.lang.Null<double> y, global::haxe.lang.Null<double> z, global::haxe.lang.Null<double> w) {
			global::glm.Quat.__hx_ctor_glm_Quat(this, x, y, z, w);
		}
		
		
		public static void __hx_ctor_glm_Quat(global::glm.Quat __hx_this, global::haxe.lang.Null<double> x, global::haxe.lang.Null<double> y, global::haxe.lang.Null<double> z, global::haxe.lang.Null<double> w) {
			unchecked {
				double __temp_w40 = ( ( ! (w.hasValue) ) ? (((double) (1) )) : ((w).@value) );
				double __temp_z39 = ( ( ! (z.hasValue) ) ? (((double) (0) )) : ((z).@value) );
				double __temp_y38 = ( ( ! (y.hasValue) ) ? (((double) (0) )) : ((y).@value) );
				double __temp_x37 = ( ( ! (x.hasValue) ) ? (((double) (0) )) : ((x).@value) );
				__hx_this.x = __temp_x37;
				__hx_this.y = __temp_y38;
				__hx_this.z = __temp_z39;
				__hx_this.w = __temp_w40;
			}
		}
		
		
		public static global::glm.Quat normalize(global::glm.Quat q, global::glm.Quat dest) {
			unchecked {
				double length = global::System.Math.Sqrt(((double) (( ( ( ( q.x * q.x ) + ( q.y * q.y ) ) + ( q.z * q.z ) ) + ( q.w * q.w ) )) ));
				double mult = ((double) (0) );
				if (( length >= global::glm.GLM.EPSILON )) {
					mult = ( 1 / length );
				}
				
				dest.x = ( q.x * mult );
				dest.y = ( q.y * mult );
				dest.z = ( q.z * mult );
				dest.w = ( q.w * mult );
				return dest;
			}
		}
		
		
		public static double dot(global::glm.Quat a, global::glm.Quat b) {
			return ( ( ( ( a.x * b.x ) + ( a.y * b.y ) ) + ( a.z * b.z ) ) + ( a.w * b.w ) );
		}
		
		
		public static global::glm.Quat identity(global::glm.Quat dest) {
			unchecked {
				dest.x = ((double) (0) );
				dest.y = ((double) (0) );
				dest.z = ((double) (0) );
				dest.w = ((double) (1) );
				return dest;
			}
		}
		
		
		public static global::glm.Quat copy(global::glm.Quat src, global::glm.Quat dest) {
			dest.x = src.x;
			dest.y = src.y;
			dest.z = src.z;
			dest.w = src.w;
			return dest;
		}
		
		
		public static global::glm.Quat axisAngle(global::glm.Vec3 axis, double angle, global::glm.Quat dest) {
			angle *= 0.5;
			double s = global::System.Math.Sin(((double) (angle) ));
			dest.x = ( s * axis.x );
			dest.y = ( s * axis.y );
			dest.z = ( s * axis.z );
			dest.w = global::System.Math.Cos(((double) (angle) ));
			return dest;
		}
		
		
		public static global::glm.Quat multiplyQuats(global::glm.Quat a, global::glm.Quat b, global::glm.Quat dest) {
			double ax = a.x;
			double ay = a.y;
			double az = a.z;
			double aw = a.w;
			double bx = b.x;
			double @by = b.y;
			double bz = b.z;
			double bw = b.w;
			dest.x = ( ( ( ( ax * bw ) + ( aw * bx ) ) + ( ay * bz ) ) - ( az * @by ) );
			dest.y = ( ( ( ( ay * bw ) + ( aw * @by ) ) + ( az * bx ) ) - ( ax * bz ) );
			dest.z = ( ( ( ( az * bw ) + ( aw * bz ) ) + ( ax * @by ) ) - ( ay * bx ) );
			dest.w = ( ( ( ( aw * bw ) - ( ax * bx ) ) - ( ay * @by ) ) - ( az * bz ) );
			return dest;
		}
		
		
		public static global::glm.Quat multiplyQuatsOp(global::glm.Quat a, global::glm.Quat b) {
			global::glm.Quat dest = new global::glm.Quat(default(global::haxe.lang.Null<double>), default(global::haxe.lang.Null<double>), default(global::haxe.lang.Null<double>), default(global::haxe.lang.Null<double>));
			double ax = a.x;
			double ay = a.y;
			double az = a.z;
			double aw = a.w;
			double bx = b.x;
			double @by = b.y;
			double bz = b.z;
			double bw = b.w;
			dest.x = ( ( ( ( ax * bw ) + ( aw * bx ) ) + ( ay * bz ) ) - ( az * @by ) );
			dest.y = ( ( ( ( ay * bw ) + ( aw * @by ) ) + ( az * bx ) ) - ( ax * bz ) );
			dest.z = ( ( ( ( az * bw ) + ( aw * bz ) ) + ( ax * @by ) ) - ( ay * bx ) );
			dest.w = ( ( ( ( aw * bw ) - ( ax * bx ) ) - ( ay * @by ) ) - ( az * bz ) );
			return dest;
		}
		
		
		public static global::glm.Quat multiplyScalar(global::glm.Quat a, double s, global::glm.Quat dest) {
			dest.x = ( a.x * s );
			dest.y = ( a.y * s );
			dest.z = ( a.z * s );
			dest.w = ( a.w * s );
			return dest;
		}
		
		
		public static global::glm.Quat multiplyScalarOp(global::glm.Quat a, double s) {
			global::glm.Quat dest = new global::glm.Quat(default(global::haxe.lang.Null<double>), default(global::haxe.lang.Null<double>), default(global::haxe.lang.Null<double>), default(global::haxe.lang.Null<double>));
			dest.x = ( a.x * s );
			dest.y = ( a.y * s );
			dest.z = ( a.z * s );
			dest.w = ( a.w * s );
			return dest;
		}
		
		
		public static global::glm.Vec3 rotateVec3(global::glm.Quat q, global::glm.Vec3 v, global::glm.Vec3 dest) {
			double num12 = ( q.x + q.x );
			double num2 = ( q.y + q.y );
			double num = ( q.z + q.z );
			double num11 = ( q.w * num12 );
			double num10 = ( q.w * num2 );
			double num9 = ( q.w * num );
			double num8 = ( q.x * num12 );
			double num7 = ( q.x * num2 );
			double num6 = ( q.x * num );
			double num5 = ( q.y * num2 );
			double num4 = ( q.y * num );
			double num3 = ( q.z * num );
			double num15 = ( ( ( v.x * (( ( 1.0 - num5 ) - num3 )) ) + ( v.y * (( num7 - num9 )) ) ) + ( v.z * (( num6 + num10 )) ) );
			double num14 = ( ( ( v.x * (( num7 + num9 )) ) + ( v.y * (( ( 1.0 - num8 ) - num3 )) ) ) + ( v.z * (( num4 - num11 )) ) );
			double num13 = ( ( ( v.x * (( num6 - num10 )) ) + ( v.y * (( num4 + num11 )) ) ) + ( v.z * (( ( 1.0 - num8 ) - num5 )) ) );
			dest.x = num15;
			dest.y = num14;
			dest.z = num13;
			return dest;
		}
		
		
		public static global::glm.Quat lerp(global::glm.Quat a, global::glm.Quat b, double t, global::glm.Quat dest) {
			double a1 = a.x;
			dest.x = ( a1 + ( t * (( b.x - a1 )) ) );
			double a2 = a.y;
			dest.y = ( a2 + ( t * (( b.y - a2 )) ) );
			double a3 = a.z;
			dest.z = ( a3 + ( t * (( b.z - a3 )) ) );
			double a4 = a.w;
			dest.w = ( a4 + ( t * (( b.w - a4 )) ) );
			return dest;
		}
		
		
		public static global::glm.Quat slerp(global::glm.Quat a, global::glm.Quat b, double t, global::glm.Quat dest) {
			unchecked {
				double bx = b.x;
				double @by = b.y;
				double bz = b.z;
				double bw = b.w;
				double cosTheta = ( ( ( ( a.x * b.x ) + ( a.y * b.y ) ) + ( a.z * b.z ) ) + ( a.w * b.w ) );
				if (( cosTheta < 0 )) {
					cosTheta =  - (cosTheta) ;
					bx =  - (bx) ;
					@by =  - (@by) ;
					bz =  - (bz) ;
					bw =  - (bw) ;
				}
				
				if (( cosTheta > ( 1 - global::glm.GLM.EPSILON ) )) {
					double a1 = a.x;
					dest.x = ( a1 + ( t * (( b.x - a1 )) ) );
					double a2 = a.y;
					dest.y = ( a2 + ( t * (( b.y - a2 )) ) );
					double a3 = a.z;
					dest.z = ( a3 + ( t * (( b.z - a3 )) ) );
					double a4 = a.w;
					dest.w = ( a4 + ( t * (( b.w - a4 )) ) );
					return dest;
				}
				else {
					double angle = global::System.Math.Acos(((double) (cosTheta) ));
					double sa = ( 1 / global::System.Math.Sin(((double) (angle) )) );
					double i = global::System.Math.Sin(((double) (( (( 1 - t )) * angle )) ));
					double j = global::System.Math.Sin(((double) (( t * angle )) ));
					dest.x = ( (( ( i * a.x ) + ( j * bx ) )) * sa );
					dest.y = ( (( ( i * a.y ) + ( j * @by ) )) * sa );
					dest.z = ( (( ( i * a.z ) + ( j * bz ) )) * sa );
					dest.w = ( (( ( i * a.w ) + ( j * bw ) )) * sa );
					return dest;
				}
				
			}
		}
		
		
		public static global::glm.Quat invert(global::glm.Quat q, global::glm.Quat dest) {
			unchecked {
				double x = q.x;
				double y = q.y;
				double z = q.z;
				double w = q.w;
				double d = ( ( ( ( q.x * q.x ) + ( q.y * q.y ) ) + ( q.z * q.z ) ) + ( q.w * q.w ) );
				double oneOverD = ( (( d < global::glm.GLM.EPSILON )) ? (((double) (0) )) : (( 1 / d )) );
				dest.x = (  - (x)  * oneOverD );
				dest.y = (  - (y)  * oneOverD );
				dest.z = (  - (z)  * oneOverD );
				dest.w = ( w * oneOverD );
				return dest;
			}
		}
		
		
		public static global::glm.Quat conjugate(global::glm.Quat q, global::glm.Quat dest) {
			unchecked {
				dest.x = ( -1 * q.x );
				dest.y = ( -1 * q.y );
				dest.z = ( -1 * q.z );
				dest.w = q.w;
				return dest;
			}
		}
		
		
		public static global::glm.Quat fromEuler(double x, double y, double z, global::glm.Quat dest) {
			unchecked {
				double c1 = global::System.Math.Cos(((double) (( x / 2 )) ));
				double c2 = global::System.Math.Cos(((double) (( y / 2 )) ));
				double c3 = global::System.Math.Cos(((double) (( z / 2 )) ));
				double s1 = global::System.Math.Sin(((double) (( x / 2 )) ));
				double s2 = global::System.Math.Sin(((double) (( y / 2 )) ));
				double s3 = global::System.Math.Sin(((double) (( z / 2 )) ));
				dest.x = ( ( ( s1 * c2 ) * c3 ) + ( ( c1 * s2 ) * s3 ) );
				dest.y = ( ( ( c1 * s2 ) * c3 ) - ( ( s1 * c2 ) * s3 ) );
				dest.z = ( ( ( c1 * c2 ) * s3 ) + ( ( s1 * s2 ) * c3 ) );
				dest.w = ( ( ( c1 * c2 ) * c3 ) - ( ( s1 * s2 ) * s3 ) );
				return dest;
			}
		}
		
		
		public static global::glm.Quat newFromEuler(double x, double y, double z) {
			unchecked {
				global::glm.Quat dest = new global::glm.Quat(default(global::haxe.lang.Null<double>), default(global::haxe.lang.Null<double>), default(global::haxe.lang.Null<double>), default(global::haxe.lang.Null<double>));
				double c1 = global::System.Math.Cos(((double) (( x / 2 )) ));
				double c2 = global::System.Math.Cos(((double) (( y / 2 )) ));
				double c3 = global::System.Math.Cos(((double) (( z / 2 )) ));
				double s1 = global::System.Math.Sin(((double) (( x / 2 )) ));
				double s2 = global::System.Math.Sin(((double) (( y / 2 )) ));
				double s3 = global::System.Math.Sin(((double) (( z / 2 )) ));
				dest.x = ( ( ( s1 * c2 ) * c3 ) + ( ( c1 * s2 ) * s3 ) );
				dest.y = ( ( ( c1 * s2 ) * c3 ) - ( ( s1 * c2 ) * s3 ) );
				dest.z = ( ( ( c1 * c2 ) * s3 ) + ( ( s1 * s2 ) * c3 ) );
				dest.w = ( ( ( c1 * c2 ) * c3 ) - ( ( s1 * s2 ) * s3 ) );
				return dest;
			}
		}
		
		
		public static global::glm.Quat fromFloatArray(global::haxe.root.Array<double> arr) {
			unchecked {
				return new global::glm.Quat(new global::haxe.lang.Null<double>(arr[0], true), new global::haxe.lang.Null<double>(arr[1], true), new global::haxe.lang.Null<double>(arr[2], true), new global::haxe.lang.Null<double>(arr[3], true));
			}
		}
		
		
		public double x;
		
		public double y;
		
		public double z;
		
		public double w;
		
		public double @get(int key) {
			unchecked {
				switch (key) {
					case 0:
					{
						return this.x;
					}
					
					
					case 1:
					{
						return this.y;
					}
					
					
					case 2:
					{
						return this.z;
					}
					
					
					case 3:
					{
						return this.w;
					}
					
					
					default:
					{
						throw global::haxe.lang.HaxeException.wrap(global::haxe.lang.Runtime.concat(global::haxe.lang.Runtime.concat("Index ", global::haxe.lang.Runtime.toString(key)), " out of bounds (0-3)!"));
					}
					
				}
				
			}
		}
		
		
		public double arrayWrite(int key, double @value) {
			unchecked {
				switch (key) {
					case 0:
					{
						return this.x = @value;
					}
					
					
					case 1:
					{
						return this.y = @value;
					}
					
					
					case 2:
					{
						return this.z = @value;
					}
					
					
					case 3:
					{
						return this.w = @value;
					}
					
					
					default:
					{
						throw global::haxe.lang.HaxeException.wrap(global::haxe.lang.Runtime.concat(global::haxe.lang.Runtime.concat("Index ", global::haxe.lang.Runtime.toString(key)), " out of bounds (0-3)!"));
					}
					
				}
				
			}
		}
		
		
		public bool @equals(global::glm.Quat b) {
			return  ! ((( ( ( ( global::System.Math.Abs(((double) (( this.x - b.x )) )) >= global::glm.GLM.EPSILON ) || ( global::System.Math.Abs(((double) (( this.y - b.y )) )) >= global::glm.GLM.EPSILON ) ) || ( global::System.Math.Abs(((double) (( this.z - b.z )) )) >= global::glm.GLM.EPSILON ) ) || ( global::System.Math.Abs(((double) (( this.w - b.w )) )) >= global::glm.GLM.EPSILON ) ))) ;
		}
		
		
		public string toString() {
			return global::haxe.lang.Runtime.concat(global::haxe.lang.Runtime.concat(global::haxe.lang.Runtime.concat(global::haxe.lang.Runtime.concat(global::haxe.lang.Runtime.concat(global::haxe.lang.Runtime.concat(global::haxe.lang.Runtime.concat(global::haxe.lang.Runtime.concat("{", global::haxe.lang.Runtime.toString(this.x)), ", "), global::haxe.lang.Runtime.toString(this.y)), ", "), global::haxe.lang.Runtime.toString(this.z)), ", "), global::haxe.lang.Runtime.toString(this.w)), "}");
		}
		
		
		public double lengthSquared() {
			return ( ( ( ( this.x * this.x ) + ( this.y * this.y ) ) + ( this.z * this.z ) ) + ( this.w * this.w ) );
		}
		
		
		public double length() {
			return global::System.Math.Sqrt(((double) (( ( ( ( this.x * this.x ) + ( this.y * this.y ) ) + ( this.z * this.z ) ) + ( this.w * this.w ) )) ));
		}
		
		
		public global::glm.Quat multiplied(global::glm.Quat q) {
			global::glm.Quat dest = new global::glm.Quat(default(global::haxe.lang.Null<double>), default(global::haxe.lang.Null<double>), default(global::haxe.lang.Null<double>), default(global::haxe.lang.Null<double>));
			double ax = this.x;
			double ay = this.y;
			double az = this.z;
			double aw = this.w;
			double bx = q.x;
			double @by = q.y;
			double bz = q.z;
			double bw = q.w;
			dest.x = ( ( ( ( ax * bw ) + ( aw * bx ) ) + ( ay * bz ) ) - ( az * @by ) );
			dest.y = ( ( ( ( ay * bw ) + ( aw * @by ) ) + ( az * bx ) ) - ( ax * bz ) );
			dest.z = ( ( ( ( az * bw ) + ( aw * bz ) ) + ( ax * @by ) ) - ( ay * bx ) );
			dest.w = ( ( ( ( aw * bw ) - ( ax * bx ) ) - ( ay * @by ) ) - ( az * bz ) );
			return dest;
		}
		
		
		public global::glm.Vec3 rotate(global::glm.Vec3 v) {
			global::glm.Vec3 dest = new global::glm.Vec3(default(global::haxe.lang.Null<double>), default(global::haxe.lang.Null<double>), default(global::haxe.lang.Null<double>));
			double num12 = ( this.x + this.x );
			double num2 = ( this.y + this.y );
			double num = ( this.z + this.z );
			double num11 = ( this.w * num12 );
			double num10 = ( this.w * num2 );
			double num9 = ( this.w * num );
			double num8 = ( this.x * num12 );
			double num7 = ( this.x * num2 );
			double num6 = ( this.x * num );
			double num5 = ( this.y * num2 );
			double num4 = ( this.y * num );
			double num3 = ( this.z * num );
			double num15 = ( ( ( v.x * (( ( 1.0 - num5 ) - num3 )) ) + ( v.y * (( num7 - num9 )) ) ) + ( v.z * (( num6 + num10 )) ) );
			double num14 = ( ( ( v.x * (( num7 + num9 )) ) + ( v.y * (( ( 1.0 - num8 ) - num3 )) ) ) + ( v.z * (( num4 - num11 )) ) );
			double num13 = ( ( ( v.x * (( num6 - num10 )) ) + ( v.y * (( num4 + num11 )) ) ) + ( v.z * (( ( 1.0 - num8 ) - num5 )) ) );
			dest.x = num15;
			dest.y = num14;
			dest.z = num13;
			return dest;
		}
		
		
		public global::glm.Quat inverted() {
			unchecked {
				global::glm.Quat dest = new global::glm.Quat(default(global::haxe.lang.Null<double>), default(global::haxe.lang.Null<double>), default(global::haxe.lang.Null<double>), default(global::haxe.lang.Null<double>));
				double x = this.x;
				double y = this.y;
				double z = this.z;
				double w = this.w;
				double d = ( ( ( ( this.x * this.x ) + ( this.y * this.y ) ) + ( this.z * this.z ) ) + ( this.w * this.w ) );
				double oneOverD = ( (( d < global::glm.GLM.EPSILON )) ? (((double) (0) )) : (( 1 / d )) );
				dest.x = (  - (x)  * oneOverD );
				dest.y = (  - (y)  * oneOverD );
				dest.z = (  - (z)  * oneOverD );
				dest.w = ( w * oneOverD );
				return dest;
			}
		}
		
		
		public global::glm.Quat fromQuat(global::glm.Quat q) {
			this.x = q.x;
			this.y = q.y;
			this.z = q.z;
			this.w = q.w;
			return this;
		}
		
		
		public global::haxe.root.Array<double> toFloatArray() {
			return new global::haxe.root.Array<double>(new double[]{this.x, this.y, this.z, this.w});
		}
		
		
		public override double __hx_setField_f(string field, int hash, double @value, bool handleProperties) {
			unchecked {
				switch (hash) {
					case 119:
					{
						this.w = ((double) (@value) );
						return @value;
					}
					
					
					case 122:
					{
						this.z = ((double) (@value) );
						return @value;
					}
					
					
					case 121:
					{
						this.y = ((double) (@value) );
						return @value;
					}
					
					
					case 120:
					{
						this.x = ((double) (@value) );
						return @value;
					}
					
					
					default:
					{
						return base.__hx_setField_f(field, hash, @value, handleProperties);
					}
					
				}
				
			}
		}
		
		
		public override object __hx_setField(string field, int hash, object @value, bool handleProperties) {
			unchecked {
				switch (hash) {
					case 119:
					{
						this.w = ((double) (global::haxe.lang.Runtime.toDouble(@value)) );
						return @value;
					}
					
					
					case 122:
					{
						this.z = ((double) (global::haxe.lang.Runtime.toDouble(@value)) );
						return @value;
					}
					
					
					case 121:
					{
						this.y = ((double) (global::haxe.lang.Runtime.toDouble(@value)) );
						return @value;
					}
					
					
					case 120:
					{
						this.x = ((double) (global::haxe.lang.Runtime.toDouble(@value)) );
						return @value;
					}
					
					
					default:
					{
						return base.__hx_setField(field, hash, @value, handleProperties);
					}
					
				}
				
			}
		}
		
		
		public override object __hx_getField(string field, int hash, bool throwErrors, bool isCheck, bool handleProperties) {
			unchecked {
				switch (hash) {
					case 1711764408:
					{
						return ((global::haxe.lang.Function) (new global::haxe.lang.Closure(this, "toFloatArray", 1711764408)) );
					}
					
					
					case 685115233:
					{
						return ((global::haxe.lang.Function) (new global::haxe.lang.Closure(this, "fromQuat", 685115233)) );
					}
					
					
					case 1966190837:
					{
						return ((global::haxe.lang.Function) (new global::haxe.lang.Closure(this, "inverted", 1966190837)) );
					}
					
					
					case 1260406363:
					{
						return ((global::haxe.lang.Function) (new global::haxe.lang.Closure(this, "rotate", 1260406363)) );
					}
					
					
					case 18409331:
					{
						return ((global::haxe.lang.Function) (new global::haxe.lang.Closure(this, "multiplied", 18409331)) );
					}
					
					
					case 520590566:
					{
						return ((global::haxe.lang.Function) (new global::haxe.lang.Closure(this, "length", 520590566)) );
					}
					
					
					case 893723873:
					{
						return ((global::haxe.lang.Function) (new global::haxe.lang.Closure(this, "lengthSquared", 893723873)) );
					}
					
					
					case 946786476:
					{
						return ((global::haxe.lang.Function) (new global::haxe.lang.Closure(this, "toString", 946786476)) );
					}
					
					
					case 1072885311:
					{
						return ((global::haxe.lang.Function) (new global::haxe.lang.Closure(this, "equals", 1072885311)) );
					}
					
					
					case 1250329734:
					{
						return ((global::haxe.lang.Function) (new global::haxe.lang.Closure(this, "arrayWrite", 1250329734)) );
					}
					
					
					case 5144726:
					{
						return ((global::haxe.lang.Function) (new global::haxe.lang.Closure(this, "get", 5144726)) );
					}
					
					
					case 119:
					{
						return this.w;
					}
					
					
					case 122:
					{
						return this.z;
					}
					
					
					case 121:
					{
						return this.y;
					}
					
					
					case 120:
					{
						return this.x;
					}
					
					
					default:
					{
						return base.__hx_getField(field, hash, throwErrors, isCheck, handleProperties);
					}
					
				}
				
			}
		}
		
		
		public override double __hx_getField_f(string field, int hash, bool throwErrors, bool handleProperties) {
			unchecked {
				switch (hash) {
					case 119:
					{
						return this.w;
					}
					
					
					case 122:
					{
						return this.z;
					}
					
					
					case 121:
					{
						return this.y;
					}
					
					
					case 120:
					{
						return this.x;
					}
					
					
					default:
					{
						return base.__hx_getField_f(field, hash, throwErrors, handleProperties);
					}
					
				}
				
			}
		}
		
		
		public override object __hx_invokeField(string field, int hash, global::haxe.root.Array dynargs) {
			unchecked {
				switch (hash) {
					case 1711764408:
					{
						return this.toFloatArray();
					}
					
					
					case 685115233:
					{
						return this.fromQuat(((global::glm.Quat) (dynargs[0]) ));
					}
					
					
					case 1966190837:
					{
						return this.inverted();
					}
					
					
					case 1260406363:
					{
						return this.rotate(((global::glm.Vec3) (dynargs[0]) ));
					}
					
					
					case 18409331:
					{
						return this.multiplied(((global::glm.Quat) (dynargs[0]) ));
					}
					
					
					case 520590566:
					{
						return this.length();
					}
					
					
					case 893723873:
					{
						return this.lengthSquared();
					}
					
					
					case 946786476:
					{
						return this.toString();
					}
					
					
					case 1072885311:
					{
						return this.@equals(((global::glm.Quat) (dynargs[0]) ));
					}
					
					
					case 1250329734:
					{
						return this.arrayWrite(((int) (global::haxe.lang.Runtime.toInt(dynargs[0])) ), ((double) (global::haxe.lang.Runtime.toDouble(dynargs[1])) ));
					}
					
					
					case 5144726:
					{
						return this.@get(((int) (global::haxe.lang.Runtime.toInt(dynargs[0])) ));
					}
					
					
					default:
					{
						return base.__hx_invokeField(field, hash, dynargs);
					}
					
				}
				
			}
		}
		
		
		public override void __hx_getFields(global::haxe.root.Array<object> baseArr) {
			baseArr.push("w");
			baseArr.push("z");
			baseArr.push("y");
			baseArr.push("x");
			base.__hx_getFields(baseArr);
		}
		
		
		public override string ToString(){
			return this.toString();
		}
		
		
	}
}


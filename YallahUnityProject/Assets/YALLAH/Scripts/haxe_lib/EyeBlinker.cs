// Generated by Haxe 3.4.7
using haxe.root;

#pragma warning disable 109, 114, 219, 429, 168, 162
namespace haxe.root {
	public class BlinkException : global::haxe.lang.HxObject {
		
		public BlinkException(global::haxe.lang.EmptyObject empty) {
		}
		
		
		public BlinkException(string reason) {
			global::haxe.root.BlinkException.__hx_ctor__BlinkException(this, reason);
		}
		
		
		public static void __hx_ctor__BlinkException(global::haxe.root.BlinkException __hx_this, string reason) {
			__hx_this.reason = reason;
		}
		
		
		public string reason;
		
		public override object __hx_setField(string field, int hash, object @value, bool handleProperties) {
			unchecked {
				switch (hash) {
					case 2090667972:
					{
						this.reason = global::haxe.lang.Runtime.toString(@value);
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
					case 2090667972:
					{
						return this.reason;
					}
					
					
					default:
					{
						return base.__hx_getField(field, hash, throwErrors, isCheck, handleProperties);
					}
					
				}
				
			}
		}
		
		
		public override void __hx_getFields(global::haxe.root.Array<object> baseArr) {
			baseArr.push("reason");
			base.__hx_getFields(baseArr);
		}
		
		
	}
}



#pragma warning disable 109, 114, 219, 429, 168, 162
namespace haxe.root {
	public class BlinkStatus : global::haxe.lang.Enum {
		
		public BlinkStatus(int index) : base(index) {
		}
		
		
		public static readonly string[] __hx_constructs = new string[]{"OPENING", "CLOSING", "WAITING"};
		
		public static readonly global::haxe.root.BlinkStatus OPENING = new global::haxe.root.BlinkStatus(0);
		
		public static readonly global::haxe.root.BlinkStatus CLOSING = new global::haxe.root.BlinkStatus(1);
		
		public static readonly global::haxe.root.BlinkStatus WAITING = new global::haxe.root.BlinkStatus(2);
		
		public override string getTag() {
			return global::haxe.root.BlinkStatus.__hx_constructs[this.index];
		}
		
		
	}
}



#pragma warning disable 109, 114, 219, 429, 168, 162
namespace haxe.root {
	public class EyeBlinker : global::haxe.lang.HxObject {
		
		static EyeBlinker() {
			global::haxe.root.EyeBlinker.EYE_CLOSE_SPEED = ((double) (((int) (8) )) );
			global::haxe.root.EyeBlinker.EYE_OPEN_SPEED = ((double) (((int) (10) )) );
			global::haxe.root.EyeBlinker.MIN_DELAY = 4.0;
			global::haxe.root.EyeBlinker.MAX_DELAY = 8.0;
			global::haxe.root.EyeBlinker.VISEMES = new global::haxe.root.Array<object>(new object[]{"Expressions_eyeClosedL_max", "Expressions_eyeClosedR_max"});
		}
		
		
		public EyeBlinker(global::haxe.lang.EmptyObject empty) {
		}
		
		
		public EyeBlinker() {
			global::haxe.root.EyeBlinker.__hx_ctor__EyeBlinker(this);
		}
		
		
		public static void __hx_ctor__EyeBlinker(global::haxe.root.EyeBlinker __hx_this) {
			__hx_this.blink_status = global::haxe.root.BlinkStatus.WAITING;
			__hx_this.next_blink_time = 0.0;
			__hx_this.current_weight = 0.0;
			__hx_this.last_time = ((double) (((int) (-1) )) );
		}
		
		
		public static double EYE_CLOSE_SPEED;
		
		public static double EYE_OPEN_SPEED;
		
		public static double MIN_DELAY;
		
		public static double MAX_DELAY;
		
		public static global::haxe.root.Array<object> VISEMES;
		
		public static int get_viseme_count() {
			return global::haxe.root.EyeBlinker.VISEMES.length;
		}
		
		
		public static int poisson(double lambda) {
			double limit = global::System.Math.Exp(((double) ( - (lambda) ) ));
			double prod = global::haxe.root.Math.rand.NextDouble();
			int n = 0;
			while (( prod >= limit )) {
				prod *= global::haxe.root.Math.rand.NextDouble();
				 ++ n;
			}
			
			return n;
		}
		
		
		public static void main() {
			global::haxe.root.EyeBlinker.test_poisson();
		}
		
		
		public static void test_speed() {
			unchecked {
				double SIM_REAL_TIME = 10.0;
				global::haxe.root.EyeBlinker blinker = new global::haxe.root.EyeBlinker();
				global::haxe.Log.trace.__hx_invoke2_o(default(double), global::haxe.lang.Runtime.concat("Instance ", global::haxe.root.Std.@string(blinker)), default(double), new global::haxe.lang.DynamicObject(new int[]{302979532, 1547539107, 1648581351}, new object[]{"test_speed", "EyeBlinker", "EyeBlinker.hx"}, new int[]{1981972957}, new double[]{((double) (164) )}));
				int n_visemes = global::haxe.root.EyeBlinker.VISEMES.length;
				double[] this1 = new double[n_visemes];
				double[] visemes_buffer = ((double[]) (this1) );
				{
					int _g1 = 0;
					int _g = ( ((double[]) (visemes_buffer) ) as global::System.Array ).Length;
					while (( _g1 < _g )) {
						int i = _g1++;
						((double[]) (visemes_buffer) )[i] = 0.0;
					}
					
				}
				
				double simulated_time = 0.0;
				int iterations = 0;
				double before = global::haxe.root.Sys.time();
				while (( ( global::haxe.root.Sys.time() - before ) < SIM_REAL_TIME )) {
					blinker.update(simulated_time, visemes_buffer);
					simulated_time += 0.02;
					 ++ iterations;
				}
				
				double after = global::haxe.root.Sys.time();
				global::haxe.Log.trace.__hx_invoke2_o(default(double), global::haxe.lang.Runtime.concat(global::haxe.lang.Runtime.concat("Simulated ", global::haxe.lang.Runtime.toString(SIM_REAL_TIME)), " seconds"), default(double), new global::haxe.lang.DynamicObject(new int[]{302979532, 1547539107, 1648581351}, new object[]{"test_speed", "EyeBlinker", "EyeBlinker.hx"}, new int[]{1981972957}, new double[]{((double) (190) )}));
				double elapsed = ( after - before );
				double iter_per_sec = ( iterations / elapsed );
				global::haxe.Log.trace.__hx_invoke2_o(default(double), global::haxe.lang.Runtime.concat("Number of iterations: ", global::haxe.lang.Runtime.toString(iterations)), default(double), new global::haxe.lang.DynamicObject(new int[]{302979532, 1547539107, 1648581351}, new object[]{"test_speed", "EyeBlinker", "EyeBlinker.hx"}, new int[]{1981972957}, new double[]{((double) (193) )}));
				global::haxe.Log.trace.__hx_invoke2_o(default(double), global::haxe.lang.Runtime.concat("Elapsed (secs): ", global::haxe.lang.Runtime.toString(elapsed)), default(double), new global::haxe.lang.DynamicObject(new int[]{302979532, 1547539107, 1648581351}, new object[]{"test_speed", "EyeBlinker", "EyeBlinker.hx"}, new int[]{1981972957}, new double[]{((double) (194) )}));
				global::haxe.Log.trace.__hx_invoke2_o(default(double), global::haxe.lang.Runtime.concat("Iter / sec: ", global::haxe.lang.Runtime.toString(iter_per_sec)), default(double), new global::haxe.lang.DynamicObject(new int[]{302979532, 1547539107, 1648581351}, new object[]{"test_speed", "EyeBlinker", "EyeBlinker.hx"}, new int[]{1981972957}, new double[]{((double) (195) )}));
				global::haxe.Log.trace.__hx_invoke2_o(default(double), "Main finished.", default(double), new global::haxe.lang.DynamicObject(new int[]{302979532, 1547539107, 1648581351}, new object[]{"test_speed", "EyeBlinker", "EyeBlinker.hx"}, new int[]{1981972957}, new double[]{((double) (197) )}));
			}
		}
		
		
		public static void test_poisson() {
			unchecked {
				int sample_size = 15;
				int n_rolls = 1000;
				int max_plot_chars = 150;
				global::haxe.root.Array<int> _g = new global::haxe.root.Array<int>(new int[]{});
				{
					int _g2 = 0;
					int _g1 = sample_size;
					while (( _g2 < _g1 )) {
						int i = _g2++;
						_g.push(0);
					}
					
				}
				
				global::haxe.root.Array<int> counters = _g;
				global::haxe.Log.trace.__hx_invoke2_o(default(double), "Randomizing...", default(double), new global::haxe.lang.DynamicObject(new int[]{302979532, 1547539107, 1648581351}, new object[]{"test_poisson", "EyeBlinker", "EyeBlinker.hx"}, new int[]{1981972957}, new double[]{((double) (210) )}));
				{
					int _g21 = 0;
					int _g11 = n_rolls;
					while (( _g21 < _g11 )) {
						int i1 = _g21++;
						int n = global::haxe.root.EyeBlinker.poisson(0.5);
						if (( n < sample_size )) {
							counters[n] += 1;
						}
						
					}
					
				}
				
				int max_count = 0;
				{
					int _g22 = 0;
					int _g12 = counters.length;
					while (( _g22 < _g12 )) {
						int i2 = _g22++;
						int n1 = counters[i2];
						if (( n1 > max_count )) {
							max_count = n1;
						}
						
					}
					
				}
				
				double div = ( ((double) (max_count) ) / max_plot_chars );
				{
					int _g23 = 0;
					int _g13 = counters.length;
					while (( _g23 < _g13 )) {
						int i3 = _g23++;
						int n2 = counters[i3];
						global::System.Console.Write(((object) (global::haxe.lang.Runtime.concat(global::haxe.lang.Runtime.concat(global::haxe.lang.Runtime.concat(global::haxe.lang.Runtime.toString(i3), "("), global::haxe.lang.Runtime.toString(n2)), "):\t")) ));
						n2 = ((int) (( n2 / div )) );
						{
							int _g4 = 0;
							int _g3 = n2;
							while (( _g4 < _g3 )) {
								int j = _g4++;
								global::System.Console.Write(((object) ("*") ));
							}
							
						}
						
						global::System.Console.WriteLine(((object) ("") ));
					}
					
				}
				
			}
		}
		
		
		public double last_time;
		
		public double current_weight;
		
		public double next_blink_time;
		
		public global::haxe.root.BlinkStatus blink_status;
		
		public virtual void update(double now, double[] viseme_weights) {
			unchecked {
				if (( ( ((double[]) (viseme_weights) ) as global::System.Array ).Length != global::haxe.root.EyeBlinker.VISEMES.length )) {
					throw global::haxe.lang.HaxeException.wrap(new global::haxe.root.BlinkException(((string) (global::haxe.lang.Runtime.concat(global::haxe.lang.Runtime.concat(global::haxe.lang.Runtime.concat(global::haxe.lang.Runtime.concat("Viseme weight vector has wrong size.", " Expected "), global::haxe.lang.Runtime.toString(global::haxe.root.EyeBlinker.VISEMES.length)), ", found "), global::haxe.lang.Runtime.toString(( ((double[]) (viseme_weights) ) as global::System.Array ).Length))) )));
				}
				
				if (( this.last_time == -1 )) {
					this.last_time = now;
					return;
				}
				
				double delta_time = ( now - this.last_time );
				this.last_time = now;
				if (( this.blink_status == global::haxe.root.BlinkStatus.WAITING )) {
					if (( now >= this.next_blink_time )) {
						this.blink_status = global::haxe.root.BlinkStatus.CLOSING;
					}
					
				}
				else if (( this.blink_status == global::haxe.root.BlinkStatus.CLOSING )) {
					double delta_close = ( global::haxe.root.EyeBlinker.EYE_CLOSE_SPEED * delta_time );
					this.current_weight += delta_close;
					if (( this.current_weight >= 1.0 )) {
						this.current_weight = 1.0;
						this.blink_status = global::haxe.root.BlinkStatus.OPENING;
					}
					
				}
				else if (( this.blink_status == global::haxe.root.BlinkStatus.OPENING )) {
					double delta_open = ( global::haxe.root.EyeBlinker.EYE_OPEN_SPEED * delta_time );
					this.current_weight -= delta_open;
					if (( this.current_weight <= 0.0 )) {
						this.current_weight = 0.0;
						this.blink_status = global::haxe.root.BlinkStatus.WAITING;
						double delay = ( global::haxe.root.EyeBlinker.MIN_DELAY + ( (( global::haxe.root.EyeBlinker.MAX_DELAY - global::haxe.root.EyeBlinker.MIN_DELAY )) * global::haxe.root.Math.rand.NextDouble() ) );
						this.next_blink_time = ( now + delay );
					}
					
				}
				
				{
					int _g1 = 0;
					int _g = global::haxe.root.EyeBlinker.VISEMES.length;
					while (( _g1 < _g )) {
						int i = _g1++;
						((double[]) (viseme_weights) )[i] = this.current_weight;
					}
					
				}
				
			}
		}
		
		
		public override double __hx_setField_f(string field, int hash, double @value, bool handleProperties) {
			unchecked {
				switch (hash) {
					case 1485070364:
					{
						this.next_blink_time = ((double) (@value) );
						return @value;
					}
					
					
					case 811651070:
					{
						this.current_weight = ((double) (@value) );
						return @value;
					}
					
					
					case 965584342:
					{
						this.last_time = ((double) (@value) );
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
					case 1743530741:
					{
						this.blink_status = ((global::haxe.root.BlinkStatus) (@value) );
						return @value;
					}
					
					
					case 1485070364:
					{
						this.next_blink_time = ((double) (global::haxe.lang.Runtime.toDouble(@value)) );
						return @value;
					}
					
					
					case 811651070:
					{
						this.current_weight = ((double) (global::haxe.lang.Runtime.toDouble(@value)) );
						return @value;
					}
					
					
					case 965584342:
					{
						this.last_time = ((double) (global::haxe.lang.Runtime.toDouble(@value)) );
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
					case 117802505:
					{
						return ((global::haxe.lang.Function) (new global::haxe.lang.Closure(this, "update", 117802505)) );
					}
					
					
					case 1743530741:
					{
						return this.blink_status;
					}
					
					
					case 1485070364:
					{
						return this.next_blink_time;
					}
					
					
					case 811651070:
					{
						return this.current_weight;
					}
					
					
					case 965584342:
					{
						return this.last_time;
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
					case 1485070364:
					{
						return this.next_blink_time;
					}
					
					
					case 811651070:
					{
						return this.current_weight;
					}
					
					
					case 965584342:
					{
						return this.last_time;
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
					case 117802505:
					{
						this.update(((double) (global::haxe.lang.Runtime.toDouble(dynargs[0])) ), ((double[]) (dynargs[1]) ));
						break;
					}
					
					
					default:
					{
						return base.__hx_invokeField(field, hash, dynargs);
					}
					
				}
				
				return null;
			}
		}
		
		
		public override void __hx_getFields(global::haxe.root.Array<object> baseArr) {
			baseArr.push("blink_status");
			baseArr.push("next_blink_time");
			baseArr.push("current_weight");
			baseArr.push("last_time");
			base.__hx_getFields(baseArr);
		}
		
		
	}
}



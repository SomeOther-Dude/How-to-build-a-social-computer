// Generated by Haxe 3.4.7
using haxe.root;

#pragma warning disable 109, 114, 219, 429, 168, 162
namespace haxe.root {
	public class Sys : global::haxe.lang.HxObject {
		
		public Sys(global::haxe.lang.EmptyObject empty) {
		}
		
		
		public Sys() {
			global::haxe.root.Sys.__hx_ctor__Sys(this);
		}
		
		
		public static void __hx_ctor__Sys(global::haxe.root.Sys __hx_this) {
		}
		
		
		public static readonly long epochTicks = new global::System.DateTime(1970, 1, 1).Ticks;
		
		public static double time() {
			return ( ((double) (((long) (( ((long) (global::System.DateTime.UtcNow.Ticks) ) - ((long) (global::haxe.root.Sys.epochTicks) ) )) )) ) / ((double) (global::System.TimeSpan.TicksPerSecond) ) );
		}
		
		
	}
}



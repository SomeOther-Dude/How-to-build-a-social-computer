// Generated by Haxe 3.4.7

#pragma warning disable 109, 114, 219, 429, 168, 162
namespace haxe.io {
	public class Error : global::haxe.lang.ParamEnum {
		
		public Error(int index, object[] @params) : base(index, @params) {
		}
		
		
		public static readonly string[] __hx_constructs = new string[]{"Blocked", "Overflow", "OutsideBounds", "Custom"};
		
		public static readonly global::haxe.io.Error Blocked = new global::haxe.io.Error(0, null);
		
		public static readonly global::haxe.io.Error Overflow = new global::haxe.io.Error(1, null);
		
		public static readonly global::haxe.io.Error OutsideBounds = new global::haxe.io.Error(2, null);
		
		public static global::haxe.io.Error Custom(object e) {
			unchecked {
				return new global::haxe.io.Error(3, new object[]{e});
			}
		}
		
		
		public override string getTag() {
			return global::haxe.io.Error.__hx_constructs[this.index];
		}
		
		
	}
}



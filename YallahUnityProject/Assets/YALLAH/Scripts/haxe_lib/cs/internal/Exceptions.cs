// Generated by Haxe 3.4.7
using haxe.root;

#pragma warning disable 109, 114, 219, 429, 168, 162
namespace haxe.lang {
	public class Exceptions {
		
		public Exceptions() {
		}
		
		
		[System.ThreadStaticAttribute]
		public static global::System.Exception exception;
		
	}
}



#pragma warning disable 109, 114, 219, 429, 168, 162
namespace haxe.lang {
	public class HaxeException : global::System.Exception {
		
		override public string Message { get { return this.toString(); } }

		public HaxeException(object obj) : base() {
			if (( obj is global::haxe.lang.HaxeException )) {
				global::haxe.lang.HaxeException _obj = ((global::haxe.lang.HaxeException) (obj) );
				obj = _obj.getObject();
			}
			
			this.obj = obj;
		}
		
		
		public static global::System.Exception wrap(object obj) {
			if (( obj is global::System.Exception )) {
				return ((global::System.Exception) (obj) );
			}
			
			return new global::haxe.lang.HaxeException(obj);
		}
		
		
		public object obj;
		
		public virtual object getObject() {
			return this.obj;
		}
		
		
		public virtual string toString() {
			return global::haxe.root.Std.@string(this.obj);
		}
		
		
		public override string ToString(){
			return this.toString();
		}
		
		
	}
}



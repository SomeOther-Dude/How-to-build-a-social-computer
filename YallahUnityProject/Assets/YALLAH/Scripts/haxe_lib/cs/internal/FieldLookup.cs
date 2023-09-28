// Generated by Haxe 3.4.7
using haxe.root;

#pragma warning disable 109, 114, 219, 429, 168, 162
namespace haxe.lang {
	public sealed class FieldHashConflict {
		
		public FieldHashConflict(int hash, string name, object @value, global::haxe.lang.FieldHashConflict next) {
			this.hash = hash;
			this.name = name;
			this.@value = @value;
			this.next = next;
		}
		
		
		public readonly int hash;
		
		public readonly string name;
		
		public object @value;
		
		public global::haxe.lang.FieldHashConflict next;
		
	}
}



#pragma warning disable 109, 114, 219, 429, 168, 162
namespace haxe.lang {
	public sealed class FieldLookup {
		
		#pragma warning disable 628
		static FieldLookup() {
			global::haxe.lang.FieldLookup.length = ( global::haxe.lang.FieldLookup.fieldIds as global::System.Array ).Length;
		}
		
		
		public FieldLookup() {
		}
		
		
		protected static int[] fieldIds = new int[]{97, 98, 103, 105, 106, 109, 114, 119, 120, 121, 122, 4735007, 4735008, 4735009, 4735010, 4735230, 4735231, 4735232, 4735233, 4735453, 4735454, 4735455, 4735456, 4735676, 4735677, 4735678, 4735679, 4745537, 4849249, 5144726, 5393365, 5442204, 5594513, 5594516, 5741474, 5744817, 18409331, 46374763, 53043259, 57476627, 76061764, 87367608, 117802505, 142301684, 208459108, 243225909, 288167040, 290374058, 291546424, 291546425, 291546430, 291546432, 291546433, 291546441, 302979532, 316767152, 328878574, 359333139, 407283053, 452737314, 480756972, 493819893, 501039929, 520590566, 542885014, 545779894, 652994848, 685115233, 701410669, 722177317, 811651070, 836123838, 882154836, 893723873, 922671056, 946786476, 965584342, 995006396, 999145111, 1040314522, 1048318581, 1058556349, 1067353468, 1071652316, 1072057371, 1072885311, 1103412149, 1181037546, 1204816148, 1214453688, 1215249846, 1224901875, 1228056441, 1247875546, 1250329734, 1260406363, 1262080244, 1262080245, 1262080246, 1262080247, 1262129973, 1262129974, 1262129975, 1262129976, 1262179702, 1262179703, 1262179704, 1262179705, 1262229431, 1262229432, 1262229433, 1262229434, 1266619755, 1266619756, 1266619757, 1266619758, 1266669484, 1266669485, 1266669486, 1266669487, 1266719213, 1266719214, 1266719215, 1266719216, 1266768942, 1266768943, 1266768944, 1266768945, 1280549057, 1280845662, 1282943179, 1313416818, 1352786672, 1367651702, 1395555037, 1398464674, 1431819701, 1436822557, 1450762973, 1485070364, 1532710347, 1537812987, 1547539107, 1620824029, 1621420777, 1623148745, 1639293562, 1648581351, 1705629508, 1711764408, 1743530741, 1763375486, 1768617329, 1782881861, 1790523959, 1830310359, 1877571264, 1915412854, 1916009602, 1935595882, 1966190837, 1981972957, 2014410004, 2022294396, 2025055113, 2039949928, 2039949929, 2039949930, 2039949931, 2039999657, 2039999658, 2039999659, 2039999660, 2040049386, 2040049387, 2040049388, 2040049389, 2040099115, 2040099116, 2040099117, 2040099118, 2048392659, 2049940292, 2049940293, 2049940298, 2049940300, 2049940301, 2049940309, 2054707467, 2057722141, 2082663554, 2090667972, 2127021138};
		
		protected static string[] fields = new string[]{"a", "b", "g", "i", "j", "m", "r", "w", "x", "y", "z", "_00", "_01", "_02", "_03", "_10", "_11", "_12", "_13", "_20", "_21", "_22", "_23", "_30", "_31", "_32", "_33", "__a", "arr", "get", "len", "map", "pop", "pos", "set", "str", "multiplied", "readAll", "DEFAULT_VISEME", "getEnumConstructs", "remove", "filter", "update", "resize", "parseString", "readBytes", "stream", "ready_to_speak", "get_a", "get_b", "get_g", "get_i", "get_j", "get_r", "methodName", "ramp_up_speed", "iterator", "lastIndexOf", "hasNext", "reverse", "nOccupied", "getBytes", "insert", "length", "VISEMES", "visemes", "invalidNumber", "fromQuat", "invalidChar", "realized_visemes", "current_weight", "reset_timers", "stop_sequencer", "lengthSquared", "cachedIndex", "toString", "last_time", "hashes", "speak_start_time", "parse_realized_durations", "realized_times", "_eof", "splice", "exists", "default_viseme", "equals", "copy", "join", "concat", "close", "active_viseme", "next", "enumConstructor", "push", "arrayWrite", "rotate", "get_r0c0", "get_r0c1", "get_r0c2", "get_r0c3", "get_r1c0", "get_r1c1", "get_r1c2", "get_r1c3", "get_r2c0", "get_r2c1", "get_r2c2", "get_r2c3", "get_r3c0", "get_r3c1", "get_r3c2", "get_r3c3", "r0c0", "r0c1", "r0c2", "r0c3", "r1c0", "r1c1", "r1c2", "r1c3", "r2c0", "r2c1", "r2c2", "r2c3", "r3c0", "r3c1", "r3c2", "r3c3", "size", "sort", "quicksort", "vals", "spliceVoid", "get_viseme_count", "cachedKey", "getEnumName", "createEnumIndex", "createEnum", "parseRec", "next_blink_time", "concatNative", "nBuckets", "className", "__unsafe_get", "__unsafe_set", "indexOf", "lookup", "fileName", "toDynamic", "toFloatArray", "blink_status", "readByte", "allEnums", "is_speaking", "ramp_down_speed", "customParams", "getVisemes", "__get", "__set", "PHONEMES_MAP", "inverted", "lineNumber", "subtract", "upperBound", "unshift", "set_r0c0", "set_r0c1", "set_r0c2", "set_r0c3", "set_r1c0", "set_r1c1", "set_r1c2", "set_r1c3", "set_r2c0", "set_r2c1", "set_r2c2", "set_r2c3", "set_r3c0", "set_r3c1", "set_r3c2", "set_r3c3", "_keys", "set_a", "set_b", "set_g", "set_i", "set_j", "set_r", "enumParameters", "position_tts", "shift", "reason", "slice"};
		
		protected static int length;
		
		public static void addFields(int[] nids, string[] nfields) {
			unchecked {
				int[] cids = global::haxe.lang.FieldLookup.fieldIds;
				string[] cfields = global::haxe.lang.FieldLookup.fields;
				int nlen = ( nids as global::System.Array ).Length;
				int clen = global::haxe.lang.FieldLookup.length;
				if (( ( nfields as global::System.Array ).Length != nlen )) {
					throw global::haxe.lang.HaxeException.wrap(global::haxe.lang.Runtime.concat(global::haxe.lang.Runtime.concat(global::haxe.lang.Runtime.concat("Different fields length: ", global::haxe.lang.Runtime.toString(nlen)), " and "), global::haxe.lang.Runtime.toString(( nfields as global::System.Array ).Length)));
				}
				
				bool needsChange = false;
				{
					uint _g_idx = default(uint);
					int[] _g_arr = nids;
					_g_idx = ((uint) (0) );
					while (((bool) (( _g_idx < ( _g_arr as global::System.Array ).Length )) )) {
						int i = ((int) (_g_arr[((int) (_g_idx++) )]) );
						if (( global::haxe.lang.FieldLookup.findHash(i, cids, clen) < 0 )) {
							needsChange = true;
							break;
						}
						
					}
					
				}
				
				if (needsChange) {
					lock(typeof(global::haxe.lang.FieldLookup)){
						int[] ansIds = new int[( clen + nlen )];
						string[] ansFields = new string[( clen + nlen )];
						int ci = 0;
						int ni = 0;
						int ansi = 0;
						while (true) {
							if ( ! ((( (( ci < clen )) ? (( ni < nlen )) : (false) ))) ) {
								break;
							}
							
							if (( cids[ci] < nids[ni] )) {
								ansIds[ansi] = cids[ci];
								ansFields[ansi] = cfields[ci];
								ci = ( ci + 1 );
							}
							else {
								ansIds[ansi] = nids[ni];
								ansFields[ansi] = nfields[ni];
								ni = ( ni + 1 );
							}
							
							ansi = ( ansi + 1 );
						}
						
						if (( ci < clen )) {
							global::System.Array.Copy(((global::System.Array) (cids) ), ((int) (ci) ), ((global::System.Array) (ansIds) ), ((int) (ansi) ), ((int) (( clen - ci )) ));
							global::System.Array.Copy(((global::System.Array) (cfields) ), ((int) (ci) ), ((global::System.Array) (ansFields) ), ((int) (ansi) ), ((int) (( clen - ci )) ));
							ansi = ( ansi + (( clen - ci )) );
						}
						
						if (( ni < nlen )) {
							global::System.Array.Copy(((global::System.Array) (nids) ), ((int) (ni) ), ((global::System.Array) (ansIds) ), ((int) (ansi) ), ((int) (( nlen - ni )) ));
							global::System.Array.Copy(((global::System.Array) (nfields) ), ((int) (ni) ), ((global::System.Array) (ansFields) ), ((int) (ansi) ), ((int) (( nlen - ni )) ));
							ansi = ( ansi + (( nlen - ni )) );
						}
						
						global::haxe.lang.FieldLookup.fieldIds = ansIds;
						global::haxe.lang.FieldLookup.fields = ansFields;
						global::haxe.lang.FieldLookup.length = ansi;
					}
					;
				}
				
			}
		}
		
		
		public static int doHash(string s) {
			unchecked {
				int acc = 0;
				{
					int _g1 = 0;
					int _g = s.Length;
					while (( _g1 < _g )) {
						int i = _g1++;
						acc = ( ( ( 223 * (( acc >> 1 )) ) + ((int) (s[i]) ) ) << 1 );
					}
					
				}
				
				return ((int) (( ((uint) (acc) ) >> 1 )) );
			}
		}
		
		
		public static string lookupHash(int key) {
			unchecked {
				int[] ids = global::haxe.lang.FieldLookup.fieldIds;
				int min = 0;
				int max = global::haxe.lang.FieldLookup.length;
				while (( min < max )) {
					int mid = ( min + ( (( max - min )) / 2 ) );
					int imid = ids[mid];
					if (( key < imid )) {
						max = mid;
					}
					else if (( key > imid )) {
						min = ( mid + 1 );
					}
					else {
						return global::haxe.lang.FieldLookup.fields[mid];
					}
					
				}
				
				throw global::haxe.lang.HaxeException.wrap(global::haxe.lang.Runtime.concat("Field not found for hash ", global::haxe.lang.Runtime.toString(key)));
			}
		}
		
		
		public static int hash(string s) {
			unchecked {
				if (string.Equals(s, null)) {
					return 0;
				}
				
				int acc = 0;
				{
					int _g1 = 0;
					int _g = s.Length;
					while (( _g1 < _g )) {
						int i = _g1++;
						acc = ( ( ( 223 * (( acc >> 1 )) ) + ((int) (s[i]) ) ) << 1 );
					}
					
				}
				
				int key = ((int) (( ((uint) (acc) ) >> 1 )) );
				int[] ids = global::haxe.lang.FieldLookup.fieldIds;
				string[] fld = global::haxe.lang.FieldLookup.fields;
				int min = 0;
				int max = global::haxe.lang.FieldLookup.length;
				int len = global::haxe.lang.FieldLookup.length;
				while (( min < max )) {
					int mid = ((int) (( min + ( ((double) ((( max - min ))) ) / 2 ) )) );
					int imid = ids[mid];
					if (( key < imid )) {
						max = mid;
					}
					else if (( key > imid )) {
						min = ( mid + 1 );
					}
					else {
						string field = fld[mid];
						if ( ! (string.Equals(field, s)) ) {
							return  ~ (key) ;
						}
						
						return key;
					}
					
				}
				
				lock(typeof(global::haxe.lang.FieldLookup)){
					if (( len != global::haxe.lang.FieldLookup.length )) {
						return global::haxe.lang.FieldLookup.hash(s);
					}
					
					global::haxe.lang.FieldLookup.insert<int>(ref global::haxe.lang.FieldLookup.fieldIds, ((int) (global::haxe.lang.FieldLookup.length) ), ((int) (min) ), ((int) (key) ));
					global::haxe.lang.FieldLookup.insert<string>(ref global::haxe.lang.FieldLookup.fields, ((int) (global::haxe.lang.FieldLookup.length) ), ((int) (min) ), ((string) (s) ));
					 ++ global::haxe.lang.FieldLookup.length;
				}
				;
				return key;
			}
		}
		
		
		public static int findHash(int hash, int[] hashs, int length) {
			unchecked {
				int min = 0;
				int max = length;
				while (( min < max )) {
					int mid = ( (( max + min )) / 2 );
					int imid = hashs[mid];
					if (( hash < imid )) {
						max = mid;
					}
					else if (( hash > imid )) {
						min = ( mid + 1 );
					}
					else {
						return mid;
					}
					
				}
				
				return  ~ (min) ;
			}
		}
		
		
		public static void @remove<T>(T[] a, int length, int pos) {
			unchecked {
				global::System.Array.Copy(((global::System.Array) (a) ), ((int) (( pos + 1 )) ), ((global::System.Array) (a) ), ((int) (pos) ), ((int) (( ( length - pos ) - 1 )) ));
				a[( length - 1 )] = default(T);
			}
		}
		
		
		public static void insert<T>(ref T[] a, int length, int pos, T x) {
			unchecked {
				int capacity = ( a as global::System.Array ).Length;
				if (( pos == length )) {
					if (( capacity == length )) {
						T[] newarr = new T[( (( length << 1 )) + 1 )];
						( a as global::System.Array ).CopyTo(((global::System.Array) (newarr) ), ((int) (0) ));
						a = ((T[]) (newarr) );
					}
					
				}
				else if (( pos == 0 )) {
					if (( capacity == length )) {
						T[] newarr1 = new T[( (( length << 1 )) + 1 )];
						global::System.Array.Copy(((global::System.Array) (a) ), ((int) (0) ), ((global::System.Array) (newarr1) ), ((int) (1) ), ((int) (length) ));
						a = ((T[]) (newarr1) );
					}
					else {
						global::System.Array.Copy(((global::System.Array) (a) ), ((int) (0) ), ((global::System.Array) (a) ), ((int) (1) ), ((int) (length) ));
					}
					
				}
				else if (( capacity == length )) {
					T[] newarr2 = new T[( (( length << 1 )) + 1 )];
					global::System.Array.Copy(((global::System.Array) (a) ), ((int) (0) ), ((global::System.Array) (newarr2) ), ((int) (0) ), ((int) (pos) ));
					global::System.Array.Copy(((global::System.Array) (a) ), ((int) (pos) ), ((global::System.Array) (newarr2) ), ((int) (( pos + 1 )) ), ((int) (( length - pos )) ));
					a = ((T[]) (newarr2) );
				}
				else {
					global::System.Array.Copy(((global::System.Array) (a) ), ((int) (pos) ), ((global::System.Array) (a) ), ((int) (( pos + 1 )) ), ((int) (( length - pos )) ));
					global::System.Array.Copy(((global::System.Array) (a) ), ((int) (0) ), ((global::System.Array) (a) ), ((int) (0) ), ((int) (pos) ));
				}
				
				a[pos] = x;
			}
		}
		
		
		public static global::haxe.lang.FieldHashConflict getHashConflict(global::haxe.lang.FieldHashConflict head, int hash, string name) {
			while (( head != null )) {
				if (( ( head.hash == hash ) && string.Equals(head.name, name) )) {
					return head;
				}
				
				head = head.next;
			}
			
			return null;
		}
		
		
		public static void setHashConflict(ref global::haxe.lang.FieldHashConflict head, int hash, string name, object @value) {
			global::haxe.lang.FieldHashConflict node = head;
			while (( node != null )) {
				if (( ( node.hash == hash ) && string.Equals(node.name, name) )) {
					node.@value = @value;
					return;
				}
				
				node = ((global::haxe.lang.FieldHashConflict) (node.next) );
			}
			
			head = ((global::haxe.lang.FieldHashConflict) (new global::haxe.lang.FieldHashConflict(hash, name, @value, ((global::haxe.lang.FieldHashConflict) (head) ))) );
		}
		
		
		public static bool deleteHashConflict(ref global::haxe.lang.FieldHashConflict head, int hash, string name) {
			if (( head == null )) {
				return false;
			}
			
			if (( ( head.hash == hash ) && string.Equals(head.name, name) )) {
				head = ((global::haxe.lang.FieldHashConflict) (head.next) );
				return true;
			}
			
			global::haxe.lang.FieldHashConflict prev = head;
			global::haxe.lang.FieldHashConflict node = head.next;
			while (( node != null )) {
				if (( ( node.hash == hash ) && string.Equals(node.name, name) )) {
					prev.next = node.next;
					return true;
				}
				
				node = node.next;
			}
			
			return false;
		}
		
		
		public static void addHashConflictNames(global::haxe.lang.FieldHashConflict head, global::haxe.root.Array<object> arr) {
			while (( head != null )) {
				arr.push(head.name);
				head = head.next;
			}
			
		}
		
		
	}
}



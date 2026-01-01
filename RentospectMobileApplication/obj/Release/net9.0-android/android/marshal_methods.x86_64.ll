; ModuleID = 'marshal_methods.x86_64.ll'
source_filename = "marshal_methods.x86_64.ll"
target datalayout = "e-m:e-p270:32:32-p271:32:32-p272:64:64-i64:64-f80:128-n8:16:32:64-S128"
target triple = "x86_64-unknown-linux-android21"

%struct.MarshalMethodName = type {
	i64, ; uint64_t id
	ptr ; char* name
}

%struct.MarshalMethodsManagedClass = type {
	i32, ; uint32_t token
	ptr ; MonoClass klass
}

@assembly_image_cache = dso_local local_unnamed_addr global [172 x ptr] zeroinitializer, align 16

; Each entry maps hash of an assembly name to an index into the `assembly_image_cache` array
@assembly_image_cache_hashes = dso_local local_unnamed_addr constant [516 x i64] [
	i64 u0x001e58127c546039, ; 0: lib_System.Globalization.dll.so => 119
	i64 u0x0071cf2d27b7d61e, ; 1: lib_Xamarin.AndroidX.SwipeRefreshLayout.dll.so => 92
	i64 u0x00b3aadb3a4c4038, ; 2: lib_Refit.dll.so => 62
	i64 u0x01109b0e4d99e61f, ; 3: System.ComponentModel.Annotations.dll => 107
	i64 u0x02123411c4e01926, ; 4: lib_Xamarin.AndroidX.Navigation.Runtime.dll.so => 87
	i64 u0x022e81ea9c46e03a, ; 5: lib_CommunityToolkit.Maui.Core.dll.so => 37
	i64 u0x02abedc11addc1ed, ; 6: lib_Mono.Android.Runtime.dll.so => 170
	i64 u0x032267b2a94db371, ; 7: lib_Xamarin.AndroidX.AppCompat.dll.so => 70
	i64 u0x0363ac97a4cb84e6, ; 8: SQLitePCLRaw.provider.e_sqlite3.dll => 68
	i64 u0x03c4743d1c68b959, ; 9: CommonServiceLocator.dll => 35
	i64 u0x043032f1d071fae0, ; 10: ru/Microsoft.Maui.Controls.resources => 24
	i64 u0x044440a55165631e, ; 11: lib-cs-Microsoft.Maui.Controls.resources.dll.so => 2
	i64 u0x046eb1581a80c6b0, ; 12: vi/Microsoft.Maui.Controls.resources => 30
	i64 u0x0517ef04e06e9f76, ; 13: System.Net.Primitives => 130
	i64 u0x0565d18c6da3de38, ; 14: Xamarin.AndroidX.RecyclerView => 89
	i64 u0x0581db89237110e9, ; 15: lib_System.Collections.dll.so => 106
	i64 u0x05989cb940b225a9, ; 16: Microsoft.Maui.dll => 55
	i64 u0x06076b5d2b581f08, ; 17: zh-HK/Microsoft.Maui.Controls.resources => 31
	i64 u0x06388ffe9f6c161a, ; 18: System.Xml.Linq.dll => 162
	i64 u0x0680a433c781bb3d, ; 19: Xamarin.AndroidX.Collection.Jvm => 73
	i64 u0x07469f2eecce9e85, ; 20: mscorlib.dll => 166
	i64 u0x07c57877c7ba78ad, ; 21: ru/Microsoft.Maui.Controls.resources.dll => 24
	i64 u0x07dcdc7460a0c5e4, ; 22: System.Collections.NonGeneric => 104
	i64 u0x08a7c865576bbde7, ; 23: System.Reflection.Primitives => 139
	i64 u0x08f3c9788ee2153c, ; 24: Xamarin.AndroidX.DrawerLayout => 78
	i64 u0x09138715c92dba90, ; 25: lib_System.ComponentModel.Annotations.dll.so => 107
	i64 u0x0919c28b89381a0b, ; 26: lib_Microsoft.Extensions.Options.dll.so => 51
	i64 u0x092266563089ae3e, ; 27: lib_System.Collections.NonGeneric.dll.so => 104
	i64 u0x09d144a7e214d457, ; 28: System.Security.Cryptography => 151
	i64 u0x09dbaa7976e41105, ; 29: GalaSoft.MvvmLight.Platform.dll => 60
	i64 u0x09e2b9f743db21a8, ; 30: lib_System.Reflection.Metadata.dll.so => 138
	i64 u0x0b3b632c3bbee20c, ; 31: sk/Microsoft.Maui.Controls.resources => 25
	i64 u0x0b6aff547b84fbe9, ; 32: Xamarin.KotlinX.Serialization.Core.Jvm => 99
	i64 u0x0be2e1f8ce4064ed, ; 33: Xamarin.AndroidX.ViewPager => 93
	i64 u0x0c3ca6cc978e2aae, ; 34: pt-BR/Microsoft.Maui.Controls.resources => 21
	i64 u0x0c59ad9fbbd43abe, ; 35: Mono.Android => 171
	i64 u0x0c7790f60165fc06, ; 36: lib_Microsoft.Maui.Essentials.dll.so => 56
	i64 u0x0cce4bce83380b7f, ; 37: Xamarin.AndroidX.Security.SecurityCrypto => 91
	i64 u0x0e4c998d04592fe0, ; 38: GalaSoft.MvvmLight.Extras => 59
	i64 u0x0eb936af36ee296b, ; 39: RentospectMobileApplication.dll => 101
	i64 u0x102a31b45304b1da, ; 40: Xamarin.AndroidX.CustomView => 77
	i64 u0x105b053cfbaba1f0, ; 41: lib_Microsoft.CodeAnalysis.dll.so => 39
	i64 u0x10a579e648829775, ; 42: Microsoft.CodeAnalysis => 39
	i64 u0x10f6cfcbcf801616, ; 43: System.IO.Compression.Brotli => 120
	i64 u0x125b7f94acb989db, ; 44: Xamarin.AndroidX.RecyclerView.dll => 89
	i64 u0x12986187c41521fc, ; 45: RentospectShared.dll => 100
	i64 u0x13a01de0cbc3f06c, ; 46: lib-fr-Microsoft.Maui.Controls.resources.dll.so => 8
	i64 u0x13f1e5e209e91af4, ; 47: lib_Java.Interop.dll.so => 169
	i64 u0x13f1e880c25d96d1, ; 48: he/Microsoft.Maui.Controls.resources => 9
	i64 u0x143d8ea60a6a4011, ; 49: Microsoft.Extensions.DependencyInjection.Abstractions => 45
	i64 u0x16b6a9587f4bc19e, ; 50: lib_RentospectShared.dll.so => 100
	i64 u0x16eeae54c7ebcc08, ; 51: System.Reflection.dll => 141
	i64 u0x17125c9a85b4929f, ; 52: lib_netstandard.dll.so => 167
	i64 u0x1752c12f1e1fc00c, ; 53: System.Core => 112
	i64 u0x17b56e25558a5d36, ; 54: lib-hu-Microsoft.Maui.Controls.resources.dll.so => 12
	i64 u0x17f9358913beb16a, ; 55: System.Text.Encodings.Web => 154
	i64 u0x1809fb23f29ba44a, ; 56: lib_System.Reflection.TypeExtensions.dll.so => 140
	i64 u0x18402a709e357f3b, ; 57: lib_Xamarin.KotlinX.Serialization.Core.Jvm.dll.so => 99
	i64 u0x18f0ce884e87d89a, ; 58: nb/Microsoft.Maui.Controls.resources.dll => 18
	i64 u0x18facb3695ca9224, ; 59: Refit.HttpClientFactory => 63
	i64 u0x19a4c090f14ebb66, ; 60: System.Security.Claims => 150
	i64 u0x1a91866a319e9259, ; 61: lib_System.Collections.Concurrent.dll.so => 102
	i64 u0x1aac34d1917ba5d3, ; 62: lib_System.dll.so => 165
	i64 u0x1aad60783ffa3e5b, ; 63: lib-th-Microsoft.Maui.Controls.resources.dll.so => 27
	i64 u0x1c292b1598348d77, ; 64: Microsoft.Extensions.Diagnostics.dll => 46
	i64 u0x1c753b5ff15bce1b, ; 65: Mono.Android.Runtime.dll => 170
	i64 u0x1cd47467799d8250, ; 66: System.Threading.Tasks.dll => 158
	i64 u0x1da4110562816681, ; 67: Xamarin.AndroidX.Security.SecurityCrypto.dll => 91
	i64 u0x1e3d87657e9659bc, ; 68: Xamarin.AndroidX.Navigation.UI => 88
	i64 u0x1e71143913d56c10, ; 69: lib-ko-Microsoft.Maui.Controls.resources.dll.so => 16
	i64 u0x1e7c31185e2fb266, ; 70: lib_System.Threading.Tasks.Parallel.dll.so => 157
	i64 u0x1ed8fcce5e9b50a0, ; 71: Microsoft.Extensions.Options.dll => 51
	i64 u0x209375905fcc1bad, ; 72: lib_System.IO.Compression.Brotli.dll.so => 120
	i64 u0x2110167c128cba15, ; 73: System.Globalization => 119
	i64 u0x2174319c0d835bc9, ; 74: System.Runtime => 149
	i64 u0x220fd4f2e7c48170, ; 75: th/Microsoft.Maui.Controls.resources => 27
	i64 u0x237be844f1f812c7, ; 76: System.Threading.Thread.dll => 159
	i64 u0x23852b3bdc9f7096, ; 77: System.Resources.ResourceManager => 142
	i64 u0x2407aef2bbe8fadf, ; 78: System.Console => 111
	i64 u0x240abe014b27e7d3, ; 79: Xamarin.AndroidX.Core.dll => 75
	i64 u0x247619fe4413f8bf, ; 80: System.Runtime.Serialization.Primitives.dll => 148
	i64 u0x252073cc3caa62c2, ; 81: fr/Microsoft.Maui.Controls.resources.dll => 8
	i64 u0x256b8d41255f01b1, ; 82: Xamarin.Google.Crypto.Tink.Android => 96
	i64 u0x25a0a7eff76ea08e, ; 83: SQLitePCLRaw.batteries_v2.dll => 65
	i64 u0x2662c629b96b0b30, ; 84: lib_Xamarin.Kotlin.StdLib.dll.so => 97
	i64 u0x268c1439f13bcc29, ; 85: lib_Microsoft.Extensions.Primitives.dll.so => 52
	i64 u0x26a670e154a9c54b, ; 86: System.Reflection.Extensions.dll => 137
	i64 u0x26d077d9678fe34f, ; 87: System.IO.dll => 124
	i64 u0x273f3515de5faf0d, ; 88: id/Microsoft.Maui.Controls.resources.dll => 13
	i64 u0x2742545f9094896d, ; 89: hr/Microsoft.Maui.Controls.resources => 11
	i64 u0x27b2b16f3e9de038, ; 90: Xamarin.Google.Crypto.Tink.Android.dll => 96
	i64 u0x27b410442fad6cf1, ; 91: Java.Interop.dll => 169
	i64 u0x27b97e0d52c3034a, ; 92: System.Diagnostics.Debug => 113
	i64 u0x2801845a2c71fbfb, ; 93: System.Net.Primitives.dll => 130
	i64 u0x288f0dc6b8b36b5f, ; 94: Refit.dll => 62
	i64 u0x28a793c4ba1c857d, ; 95: RentospectShared => 100
	i64 u0x28e52865585a1ebe, ; 96: Microsoft.Extensions.Diagnostics.Abstractions.dll => 47
	i64 u0x2a128783efe70ba0, ; 97: uk/Microsoft.Maui.Controls.resources.dll => 29
	i64 u0x2a6507a5ffabdf28, ; 98: System.Diagnostics.TraceSource.dll => 116
	i64 u0x2ad156c8e1354139, ; 99: fi/Microsoft.Maui.Controls.resources => 7
	i64 u0x2af298f63581d886, ; 100: System.Text.RegularExpressions.dll => 156
	i64 u0x2afc1c4f898552ee, ; 101: lib_System.Formats.Asn1.dll.so => 118
	i64 u0x2b148910ed40fbf9, ; 102: zh-Hant/Microsoft.Maui.Controls.resources.dll => 33
	i64 u0x2c8bd14bb93a7d82, ; 103: lib-pl-Microsoft.Maui.Controls.resources.dll.so => 20
	i64 u0x2cd723e9fe623c7c, ; 104: lib_System.Private.Xml.Linq.dll.so => 135
	i64 u0x2d169d318a968379, ; 105: System.Threading.dll => 160
	i64 u0x2d47774b7d993f59, ; 106: sv/Microsoft.Maui.Controls.resources.dll => 26
	i64 u0x2db915caf23548d2, ; 107: System.Text.Json.dll => 155
	i64 u0x2e6f1f226821322a, ; 108: el/Microsoft.Maui.Controls.resources.dll => 5
	i64 u0x2f2e98e1c89b1aff, ; 109: System.Xml.ReaderWriter => 163
	i64 u0x2ff49de6a71764a1, ; 110: lib_Microsoft.Extensions.Http.dll.so => 48
	i64 u0x309ee9eeec09a71e, ; 111: lib_Xamarin.AndroidX.Fragment.dll.so => 79
	i64 u0x31195fef5d8fb552, ; 112: _Microsoft.Android.Resource.Designer.dll => 34
	i64 u0x32243413e774362a, ; 113: Xamarin.AndroidX.CardView.dll => 72
	i64 u0x324972b7bc4ebe64, ; 114: lib_GalaSoft.MvvmLight.Platform.dll.so => 60
	i64 u0x329753a17a517811, ; 115: fr/Microsoft.Maui.Controls.resources => 8
	i64 u0x32aa989ff07a84ff, ; 116: lib_System.Xml.ReaderWriter.dll.so => 163
	i64 u0x33829542f112d59b, ; 117: System.Collections.Immutable => 103
	i64 u0x33a31443733849fe, ; 118: lib-es-Microsoft.Maui.Controls.resources.dll.so => 6
	i64 u0x34dfd74fe2afcf37, ; 119: Microsoft.Maui => 55
	i64 u0x34e292762d9615df, ; 120: cs/Microsoft.Maui.Controls.resources.dll => 2
	i64 u0x3508234247f48404, ; 121: Microsoft.Maui.Controls => 53
	i64 u0x353590da528c9d22, ; 122: System.ComponentModel.Annotations => 107
	i64 u0x3549870798b4cd30, ; 123: lib_Xamarin.AndroidX.ViewPager2.dll.so => 94
	i64 u0x355282fc1c909694, ; 124: Microsoft.Extensions.Configuration => 42
	i64 u0x3628ab68db23a01a, ; 125: lib_System.Diagnostics.Tools.dll.so => 115
	i64 u0x3673b042508f5b6b, ; 126: lib_System.Runtime.Extensions.dll.so => 143
	i64 u0x36cada77dc79928b, ; 127: System.IO.MemoryMappedFiles => 122
	i64 u0x374ef46b06791af6, ; 128: System.Reflection.Primitives.dll => 139
	i64 u0x37bc29f3183003b6, ; 129: lib_System.IO.dll.so => 124
	i64 u0x380134e03b1e160a, ; 130: System.Collections.Immutable.dll => 103
	i64 u0x385c17636bb6fe6e, ; 131: Xamarin.AndroidX.CustomView.dll => 77
	i64 u0x393c226616977fdb, ; 132: lib_Xamarin.AndroidX.ViewPager.dll.so => 93
	i64 u0x395e37c3334cf82a, ; 133: lib-ca-Microsoft.Maui.Controls.resources.dll.so => 1
	i64 u0x3a8975149c2ab9de, ; 134: GalaSoft.MvvmLight.dll => 61
	i64 u0x3b860f9932505633, ; 135: lib_System.Text.Encoding.Extensions.dll.so => 152
	i64 u0x3c7c495f58ac5ee9, ; 136: Xamarin.Kotlin.StdLib => 97
	i64 u0x3d46f0b995082740, ; 137: System.Xml.Linq => 162
	i64 u0x3d9c2a242b040a50, ; 138: lib_Xamarin.AndroidX.Core.dll.so => 75
	i64 u0x3da7781d6333a8fe, ; 139: SQLitePCLRaw.batteries_v2 => 65
	i64 u0x3e57d4d195c53c2e, ; 140: System.Reflection.TypeExtensions => 140
	i64 u0x407a10bb4bf95829, ; 141: lib_Xamarin.AndroidX.Navigation.Common.dll.so => 85
	i64 u0x40c98b6bd77346d4, ; 142: Microsoft.VisualBasic.dll => 58
	i64 u0x41833cf766d27d96, ; 143: mscorlib => 166
	i64 u0x41cab042be111c34, ; 144: lib_Xamarin.AndroidX.AppCompat.AppCompatResources.dll.so => 71
	i64 u0x423a9ecc4d905a88, ; 145: lib_System.Resources.ResourceManager.dll.so => 142
	i64 u0x43375950ec7c1b6a, ; 146: netstandard.dll => 167
	i64 u0x434c4e1d9284cdae, ; 147: Mono.Android.dll => 171
	i64 u0x437d06c381ed575a, ; 148: lib_Microsoft.VisualBasic.dll.so => 58
	i64 u0x43950f84de7cc79a, ; 149: pl/Microsoft.Maui.Controls.resources.dll => 20
	i64 u0x4499fa3c8e494654, ; 150: lib_System.Runtime.Serialization.Primitives.dll.so => 148
	i64 u0x4515080865a951a5, ; 151: Xamarin.Kotlin.StdLib.dll => 97
	i64 u0x45b443c996872a73, ; 152: GalaSoft.MvvmLight.Platform => 60
	i64 u0x45c40276a42e283e, ; 153: System.Diagnostics.TraceSource => 116
	i64 u0x46a4213bc97fe5ae, ; 154: lib-ru-Microsoft.Maui.Controls.resources.dll.so => 24
	i64 u0x47358bd471172e1d, ; 155: lib_System.Xml.Linq.dll.so => 162
	i64 u0x47daf4e1afbada10, ; 156: pt/Microsoft.Maui.Controls.resources => 22
	i64 u0x480c0a47dd42dd81, ; 157: lib_System.IO.MemoryMappedFiles.dll.so => 122
	i64 u0x49e952f19a4e2022, ; 158: System.ObjectModel => 133
	i64 u0x4a5667b2462a664b, ; 159: lib_Xamarin.AndroidX.Navigation.UI.dll.so => 88
	i64 u0x4b07a0ed0ab33ff4, ; 160: System.Runtime.Extensions.dll => 143
	i64 u0x4b7b6532ded934b7, ; 161: System.Text.Json => 155
	i64 u0x4c7755cf07ad2d5f, ; 162: System.Net.Http.Json.dll => 128
	i64 u0x4cc5f15266470798, ; 163: lib_Xamarin.AndroidX.Loader.dll.so => 84
	i64 u0x4d479f968a05e504, ; 164: System.Linq.Expressions.dll => 125
	i64 u0x4d55a010ffc4faff, ; 165: System.Private.Xml => 136
	i64 u0x4d95fccc1f67c7ca, ; 166: System.Runtime.Loader.dll => 146
	i64 u0x4dcf44c3c9b076a2, ; 167: it/Microsoft.Maui.Controls.resources.dll => 14
	i64 u0x4dd9247f1d2c3235, ; 168: Xamarin.AndroidX.Loader.dll => 84
	i64 u0x4e32f00cb0937401, ; 169: Mono.Android.Runtime => 170
	i64 u0x4f21ee6ef9eb527e, ; 170: ca/Microsoft.Maui.Controls.resources => 1
	i64 u0x4fd5f3ee53d0a4f0, ; 171: SQLitePCLRaw.lib.e_sqlite3.android => 67
	i64 u0x5037f0be3c28c7a3, ; 172: lib_Microsoft.Maui.Controls.dll.so => 53
	i64 u0x5112ed116d87baf8, ; 173: CommunityToolkit.Mvvm => 38
	i64 u0x5131bbe80989093f, ; 174: Xamarin.AndroidX.Lifecycle.ViewModel.Android.dll => 82
	i64 u0x51b504c7121b6136, ; 175: lib_Microsoft.CodeAnalysis.VisualBasic.dll.so => 41
	i64 u0x526ce79eb8e90527, ; 176: lib_System.Net.Primitives.dll.so => 130
	i64 u0x529ffe06f39ab8db, ; 177: Xamarin.AndroidX.Core => 75
	i64 u0x52ff996554dbf352, ; 178: Microsoft.Maui.Graphics => 57
	i64 u0x535f7e40e8fef8af, ; 179: lib-sk-Microsoft.Maui.Controls.resources.dll.so => 25
	i64 u0x53be1038a61e8d44, ; 180: System.Runtime.InteropServices.RuntimeInformation.dll => 144
	i64 u0x53c3014b9437e684, ; 181: lib-zh-HK-Microsoft.Maui.Controls.resources.dll.so => 31
	i64 u0x5435e6f049e9bc37, ; 182: System.Security.Claims.dll => 150
	i64 u0x54795225dd1587af, ; 183: lib_System.Runtime.dll.so => 149
	i64 u0x556e8b63b660ab8b, ; 184: Xamarin.AndroidX.Lifecycle.Common.Jvm.dll => 80
	i64 u0x5588627c9a108ec9, ; 185: System.Collections.Specialized => 105
	i64 u0x571c5cfbec5ae8e2, ; 186: System.Private.Uri => 134
	i64 u0x578cd35c91d7b347, ; 187: lib_SQLitePCLRaw.core.dll.so => 66
	i64 u0x579a06fed6eec900, ; 188: System.Private.CoreLib.dll => 168
	i64 u0x57c542c14049b66d, ; 189: System.Diagnostics.DiagnosticSource => 114
	i64 u0x58601b2dda4a27b9, ; 190: lib-ja-Microsoft.Maui.Controls.resources.dll.so => 15
	i64 u0x58688d9af496b168, ; 191: Microsoft.Extensions.DependencyInjection.dll => 44
	i64 u0x5a89a886ae30258d, ; 192: lib_Xamarin.AndroidX.CoordinatorLayout.dll.so => 74
	i64 u0x5a8f6699f4a1caa9, ; 193: lib_System.Threading.dll.so => 160
	i64 u0x5ae9cd33b15841bf, ; 194: System.ComponentModel => 110
	i64 u0x5b5f0e240a06a2a2, ; 195: da/Microsoft.Maui.Controls.resources.dll => 3
	i64 u0x5c30a4a35f9cc8c4, ; 196: lib_System.Reflection.Extensions.dll.so => 137
	i64 u0x5c393624b8176517, ; 197: lib_Microsoft.Extensions.Logging.dll.so => 49
	i64 u0x5d7ec76c1c703055, ; 198: System.Threading.Tasks.Parallel => 157
	i64 u0x5db0cbbd1028510e, ; 199: lib_System.Runtime.InteropServices.dll.so => 145
	i64 u0x5db30905d3e5013b, ; 200: Xamarin.AndroidX.Collection.Jvm.dll => 73
	i64 u0x5e467bc8f09ad026, ; 201: System.Collections.Specialized.dll => 105
	i64 u0x5ea92fdb19ec8c4c, ; 202: System.Text.Encodings.Web.dll => 154
	i64 u0x5eb8046dd40e9ac3, ; 203: System.ComponentModel.Primitives => 108
	i64 u0x5f36ccf5c6a57e24, ; 204: System.Xml.ReaderWriter.dll => 163
	i64 u0x5f7399e166075632, ; 205: lib_SQLitePCLRaw.lib.e_sqlite3.android.dll.so => 67
	i64 u0x5f9a2d823f664957, ; 206: lib-el-Microsoft.Maui.Controls.resources.dll.so => 5
	i64 u0x609f4b7b63d802d4, ; 207: lib_Microsoft.Extensions.DependencyInjection.dll.so => 44
	i64 u0x60cd4e33d7e60134, ; 208: Xamarin.KotlinX.Coroutines.Core.Jvm => 98
	i64 u0x60f62d786afcf130, ; 209: System.Memory => 127
	i64 u0x61bb78c89f867353, ; 210: System.IO => 124
	i64 u0x61be8d1299194243, ; 211: Microsoft.Maui.Controls.Xaml => 54
	i64 u0x61d2cba29557038f, ; 212: de/Microsoft.Maui.Controls.resources => 4
	i64 u0x61d88f399afb2f45, ; 213: lib_System.Runtime.Loader.dll.so => 146
	i64 u0x62169ead292eda39, ; 214: lib_GalaSoft.MvvmLight.Extras.dll.so => 59
	i64 u0x622eef6f9e59068d, ; 215: System.Private.CoreLib => 168
	i64 u0x63f1f6883c1e23c2, ; 216: lib_System.Collections.Immutable.dll.so => 103
	i64 u0x6400f68068c1e9f1, ; 217: Xamarin.Google.Android.Material.dll => 95
	i64 u0x64587004560099b9, ; 218: System.Reflection => 141
	i64 u0x658f524e4aba7dad, ; 219: CommunityToolkit.Maui.dll => 36
	i64 u0x659dc45417570048, ; 220: Refit => 62
	i64 u0x65ecac39144dd3cc, ; 221: Microsoft.Maui.Controls.dll => 53
	i64 u0x65ece51227bfa724, ; 222: lib_System.Runtime.Numerics.dll.so => 147
	i64 u0x6692e924eade1b29, ; 223: lib_System.Console.dll.so => 111
	i64 u0x66a4e5c6a3fb0bae, ; 224: lib_Xamarin.AndroidX.Lifecycle.ViewModel.Android.dll.so => 82
	i64 u0x66d13304ce1a3efa, ; 225: Xamarin.AndroidX.CursorAdapter => 76
	i64 u0x68558ec653afa616, ; 226: lib-da-Microsoft.Maui.Controls.resources.dll.so => 3
	i64 u0x68fbbbe2eb455198, ; 227: System.Formats.Asn1 => 118
	i64 u0x69063fc0ba8e6bdd, ; 228: he/Microsoft.Maui.Controls.resources.dll => 9
	i64 u0x699dffb2427a2d71, ; 229: SQLitePCLRaw.lib.e_sqlite3.android.dll => 67
	i64 u0x6a4d7577b2317255, ; 230: System.Runtime.InteropServices.dll => 145
	i64 u0x6abfbfb2796f4e84, ; 231: Microsoft.CodeAnalysis.CSharp => 40
	i64 u0x6ace3b74b15ee4a4, ; 232: nb/Microsoft.Maui.Controls.resources => 18
	i64 u0x6afcedb171067e2b, ; 233: System.Core.dll => 112
	i64 u0x6d12bfaa99c72b1f, ; 234: lib_Microsoft.Maui.Graphics.dll.so => 57
	i64 u0x6d79993361e10ef2, ; 235: Microsoft.Extensions.Primitives => 52
	i64 u0x6d86d56b84c8eb71, ; 236: lib_Xamarin.AndroidX.CursorAdapter.dll.so => 76
	i64 u0x6d9bea6b3e895cf7, ; 237: Microsoft.Extensions.Primitives.dll => 52
	i64 u0x6e25a02c3833319a, ; 238: lib_Xamarin.AndroidX.Navigation.Fragment.dll.so => 86
	i64 u0x6e9965ce1095e60a, ; 239: lib_System.Core.dll.so => 112
	i64 u0x6fd2265da78b93a4, ; 240: lib_Microsoft.Maui.dll.so => 55
	i64 u0x6fdfc7de82c33008, ; 241: cs/Microsoft.Maui.Controls.resources => 2
	i64 u0x70e99f48c05cb921, ; 242: tr/Microsoft.Maui.Controls.resources.dll => 28
	i64 u0x70fd3deda22442d2, ; 243: lib-nb-Microsoft.Maui.Controls.resources.dll.so => 18
	i64 u0x71485e7ffdb4b958, ; 244: System.Reflection.Extensions => 137
	i64 u0x717530326f808838, ; 245: lib_Microsoft.Extensions.Diagnostics.Abstractions.dll.so => 47
	i64 u0x71a495ea3761dde8, ; 246: lib-it-Microsoft.Maui.Controls.resources.dll.so => 14
	i64 u0x71ad672adbe48f35, ; 247: System.ComponentModel.Primitives.dll => 108
	i64 u0x72b1fb4109e08d7b, ; 248: lib-hr-Microsoft.Maui.Controls.resources.dll.so => 11
	i64 u0x73e4ce94e2eb6ffc, ; 249: lib_System.Memory.dll.so => 127
	i64 u0x746cf89b511b4d40, ; 250: lib_Microsoft.Extensions.Diagnostics.dll.so => 46
	i64 u0x755a91767330b3d4, ; 251: lib_Microsoft.Extensions.Configuration.dll.so => 42
	i64 u0x76012e7334db86e5, ; 252: lib_Xamarin.AndroidX.SavedState.dll.so => 90
	i64 u0x76ca07b878f44da0, ; 253: System.Runtime.Numerics.dll => 147
	i64 u0x780bc73597a503a9, ; 254: lib-ms-Microsoft.Maui.Controls.resources.dll.so => 17
	i64 u0x783606d1e53e7a1a, ; 255: th/Microsoft.Maui.Controls.resources.dll => 27
	i64 u0x78a45e51311409b6, ; 256: Xamarin.AndroidX.Fragment.dll => 79
	i64 u0x7996e32deaf72986, ; 257: Microsoft.CodeAnalysis.CSharp.dll => 40
	i64 u0x7a25bdb29108c6e7, ; 258: Microsoft.Extensions.Http => 48
	i64 u0x7adb8da2ac89b647, ; 259: fi/Microsoft.Maui.Controls.resources.dll => 7
	i64 u0x7bef86a4335c4870, ; 260: System.ComponentModel.TypeConverter => 109
	i64 u0x7c0820144cd34d6a, ; 261: sk/Microsoft.Maui.Controls.resources.dll => 25
	i64 u0x7c2a0bd1e0f988fc, ; 262: lib-de-Microsoft.Maui.Controls.resources.dll.so => 4
	i64 u0x7cc637f941f716d0, ; 263: CommunityToolkit.Maui.Core => 37
	i64 u0x7d649b75d580bb42, ; 264: ms/Microsoft.Maui.Controls.resources.dll => 17
	i64 u0x7d8ee2bdc8e3aad1, ; 265: System.Numerics.Vectors => 132
	i64 u0x7dd79496c6166bbf, ; 266: lib_CommonServiceLocator.dll.so => 35
	i64 u0x7dfc3d6d9d8d7b70, ; 267: System.Collections => 106
	i64 u0x7e302e110e1e1346, ; 268: lib_System.Security.Claims.dll.so => 150
	i64 u0x7e946809d6008ef2, ; 269: lib_System.ObjectModel.dll.so => 133
	i64 u0x7ecc13347c8fd849, ; 270: lib_System.ComponentModel.dll.so => 110
	i64 u0x7f00ddd9b9ca5a13, ; 271: Xamarin.AndroidX.ViewPager.dll => 93
	i64 u0x7f9351cd44b1273f, ; 272: Microsoft.Extensions.Configuration.Abstractions => 43
	i64 u0x7fbd557c99b3ce6f, ; 273: lib_Xamarin.AndroidX.Lifecycle.LiveData.Core.dll.so => 81
	i64 u0x80da183a87731838, ; 274: System.Reflection.Metadata => 138
	i64 u0x80fa55b6d1b0be99, ; 275: SQLitePCLRaw.provider.e_sqlite3 => 68
	i64 u0x812c069d5cdecc17, ; 276: System.dll => 165
	i64 u0x81ab745f6c0f5ce6, ; 277: zh-Hant/Microsoft.Maui.Controls.resources => 33
	i64 u0x8277f2be6b5ce05f, ; 278: Xamarin.AndroidX.AppCompat => 70
	i64 u0x828f06563b30bc50, ; 279: lib_Xamarin.AndroidX.CardView.dll.so => 72
	i64 u0x82f6403342e12049, ; 280: uk/Microsoft.Maui.Controls.resources => 29
	i64 u0x83144699b312ad81, ; 281: SQLite-net.dll => 64
	i64 u0x83c14ba66c8e2b8c, ; 282: zh-Hans/Microsoft.Maui.Controls.resources => 32
	i64 u0x846ce984efea52c7, ; 283: System.Threading.Tasks.Parallel.dll => 157
	i64 u0x8662aaeb94fef37f, ; 284: lib_System.Dynamic.Runtime.dll.so => 117
	i64 u0x86a909228dc7657b, ; 285: lib-zh-Hant-Microsoft.Maui.Controls.resources.dll.so => 33
	i64 u0x86b3e00c36b84509, ; 286: Microsoft.Extensions.Configuration.dll => 42
	i64 u0x87c69b87d9283884, ; 287: lib_System.Threading.Thread.dll.so => 159
	i64 u0x87f6569b25707834, ; 288: System.IO.Compression.Brotli.dll => 120
	i64 u0x8842b3a5d2d3fb36, ; 289: Microsoft.Maui.Essentials => 56
	i64 u0x88ba6bc4f7762b03, ; 290: lib_System.Reflection.dll.so => 141
	i64 u0x88bda98e0cffb7a9, ; 291: lib_Xamarin.KotlinX.Coroutines.Core.Jvm.dll.so => 98
	i64 u0x8930322c7bd8f768, ; 292: netstandard => 167
	i64 u0x897a606c9e39c75f, ; 293: lib_System.ComponentModel.Primitives.dll.so => 108
	i64 u0x89c5188089ec2cd5, ; 294: lib_System.Runtime.InteropServices.RuntimeInformation.dll.so => 144
	i64 u0x8a19e3dc71b34b2c, ; 295: System.Reflection.TypeExtensions.dll => 140
	i64 u0x8a57cc32f1ee0ee9, ; 296: lib_RentospectMobileApplication.dll.so => 101
	i64 u0x8ad229ea26432ee2, ; 297: Xamarin.AndroidX.Loader => 84
	i64 u0x8b4ff5d0fdd5faa1, ; 298: lib_System.Diagnostics.DiagnosticSource.dll.so => 114
	i64 u0x8b9ceca7acae3451, ; 299: lib-he-Microsoft.Maui.Controls.resources.dll.so => 9
	i64 u0x8bc977efb589eb64, ; 300: GalaSoft.MvvmLight.Extras.dll => 59
	i64 u0x8d0f420977c2c1c7, ; 301: Xamarin.AndroidX.CursorAdapter.dll => 76
	i64 u0x8d7b8ab4b3310ead, ; 302: System.Threading => 160
	i64 u0x8da188285aadfe8e, ; 303: System.Collections.Concurrent => 102
	i64 u0x8ed807bfe9858dfc, ; 304: Xamarin.AndroidX.Navigation.Common => 85
	i64 u0x8ee08b8194a30f48, ; 305: lib-hi-Microsoft.Maui.Controls.resources.dll.so => 10
	i64 u0x8ef7601039857a44, ; 306: lib-ro-Microsoft.Maui.Controls.resources.dll.so => 23
	i64 u0x8ef9414937d93a0a, ; 307: SQLitePCLRaw.core.dll => 66
	i64 u0x8f32c6f611f6ffab, ; 308: pt/Microsoft.Maui.Controls.resources.dll => 22
	i64 u0x8f8829d21c8985a4, ; 309: lib-pt-BR-Microsoft.Maui.Controls.resources.dll.so => 21
	i64 u0x8fbf5b0114c6dcef, ; 310: System.Globalization.dll => 119
	i64 u0x8fd27d934d7b3a55, ; 311: SQLitePCLRaw.core => 66
	i64 u0x90263f8448b8f572, ; 312: lib_System.Diagnostics.TraceSource.dll.so => 116
	i64 u0x903101b46fb73a04, ; 313: _Microsoft.Android.Resource.Designer => 34
	i64 u0x90393bd4865292f3, ; 314: lib_System.IO.Compression.dll.so => 121
	i64 u0x90634f86c5ebe2b5, ; 315: Xamarin.AndroidX.Lifecycle.ViewModel.Android => 82
	i64 u0x907b636704ad79ef, ; 316: lib_Microsoft.Maui.Controls.Xaml.dll.so => 54
	i64 u0x91418dc638b29e68, ; 317: lib_Xamarin.AndroidX.CustomView.dll.so => 77
	i64 u0x9157bd523cd7ed36, ; 318: lib_System.Text.Json.dll.so => 155
	i64 u0x91a74f07b30d37e2, ; 319: System.Linq.dll => 126
	i64 u0x91fa41a87223399f, ; 320: ca/Microsoft.Maui.Controls.resources.dll => 1
	i64 u0x93cfa73ab28d6e35, ; 321: ms/Microsoft.Maui.Controls.resources => 17
	i64 u0x944077d8ca3c6580, ; 322: System.IO.Compression.dll => 121
	i64 u0x957a4cdfdcfd6d83, ; 323: Refit.HttpClientFactory.dll => 63
	i64 u0x967fc325e09bfa8c, ; 324: es/Microsoft.Maui.Controls.resources => 6
	i64 u0x9732d8dbddea3d9a, ; 325: id/Microsoft.Maui.Controls.resources => 13
	i64 u0x978be80e5210d31b, ; 326: Microsoft.Maui.Graphics.dll => 57
	i64 u0x97b8c771ea3e4220, ; 327: System.ComponentModel.dll => 110
	i64 u0x97e144c9d3c6976e, ; 328: System.Collections.Concurrent.dll => 102
	i64 u0x982200a57f0d6bdf, ; 329: GalaSoft.MvvmLight => 61
	i64 u0x991d510397f92d9d, ; 330: System.Linq.Expressions => 125
	i64 u0x999cb19e1a04ffd3, ; 331: CommunityToolkit.Mvvm.dll => 38
	i64 u0x99a00ca5270c6878, ; 332: Xamarin.AndroidX.Navigation.Runtime => 87
	i64 u0x99cdc6d1f2d3a72f, ; 333: ko/Microsoft.Maui.Controls.resources.dll => 16
	i64 u0x9baed7b80a4ffdd1, ; 334: lib_GalaSoft.MvvmLight.dll.so => 61
	i64 u0x9d5dbcf5a48583fe, ; 335: lib_Xamarin.AndroidX.Activity.dll.so => 69
	i64 u0x9d74dee1a7725f34, ; 336: Microsoft.Extensions.Configuration.Abstractions.dll => 43
	i64 u0x9e4534b6adaf6e84, ; 337: nl/Microsoft.Maui.Controls.resources => 19
	i64 u0x9e4b95dec42769f7, ; 338: System.Diagnostics.Debug.dll => 113
	i64 u0x9eaf1efdf6f7267e, ; 339: Xamarin.AndroidX.Navigation.Common.dll => 85
	i64 u0x9ef542cf1f78c506, ; 340: Xamarin.AndroidX.Lifecycle.LiveData.Core => 81
	i64 u0xa0d8259f4cc284ec, ; 341: lib_System.Security.Cryptography.dll.so => 151
	i64 u0xa0e17ca50c77a225, ; 342: lib_Xamarin.Google.Crypto.Tink.Android.dll.so => 96
	i64 u0xa1440773ee9d341e, ; 343: Xamarin.Google.Android.Material => 95
	i64 u0xa1b9d7c27f47219f, ; 344: Xamarin.AndroidX.Navigation.UI.dll => 88
	i64 u0xa2572680829d2c7c, ; 345: System.IO.Pipelines.dll => 123
	i64 u0xa308401900e5bed3, ; 346: lib_mscorlib.dll.so => 166
	i64 u0xa3e683f24b43af6f, ; 347: System.Dynamic.Runtime.dll => 117
	i64 u0xa46aa1eaa214539b, ; 348: ko/Microsoft.Maui.Controls.resources => 16
	i64 u0xa4a372eecb9e4df0, ; 349: Microsoft.Extensions.Diagnostics => 46
	i64 u0xa4d20d2ff0563d26, ; 350: lib_CommunityToolkit.Mvvm.dll.so => 38
	i64 u0xa5e599d1e0524750, ; 351: System.Numerics.Vectors.dll => 132
	i64 u0xa5f1ba49b85dd355, ; 352: System.Security.Cryptography.dll => 151
	i64 u0xa67dbee13e1df9ca, ; 353: Xamarin.AndroidX.SavedState.dll => 90
	i64 u0xa684b098dd27b296, ; 354: lib_Xamarin.AndroidX.Security.SecurityCrypto.dll.so => 91
	i64 u0xa68a420042bb9b1f, ; 355: Xamarin.AndroidX.DrawerLayout.dll => 78
	i64 u0xa78ce3745383236a, ; 356: Xamarin.AndroidX.Lifecycle.Common.Jvm => 80
	i64 u0xa7c31b56b4dc7b33, ; 357: hu/Microsoft.Maui.Controls.resources => 12
	i64 u0xa964304b5631e28a, ; 358: CommunityToolkit.Maui.Core.dll => 37
	i64 u0xaa2219c8e3449ff5, ; 359: Microsoft.Extensions.Logging.Abstractions => 50
	i64 u0xaa443ac34067eeef, ; 360: System.Private.Xml.dll => 136
	i64 u0xaa52de307ef5d1dd, ; 361: System.Net.Http => 129
	i64 u0xaaaf86367285a918, ; 362: Microsoft.Extensions.DependencyInjection.Abstractions.dll => 45
	i64 u0xaaf84bb3f052a265, ; 363: el/Microsoft.Maui.Controls.resources => 5
	i64 u0xab9c1b2687d86b0b, ; 364: lib_System.Linq.Expressions.dll.so => 125
	i64 u0xac2af3fa195a15ce, ; 365: System.Runtime.Numerics => 147
	i64 u0xac5376a2a538dc10, ; 366: Xamarin.AndroidX.Lifecycle.LiveData.Core.dll => 81
	i64 u0xac5acae88f60357e, ; 367: System.Diagnostics.Tools.dll => 115
	i64 u0xac98d31068e24591, ; 368: System.Xml.XDocument => 164
	i64 u0xacd46e002c3ccb97, ; 369: ro/Microsoft.Maui.Controls.resources => 23
	i64 u0xad89c07347f1bad6, ; 370: nl/Microsoft.Maui.Controls.resources.dll => 19
	i64 u0xadbb53caf78a79d2, ; 371: System.Web.HttpUtility => 161
	i64 u0xadc90ab061a9e6e4, ; 372: System.ComponentModel.TypeConverter.dll => 109
	i64 u0xae282bcd03739de7, ; 373: Java.Interop => 169
	i64 u0xae53579c90db1107, ; 374: System.ObjectModel.dll => 133
	i64 u0xae7ea18c61eef394, ; 375: SQLite-net => 64
	i64 u0xafe29f45095518e7, ; 376: lib_Xamarin.AndroidX.Lifecycle.ViewModelSavedState.dll.so => 83
	i64 u0xb05cc42cd94c6d9d, ; 377: lib-sv-Microsoft.Maui.Controls.resources.dll.so => 26
	i64 u0xb220631954820169, ; 378: System.Text.RegularExpressions => 156
	i64 u0xb2a3f67f3bf29fce, ; 379: da/Microsoft.Maui.Controls.resources => 3
	i64 u0xb3f0a0fcda8d3ebc, ; 380: Xamarin.AndroidX.CardView => 72
	i64 u0xb46be1aa6d4fff93, ; 381: hi/Microsoft.Maui.Controls.resources => 10
	i64 u0xb477491be13109d8, ; 382: ar/Microsoft.Maui.Controls.resources => 0
	i64 u0xb4bd7015ecee9d86, ; 383: System.IO.Pipelines => 123
	i64 u0xb5c38bf497a4cfe2, ; 384: lib_System.Threading.Tasks.dll.so => 158
	i64 u0xb5c7fcdafbc67ee4, ; 385: Microsoft.Extensions.Logging.Abstractions.dll => 50
	i64 u0xb7b7753d1f319409, ; 386: sv/Microsoft.Maui.Controls.resources => 26
	i64 u0xb81a2c6e0aee50fe, ; 387: lib_System.Private.CoreLib.dll.so => 168
	i64 u0xb872c26142d22aa9, ; 388: Microsoft.Extensions.Http.dll => 48
	i64 u0xb9f64d3b230def68, ; 389: lib-pt-Microsoft.Maui.Controls.resources.dll.so => 22
	i64 u0xb9fc3c8a556e3691, ; 390: ja/Microsoft.Maui.Controls.resources => 15
	i64 u0xba4670aa94a2b3c6, ; 391: lib_System.Xml.XDocument.dll.so => 164
	i64 u0xba48785529705af9, ; 392: System.Collections.dll => 106
	i64 u0xbc22a245dab70cb4, ; 393: lib_SQLitePCLRaw.provider.e_sqlite3.dll.so => 68
	i64 u0xbd0e2c0d55246576, ; 394: System.Net.Http.dll => 129
	i64 u0xbd437a2cdb333d0d, ; 395: Xamarin.AndroidX.ViewPager2 => 94
	i64 u0xbee38d4a88835966, ; 396: Xamarin.AndroidX.AppCompat.AppCompatResources => 71
	i64 u0xbfc1e1fb3095f2b3, ; 397: lib_System.Net.Http.Json.dll.so => 128
	i64 u0xc040a4ab55817f58, ; 398: ar/Microsoft.Maui.Controls.resources.dll => 0
	i64 u0xc0d928351ab5ca77, ; 399: System.Console.dll => 111
	i64 u0xc0e73ff4e946af82, ; 400: Microsoft.CodeAnalysis.VisualBasic.dll => 41
	i64 u0xc12b8b3afa48329c, ; 401: lib_System.Linq.dll.so => 126
	i64 u0xc1ff9ae3cdb6e1e6, ; 402: Xamarin.AndroidX.Activity.dll => 69
	i64 u0xc28c50f32f81cc73, ; 403: ja/Microsoft.Maui.Controls.resources.dll => 15
	i64 u0xc2bcfec99f69365e, ; 404: Xamarin.AndroidX.ViewPager2.dll => 94
	i64 u0xc39ced8467203460, ; 405: lib_Refit.HttpClientFactory.dll.so => 63
	i64 u0xc4d3858ed4d08512, ; 406: Xamarin.AndroidX.Lifecycle.ViewModelSavedState.dll => 83
	i64 u0xc50fded0ded1418c, ; 407: lib_System.ComponentModel.TypeConverter.dll.so => 109
	i64 u0xc519125d6bc8fb11, ; 408: lib_System.Net.Requests.dll.so => 131
	i64 u0xc5293b19e4dc230e, ; 409: Xamarin.AndroidX.Navigation.Fragment => 86
	i64 u0xc5325b2fcb37446f, ; 410: lib_System.Private.Xml.dll.so => 136
	i64 u0xc5a0f4b95a699af7, ; 411: lib_System.Private.Uri.dll.so => 134
	i64 u0xc7aa88580f6120f0, ; 412: Microsoft.CodeAnalysis.VisualBasic => 41
	i64 u0xc7c01e7d7c93a110, ; 413: System.Text.Encoding.Extensions.dll => 152
	i64 u0xc7ce851898a4548e, ; 414: lib_System.Web.HttpUtility.dll.so => 161
	i64 u0xc858a28d9ee5a6c5, ; 415: lib_System.Collections.Specialized.dll.so => 105
	i64 u0xc9e54b32fc19baf3, ; 416: lib_CommunityToolkit.Maui.dll.so => 36
	i64 u0xca3a723e7342c5b6, ; 417: lib-tr-Microsoft.Maui.Controls.resources.dll.so => 28
	i64 u0xca5801070d9fccfb, ; 418: System.Text.Encoding => 153
	i64 u0xcab3493c70141c2d, ; 419: pl/Microsoft.Maui.Controls.resources => 20
	i64 u0xcacfddc9f7c6de76, ; 420: ro/Microsoft.Maui.Controls.resources.dll => 23
	i64 u0xcbd4fdd9cef4a294, ; 421: lib__Microsoft.Android.Resource.Designer.dll.so => 34
	i64 u0xcc2876b32ef2794c, ; 422: lib_System.Text.RegularExpressions.dll.so => 156
	i64 u0xcc5c3bb714c4561e, ; 423: Xamarin.KotlinX.Coroutines.Core.Jvm.dll => 98
	i64 u0xcc76886e09b88260, ; 424: Xamarin.KotlinX.Serialization.Core.Jvm.dll => 99
	i64 u0xccf25c4b634ccd3a, ; 425: zh-Hans/Microsoft.Maui.Controls.resources.dll => 32
	i64 u0xcd10a42808629144, ; 426: System.Net.Requests => 131
	i64 u0xcdd0c48b6937b21c, ; 427: Xamarin.AndroidX.SwipeRefreshLayout => 92
	i64 u0xcf23d8093f3ceadf, ; 428: System.Diagnostics.DiagnosticSource.dll => 114
	i64 u0xcf8fc898f98b0d34, ; 429: System.Private.Xml.Linq => 135
	i64 u0xd04b5f59ed596e31, ; 430: System.Reflection.Metadata.dll => 138
	i64 u0xd0fc33d5ae5d4cb8, ; 431: System.Runtime.Extensions => 143
	i64 u0xd10d5932534af399, ; 432: CommonServiceLocator => 35
	i64 u0xd1194e1d8a8de83c, ; 433: lib_Xamarin.AndroidX.Lifecycle.Common.Jvm.dll.so => 80
	i64 u0xd12beacdfc14f696, ; 434: System.Dynamic.Runtime => 117
	i64 u0xd16fd7fb9bbcd43e, ; 435: Microsoft.Extensions.Diagnostics.Abstractions => 47
	i64 u0xd333d0af9e423810, ; 436: System.Runtime.InteropServices => 145
	i64 u0xd3426d966bb704f5, ; 437: Xamarin.AndroidX.AppCompat.AppCompatResources.dll => 71
	i64 u0xd3651b6fc3125825, ; 438: System.Private.Uri.dll => 134
	i64 u0xd373685349b1fe8b, ; 439: Microsoft.Extensions.Logging.dll => 49
	i64 u0xd3e4c8d6a2d5d470, ; 440: it/Microsoft.Maui.Controls.resources => 14
	i64 u0xd4645626dffec99d, ; 441: lib_Microsoft.Extensions.DependencyInjection.Abstractions.dll.so => 45
	i64 u0xd5507e11a2b2839f, ; 442: Xamarin.AndroidX.Lifecycle.ViewModelSavedState => 83
	i64 u0xd6694f8359737e4e, ; 443: Xamarin.AndroidX.SavedState => 90
	i64 u0xd6d21782156bc35b, ; 444: Xamarin.AndroidX.SwipeRefreshLayout.dll => 92
	i64 u0xd72329819cbbbc44, ; 445: lib_Microsoft.Extensions.Configuration.Abstractions.dll.so => 43
	i64 u0xd7b3764ada9d341d, ; 446: lib_Microsoft.Extensions.Logging.Abstractions.dll.so => 50
	i64 u0xda1dfa4c534a9251, ; 447: Microsoft.Extensions.DependencyInjection => 44
	i64 u0xdad05a11827959a3, ; 448: System.Collections.NonGeneric.dll => 104
	i64 u0xdb5383ab5865c007, ; 449: lib-vi-Microsoft.Maui.Controls.resources.dll.so => 30
	i64 u0xdbeda89f832aa805, ; 450: vi/Microsoft.Maui.Controls.resources.dll => 30
	i64 u0xdbf9607a441b4505, ; 451: System.Linq => 126
	i64 u0xdbfc90157a0de9b0, ; 452: lib_System.Text.Encoding.dll.so => 153
	i64 u0xdce2c53525640bf3, ; 453: Microsoft.Extensions.Logging => 49
	i64 u0xdd2b722d78ef5f43, ; 454: System.Runtime.dll => 149
	i64 u0xdd67031857c72f96, ; 455: lib_System.Text.Encodings.Web.dll.so => 154
	i64 u0xdde30e6b77aa6f6c, ; 456: lib-zh-Hans-Microsoft.Maui.Controls.resources.dll.so => 32
	i64 u0xde110ae80fa7c2e2, ; 457: System.Xml.XDocument.dll => 164
	i64 u0xde8769ebda7d8647, ; 458: hr/Microsoft.Maui.Controls.resources.dll => 11
	i64 u0xe0142572c095a480, ; 459: Xamarin.AndroidX.AppCompat.dll => 70
	i64 u0xe021eaa401792a05, ; 460: System.Text.Encoding.dll => 153
	i64 u0xe02f89350ec78051, ; 461: Xamarin.AndroidX.CoordinatorLayout.dll => 74
	i64 u0xe192a588d4410686, ; 462: lib_System.IO.Pipelines.dll.so => 123
	i64 u0xe1a08bd3fa539e0d, ; 463: System.Runtime.Loader => 146
	i64 u0xe1b52f9f816c70ef, ; 464: System.Private.Xml.Linq.dll => 135
	i64 u0xe2420585aeceb728, ; 465: System.Net.Requests.dll => 131
	i64 u0xe29b73bc11392966, ; 466: lib-id-Microsoft.Maui.Controls.resources.dll.so => 13
	i64 u0xe3811d68d4fe8463, ; 467: pt-BR/Microsoft.Maui.Controls.resources.dll => 21
	i64 u0xe3a586956771a0ed, ; 468: lib_SQLite-net.dll.so => 64
	i64 u0xe494f7ced4ecd10a, ; 469: hu/Microsoft.Maui.Controls.resources.dll => 12
	i64 u0xe4a9b1e40d1e8917, ; 470: lib-fi-Microsoft.Maui.Controls.resources.dll.so => 7
	i64 u0xe4f74a0b5bf9703f, ; 471: System.Runtime.Serialization.Primitives => 148
	i64 u0xe51aadb833ed7eb1, ; 472: lib_Microsoft.CodeAnalysis.CSharp.dll.so => 40
	i64 u0xe5434e8a119ceb69, ; 473: lib_Mono.Android.dll.so => 171
	i64 u0xe55703b9ce5c038a, ; 474: System.Diagnostics.Tools => 115
	i64 u0xe57013c8afc270b5, ; 475: Microsoft.VisualBasic => 58
	i64 u0xe6aff18cfcb9d070, ; 476: RentospectMobileApplication => 101
	i64 u0xedc632067fb20ff3, ; 477: System.Memory.dll => 127
	i64 u0xedc8e4ca71a02a8b, ; 478: Xamarin.AndroidX.Navigation.Runtime.dll => 87
	i64 u0xeeb7ebb80150501b, ; 479: lib_Xamarin.AndroidX.Collection.Jvm.dll.so => 73
	i64 u0xef72742e1bcca27a, ; 480: Microsoft.Maui.Essentials.dll => 56
	i64 u0xefd1e0c4e5c9b371, ; 481: System.Resources.ResourceManager.dll => 142
	i64 u0xefec0b7fdc57ec42, ; 482: Xamarin.AndroidX.Activity => 69
	i64 u0xf00c29406ea45e19, ; 483: es/Microsoft.Maui.Controls.resources.dll => 6
	i64 u0xf0ac2b489fed2e35, ; 484: lib_System.Diagnostics.Debug.dll.so => 113
	i64 u0xf11b621fc87b983f, ; 485: Microsoft.Maui.Controls.Xaml.dll => 54
	i64 u0xf1c4b4005493d871, ; 486: System.Formats.Asn1.dll => 118
	i64 u0xf238bd79489d3a96, ; 487: lib-nl-Microsoft.Maui.Controls.resources.dll.so => 19
	i64 u0xf37221fda4ef8830, ; 488: lib_Xamarin.Google.Android.Material.dll.so => 95
	i64 u0xf3ddfe05336abf29, ; 489: System => 165
	i64 u0xf4c1dd70a5496a17, ; 490: System.IO.Compression => 121
	i64 u0xf518f63ead11fcd1, ; 491: System.Threading.Tasks => 158
	i64 u0xf5967aac376787d7, ; 492: Microsoft.CodeAnalysis.dll => 39
	i64 u0xf6077741019d7428, ; 493: Xamarin.AndroidX.CoordinatorLayout => 74
	i64 u0xf77b20923f07c667, ; 494: de/Microsoft.Maui.Controls.resources.dll => 4
	i64 u0xf7e2cac4c45067b3, ; 495: lib_System.Numerics.Vectors.dll.so => 132
	i64 u0xf7e74930e0e3d214, ; 496: zh-HK/Microsoft.Maui.Controls.resources.dll => 31
	i64 u0xf84773b5c81e3cef, ; 497: lib-uk-Microsoft.Maui.Controls.resources.dll.so => 29
	i64 u0xf8b77539b362d3ba, ; 498: lib_System.Reflection.Primitives.dll.so => 139
	i64 u0xf8e045dc345b2ea3, ; 499: lib_Xamarin.AndroidX.RecyclerView.dll.so => 89
	i64 u0xf915dc29808193a1, ; 500: System.Web.HttpUtility.dll => 161
	i64 u0xf96c777a2a0686f4, ; 501: hi/Microsoft.Maui.Controls.resources.dll => 10
	i64 u0xf9eec5bb3a6aedc6, ; 502: Microsoft.Extensions.Options => 51
	i64 u0xfa5ed7226d978949, ; 503: lib-ar-Microsoft.Maui.Controls.resources.dll.so => 0
	i64 u0xfa645d91e9fc4cba, ; 504: System.Threading.Thread => 159
	i64 u0xfb022853d73b7fa5, ; 505: lib_SQLitePCLRaw.batteries_v2.dll.so => 65
	i64 u0xfbf0a31c9fc34bc4, ; 506: lib_System.Net.Http.dll.so => 129
	i64 u0xfc719aec26adf9d9, ; 507: Xamarin.AndroidX.Navigation.Fragment.dll => 86
	i64 u0xfcd302092ada6328, ; 508: System.IO.MemoryMappedFiles.dll => 122
	i64 u0xfd22f00870e40ae0, ; 509: lib_Xamarin.AndroidX.DrawerLayout.dll.so => 78
	i64 u0xfd49b3c1a76e2748, ; 510: System.Runtime.InteropServices.RuntimeInformation => 144
	i64 u0xfd536c702f64dc47, ; 511: System.Text.Encoding.Extensions => 152
	i64 u0xfd583f7657b6a1cb, ; 512: Xamarin.AndroidX.Fragment => 79
	i64 u0xfdbe4710aa9beeff, ; 513: CommunityToolkit.Maui => 36
	i64 u0xfeae9952cf03b8cb, ; 514: tr/Microsoft.Maui.Controls.resources => 28
	i64 u0xff9b54613e0d2cc8 ; 515: System.Net.Http.Json => 128
], align 16

@assembly_image_cache_indices = dso_local local_unnamed_addr constant [516 x i32] [
	i32 119, i32 92, i32 62, i32 107, i32 87, i32 37, i32 170, i32 70,
	i32 68, i32 35, i32 24, i32 2, i32 30, i32 130, i32 89, i32 106,
	i32 55, i32 31, i32 162, i32 73, i32 166, i32 24, i32 104, i32 139,
	i32 78, i32 107, i32 51, i32 104, i32 151, i32 60, i32 138, i32 25,
	i32 99, i32 93, i32 21, i32 171, i32 56, i32 91, i32 59, i32 101,
	i32 77, i32 39, i32 39, i32 120, i32 89, i32 100, i32 8, i32 169,
	i32 9, i32 45, i32 100, i32 141, i32 167, i32 112, i32 12, i32 154,
	i32 140, i32 99, i32 18, i32 63, i32 150, i32 102, i32 165, i32 27,
	i32 46, i32 170, i32 158, i32 91, i32 88, i32 16, i32 157, i32 51,
	i32 120, i32 119, i32 149, i32 27, i32 159, i32 142, i32 111, i32 75,
	i32 148, i32 8, i32 96, i32 65, i32 97, i32 52, i32 137, i32 124,
	i32 13, i32 11, i32 96, i32 169, i32 113, i32 130, i32 62, i32 100,
	i32 47, i32 29, i32 116, i32 7, i32 156, i32 118, i32 33, i32 20,
	i32 135, i32 160, i32 26, i32 155, i32 5, i32 163, i32 48, i32 79,
	i32 34, i32 72, i32 60, i32 8, i32 163, i32 103, i32 6, i32 55,
	i32 2, i32 53, i32 107, i32 94, i32 42, i32 115, i32 143, i32 122,
	i32 139, i32 124, i32 103, i32 77, i32 93, i32 1, i32 61, i32 152,
	i32 97, i32 162, i32 75, i32 65, i32 140, i32 85, i32 58, i32 166,
	i32 71, i32 142, i32 167, i32 171, i32 58, i32 20, i32 148, i32 97,
	i32 60, i32 116, i32 24, i32 162, i32 22, i32 122, i32 133, i32 88,
	i32 143, i32 155, i32 128, i32 84, i32 125, i32 136, i32 146, i32 14,
	i32 84, i32 170, i32 1, i32 67, i32 53, i32 38, i32 82, i32 41,
	i32 130, i32 75, i32 57, i32 25, i32 144, i32 31, i32 150, i32 149,
	i32 80, i32 105, i32 134, i32 66, i32 168, i32 114, i32 15, i32 44,
	i32 74, i32 160, i32 110, i32 3, i32 137, i32 49, i32 157, i32 145,
	i32 73, i32 105, i32 154, i32 108, i32 163, i32 67, i32 5, i32 44,
	i32 98, i32 127, i32 124, i32 54, i32 4, i32 146, i32 59, i32 168,
	i32 103, i32 95, i32 141, i32 36, i32 62, i32 53, i32 147, i32 111,
	i32 82, i32 76, i32 3, i32 118, i32 9, i32 67, i32 145, i32 40,
	i32 18, i32 112, i32 57, i32 52, i32 76, i32 52, i32 86, i32 112,
	i32 55, i32 2, i32 28, i32 18, i32 137, i32 47, i32 14, i32 108,
	i32 11, i32 127, i32 46, i32 42, i32 90, i32 147, i32 17, i32 27,
	i32 79, i32 40, i32 48, i32 7, i32 109, i32 25, i32 4, i32 37,
	i32 17, i32 132, i32 35, i32 106, i32 150, i32 133, i32 110, i32 93,
	i32 43, i32 81, i32 138, i32 68, i32 165, i32 33, i32 70, i32 72,
	i32 29, i32 64, i32 32, i32 157, i32 117, i32 33, i32 42, i32 159,
	i32 120, i32 56, i32 141, i32 98, i32 167, i32 108, i32 144, i32 140,
	i32 101, i32 84, i32 114, i32 9, i32 59, i32 76, i32 160, i32 102,
	i32 85, i32 10, i32 23, i32 66, i32 22, i32 21, i32 119, i32 66,
	i32 116, i32 34, i32 121, i32 82, i32 54, i32 77, i32 155, i32 126,
	i32 1, i32 17, i32 121, i32 63, i32 6, i32 13, i32 57, i32 110,
	i32 102, i32 61, i32 125, i32 38, i32 87, i32 16, i32 61, i32 69,
	i32 43, i32 19, i32 113, i32 85, i32 81, i32 151, i32 96, i32 95,
	i32 88, i32 123, i32 166, i32 117, i32 16, i32 46, i32 38, i32 132,
	i32 151, i32 90, i32 91, i32 78, i32 80, i32 12, i32 37, i32 50,
	i32 136, i32 129, i32 45, i32 5, i32 125, i32 147, i32 81, i32 115,
	i32 164, i32 23, i32 19, i32 161, i32 109, i32 169, i32 133, i32 64,
	i32 83, i32 26, i32 156, i32 3, i32 72, i32 10, i32 0, i32 123,
	i32 158, i32 50, i32 26, i32 168, i32 48, i32 22, i32 15, i32 164,
	i32 106, i32 68, i32 129, i32 94, i32 71, i32 128, i32 0, i32 111,
	i32 41, i32 126, i32 69, i32 15, i32 94, i32 63, i32 83, i32 109,
	i32 131, i32 86, i32 136, i32 134, i32 41, i32 152, i32 161, i32 105,
	i32 36, i32 28, i32 153, i32 20, i32 23, i32 34, i32 156, i32 98,
	i32 99, i32 32, i32 131, i32 92, i32 114, i32 135, i32 138, i32 143,
	i32 35, i32 80, i32 117, i32 47, i32 145, i32 71, i32 134, i32 49,
	i32 14, i32 45, i32 83, i32 90, i32 92, i32 43, i32 50, i32 44,
	i32 104, i32 30, i32 30, i32 126, i32 153, i32 49, i32 149, i32 154,
	i32 32, i32 164, i32 11, i32 70, i32 153, i32 74, i32 123, i32 146,
	i32 135, i32 131, i32 13, i32 21, i32 64, i32 12, i32 7, i32 148,
	i32 40, i32 171, i32 115, i32 58, i32 101, i32 127, i32 87, i32 73,
	i32 56, i32 142, i32 69, i32 6, i32 113, i32 54, i32 118, i32 19,
	i32 95, i32 165, i32 121, i32 158, i32 39, i32 74, i32 4, i32 132,
	i32 31, i32 29, i32 139, i32 89, i32 161, i32 10, i32 51, i32 0,
	i32 159, i32 65, i32 129, i32 86, i32 122, i32 78, i32 144, i32 152,
	i32 79, i32 36, i32 28, i32 128
], align 16

@marshal_methods_number_of_classes = dso_local local_unnamed_addr constant i32 0, align 4

@marshal_methods_class_cache = dso_local local_unnamed_addr global [0 x %struct.MarshalMethodsManagedClass] zeroinitializer, align 8

; Names of classes in which marshal methods reside
@mm_class_names = dso_local local_unnamed_addr constant [0 x ptr] zeroinitializer, align 8

@mm_method_names = dso_local local_unnamed_addr constant [1 x %struct.MarshalMethodName] [
	%struct.MarshalMethodName {
		i64 u0x0000000000000000, ; name: 
		ptr @.MarshalMethodName.0_name; char* name
	} ; 0
], align 8

; get_function_pointer (uint32_t mono_image_index, uint32_t class_index, uint32_t method_token, void*& target_ptr)
@get_function_pointer = internal dso_local unnamed_addr global ptr null, align 8

; Functions

; Function attributes: memory(write, argmem: none, inaccessiblemem: none) "min-legal-vector-width"="0" mustprogress "no-trapping-math"="true" nofree norecurse nosync nounwind "stack-protector-buffer-size"="8" uwtable willreturn
define void @xamarin_app_init(ptr nocapture noundef readnone %env, ptr noundef %fn) local_unnamed_addr #0
{
	%fnIsNull = icmp eq ptr %fn, null
	br i1 %fnIsNull, label %1, label %2

1: ; preds = %0
	%putsResult = call noundef i32 @puts(ptr @.str.0)
	call void @abort()
	unreachable 

2: ; preds = %1, %0
	store ptr %fn, ptr @get_function_pointer, align 8, !tbaa !3
	ret void
}

; Strings
@.str.0 = private unnamed_addr constant [40 x i8] c"get_function_pointer MUST be specified\0A\00", align 16

;MarshalMethodName
@.MarshalMethodName.0_name = private unnamed_addr constant [1 x i8] c"\00", align 1

; External functions

; Function attributes: "no-trapping-math"="true" noreturn nounwind "stack-protector-buffer-size"="8"
declare void @abort() local_unnamed_addr #2

; Function attributes: nofree nounwind
declare noundef i32 @puts(ptr noundef) local_unnamed_addr #1
attributes #0 = { memory(write, argmem: none, inaccessiblemem: none) "min-legal-vector-width"="0" mustprogress "no-trapping-math"="true" nofree norecurse nosync nounwind "stack-protector-buffer-size"="8" "target-cpu"="x86-64" "target-features"="+crc32,+cx16,+cx8,+fxsr,+mmx,+popcnt,+sse,+sse2,+sse3,+sse4.1,+sse4.2,+ssse3,+x87" "tune-cpu"="generic" uwtable willreturn }
attributes #1 = { nofree nounwind }
attributes #2 = { "no-trapping-math"="true" noreturn nounwind "stack-protector-buffer-size"="8" "target-cpu"="x86-64" "target-features"="+crc32,+cx16,+cx8,+fxsr,+mmx,+popcnt,+sse,+sse2,+sse3,+sse4.1,+sse4.2,+ssse3,+x87" "tune-cpu"="generic" }

; Metadata
!llvm.module.flags = !{!0, !1}
!0 = !{i32 1, !"wchar_size", i32 4}
!1 = !{i32 7, !"PIC Level", i32 2}
!llvm.ident = !{!2}
!2 = !{!".NET for Android remotes/origin/release/9.0.1xx @ 1dcfb6f8779c33b6f768c996495cb90ecd729329"}
!3 = !{!4, !4, i64 0}
!4 = !{!"any pointer", !5, i64 0}
!5 = !{!"omnipotent char", !6, i64 0}
!6 = !{!"Simple C++ TBAA"}

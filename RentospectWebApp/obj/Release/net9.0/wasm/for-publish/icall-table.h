#define ICALL_TABLE_corlib 1

static int corlib_icall_indexes [] = {
219,
232,
233,
234,
235,
236,
237,
238,
239,
240,
243,
244,
245,
416,
417,
418,
441,
442,
443,
460,
461,
462,
558,
559,
560,
563,
598,
599,
600,
601,
602,
606,
608,
610,
612,
618,
626,
627,
628,
629,
630,
631,
632,
633,
634,
635,
636,
637,
638,
639,
640,
641,
642,
644,
645,
646,
647,
648,
649,
650,
732,
733,
734,
735,
736,
737,
738,
739,
740,
741,
742,
743,
744,
745,
746,
747,
748,
750,
751,
752,
753,
754,
755,
756,
811,
820,
821,
890,
896,
899,
901,
906,
907,
909,
910,
914,
915,
917,
918,
921,
922,
923,
926,
928,
931,
933,
935,
944,
1008,
1010,
1012,
1022,
1023,
1024,
1026,
1032,
1033,
1034,
1035,
1036,
1044,
1045,
1046,
1050,
1051,
1053,
1057,
1058,
1059,
1351,
1511,
1512,
9092,
9093,
9095,
9096,
9097,
9098,
9099,
9101,
9102,
9103,
9104,
9122,
9124,
9131,
9133,
9135,
9137,
9140,
9190,
9191,
9193,
9194,
9195,
9196,
9197,
9199,
9201,
10233,
10237,
10239,
10240,
10241,
10242,
10659,
10660,
10661,
10662,
10680,
10681,
10682,
10727,
10793,
10796,
10804,
10805,
10806,
10807,
10808,
11128,
11132,
11133,
11160,
11194,
11201,
11208,
11219,
11223,
11246,
11324,
11326,
11335,
11337,
11338,
11345,
11360,
11380,
11381,
11389,
11391,
11398,
11399,
11402,
11404,
11409,
11415,
11416,
11423,
11425,
11437,
11440,
11441,
11442,
11453,
11463,
11469,
11470,
11471,
11473,
11474,
11491,
11493,
11508,
11526,
11553,
11583,
11584,
12123,
12207,
12208,
12392,
12393,
12397,
12398,
12399,
12404,
12455,
12942,
12943,
13310,
13315,
13325,
14224,
14245,
14247,
14249,
};
void ves_icall_System_Array_InternalCreate (int,int,int,int,int);
int ves_icall_System_Array_GetCorElementTypeOfElementTypeInternal (int);
int ves_icall_System_Array_IsValueOfElementTypeInternal (int,int);
int ves_icall_System_Array_CanChangePrimitive (int,int,int);
int ves_icall_System_Array_FastCopy (int,int,int,int,int);
int ves_icall_System_Array_GetLengthInternal_raw (int,int,int);
int ves_icall_System_Array_GetLowerBoundInternal_raw (int,int,int);
void ves_icall_System_Array_GetGenericValue_icall (int,int,int);
void ves_icall_System_Array_GetValueImpl_raw (int,int,int,int);
void ves_icall_System_Array_SetGenericValue_icall (int,int,int);
void ves_icall_System_Array_SetValueImpl_raw (int,int,int,int);
void ves_icall_System_Array_InitializeInternal_raw (int,int);
void ves_icall_System_Array_SetValueRelaxedImpl_raw (int,int,int,int);
void ves_icall_System_Runtime_RuntimeImports_ZeroMemory (int,int);
void ves_icall_System_Runtime_RuntimeImports_Memmove (int,int,int);
void ves_icall_System_Buffer_BulkMoveWithWriteBarrier (int,int,int,int);
int ves_icall_System_Delegate_AllocDelegateLike_internal_raw (int,int);
int ves_icall_System_Delegate_CreateDelegate_internal_raw (int,int,int,int,int);
int ves_icall_System_Delegate_GetVirtualMethod_internal_raw (int,int);
void ves_icall_System_Enum_GetEnumValuesAndNames_raw (int,int,int,int);
int ves_icall_System_Enum_InternalGetCorElementType (int);
void ves_icall_System_Enum_InternalGetUnderlyingType_raw (int,int,int);
int ves_icall_System_Environment_get_ProcessorCount ();
int ves_icall_System_Environment_get_TickCount ();
int64_t ves_icall_System_Environment_get_TickCount64 ();
void ves_icall_System_Environment_FailFast_raw (int,int,int,int);
int ves_icall_System_GC_GetCollectionCount (int);
int ves_icall_System_GC_GetMaxGeneration ();
void ves_icall_System_GC_register_ephemeron_array_raw (int,int);
int ves_icall_System_GC_get_ephemeron_tombstone_raw (int);
int64_t ves_icall_System_GC_GetTotalAllocatedBytes_raw (int,int);
void ves_icall_System_GC_SuppressFinalize_raw (int,int);
void ves_icall_System_GC_ReRegisterForFinalize_raw (int,int);
void ves_icall_System_GC_GetGCMemoryInfo (int,int,int,int,int,int);
int ves_icall_System_GC_AllocPinnedArray_raw (int,int,int);
int ves_icall_System_Object_MemberwiseClone_raw (int,int);
double ves_icall_System_Math_Acos (double);
double ves_icall_System_Math_Acosh (double);
double ves_icall_System_Math_Asin (double);
double ves_icall_System_Math_Asinh (double);
double ves_icall_System_Math_Atan (double);
double ves_icall_System_Math_Atan2 (double,double);
double ves_icall_System_Math_Atanh (double);
double ves_icall_System_Math_Cbrt (double);
double ves_icall_System_Math_Ceiling (double);
double ves_icall_System_Math_Cos (double);
double ves_icall_System_Math_Cosh (double);
double ves_icall_System_Math_Exp (double);
double ves_icall_System_Math_Floor (double);
double ves_icall_System_Math_Log (double);
double ves_icall_System_Math_Log10 (double);
double ves_icall_System_Math_Pow (double,double);
double ves_icall_System_Math_Sin (double);
double ves_icall_System_Math_Sinh (double);
double ves_icall_System_Math_Sqrt (double);
double ves_icall_System_Math_Tan (double);
double ves_icall_System_Math_Tanh (double);
double ves_icall_System_Math_FusedMultiplyAdd (double,double,double);
double ves_icall_System_Math_Log2 (double);
double ves_icall_System_Math_ModF (double,int);
float ves_icall_System_MathF_Acos (float);
float ves_icall_System_MathF_Acosh (float);
float ves_icall_System_MathF_Asin (float);
float ves_icall_System_MathF_Asinh (float);
float ves_icall_System_MathF_Atan (float);
float ves_icall_System_MathF_Atan2 (float,float);
float ves_icall_System_MathF_Atanh (float);
float ves_icall_System_MathF_Cbrt (float);
float ves_icall_System_MathF_Ceiling (float);
float ves_icall_System_MathF_Cos (float);
float ves_icall_System_MathF_Cosh (float);
float ves_icall_System_MathF_Exp (float);
float ves_icall_System_MathF_Floor (float);
float ves_icall_System_MathF_Log (float);
float ves_icall_System_MathF_Log10 (float);
float ves_icall_System_MathF_Pow (float,float);
float ves_icall_System_MathF_Sin (float);
float ves_icall_System_MathF_Sinh (float);
float ves_icall_System_MathF_Sqrt (float);
float ves_icall_System_MathF_Tan (float);
float ves_icall_System_MathF_Tanh (float);
float ves_icall_System_MathF_FusedMultiplyAdd (float,float,float);
float ves_icall_System_MathF_Log2 (float);
float ves_icall_System_MathF_ModF (float,int);
int ves_icall_RuntimeMethodHandle_GetFunctionPointer_raw (int,int);
void ves_icall_RuntimeMethodHandle_ReboxFromNullable_raw (int,int,int);
void ves_icall_RuntimeMethodHandle_ReboxToNullable_raw (int,int,int,int);
int ves_icall_RuntimeType_GetCorrespondingInflatedMethod_raw (int,int,int);
void ves_icall_RuntimeType_make_array_type_raw (int,int,int,int);
void ves_icall_RuntimeType_make_byref_type_raw (int,int,int);
void ves_icall_RuntimeType_make_pointer_type_raw (int,int,int);
void ves_icall_RuntimeType_MakeGenericType_raw (int,int,int,int);
int ves_icall_RuntimeType_GetMethodsByName_native_raw (int,int,int,int,int);
int ves_icall_RuntimeType_GetPropertiesByName_native_raw (int,int,int,int,int);
int ves_icall_RuntimeType_GetConstructors_native_raw (int,int,int);
int ves_icall_System_RuntimeType_CreateInstanceInternal_raw (int,int);
void ves_icall_RuntimeType_GetDeclaringMethod_raw (int,int,int);
void ves_icall_System_RuntimeType_getFullName_raw (int,int,int,int,int);
void ves_icall_RuntimeType_GetGenericArgumentsInternal_raw (int,int,int,int);
int ves_icall_RuntimeType_GetGenericParameterPosition (int);
int ves_icall_RuntimeType_GetEvents_native_raw (int,int,int,int);
int ves_icall_RuntimeType_GetFields_native_raw (int,int,int,int,int);
void ves_icall_RuntimeType_GetInterfaces_raw (int,int,int);
int ves_icall_RuntimeType_GetNestedTypes_native_raw (int,int,int,int,int);
void ves_icall_RuntimeType_GetDeclaringType_raw (int,int,int);
void ves_icall_RuntimeType_GetName_raw (int,int,int);
void ves_icall_RuntimeType_GetNamespace_raw (int,int,int);
int ves_icall_RuntimeType_FunctionPointerReturnAndParameterTypes_raw (int,int);
int ves_icall_RuntimeTypeHandle_GetAttributes (int);
int ves_icall_RuntimeTypeHandle_GetMetadataToken_raw (int,int);
void ves_icall_RuntimeTypeHandle_GetGenericTypeDefinition_impl_raw (int,int,int);
int ves_icall_RuntimeTypeHandle_GetCorElementType (int);
int ves_icall_RuntimeTypeHandle_HasInstantiation (int);
int ves_icall_RuntimeTypeHandle_IsInstanceOfType_raw (int,int,int);
int ves_icall_RuntimeTypeHandle_HasReferences_raw (int,int);
int ves_icall_RuntimeTypeHandle_GetArrayRank_raw (int,int);
void ves_icall_RuntimeTypeHandle_GetAssembly_raw (int,int,int);
void ves_icall_RuntimeTypeHandle_GetElementType_raw (int,int,int);
void ves_icall_RuntimeTypeHandle_GetModule_raw (int,int,int);
void ves_icall_RuntimeTypeHandle_GetBaseType_raw (int,int,int);
int ves_icall_RuntimeTypeHandle_type_is_assignable_from_raw (int,int,int);
int ves_icall_RuntimeTypeHandle_IsGenericTypeDefinition (int);
int ves_icall_RuntimeTypeHandle_GetGenericParameterInfo_raw (int,int);
int ves_icall_RuntimeTypeHandle_is_subclass_of_raw (int,int,int);
int ves_icall_RuntimeTypeHandle_IsByRefLike_raw (int,int);
void ves_icall_System_RuntimeTypeHandle_internal_from_name_raw (int,int,int,int,int,int);
int ves_icall_System_String_FastAllocateString_raw (int,int);
int ves_icall_System_String_InternalIsInterned_raw (int,int);
int ves_icall_System_String_InternalIntern_raw (int,int);
int ves_icall_System_Type_internal_from_handle_raw (int,int);
int ves_icall_System_ValueType_InternalGetHashCode_raw (int,int,int);
int ves_icall_System_ValueType_Equals_raw (int,int,int,int);
int ves_icall_System_Threading_Interlocked_CompareExchange_Int (int,int,int);
void ves_icall_System_Threading_Interlocked_CompareExchange_Object (int,int,int,int);
int ves_icall_System_Threading_Interlocked_Decrement_Int (int);
int ves_icall_System_Threading_Interlocked_Increment_Int (int);
int64_t ves_icall_System_Threading_Interlocked_Increment_Long (int);
int ves_icall_System_Threading_Interlocked_Exchange_Int (int,int);
void ves_icall_System_Threading_Interlocked_Exchange_Object (int,int,int);
int64_t ves_icall_System_Threading_Interlocked_CompareExchange_Long (int,int64_t,int64_t);
int64_t ves_icall_System_Threading_Interlocked_Exchange_Long (int,int64_t);
int ves_icall_System_Threading_Interlocked_Add_Int (int,int);
int64_t ves_icall_System_Threading_Interlocked_Add_Long (int,int64_t);
void ves_icall_System_Threading_Monitor_Monitor_Enter_raw (int,int);
void mono_monitor_exit_icall_raw (int,int);
void ves_icall_System_Threading_Monitor_Monitor_pulse_raw (int,int);
void ves_icall_System_Threading_Monitor_Monitor_pulse_all_raw (int,int);
int ves_icall_System_Threading_Monitor_Monitor_wait_raw (int,int,int,int);
void ves_icall_System_Threading_Monitor_Monitor_try_enter_with_atomic_var_raw (int,int,int,int,int);
int64_t ves_icall_System_Threading_Monitor_Monitor_get_lock_contention_count ();
void ves_icall_System_Threading_Thread_InitInternal_raw (int,int);
int ves_icall_System_Threading_Thread_GetCurrentThread ();
void ves_icall_System_Threading_InternalThread_Thread_free_internal_raw (int,int);
int ves_icall_System_Threading_Thread_GetState_raw (int,int);
void ves_icall_System_Threading_Thread_SetState_raw (int,int,int);
void ves_icall_System_Threading_Thread_ClrState_raw (int,int,int);
void ves_icall_System_Threading_Thread_SetName_icall_raw (int,int,int,int);
int ves_icall_System_Threading_Thread_YieldInternal ();
void ves_icall_System_Threading_Thread_SetPriority_raw (int,int,int);
void ves_icall_System_Runtime_Loader_AssemblyLoadContext_PrepareForAssemblyLoadContextRelease_raw (int,int,int);
int ves_icall_System_Runtime_Loader_AssemblyLoadContext_GetLoadContextForAssembly_raw (int,int);
int ves_icall_System_Runtime_Loader_AssemblyLoadContext_InternalLoadFile_raw (int,int,int,int);
int ves_icall_System_Runtime_Loader_AssemblyLoadContext_InternalInitializeNativeALC_raw (int,int,int,int,int);
int ves_icall_System_Runtime_Loader_AssemblyLoadContext_InternalLoadFromStream_raw (int,int,int,int,int,int);
int ves_icall_System_Runtime_Loader_AssemblyLoadContext_InternalGetLoadedAssemblies_raw (int);
int ves_icall_System_GCHandle_InternalAlloc_raw (int,int,int);
void ves_icall_System_GCHandle_InternalFree_raw (int,int);
int ves_icall_System_GCHandle_InternalGet_raw (int,int);
void ves_icall_System_GCHandle_InternalSet_raw (int,int,int);
int ves_icall_System_Runtime_InteropServices_Marshal_GetLastPInvokeError ();
void ves_icall_System_Runtime_InteropServices_Marshal_SetLastPInvokeError (int);
void ves_icall_System_Runtime_InteropServices_Marshal_StructureToPtr_raw (int,int,int,int);
int ves_icall_System_Runtime_InteropServices_NativeLibrary_LoadByName_raw (int,int,int,int,int,int);
int ves_icall_System_Runtime_CompilerServices_RuntimeHelpers_InternalGetHashCode_raw (int,int);
int ves_icall_System_Runtime_CompilerServices_RuntimeHelpers_GetObjectValue_raw (int,int);
int ves_icall_System_Runtime_CompilerServices_RuntimeHelpers_GetUninitializedObjectInternal_raw (int,int);
void ves_icall_System_Runtime_CompilerServices_RuntimeHelpers_InitializeArray_raw (int,int,int);
int ves_icall_System_Runtime_CompilerServices_RuntimeHelpers_GetSpanDataFrom_raw (int,int,int,int);
int ves_icall_System_Runtime_CompilerServices_RuntimeHelpers_SufficientExecutionStack ();
int ves_icall_System_Runtime_CompilerServices_RuntimeHelpers_InternalBox_raw (int,int,int);
int ves_icall_System_Reflection_Assembly_GetEntryAssembly_raw (int);
int ves_icall_System_Reflection_Assembly_InternalLoad_raw (int,int,int,int);
int ves_icall_System_Reflection_Assembly_InternalGetType_raw (int,int,int,int,int,int);
int ves_icall_System_Reflection_AssemblyName_GetNativeName (int);
int ves_icall_MonoCustomAttrs_GetCustomAttributesInternal_raw (int,int,int,int);
int ves_icall_MonoCustomAttrs_GetCustomAttributesDataInternal_raw (int,int);
int ves_icall_MonoCustomAttrs_IsDefinedInternal_raw (int,int,int);
int ves_icall_System_Reflection_FieldInfo_internal_from_handle_type_raw (int,int,int);
int ves_icall_System_Reflection_FieldInfo_get_marshal_info_raw (int,int);
int ves_icall_System_Reflection_LoaderAllocatorScout_Destroy (int);
void ves_icall_System_Reflection_RuntimeAssembly_GetManifestResourceNames_raw (int,int,int);
void ves_icall_System_Reflection_RuntimeAssembly_GetExportedTypes_raw (int,int,int);
void ves_icall_System_Reflection_RuntimeAssembly_GetInfo_raw (int,int,int,int);
int ves_icall_System_Reflection_RuntimeAssembly_GetManifestResourceInternal_raw (int,int,int,int,int);
void ves_icall_System_Reflection_Assembly_GetManifestModuleInternal_raw (int,int,int);
void ves_icall_System_Reflection_RuntimeCustomAttributeData_ResolveArgumentsInternal_raw (int,int,int,int,int,int,int);
void ves_icall_RuntimeEventInfo_get_event_info_raw (int,int,int);
int ves_icall_reflection_get_token_raw (int,int);
int ves_icall_System_Reflection_EventInfo_internal_from_handle_type_raw (int,int,int);
int ves_icall_RuntimeFieldInfo_ResolveType_raw (int,int);
int ves_icall_RuntimeFieldInfo_GetParentType_raw (int,int,int);
int ves_icall_RuntimeFieldInfo_GetFieldOffset_raw (int,int);
int ves_icall_RuntimeFieldInfo_GetValueInternal_raw (int,int,int);
void ves_icall_RuntimeFieldInfo_SetValueInternal_raw (int,int,int,int);
int ves_icall_RuntimeFieldInfo_GetRawConstantValue_raw (int,int);
int ves_icall_reflection_get_token_raw (int,int);
void ves_icall_get_method_info_raw (int,int,int);
int ves_icall_get_method_attributes (int);
int ves_icall_System_Reflection_MonoMethodInfo_get_parameter_info_raw (int,int,int);
int ves_icall_System_MonoMethodInfo_get_retval_marshal_raw (int,int);
int ves_icall_System_Reflection_RuntimeMethodInfo_GetMethodFromHandleInternalType_native_raw (int,int,int,int);
int ves_icall_RuntimeMethodInfo_get_name_raw (int,int);
int ves_icall_RuntimeMethodInfo_get_base_method_raw (int,int,int);
int ves_icall_reflection_get_token_raw (int,int);
int ves_icall_InternalInvoke_raw (int,int,int,int,int);
void ves_icall_RuntimeMethodInfo_GetPInvoke_raw (int,int,int,int,int);
int ves_icall_RuntimeMethodInfo_MakeGenericMethod_impl_raw (int,int,int);
int ves_icall_RuntimeMethodInfo_GetGenericArguments_raw (int,int);
int ves_icall_RuntimeMethodInfo_GetGenericMethodDefinition_raw (int,int);
int ves_icall_RuntimeMethodInfo_get_IsGenericMethodDefinition_raw (int,int);
int ves_icall_RuntimeMethodInfo_get_IsGenericMethod_raw (int,int);
void ves_icall_InvokeClassConstructor_raw (int,int);
int ves_icall_InternalInvoke_raw (int,int,int,int,int);
int ves_icall_reflection_get_token_raw (int,int);
int ves_icall_System_Reflection_RuntimeModule_ResolveMethodToken_raw (int,int,int,int,int,int);
void ves_icall_RuntimePropertyInfo_get_property_info_raw (int,int,int,int);
int ves_icall_reflection_get_token_raw (int,int);
int ves_icall_System_Reflection_RuntimePropertyInfo_internal_from_handle_type_raw (int,int,int);
void ves_icall_DynamicMethod_create_dynamic_method_raw (int,int,int,int,int);
void ves_icall_AssemblyBuilder_basic_init_raw (int,int);
void ves_icall_AssemblyBuilder_UpdateNativeCustomAttributes_raw (int,int);
void ves_icall_ModuleBuilder_basic_init_raw (int,int);
void ves_icall_ModuleBuilder_set_wrappers_type_raw (int,int,int);
int ves_icall_ModuleBuilder_getUSIndex_raw (int,int,int);
int ves_icall_ModuleBuilder_getToken_raw (int,int,int,int);
int ves_icall_ModuleBuilder_getMethodToken_raw (int,int,int,int);
void ves_icall_ModuleBuilder_RegisterToken_raw (int,int,int,int);
int ves_icall_TypeBuilder_create_runtime_class_raw (int,int);
int ves_icall_System_IO_Stream_HasOverriddenBeginEndRead_raw (int,int);
int ves_icall_System_IO_Stream_HasOverriddenBeginEndWrite_raw (int,int);
int ves_icall_System_Diagnostics_Debugger_IsAttached_internal ();
int ves_icall_System_Diagnostics_StackFrame_GetFrameInfo (int,int,int,int,int,int,int,int);
void ves_icall_System_Diagnostics_StackTrace_GetTrace (int,int,int,int);
int ves_icall_Mono_RuntimeClassHandle_GetTypeFromClass (int);
void ves_icall_Mono_RuntimeGPtrArrayHandle_GPtrArrayFree (int);
int ves_icall_Mono_SafeStringMarshal_StringToUtf8 (int);
void ves_icall_Mono_SafeStringMarshal_GFree (int);
static void *corlib_icall_funcs [] = {
// token 219,
ves_icall_System_Array_InternalCreate,
// token 232,
ves_icall_System_Array_GetCorElementTypeOfElementTypeInternal,
// token 233,
ves_icall_System_Array_IsValueOfElementTypeInternal,
// token 234,
ves_icall_System_Array_CanChangePrimitive,
// token 235,
ves_icall_System_Array_FastCopy,
// token 236,
ves_icall_System_Array_GetLengthInternal_raw,
// token 237,
ves_icall_System_Array_GetLowerBoundInternal_raw,
// token 238,
ves_icall_System_Array_GetGenericValue_icall,
// token 239,
ves_icall_System_Array_GetValueImpl_raw,
// token 240,
ves_icall_System_Array_SetGenericValue_icall,
// token 243,
ves_icall_System_Array_SetValueImpl_raw,
// token 244,
ves_icall_System_Array_InitializeInternal_raw,
// token 245,
ves_icall_System_Array_SetValueRelaxedImpl_raw,
// token 416,
ves_icall_System_Runtime_RuntimeImports_ZeroMemory,
// token 417,
ves_icall_System_Runtime_RuntimeImports_Memmove,
// token 418,
ves_icall_System_Buffer_BulkMoveWithWriteBarrier,
// token 441,
ves_icall_System_Delegate_AllocDelegateLike_internal_raw,
// token 442,
ves_icall_System_Delegate_CreateDelegate_internal_raw,
// token 443,
ves_icall_System_Delegate_GetVirtualMethod_internal_raw,
// token 460,
ves_icall_System_Enum_GetEnumValuesAndNames_raw,
// token 461,
ves_icall_System_Enum_InternalGetCorElementType,
// token 462,
ves_icall_System_Enum_InternalGetUnderlyingType_raw,
// token 558,
ves_icall_System_Environment_get_ProcessorCount,
// token 559,
ves_icall_System_Environment_get_TickCount,
// token 560,
ves_icall_System_Environment_get_TickCount64,
// token 563,
ves_icall_System_Environment_FailFast_raw,
// token 598,
ves_icall_System_GC_GetCollectionCount,
// token 599,
ves_icall_System_GC_GetMaxGeneration,
// token 600,
ves_icall_System_GC_register_ephemeron_array_raw,
// token 601,
ves_icall_System_GC_get_ephemeron_tombstone_raw,
// token 602,
ves_icall_System_GC_GetTotalAllocatedBytes_raw,
// token 606,
ves_icall_System_GC_SuppressFinalize_raw,
// token 608,
ves_icall_System_GC_ReRegisterForFinalize_raw,
// token 610,
ves_icall_System_GC_GetGCMemoryInfo,
// token 612,
ves_icall_System_GC_AllocPinnedArray_raw,
// token 618,
ves_icall_System_Object_MemberwiseClone_raw,
// token 626,
ves_icall_System_Math_Acos,
// token 627,
ves_icall_System_Math_Acosh,
// token 628,
ves_icall_System_Math_Asin,
// token 629,
ves_icall_System_Math_Asinh,
// token 630,
ves_icall_System_Math_Atan,
// token 631,
ves_icall_System_Math_Atan2,
// token 632,
ves_icall_System_Math_Atanh,
// token 633,
ves_icall_System_Math_Cbrt,
// token 634,
ves_icall_System_Math_Ceiling,
// token 635,
ves_icall_System_Math_Cos,
// token 636,
ves_icall_System_Math_Cosh,
// token 637,
ves_icall_System_Math_Exp,
// token 638,
ves_icall_System_Math_Floor,
// token 639,
ves_icall_System_Math_Log,
// token 640,
ves_icall_System_Math_Log10,
// token 641,
ves_icall_System_Math_Pow,
// token 642,
ves_icall_System_Math_Sin,
// token 644,
ves_icall_System_Math_Sinh,
// token 645,
ves_icall_System_Math_Sqrt,
// token 646,
ves_icall_System_Math_Tan,
// token 647,
ves_icall_System_Math_Tanh,
// token 648,
ves_icall_System_Math_FusedMultiplyAdd,
// token 649,
ves_icall_System_Math_Log2,
// token 650,
ves_icall_System_Math_ModF,
// token 732,
ves_icall_System_MathF_Acos,
// token 733,
ves_icall_System_MathF_Acosh,
// token 734,
ves_icall_System_MathF_Asin,
// token 735,
ves_icall_System_MathF_Asinh,
// token 736,
ves_icall_System_MathF_Atan,
// token 737,
ves_icall_System_MathF_Atan2,
// token 738,
ves_icall_System_MathF_Atanh,
// token 739,
ves_icall_System_MathF_Cbrt,
// token 740,
ves_icall_System_MathF_Ceiling,
// token 741,
ves_icall_System_MathF_Cos,
// token 742,
ves_icall_System_MathF_Cosh,
// token 743,
ves_icall_System_MathF_Exp,
// token 744,
ves_icall_System_MathF_Floor,
// token 745,
ves_icall_System_MathF_Log,
// token 746,
ves_icall_System_MathF_Log10,
// token 747,
ves_icall_System_MathF_Pow,
// token 748,
ves_icall_System_MathF_Sin,
// token 750,
ves_icall_System_MathF_Sinh,
// token 751,
ves_icall_System_MathF_Sqrt,
// token 752,
ves_icall_System_MathF_Tan,
// token 753,
ves_icall_System_MathF_Tanh,
// token 754,
ves_icall_System_MathF_FusedMultiplyAdd,
// token 755,
ves_icall_System_MathF_Log2,
// token 756,
ves_icall_System_MathF_ModF,
// token 811,
ves_icall_RuntimeMethodHandle_GetFunctionPointer_raw,
// token 820,
ves_icall_RuntimeMethodHandle_ReboxFromNullable_raw,
// token 821,
ves_icall_RuntimeMethodHandle_ReboxToNullable_raw,
// token 890,
ves_icall_RuntimeType_GetCorrespondingInflatedMethod_raw,
// token 896,
ves_icall_RuntimeType_make_array_type_raw,
// token 899,
ves_icall_RuntimeType_make_byref_type_raw,
// token 901,
ves_icall_RuntimeType_make_pointer_type_raw,
// token 906,
ves_icall_RuntimeType_MakeGenericType_raw,
// token 907,
ves_icall_RuntimeType_GetMethodsByName_native_raw,
// token 909,
ves_icall_RuntimeType_GetPropertiesByName_native_raw,
// token 910,
ves_icall_RuntimeType_GetConstructors_native_raw,
// token 914,
ves_icall_System_RuntimeType_CreateInstanceInternal_raw,
// token 915,
ves_icall_RuntimeType_GetDeclaringMethod_raw,
// token 917,
ves_icall_System_RuntimeType_getFullName_raw,
// token 918,
ves_icall_RuntimeType_GetGenericArgumentsInternal_raw,
// token 921,
ves_icall_RuntimeType_GetGenericParameterPosition,
// token 922,
ves_icall_RuntimeType_GetEvents_native_raw,
// token 923,
ves_icall_RuntimeType_GetFields_native_raw,
// token 926,
ves_icall_RuntimeType_GetInterfaces_raw,
// token 928,
ves_icall_RuntimeType_GetNestedTypes_native_raw,
// token 931,
ves_icall_RuntimeType_GetDeclaringType_raw,
// token 933,
ves_icall_RuntimeType_GetName_raw,
// token 935,
ves_icall_RuntimeType_GetNamespace_raw,
// token 944,
ves_icall_RuntimeType_FunctionPointerReturnAndParameterTypes_raw,
// token 1008,
ves_icall_RuntimeTypeHandle_GetAttributes,
// token 1010,
ves_icall_RuntimeTypeHandle_GetMetadataToken_raw,
// token 1012,
ves_icall_RuntimeTypeHandle_GetGenericTypeDefinition_impl_raw,
// token 1022,
ves_icall_RuntimeTypeHandle_GetCorElementType,
// token 1023,
ves_icall_RuntimeTypeHandle_HasInstantiation,
// token 1024,
ves_icall_RuntimeTypeHandle_IsInstanceOfType_raw,
// token 1026,
ves_icall_RuntimeTypeHandle_HasReferences_raw,
// token 1032,
ves_icall_RuntimeTypeHandle_GetArrayRank_raw,
// token 1033,
ves_icall_RuntimeTypeHandle_GetAssembly_raw,
// token 1034,
ves_icall_RuntimeTypeHandle_GetElementType_raw,
// token 1035,
ves_icall_RuntimeTypeHandle_GetModule_raw,
// token 1036,
ves_icall_RuntimeTypeHandle_GetBaseType_raw,
// token 1044,
ves_icall_RuntimeTypeHandle_type_is_assignable_from_raw,
// token 1045,
ves_icall_RuntimeTypeHandle_IsGenericTypeDefinition,
// token 1046,
ves_icall_RuntimeTypeHandle_GetGenericParameterInfo_raw,
// token 1050,
ves_icall_RuntimeTypeHandle_is_subclass_of_raw,
// token 1051,
ves_icall_RuntimeTypeHandle_IsByRefLike_raw,
// token 1053,
ves_icall_System_RuntimeTypeHandle_internal_from_name_raw,
// token 1057,
ves_icall_System_String_FastAllocateString_raw,
// token 1058,
ves_icall_System_String_InternalIsInterned_raw,
// token 1059,
ves_icall_System_String_InternalIntern_raw,
// token 1351,
ves_icall_System_Type_internal_from_handle_raw,
// token 1511,
ves_icall_System_ValueType_InternalGetHashCode_raw,
// token 1512,
ves_icall_System_ValueType_Equals_raw,
// token 9092,
ves_icall_System_Threading_Interlocked_CompareExchange_Int,
// token 9093,
ves_icall_System_Threading_Interlocked_CompareExchange_Object,
// token 9095,
ves_icall_System_Threading_Interlocked_Decrement_Int,
// token 9096,
ves_icall_System_Threading_Interlocked_Increment_Int,
// token 9097,
ves_icall_System_Threading_Interlocked_Increment_Long,
// token 9098,
ves_icall_System_Threading_Interlocked_Exchange_Int,
// token 9099,
ves_icall_System_Threading_Interlocked_Exchange_Object,
// token 9101,
ves_icall_System_Threading_Interlocked_CompareExchange_Long,
// token 9102,
ves_icall_System_Threading_Interlocked_Exchange_Long,
// token 9103,
ves_icall_System_Threading_Interlocked_Add_Int,
// token 9104,
ves_icall_System_Threading_Interlocked_Add_Long,
// token 9122,
ves_icall_System_Threading_Monitor_Monitor_Enter_raw,
// token 9124,
mono_monitor_exit_icall_raw,
// token 9131,
ves_icall_System_Threading_Monitor_Monitor_pulse_raw,
// token 9133,
ves_icall_System_Threading_Monitor_Monitor_pulse_all_raw,
// token 9135,
ves_icall_System_Threading_Monitor_Monitor_wait_raw,
// token 9137,
ves_icall_System_Threading_Monitor_Monitor_try_enter_with_atomic_var_raw,
// token 9140,
ves_icall_System_Threading_Monitor_Monitor_get_lock_contention_count,
// token 9190,
ves_icall_System_Threading_Thread_InitInternal_raw,
// token 9191,
ves_icall_System_Threading_Thread_GetCurrentThread,
// token 9193,
ves_icall_System_Threading_InternalThread_Thread_free_internal_raw,
// token 9194,
ves_icall_System_Threading_Thread_GetState_raw,
// token 9195,
ves_icall_System_Threading_Thread_SetState_raw,
// token 9196,
ves_icall_System_Threading_Thread_ClrState_raw,
// token 9197,
ves_icall_System_Threading_Thread_SetName_icall_raw,
// token 9199,
ves_icall_System_Threading_Thread_YieldInternal,
// token 9201,
ves_icall_System_Threading_Thread_SetPriority_raw,
// token 10233,
ves_icall_System_Runtime_Loader_AssemblyLoadContext_PrepareForAssemblyLoadContextRelease_raw,
// token 10237,
ves_icall_System_Runtime_Loader_AssemblyLoadContext_GetLoadContextForAssembly_raw,
// token 10239,
ves_icall_System_Runtime_Loader_AssemblyLoadContext_InternalLoadFile_raw,
// token 10240,
ves_icall_System_Runtime_Loader_AssemblyLoadContext_InternalInitializeNativeALC_raw,
// token 10241,
ves_icall_System_Runtime_Loader_AssemblyLoadContext_InternalLoadFromStream_raw,
// token 10242,
ves_icall_System_Runtime_Loader_AssemblyLoadContext_InternalGetLoadedAssemblies_raw,
// token 10659,
ves_icall_System_GCHandle_InternalAlloc_raw,
// token 10660,
ves_icall_System_GCHandle_InternalFree_raw,
// token 10661,
ves_icall_System_GCHandle_InternalGet_raw,
// token 10662,
ves_icall_System_GCHandle_InternalSet_raw,
// token 10680,
ves_icall_System_Runtime_InteropServices_Marshal_GetLastPInvokeError,
// token 10681,
ves_icall_System_Runtime_InteropServices_Marshal_SetLastPInvokeError,
// token 10682,
ves_icall_System_Runtime_InteropServices_Marshal_StructureToPtr_raw,
// token 10727,
ves_icall_System_Runtime_InteropServices_NativeLibrary_LoadByName_raw,
// token 10793,
ves_icall_System_Runtime_CompilerServices_RuntimeHelpers_InternalGetHashCode_raw,
// token 10796,
ves_icall_System_Runtime_CompilerServices_RuntimeHelpers_GetObjectValue_raw,
// token 10804,
ves_icall_System_Runtime_CompilerServices_RuntimeHelpers_GetUninitializedObjectInternal_raw,
// token 10805,
ves_icall_System_Runtime_CompilerServices_RuntimeHelpers_InitializeArray_raw,
// token 10806,
ves_icall_System_Runtime_CompilerServices_RuntimeHelpers_GetSpanDataFrom_raw,
// token 10807,
ves_icall_System_Runtime_CompilerServices_RuntimeHelpers_SufficientExecutionStack,
// token 10808,
ves_icall_System_Runtime_CompilerServices_RuntimeHelpers_InternalBox_raw,
// token 11128,
ves_icall_System_Reflection_Assembly_GetEntryAssembly_raw,
// token 11132,
ves_icall_System_Reflection_Assembly_InternalLoad_raw,
// token 11133,
ves_icall_System_Reflection_Assembly_InternalGetType_raw,
// token 11160,
ves_icall_System_Reflection_AssemblyName_GetNativeName,
// token 11194,
ves_icall_MonoCustomAttrs_GetCustomAttributesInternal_raw,
// token 11201,
ves_icall_MonoCustomAttrs_GetCustomAttributesDataInternal_raw,
// token 11208,
ves_icall_MonoCustomAttrs_IsDefinedInternal_raw,
// token 11219,
ves_icall_System_Reflection_FieldInfo_internal_from_handle_type_raw,
// token 11223,
ves_icall_System_Reflection_FieldInfo_get_marshal_info_raw,
// token 11246,
ves_icall_System_Reflection_LoaderAllocatorScout_Destroy,
// token 11324,
ves_icall_System_Reflection_RuntimeAssembly_GetManifestResourceNames_raw,
// token 11326,
ves_icall_System_Reflection_RuntimeAssembly_GetExportedTypes_raw,
// token 11335,
ves_icall_System_Reflection_RuntimeAssembly_GetInfo_raw,
// token 11337,
ves_icall_System_Reflection_RuntimeAssembly_GetManifestResourceInternal_raw,
// token 11338,
ves_icall_System_Reflection_Assembly_GetManifestModuleInternal_raw,
// token 11345,
ves_icall_System_Reflection_RuntimeCustomAttributeData_ResolveArgumentsInternal_raw,
// token 11360,
ves_icall_RuntimeEventInfo_get_event_info_raw,
// token 11380,
ves_icall_reflection_get_token_raw,
// token 11381,
ves_icall_System_Reflection_EventInfo_internal_from_handle_type_raw,
// token 11389,
ves_icall_RuntimeFieldInfo_ResolveType_raw,
// token 11391,
ves_icall_RuntimeFieldInfo_GetParentType_raw,
// token 11398,
ves_icall_RuntimeFieldInfo_GetFieldOffset_raw,
// token 11399,
ves_icall_RuntimeFieldInfo_GetValueInternal_raw,
// token 11402,
ves_icall_RuntimeFieldInfo_SetValueInternal_raw,
// token 11404,
ves_icall_RuntimeFieldInfo_GetRawConstantValue_raw,
// token 11409,
ves_icall_reflection_get_token_raw,
// token 11415,
ves_icall_get_method_info_raw,
// token 11416,
ves_icall_get_method_attributes,
// token 11423,
ves_icall_System_Reflection_MonoMethodInfo_get_parameter_info_raw,
// token 11425,
ves_icall_System_MonoMethodInfo_get_retval_marshal_raw,
// token 11437,
ves_icall_System_Reflection_RuntimeMethodInfo_GetMethodFromHandleInternalType_native_raw,
// token 11440,
ves_icall_RuntimeMethodInfo_get_name_raw,
// token 11441,
ves_icall_RuntimeMethodInfo_get_base_method_raw,
// token 11442,
ves_icall_reflection_get_token_raw,
// token 11453,
ves_icall_InternalInvoke_raw,
// token 11463,
ves_icall_RuntimeMethodInfo_GetPInvoke_raw,
// token 11469,
ves_icall_RuntimeMethodInfo_MakeGenericMethod_impl_raw,
// token 11470,
ves_icall_RuntimeMethodInfo_GetGenericArguments_raw,
// token 11471,
ves_icall_RuntimeMethodInfo_GetGenericMethodDefinition_raw,
// token 11473,
ves_icall_RuntimeMethodInfo_get_IsGenericMethodDefinition_raw,
// token 11474,
ves_icall_RuntimeMethodInfo_get_IsGenericMethod_raw,
// token 11491,
ves_icall_InvokeClassConstructor_raw,
// token 11493,
ves_icall_InternalInvoke_raw,
// token 11508,
ves_icall_reflection_get_token_raw,
// token 11526,
ves_icall_System_Reflection_RuntimeModule_ResolveMethodToken_raw,
// token 11553,
ves_icall_RuntimePropertyInfo_get_property_info_raw,
// token 11583,
ves_icall_reflection_get_token_raw,
// token 11584,
ves_icall_System_Reflection_RuntimePropertyInfo_internal_from_handle_type_raw,
// token 12123,
ves_icall_DynamicMethod_create_dynamic_method_raw,
// token 12207,
ves_icall_AssemblyBuilder_basic_init_raw,
// token 12208,
ves_icall_AssemblyBuilder_UpdateNativeCustomAttributes_raw,
// token 12392,
ves_icall_ModuleBuilder_basic_init_raw,
// token 12393,
ves_icall_ModuleBuilder_set_wrappers_type_raw,
// token 12397,
ves_icall_ModuleBuilder_getUSIndex_raw,
// token 12398,
ves_icall_ModuleBuilder_getToken_raw,
// token 12399,
ves_icall_ModuleBuilder_getMethodToken_raw,
// token 12404,
ves_icall_ModuleBuilder_RegisterToken_raw,
// token 12455,
ves_icall_TypeBuilder_create_runtime_class_raw,
// token 12942,
ves_icall_System_IO_Stream_HasOverriddenBeginEndRead_raw,
// token 12943,
ves_icall_System_IO_Stream_HasOverriddenBeginEndWrite_raw,
// token 13310,
ves_icall_System_Diagnostics_Debugger_IsAttached_internal,
// token 13315,
ves_icall_System_Diagnostics_StackFrame_GetFrameInfo,
// token 13325,
ves_icall_System_Diagnostics_StackTrace_GetTrace,
// token 14224,
ves_icall_Mono_RuntimeClassHandle_GetTypeFromClass,
// token 14245,
ves_icall_Mono_RuntimeGPtrArrayHandle_GPtrArrayFree,
// token 14247,
ves_icall_Mono_SafeStringMarshal_StringToUtf8,
// token 14249,
ves_icall_Mono_SafeStringMarshal_GFree,
};
static uint8_t corlib_icall_flags [] = {
0,
0,
0,
0,
0,
4,
4,
0,
4,
0,
4,
4,
4,
0,
0,
0,
4,
4,
4,
4,
0,
4,
0,
0,
0,
4,
0,
0,
4,
4,
4,
4,
4,
0,
4,
4,
0,
0,
0,
0,
0,
0,
0,
0,
0,
0,
0,
0,
0,
0,
0,
0,
0,
0,
0,
0,
0,
0,
0,
0,
0,
0,
0,
0,
0,
0,
0,
0,
0,
0,
0,
0,
0,
0,
0,
0,
0,
0,
0,
0,
0,
0,
0,
0,
4,
4,
4,
4,
4,
4,
4,
4,
4,
4,
4,
4,
4,
4,
4,
0,
4,
4,
4,
4,
4,
4,
4,
4,
0,
4,
4,
0,
0,
4,
4,
4,
4,
4,
4,
4,
4,
0,
4,
4,
4,
4,
4,
4,
4,
4,
4,
4,
0,
0,
0,
0,
0,
0,
0,
0,
0,
0,
0,
4,
4,
4,
4,
4,
4,
0,
4,
0,
4,
4,
4,
4,
4,
0,
4,
4,
4,
4,
4,
4,
4,
4,
4,
4,
4,
0,
0,
4,
4,
4,
4,
4,
4,
4,
0,
4,
4,
4,
4,
0,
4,
4,
4,
4,
4,
0,
4,
4,
4,
4,
4,
4,
4,
4,
4,
4,
4,
4,
4,
4,
4,
4,
4,
0,
4,
4,
4,
4,
4,
4,
4,
4,
4,
4,
4,
4,
4,
4,
4,
4,
4,
4,
4,
4,
4,
4,
4,
4,
4,
4,
4,
4,
4,
4,
4,
4,
0,
0,
0,
0,
0,
0,
0,
};

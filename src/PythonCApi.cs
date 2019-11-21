namespace Python.Runtime.Native {
    using System;
    using System.Runtime.InteropServices;

    /// <summary>
    /// Encapsulates the low-level Python C API. Note that it is
    /// the responsibility of the caller to have acquired the GIL
    /// before calling any of these methods.
    /// </summary>
    public static class PythonCApi {
        const string _PythonDll = "FAKE";

        /// <summary>
        /// Export of Macro Py_XIncRef. Use XIncref instead.
        /// Limit this function usage for Testing and Py_Debug builds
        /// </summary>
        /// <param name="ob">PyObject Ptr</param>
        [DllImport(_PythonDll, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Py_IncRef(BorrowedObject ob);

        /// <summary>
        /// Export of Macro Py_XDecRef. Use XDecref instead.
        /// Limit this function usage for Testing and Py_Debug builds
        /// </summary>
        /// <param name="ob">PyObject Ptr</param>
        [DllImport(_PythonDll, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Py_DecRef(BorrowedObject ob);

        [DllImport(_PythonDll, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Py_Initialize();

        [DllImport(_PythonDll, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Py_InitializeEx(int initsigs);

        [DllImport(_PythonDll, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int Py_IsInitialized();

        [DllImport(_PythonDll, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Py_Finalize();

        [DllImport(_PythonDll, CallingConvention = CallingConvention.Cdecl)]
        internal static extern PythonInterpreterHandle Py_NewInterpreter();

        [DllImport(_PythonDll, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Py_EndInterpreter(PythonInterpreterHandle threadState);

        [DllImport(_PythonDll, CallingConvention = CallingConvention.Cdecl)]
        internal static extern BorrowedObject PyThreadState_New(PythonInterpreterHandle interpreter);

        [DllImport(_PythonDll, CallingConvention = CallingConvention.Cdecl)]
        internal static extern BorrowedObject PyThreadState_Get();

        [DllImport(_PythonDll, CallingConvention = CallingConvention.Cdecl)]
        internal static extern BorrowedObject PyThread_get_key_value(BorrowedObject key);

        [DllImport(_PythonDll, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int PyThread_get_thread_ident();

        [DllImport(_PythonDll, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int PyThread_set_key_value(BorrowedObject key, BorrowedObject value);

        [DllImport(_PythonDll, CallingConvention = CallingConvention.Cdecl)]
        internal static extern BorrowedObject PyThreadState_Swap(BorrowedObject key);

        [DllImport(_PythonDll, CallingConvention = CallingConvention.Cdecl)]
        internal static extern BorrowedObject PyGILState_Ensure();

        [DllImport(_PythonDll, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void PyGILState_Release(BorrowedObject gs);


        [DllImport(_PythonDll, CallingConvention = CallingConvention.Cdecl)]
        internal static extern BorrowedObject PyGILState_GetThisThreadState();

        [DllImport(_PythonDll, CallingConvention = CallingConvention.Cdecl)]
        public static extern int Py_Main(
            int argc,
            [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(StrArrayMarshaler))] string[] argv
        );

        [DllImport(_PythonDll, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void PyEval_InitThreads();

        [DllImport(_PythonDll, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int PyEval_ThreadsInitialized();

        [DllImport(_PythonDll, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void PyEval_AcquireLock();

        [DllImport(_PythonDll, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void PyEval_ReleaseLock();

        [DllImport(_PythonDll, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void PyEval_AcquireThread(BorrowedObject tstate);

        [DllImport(_PythonDll, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void PyEval_ReleaseThread(BorrowedObject tstate);

        [DllImport(_PythonDll, CallingConvention = CallingConvention.Cdecl)]
        internal static extern BorrowedObject PyEval_SaveThread();

        [DllImport(_PythonDll, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void PyEval_RestoreThread(BorrowedObject tstate);

        [DllImport(_PythonDll, CallingConvention = CallingConvention.Cdecl)]
        internal static extern BorrowedObject PyEval_GetBuiltins();

        [DllImport(_PythonDll, CallingConvention = CallingConvention.Cdecl)]
        internal static extern BorrowedObject PyEval_GetGlobals();

        [DllImport(_PythonDll, CallingConvention = CallingConvention.Cdecl)]
        internal static extern BorrowedObject PyEval_GetLocals();

        [DllImport(_PythonDll, CallingConvention = CallingConvention.Cdecl)]
        internal static extern BorrowedObject Py_GetProgramName();

        [DllImport(_PythonDll, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Py_SetProgramName(BorrowedObject name);

        [DllImport(_PythonDll, CallingConvention = CallingConvention.Cdecl)]
        internal static extern BorrowedObject Py_GetPythonHome();

        [DllImport(_PythonDll, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Py_SetPythonHome(BorrowedObject home);

        [DllImport(_PythonDll, CallingConvention = CallingConvention.Cdecl)]
        internal static extern BorrowedObject Py_GetPath();

        [DllImport(_PythonDll, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Py_SetPath(BorrowedObject home);

        [DllImport(_PythonDll, CallingConvention = CallingConvention.Cdecl)]
        internal static extern BorrowedObject Py_GetVersion();

        [DllImport(_PythonDll, CallingConvention = CallingConvention.Cdecl)]
        internal static extern BorrowedObject Py_GetPlatform();

        [DllImport(_PythonDll, CallingConvention = CallingConvention.Cdecl)]
        internal static extern BorrowedObject Py_GetCopyright();

        [DllImport(_PythonDll, CallingConvention = CallingConvention.Cdecl)]
        internal static extern BorrowedObject Py_GetCompiler();

        [DllImport(_PythonDll, CallingConvention = CallingConvention.Cdecl)]
        internal static extern BorrowedObject Py_GetBuildInfo();

        [DllImport(_PythonDll, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int PyRun_SimpleString(string code);

        [DllImport(_PythonDll, CallingConvention = CallingConvention.Cdecl)]
        internal static extern BorrowedObject PyRun_String(string code, BorrowedObject st, BorrowedObject globals, BorrowedObject locals);

        [DllImport(_PythonDll, CallingConvention = CallingConvention.Cdecl)]
        internal static extern BorrowedObject PyEval_EvalCode(BorrowedObject co, BorrowedObject globals, BorrowedObject locals);

        [DllImport(_PythonDll, CallingConvention = CallingConvention.Cdecl)]
        internal static extern BorrowedObject Py_CompileString(string code, string file, BorrowedObject tok);

        [DllImport(_PythonDll, CallingConvention = CallingConvention.Cdecl)]
        internal static extern BorrowedObject PyImport_ExecCodeModule(string name, BorrowedObject code);

        [DllImport(_PythonDll, CallingConvention = CallingConvention.Cdecl)]
        internal static extern BorrowedObject PyCFunction_NewEx(BorrowedObject ml, BorrowedObject self, BorrowedObject mod);

        [DllImport(_PythonDll, CallingConvention = CallingConvention.Cdecl)]
        internal static extern BorrowedObject PyCFunction_Call(BorrowedObject func, BorrowedObject args, BorrowedObject kw);

        [DllImport(_PythonDll, CallingConvention = CallingConvention.Cdecl)]
        internal static extern BorrowedObject PyInstance_New(BorrowedObject cls, BorrowedObject args, BorrowedObject kw);

        [DllImport(_PythonDll, CallingConvention = CallingConvention.Cdecl)]
        internal static extern BorrowedObject PyInstance_NewRaw(BorrowedObject cls, BorrowedObject dict);

        [DllImport(_PythonDll, CallingConvention = CallingConvention.Cdecl)]
        internal static extern BorrowedObject PyMethod_New(BorrowedObject func, BorrowedObject self, BorrowedObject cls);


        //====================================================================
        // Python abstract object API
        //====================================================================

        [DllImport(_PythonDll, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int PyObject_HasAttrString(BorrowedObject pointer, string name);

        [DllImport(_PythonDll, CallingConvention = CallingConvention.Cdecl)]
        internal static extern BorrowedObject PyObject_GetAttrString(BorrowedObject pointer, string name);

        [DllImport(_PythonDll, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int PyObject_SetAttrString(BorrowedObject pointer, string name, BorrowedObject value);

        [DllImport(_PythonDll, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int PyObject_HasAttr(BorrowedObject pointer, BorrowedObject name);

        [DllImport(_PythonDll, CallingConvention = CallingConvention.Cdecl)]
        internal static extern BorrowedObject PyObject_GetAttr(BorrowedObject pointer, BorrowedObject name);

        [DllImport(_PythonDll, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int PyObject_SetAttr(BorrowedObject pointer, BorrowedObject name, BorrowedObject value);

        [DllImport(_PythonDll, CallingConvention = CallingConvention.Cdecl)]
        internal static extern BorrowedObject PyObject_GetItem(BorrowedObject pointer, BorrowedObject key);

        [DllImport(_PythonDll, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int PyObject_SetItem(BorrowedObject pointer, BorrowedObject key, BorrowedObject value);

        [DllImport(_PythonDll, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int PyObject_DelItem(BorrowedObject pointer, BorrowedObject key);

        [DllImport(_PythonDll, CallingConvention = CallingConvention.Cdecl)]
        internal static extern BorrowedObject PyObject_GetIter(BorrowedObject op);

        [DllImport(_PythonDll, CallingConvention = CallingConvention.Cdecl)]
        internal static extern BorrowedObject PyObject_Call(BorrowedObject pointer, BorrowedObject args, BorrowedObject kw);

        [DllImport(_PythonDll, CallingConvention = CallingConvention.Cdecl)]
        internal static extern BorrowedObject PyObject_CallObject(BorrowedObject pointer, BorrowedObject args);

        [DllImport(_PythonDll, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int PyObject_RichCompareBool(BorrowedObject value1, BorrowedObject value2, int opid);


        [DllImport(_PythonDll, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int PyObject_IsInstance(BorrowedObject ob, BorrowedObject type);

        [DllImport(_PythonDll, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int PyObject_IsSubclass(BorrowedObject ob, BorrowedObject type);

        [DllImport(_PythonDll, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int PyCallable_Check(BorrowedObject pointer);

        [DllImport(_PythonDll, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int PyObject_IsTrue(BorrowedObject pointer);

        [DllImport(_PythonDll, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int PyObject_Not(BorrowedObject pointer);

        [DllImport(_PythonDll, CallingConvention = CallingConvention.Cdecl, EntryPoint = "PyObject_Size")]
        private static extern BorrowedObject _PyObject_Size(BorrowedObject pointer);

        [DllImport(_PythonDll, CallingConvention = CallingConvention.Cdecl)]
        internal static extern BorrowedObject PyObject_Hash(BorrowedObject op);

        [DllImport(_PythonDll, CallingConvention = CallingConvention.Cdecl)]
        internal static extern BorrowedObject PyObject_Repr(BorrowedObject pointer);

        [DllImport(_PythonDll, CallingConvention = CallingConvention.Cdecl)]
        internal static extern BorrowedObject PyObject_Str(BorrowedObject pointer);

        [DllImport(_PythonDll, CallingConvention = CallingConvention.Cdecl,
            EntryPoint = "PyObject_Str")]
        internal static extern BorrowedObject PyObject_Unicode(BorrowedObject pointer);


        [DllImport(_PythonDll, CallingConvention = CallingConvention.Cdecl)]
        internal static extern BorrowedObject PyObject_Dir(BorrowedObject pointer);


        //====================================================================
        // Python number API
        //====================================================================

        [DllImport(_PythonDll, CallingConvention = CallingConvention.Cdecl,
            EntryPoint = "PyNumber_Long")]
        internal static extern BorrowedObject PyNumber_Int(BorrowedObject ob);

        [DllImport(_PythonDll, CallingConvention = CallingConvention.Cdecl)]
        internal static extern BorrowedObject PyNumber_Long(BorrowedObject ob);

        [DllImport(_PythonDll, CallingConvention = CallingConvention.Cdecl)]
        internal static extern BorrowedObject PyNumber_Float(BorrowedObject ob);

        [DllImport(_PythonDll, CallingConvention = CallingConvention.Cdecl)]
        internal static extern bool PyNumber_Check(BorrowedObject ob);

        [DllImport(_PythonDll, CallingConvention = CallingConvention.Cdecl,
            EntryPoint = "PyLong_FromLong")]
        private static extern BorrowedObject PyInt_FromLong(BorrowedObject value);

        [DllImport(_PythonDll, CallingConvention = CallingConvention.Cdecl,
            EntryPoint = "PyLong_AsLong")]
        internal static extern int PyInt_AsLong(BorrowedObject value);

        [DllImport(_PythonDll, CallingConvention = CallingConvention.Cdecl,
            EntryPoint = "PyLong_FromString")]
        internal static extern BorrowedObject PyInt_FromString(string value, BorrowedObject end, int radix);


        [DllImport(_PythonDll, CallingConvention = CallingConvention.Cdecl)]
        internal static extern BorrowedObject PyLong_FromLong(long value);

        [DllImport(_PythonDll, CallingConvention = CallingConvention.Cdecl,
            EntryPoint = "PyLong_FromUnsignedLong")]
        internal static extern BorrowedObject PyLong_FromUnsignedLong32(uint value);

        [DllImport(_PythonDll, CallingConvention = CallingConvention.Cdecl,
            EntryPoint = "PyLong_FromUnsignedLong")]
        internal static extern BorrowedObject PyLong_FromUnsignedLong64(ulong value);

        [DllImport(_PythonDll, CallingConvention = CallingConvention.Cdecl)]
        internal static extern BorrowedObject PyLong_FromDouble(double value);

        [DllImport(_PythonDll, CallingConvention = CallingConvention.Cdecl)]
        internal static extern BorrowedObject PyLong_FromLongLong(long value);

        [DllImport(_PythonDll, CallingConvention = CallingConvention.Cdecl)]
        internal static extern BorrowedObject PyLong_FromUnsignedLongLong(ulong value);

        [DllImport(_PythonDll, CallingConvention = CallingConvention.Cdecl)]
        internal static extern BorrowedObject PyLong_FromString(string value, BorrowedObject end, int radix);

        [DllImport(_PythonDll, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int PyLong_AsLong(BorrowedObject value);

        [DllImport(_PythonDll, CallingConvention = CallingConvention.Cdecl,
            EntryPoint = "PyLong_AsUnsignedLong")]
        internal static extern uint PyLong_AsUnsignedLong32(BorrowedObject value);

        [DllImport(_PythonDll, CallingConvention = CallingConvention.Cdecl,
            EntryPoint = "PyLong_AsUnsignedLong")]
        internal static extern ulong PyLong_AsUnsignedLong64(BorrowedObject value);

        [DllImport(_PythonDll, CallingConvention = CallingConvention.Cdecl)]
        internal static extern long PyLong_AsLongLong(BorrowedObject value);

        [DllImport(_PythonDll, CallingConvention = CallingConvention.Cdecl)]
        internal static extern ulong PyLong_AsUnsignedLongLong(BorrowedObject value);

        [DllImport(_PythonDll, CallingConvention = CallingConvention.Cdecl)]
        internal static extern BorrowedObject PyFloat_FromDouble(double value);

        [DllImport(_PythonDll, CallingConvention = CallingConvention.Cdecl)]
        internal static extern BorrowedObject PyFloat_FromString(BorrowedObject value, BorrowedObject junk);

        [DllImport(_PythonDll, CallingConvention = CallingConvention.Cdecl)]
        internal static extern double PyFloat_AsDouble(BorrowedObject ob);

        [DllImport(_PythonDll, CallingConvention = CallingConvention.Cdecl)]
        internal static extern BorrowedObject PyNumber_Add(BorrowedObject o1, BorrowedObject o2);

        [DllImport(_PythonDll, CallingConvention = CallingConvention.Cdecl)]
        internal static extern BorrowedObject PyNumber_Subtract(BorrowedObject o1, BorrowedObject o2);

        [DllImport(_PythonDll, CallingConvention = CallingConvention.Cdecl)]
        internal static extern BorrowedObject PyNumber_Multiply(BorrowedObject o1, BorrowedObject o2);

        [DllImport(_PythonDll, CallingConvention = CallingConvention.Cdecl)]
        internal static extern BorrowedObject PyNumber_TrueDivide(BorrowedObject o1, BorrowedObject o2);

        [DllImport(_PythonDll, CallingConvention = CallingConvention.Cdecl)]
        internal static extern BorrowedObject PyNumber_And(BorrowedObject o1, BorrowedObject o2);

        [DllImport(_PythonDll, CallingConvention = CallingConvention.Cdecl)]
        internal static extern BorrowedObject PyNumber_Xor(BorrowedObject o1, BorrowedObject o2);

        [DllImport(_PythonDll, CallingConvention = CallingConvention.Cdecl)]
        internal static extern BorrowedObject PyNumber_Or(BorrowedObject o1, BorrowedObject o2);

        [DllImport(_PythonDll, CallingConvention = CallingConvention.Cdecl)]
        internal static extern BorrowedObject PyNumber_Lshift(BorrowedObject o1, BorrowedObject o2);

        [DllImport(_PythonDll, CallingConvention = CallingConvention.Cdecl)]
        internal static extern BorrowedObject PyNumber_Rshift(BorrowedObject o1, BorrowedObject o2);

        [DllImport(_PythonDll, CallingConvention = CallingConvention.Cdecl)]
        internal static extern BorrowedObject PyNumber_Power(BorrowedObject o1, BorrowedObject o2);

        [DllImport(_PythonDll, CallingConvention = CallingConvention.Cdecl)]
        internal static extern BorrowedObject PyNumber_Remainder(BorrowedObject o1, BorrowedObject o2);

        [DllImport(_PythonDll, CallingConvention = CallingConvention.Cdecl)]
        internal static extern BorrowedObject PyNumber_InPlaceAdd(BorrowedObject o1, BorrowedObject o2);

        [DllImport(_PythonDll, CallingConvention = CallingConvention.Cdecl)]
        internal static extern BorrowedObject PyNumber_InPlaceSubtract(BorrowedObject o1, BorrowedObject o2);

        [DllImport(_PythonDll, CallingConvention = CallingConvention.Cdecl)]
        internal static extern BorrowedObject PyNumber_InPlaceMultiply(BorrowedObject o1, BorrowedObject o2);

        [DllImport(_PythonDll, CallingConvention = CallingConvention.Cdecl)]
        internal static extern BorrowedObject PyNumber_InPlaceTrueDivide(BorrowedObject o1, BorrowedObject o2);

        [DllImport(_PythonDll, CallingConvention = CallingConvention.Cdecl)]
        internal static extern BorrowedObject PyNumber_InPlaceAnd(BorrowedObject o1, BorrowedObject o2);

        [DllImport(_PythonDll, CallingConvention = CallingConvention.Cdecl)]
        internal static extern BorrowedObject PyNumber_InPlaceXor(BorrowedObject o1, BorrowedObject o2);

        [DllImport(_PythonDll, CallingConvention = CallingConvention.Cdecl)]
        internal static extern BorrowedObject PyNumber_InPlaceOr(BorrowedObject o1, BorrowedObject o2);

        [DllImport(_PythonDll, CallingConvention = CallingConvention.Cdecl)]
        internal static extern BorrowedObject PyNumber_InPlaceLshift(BorrowedObject o1, BorrowedObject o2);

        [DllImport(_PythonDll, CallingConvention = CallingConvention.Cdecl)]
        internal static extern BorrowedObject PyNumber_InPlaceRshift(BorrowedObject o1, BorrowedObject o2);

        [DllImport(_PythonDll, CallingConvention = CallingConvention.Cdecl)]
        internal static extern BorrowedObject PyNumber_InPlacePower(BorrowedObject o1, BorrowedObject o2);

        [DllImport(_PythonDll, CallingConvention = CallingConvention.Cdecl)]
        internal static extern BorrowedObject PyNumber_InPlaceRemainder(BorrowedObject o1, BorrowedObject o2);

        [DllImport(_PythonDll, CallingConvention = CallingConvention.Cdecl)]
        internal static extern BorrowedObject PyNumber_Negative(BorrowedObject o1);

        [DllImport(_PythonDll, CallingConvention = CallingConvention.Cdecl)]
        internal static extern BorrowedObject PyNumber_Positive(BorrowedObject o1);

        [DllImport(_PythonDll, CallingConvention = CallingConvention.Cdecl)]
        internal static extern BorrowedObject PyNumber_Invert(BorrowedObject o1);


        //====================================================================
        // Python sequence API
        //====================================================================

        [DllImport(_PythonDll, CallingConvention = CallingConvention.Cdecl)]
        internal static extern bool PySequence_Check(BorrowedObject pointer);

        [DllImport(_PythonDll, CallingConvention = CallingConvention.Cdecl)]
        private static extern BorrowedObject PySequence_GetItem(BorrowedObject pointer, BorrowedObject index);

        [DllImport(_PythonDll, CallingConvention = CallingConvention.Cdecl)]
        private static extern int PySequence_SetItem(BorrowedObject pointer, BorrowedObject index, BorrowedObject value);

        [DllImport(_PythonDll, CallingConvention = CallingConvention.Cdecl)]
        private static extern int PySequence_DelItem(BorrowedObject pointer, BorrowedObject index);

        [DllImport(_PythonDll, CallingConvention = CallingConvention.Cdecl)]
        private static extern BorrowedObject PySequence_GetSlice(BorrowedObject pointer, BorrowedObject i1, BorrowedObject i2);

        [DllImport(_PythonDll, CallingConvention = CallingConvention.Cdecl)]
        private static extern int PySequence_SetSlice(BorrowedObject pointer, BorrowedObject i1, BorrowedObject i2, BorrowedObject v);

        [DllImport(_PythonDll, CallingConvention = CallingConvention.Cdecl)]
        private static extern int PySequence_DelSlice(BorrowedObject pointer, BorrowedObject i1, BorrowedObject i2);

        [DllImport(_PythonDll, CallingConvention = CallingConvention.Cdecl, EntryPoint = "PySequence_Size")]
        private static extern BorrowedObject _PySequence_Size(BorrowedObject pointer);

        [DllImport(_PythonDll, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int PySequence_Contains(BorrowedObject pointer, BorrowedObject item);

        [DllImport(_PythonDll, CallingConvention = CallingConvention.Cdecl)]
        internal static extern BorrowedObject PySequence_Concat(BorrowedObject pointer, BorrowedObject other);

        [DllImport(_PythonDll, CallingConvention = CallingConvention.Cdecl)]
        private static extern BorrowedObject PySequence_Repeat(BorrowedObject pointer, BorrowedObject count);

        [DllImport(_PythonDll, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int PySequence_Index(BorrowedObject pointer, BorrowedObject item);

        [DllImport(_PythonDll, CallingConvention = CallingConvention.Cdecl, EntryPoint = "PySequence_Count")]
        private static extern BorrowedObject _PySequence_Count(BorrowedObject pointer, BorrowedObject value);

        [DllImport(_PythonDll, CallingConvention = CallingConvention.Cdecl)]
        internal static extern BorrowedObject PySequence_Tuple(BorrowedObject pointer);

        [DllImport(_PythonDll, CallingConvention = CallingConvention.Cdecl)]
        internal static extern BorrowedObject PySequence_List(BorrowedObject pointer);


        //====================================================================
        // Python string API
        //====================================================================
        [DllImport(_PythonDll, CallingConvention = CallingConvention.Cdecl)]
        internal static extern BorrowedObject PyBytes_FromString(string op);

        [DllImport(_PythonDll, CallingConvention = CallingConvention.Cdecl, EntryPoint = "PyBytes_Size")]
        private static extern BorrowedObject _PyBytes_Size(BorrowedObject op);

        [DllImport(_PythonDll, CallingConvention = CallingConvention.Cdecl,
            EntryPoint = "PyUnicode_FromStringAndSize")]
        internal static extern BorrowedObject _PyString_FromStringAndSize(
            [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Utf8Marshaler))] string value,
            BorrowedObject size
        );

        [DllImport(_PythonDll, CallingConvention = CallingConvention.Cdecl)]
        private static extern BorrowedObject PyUnicode_FromStringAndSize(BorrowedObject value, BorrowedObject size);

        [DllImport(_PythonDll, CallingConvention = CallingConvention.Cdecl)]
        internal static extern BorrowedObject PyUnicode_FromObject(BorrowedObject ob);

        [DllImport(_PythonDll, CallingConvention = CallingConvention.Cdecl)]
        internal static extern BorrowedObject PyUnicode_FromEncodedObject(BorrowedObject ob, BorrowedObject enc, BorrowedObject err);

        [DllImport(_PythonDll, CallingConvention = CallingConvention.Cdecl)]
        private static extern BorrowedObject PyUnicode_FromKindAndData(
            int kind,
            [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UcsMarshaler))] string s,
            BorrowedObject size
        );

        [DllImport(_PythonDll, CallingConvention = CallingConvention.Cdecl, EntryPoint = "PyUnicode_GetSize")]
        private static extern BorrowedObject _PyUnicode_GetSize(BorrowedObject ob);

        [DllImport(_PythonDll, CallingConvention = CallingConvention.Cdecl)]
        internal static extern BorrowedObject PyUnicode_AsUnicode(BorrowedObject ob);

        [DllImport(_PythonDll, CallingConvention = CallingConvention.Cdecl)]
        internal static extern BorrowedObject PyUnicode_FromOrdinal(int c);


        //====================================================================
        // Python dictionary API
        //====================================================================

        [DllImport(_PythonDll, CallingConvention = CallingConvention.Cdecl)]
        internal static extern BorrowedObject PyDict_New();

        [DllImport(_PythonDll, CallingConvention = CallingConvention.Cdecl)]
        internal static extern BorrowedObject PyDictProxy_New(BorrowedObject dict);

        [DllImport(_PythonDll, CallingConvention = CallingConvention.Cdecl)]
        internal static extern BorrowedObject PyDict_GetItem(BorrowedObject pointer, BorrowedObject key);

        [DllImport(_PythonDll, CallingConvention = CallingConvention.Cdecl)]
        internal static extern BorrowedObject PyDict_GetItemString(BorrowedObject pointer, string key);

        [DllImport(_PythonDll, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int PyDict_SetItem(BorrowedObject pointer, BorrowedObject key, BorrowedObject value);

        [DllImport(_PythonDll, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int PyDict_SetItemString(BorrowedObject pointer, string key, BorrowedObject value);

        [DllImport(_PythonDll, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int PyDict_DelItem(BorrowedObject pointer, BorrowedObject key);

        [DllImport(_PythonDll, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int PyDict_DelItemString(BorrowedObject pointer, string key);

        [DllImport(_PythonDll, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int PyMapping_HasKey(BorrowedObject pointer, BorrowedObject key);

        [DllImport(_PythonDll, CallingConvention = CallingConvention.Cdecl)]
        internal static extern BorrowedObject PyDict_Keys(BorrowedObject pointer);

        [DllImport(_PythonDll, CallingConvention = CallingConvention.Cdecl)]
        internal static extern BorrowedObject PyDict_Values(BorrowedObject pointer);

        [DllImport(_PythonDll, CallingConvention = CallingConvention.Cdecl)]
        internal static extern BorrowedObject PyDict_Items(BorrowedObject pointer);

        [DllImport(_PythonDll, CallingConvention = CallingConvention.Cdecl)]
        internal static extern BorrowedObject PyDict_Copy(BorrowedObject pointer);

        [DllImport(_PythonDll, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int PyDict_Update(BorrowedObject pointer, BorrowedObject other);

        [DllImport(_PythonDll, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void PyDict_Clear(BorrowedObject pointer);

        [DllImport(_PythonDll, CallingConvention = CallingConvention.Cdecl, EntryPoint = "PyDict_Size")]
        internal static extern BorrowedObject _PyDict_Size(BorrowedObject pointer);


        //====================================================================
        // Python list API
        //====================================================================
        [DllImport(_PythonDll, CallingConvention = CallingConvention.Cdecl)]
        private static extern BorrowedObject PyList_New(BorrowedObject size);

        [DllImport(_PythonDll, CallingConvention = CallingConvention.Cdecl)]
        internal static extern BorrowedObject PyList_AsTuple(BorrowedObject pointer);

        [DllImport(_PythonDll, CallingConvention = CallingConvention.Cdecl)]
        private static extern BorrowedObject PyList_GetItem(BorrowedObject pointer, BorrowedObject index);

        [DllImport(_PythonDll, CallingConvention = CallingConvention.Cdecl)]
        private static extern int PyList_SetItem(BorrowedObject pointer, BorrowedObject index, BorrowedObject value);

        [DllImport(_PythonDll, CallingConvention = CallingConvention.Cdecl)]
        private static extern int PyList_Insert(BorrowedObject pointer, BorrowedObject index, BorrowedObject value);

        [DllImport(_PythonDll, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int PyList_Append(BorrowedObject pointer, BorrowedObject value);

        [DllImport(_PythonDll, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int PyList_Reverse(BorrowedObject pointer);

        [DllImport(_PythonDll, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int PyList_Sort(BorrowedObject pointer);

        [DllImport(_PythonDll, CallingConvention = CallingConvention.Cdecl)]
        private static extern BorrowedObject PyList_GetSlice(BorrowedObject pointer, BorrowedObject start, BorrowedObject end);

        [DllImport(_PythonDll, CallingConvention = CallingConvention.Cdecl)]
        private static extern int PyList_SetSlice(BorrowedObject pointer, BorrowedObject start, BorrowedObject end, BorrowedObject value);

        [DllImport(_PythonDll, CallingConvention = CallingConvention.Cdecl, EntryPoint = "PyList_Size")]
        private static extern BorrowedObject _PyList_Size(BorrowedObject pointer);

        //====================================================================
        // Python tuple API
        //====================================================================

        [DllImport(_PythonDll, CallingConvention = CallingConvention.Cdecl)]
        private static extern BorrowedObject PyTuple_New(BorrowedObject size);

        [DllImport(_PythonDll, CallingConvention = CallingConvention.Cdecl)]
        private static extern BorrowedObject PyTuple_GetItem(BorrowedObject pointer, BorrowedObject index);

        [DllImport(_PythonDll, CallingConvention = CallingConvention.Cdecl)]
        private static extern int PyTuple_SetItem(BorrowedObject pointer, BorrowedObject index, BorrowedObject value);

        [DllImport(_PythonDll, CallingConvention = CallingConvention.Cdecl)]
        private static extern BorrowedObject PyTuple_GetSlice(BorrowedObject pointer, BorrowedObject start, BorrowedObject end);

        [DllImport(_PythonDll, CallingConvention = CallingConvention.Cdecl, EntryPoint = "PyTuple_Size")]
        private static extern BorrowedObject _PyTuple_Size(BorrowedObject pointer);


        //====================================================================
        // Python iterator API
        //====================================================================

        [DllImport(_PythonDll, CallingConvention = CallingConvention.Cdecl)]
        internal static extern BorrowedObject PyIter_Next(BorrowedObject pointer);


        //====================================================================
        // Python module API
        //====================================================================

        [DllImport(_PythonDll, CallingConvention = CallingConvention.Cdecl)]
        internal static extern BorrowedObject PyModule_New(string name);

        [DllImport(_PythonDll, CallingConvention = CallingConvention.Cdecl)]
        internal static extern string PyModule_GetName(BorrowedObject module);

        [DllImport(_PythonDll, CallingConvention = CallingConvention.Cdecl)]
        internal static extern BorrowedObject PyModule_GetDict(BorrowedObject module);

        [DllImport(_PythonDll, CallingConvention = CallingConvention.Cdecl)]
        internal static extern string PyModule_GetFilename(BorrowedObject module);

        [DllImport(_PythonDll, CallingConvention = CallingConvention.Cdecl)]
        internal static extern BorrowedObject PyModule_Create2(BorrowedObject module, int apiver);

        [DllImport(_PythonDll, CallingConvention = CallingConvention.Cdecl)]
        internal static extern BorrowedObject PyImport_Import(BorrowedObject name);

        [DllImport(_PythonDll, CallingConvention = CallingConvention.Cdecl)]
        internal static extern BorrowedObject PyImport_ImportModule(string name);

        [DllImport(_PythonDll, CallingConvention = CallingConvention.Cdecl)]
        internal static extern BorrowedObject PyImport_ReloadModule(BorrowedObject module);

        [DllImport(_PythonDll, CallingConvention = CallingConvention.Cdecl)]
        internal static extern BorrowedObject PyImport_AddModule(string name);

        [DllImport(_PythonDll, CallingConvention = CallingConvention.Cdecl)]
        internal static extern BorrowedObject PyImport_GetModuleDict();

        [DllImport(_PythonDll, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void PySys_SetArgvEx(
            int argc,
            [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(StrArrayMarshaler))] string[] argv,
            int updatepath
        );


        [DllImport(_PythonDll, CallingConvention = CallingConvention.Cdecl)]
        internal static extern BorrowedObject PySys_GetObject(string name);

        [DllImport(_PythonDll, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int PySys_SetObject(string name, BorrowedObject ob);


        //====================================================================
        // Python type object API
        //====================================================================

        [DllImport(_PythonDll, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void PyType_Modified(BorrowedObject type);

        [DllImport(_PythonDll, CallingConvention = CallingConvention.Cdecl)]
        internal static extern bool PyType_IsSubtype(BorrowedObject t1, BorrowedObject t2);

        [DllImport(_PythonDll, CallingConvention = CallingConvention.Cdecl)]
        internal static extern BorrowedObject PyType_GenericNew(BorrowedObject type, BorrowedObject args, BorrowedObject kw);

        [DllImport(_PythonDll, CallingConvention = CallingConvention.Cdecl)]
        private static extern BorrowedObject PyType_GenericAlloc(BorrowedObject type, BorrowedObject n);

        [DllImport(_PythonDll, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int PyType_Ready(BorrowedObject type);

        [DllImport(_PythonDll, CallingConvention = CallingConvention.Cdecl)]
        internal static extern BorrowedObject _PyType_Lookup(BorrowedObject type, BorrowedObject name);

        [DllImport(_PythonDll, CallingConvention = CallingConvention.Cdecl)]
        internal static extern BorrowedObject PyObject_GenericGetAttr(BorrowedObject obj, BorrowedObject name);

        [DllImport(_PythonDll, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int PyObject_GenericSetAttr(BorrowedObject obj, BorrowedObject name, BorrowedObject value);

        [DllImport(_PythonDll, CallingConvention = CallingConvention.Cdecl)]
        internal static extern BorrowedObject _PyObject_GetDictPtr(BorrowedObject obj);

        [DllImport(_PythonDll, CallingConvention = CallingConvention.Cdecl)]
        internal static extern BorrowedObject PyObject_GC_New(BorrowedObject tp);

        [DllImport(_PythonDll, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void PyObject_GC_Del(BorrowedObject tp);

        [DllImport(_PythonDll, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void PyObject_GC_Track(BorrowedObject tp);

        [DllImport(_PythonDll, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void PyObject_GC_UnTrack(BorrowedObject tp);


        //====================================================================
        // Python memory API
        //====================================================================

        [DllImport(_PythonDll, CallingConvention = CallingConvention.Cdecl)]
        private static extern BorrowedObject PyMem_Malloc(BorrowedObject size);

        [DllImport(_PythonDll, CallingConvention = CallingConvention.Cdecl)]
        private static extern BorrowedObject PyMem_Realloc(BorrowedObject ptr, BorrowedObject size);

        [DllImport(_PythonDll, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void PyMem_Free(BorrowedObject ptr);


        //====================================================================
        // Python exception API
        //====================================================================

        [DllImport(_PythonDll, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void PyErr_SetString(BorrowedObject ob, string message);

        [DllImport(_PythonDll, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void PyErr_SetObject(BorrowedObject ob, BorrowedObject message);

        [DllImport(_PythonDll, CallingConvention = CallingConvention.Cdecl)]
        internal static extern BorrowedObject PyErr_SetFromErrno(BorrowedObject ob);

        [DllImport(_PythonDll, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void PyErr_SetNone(BorrowedObject ob);

        [DllImport(_PythonDll, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int PyErr_ExceptionMatches(BorrowedObject exception);

        [DllImport(_PythonDll, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int PyErr_GivenExceptionMatches(BorrowedObject ob, BorrowedObject val);

        [DllImport(_PythonDll, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void PyErr_NormalizeException(BorrowedObject ob, BorrowedObject val, BorrowedObject tb);

        [DllImport(_PythonDll, CallingConvention = CallingConvention.Cdecl)]
        internal static extern BorrowedObject PyErr_Occurred();

        [DllImport(_PythonDll, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void PyErr_Fetch(ref BorrowedObject ob, ref BorrowedObject val, ref BorrowedObject tb);

        [DllImport(_PythonDll, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void PyErr_Restore(BorrowedObject ob, BorrowedObject val, BorrowedObject tb);

        [DllImport(_PythonDll, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void PyErr_Clear();

        [DllImport(_PythonDll, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void PyErr_Print();


        //====================================================================
        // Miscellaneous
        //====================================================================

        [DllImport(_PythonDll, CallingConvention = CallingConvention.Cdecl)]
        internal static extern BorrowedObject PyMethod_Self(BorrowedObject ob);

        [DllImport(_PythonDll, CallingConvention = CallingConvention.Cdecl)]
        internal static extern BorrowedObject PyMethod_Function(BorrowedObject ob);

        [DllImport(_PythonDll, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int Py_AddPendingCall(BorrowedObject func, BorrowedObject arg);

        [DllImport(_PythonDll, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int Py_MakePendingCalls();
    }
}
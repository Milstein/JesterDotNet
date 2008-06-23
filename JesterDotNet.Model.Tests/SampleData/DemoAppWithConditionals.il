
//  Microsoft (R) .NET Framework IL Disassembler.  Version 2.0.50727.42
//  Copyright (c) Microsoft Corporation.  All rights reserved.



// Metadata version: v2.0.50727
.assembly extern mscorlib
{
  .publickeytoken = (B7 7A 5C 56 19 34 E0 89 )                         // .z\V.4..
  .ver 2:0:0:0
}
.assembly DemoAppWithConditionals
{
  .custom instance void [mscorlib]System.Reflection.AssemblyFileVersionAttribute::.ctor(string) = ( 01 00 07 31 2E 30 2E 30 2E 30 00 00 )             // ...1.0.0.0..
  .custom instance void [mscorlib]System.Runtime.InteropServices.GuidAttribute::.ctor(string) = ( 01 00 24 63 64 33 36 39 63 63 31 2D 32 37 34 34   // ..$cd369cc1-2744
                                                                                                  2D 34 39 30 61 2D 38 30 39 35 2D 33 31 61 37 37   // -490a-8095-31a77
                                                                                                  35 35 62 63 38 63 38 00 00 )                      // 55bc8c8..
  .custom instance void [mscorlib]System.Runtime.InteropServices.ComVisibleAttribute::.ctor(bool) = ( 01 00 00 00 00 ) 
  .custom instance void [mscorlib]System.Reflection.AssemblyTrademarkAttribute::.ctor(string) = ( 01 00 00 00 00 ) 
  .custom instance void [mscorlib]System.Reflection.AssemblyCopyrightAttribute::.ctor(string) = ( 01 00 12 43 6F 70 79 72 69 67 68 74 20 C2 A9 20   // ...Copyright .. 
                                                                                                  20 32 30 30 37 00 00 )                            //  2007..
  .custom instance void [mscorlib]System.Reflection.AssemblyProductAttribute::.ctor(string) = ( 01 00 17 44 65 6D 6F 41 70 70 57 69 74 68 43 6F   // ...DemoAppWithCo
                                                                                                6E 64 69 74 69 6F 6E 61 6C 73 00 00 )             // nditionals..
  .custom instance void [mscorlib]System.Reflection.AssemblyCompanyAttribute::.ctor(string) = ( 01 00 00 00 00 ) 
  .custom instance void [mscorlib]System.Reflection.AssemblyConfigurationAttribute::.ctor(string) = ( 01 00 00 00 00 ) 
  .custom instance void [mscorlib]System.Reflection.AssemblyDescriptionAttribute::.ctor(string) = ( 01 00 00 00 00 ) 
  .custom instance void [mscorlib]System.Reflection.AssemblyTitleAttribute::.ctor(string) = ( 01 00 17 44 65 6D 6F 41 70 70 57 69 74 68 43 6F   // ...DemoAppWithCo
                                                                                              6E 64 69 74 69 6F 6E 61 6C 73 00 00 )             // nditionals..

  // --- The following custom attribute is added automatically, do not uncomment -------
  //  .custom instance void [mscorlib]System.Diagnostics.DebuggableAttribute::.ctor(valuetype [mscorlib]System.Diagnostics.DebuggableAttribute/DebuggingModes) = ( 01 00 07 01 00 00 00 00 ) 

  .custom instance void [mscorlib]System.Runtime.CompilerServices.CompilationRelaxationsAttribute::.ctor(int32) = ( 01 00 08 00 00 00 00 00 ) 
  .custom instance void [mscorlib]System.Runtime.CompilerServices.RuntimeCompatibilityAttribute::.ctor() = ( 01 00 01 00 54 02 16 57 72 61 70 4E 6F 6E 45 78   // ....T..WrapNonEx
                                                                                                             63 65 70 74 69 6F 6E 54 68 72 6F 77 73 01 )       // ceptionThrows.
  .hash algorithm 0x00008004
  .ver 1:0:0:0
}
.module DemoAppWithConditionals.exe
// MVID: {ECDB901D-F98F-4D74-9619-12EAD07000CF}
.imagebase 0x00400000
.file alignment 0x00001000
.stackreserve 0x00100000
.subsystem 0x0003       // WINDOWS_CUI
.corflags 0x00000001    //  ILONLY
// Image base: 0x03380000


// =============== CLASS MEMBERS DECLARATION ===================

.class private auto ansi beforefieldinit DemoAppWithConditionals.Program
       extends [mscorlib]System.Object
{
  .method private hidebysig static void  Main(string[] args) cil managed
  {
    .entrypoint
    // Code size       136 (0x88)
    .maxstack  2
    .locals init ([0] bool myBoolean,
             [1] int32 myInt,
             [2] float64 myDouble,
             [3] bool CS$4$0000)
    IL_0000:  nop
    IL_0001:  ldc.i4.0
    IL_0002:  stloc.0
    IL_0003:  ldloc.0
    IL_0004:  ldc.i4.0
    IL_0005:  ceq
    IL_0007:  stloc.3
    IL_0008:  ldloc.3
    IL_0009:  brtrue.s   IL_001a

    IL_000b:  nop
    IL_000c:  ldstr      "myBoolean was true."
    IL_0011:  call       void [mscorlib]System.Console::WriteLine(string)
    IL_0016:  nop
    IL_0017:  nop
    IL_0018:  br.s       IL_0027

    IL_001a:  nop
    IL_001b:  ldstr      "myBoolean was false."
    IL_0020:  call       void [mscorlib]System.Console::WriteLine(string)
    IL_0025:  nop
    IL_0026:  nop
    IL_0027:  ldc.i4.s   10
    IL_0029:  stloc.1
    IL_002a:  ldloc.1
    IL_002b:  ldc.i4.5
    IL_002c:  clt
    IL_002e:  stloc.3
    IL_002f:  ldloc.3
    IL_0030:  brtrue.s   IL_0041

    IL_0032:  nop
    IL_0033:  ldstr      "myInt was greater than or equal to 5."
    IL_0038:  call       void [mscorlib]System.Console::WriteLine(string)
    IL_003d:  nop
    IL_003e:  nop
    IL_003f:  br.s       IL_004e

    IL_0041:  nop
    IL_0042:  ldstr      "myInt was less than 5."
    IL_0047:  call       void [mscorlib]System.Console::WriteLine(string)
    IL_004c:  nop
    IL_004d:  nop
    IL_004e:  ldc.r8     100.
    IL_0057:  stloc.2
    IL_0058:  ldloc.2
    IL_0059:  ldc.r8     50.
    IL_0062:  clt
    IL_0064:  ldc.i4.0
    IL_0065:  ceq
    IL_0067:  stloc.3
    IL_0068:  ldloc.3
    IL_0069:  brtrue.s   IL_007a

    IL_006b:  nop
    IL_006c:  ldstr      "myDouble was less than 50."
    IL_0071:  call       void [mscorlib]System.Console::WriteLine(string)
    IL_0076:  nop
    IL_0077:  nop
    IL_0078:  br.s       IL_0087

    IL_007a:  nop
    IL_007b:  ldstr      "myDouble was greater than or equal to 50."
    IL_0080:  call       void [mscorlib]System.Console::WriteLine(string)
    IL_0085:  nop
    IL_0086:  nop
    IL_0087:  ret
  } // end of method Program::Main

  .method public hidebysig specialname rtspecialname 
          instance void  .ctor() cil managed
  {
    // Code size       7 (0x7)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  call       instance void [mscorlib]System.Object::.ctor()
    IL_0006:  ret
  } // end of method Program::.ctor

} // end of class DemoAppWithConditionals.Program


// =============================================================

// *********** DISASSEMBLY COMPLETE ***********************
// WARNING: Created Win32 resource file C:\Documents and Settings\Administrator\My Documents\Code\Assembla\Jester.NET\JesterDotNet\JesterDotNet.Model.Tests\SampleData\test.res

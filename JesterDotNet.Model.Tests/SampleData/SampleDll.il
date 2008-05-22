
//  Microsoft (R) .NET Framework IL Disassembler.  Version 2.0.50727.42
//  Copyright (c) Microsoft Corporation.  All rights reserved.



// Metadata version: v2.0.50727
.assembly extern mscorlib
{
  .publickeytoken = (B7 7A 5C 56 19 34 E0 89 )                         // .z\V.4..
  .ver 2:0:0:0
}
.assembly AnimalFarm
{
  .custom instance void [mscorlib]System.Reflection.AssemblyFileVersionAttribute::.ctor(string) = ( 01 00 07 31 2E 30 2E 30 2E 30 00 00 )             // ...1.0.0.0..
  .custom instance void [mscorlib]System.Runtime.InteropServices.GuidAttribute::.ctor(string) = ( 01 00 24 65 65 32 64 33 35 34 35 2D 33 33 30 62   // ..$ee2d3545-330b
                                                                                                  2D 34 63 34 64 2D 61 65 34 37 2D 61 63 39 39 33   // -4c4d-ae47-ac993
                                                                                                  64 63 64 64 66 33 30 00 00 )                      // dcddf30..
  .custom instance void [mscorlib]System.Runtime.InteropServices.ComVisibleAttribute::.ctor(bool) = ( 01 00 00 00 00 ) 
  .custom instance void [mscorlib]System.Reflection.AssemblyTrademarkAttribute::.ctor(string) = ( 01 00 00 00 00 ) 
  .custom instance void [mscorlib]System.Reflection.AssemblyCopyrightAttribute::.ctor(string) = ( 01 00 12 43 6F 70 79 72 69 67 68 74 20 C2 A9 20   // ...Copyright .. 
                                                                                                  20 32 30 30 37 00 00 )                            //  2007..
  .custom instance void [mscorlib]System.Reflection.AssemblyProductAttribute::.ctor(string) = ( 01 00 0D 53 61 6D 70 6C 65 50 72 6F 6A 65 63 74   // ...SampleProject
                                                                                                00 00 ) 
  .custom instance void [mscorlib]System.Reflection.AssemblyCompanyAttribute::.ctor(string) = ( 01 00 00 00 00 ) 
  .custom instance void [mscorlib]System.Reflection.AssemblyConfigurationAttribute::.ctor(string) = ( 01 00 00 00 00 ) 
  .custom instance void [mscorlib]System.Reflection.AssemblyDescriptionAttribute::.ctor(string) = ( 01 00 00 00 00 ) 
  .custom instance void [mscorlib]System.Reflection.AssemblyTitleAttribute::.ctor(string) = ( 01 00 0D 53 61 6D 70 6C 65 50 72 6F 6A 65 63 74   // ...SampleProject
                                                                                              00 00 ) 

  // --- The following custom attribute is added automatically, do not uncomment -------
  //  .custom instance void [mscorlib]System.Diagnostics.DebuggableAttribute::.ctor(valuetype [mscorlib]System.Diagnostics.DebuggableAttribute/DebuggingModes) = ( 01 00 07 01 00 00 00 00 ) 

  .custom instance void [mscorlib]System.Runtime.CompilerServices.CompilationRelaxationsAttribute::.ctor(int32) = ( 01 00 08 00 00 00 00 00 ) 
  .custom instance void [mscorlib]System.Runtime.CompilerServices.RuntimeCompatibilityAttribute::.ctor() = ( 01 00 01 00 54 02 16 57 72 61 70 4E 6F 6E 45 78   // ....T..WrapNonEx
                                                                                                             63 65 70 74 69 6F 6E 54 68 72 6F 77 73 01 )       // ceptionThrows.
  .hash algorithm 0x00008004
  .ver 1:0:0:0
}
.module AnimalFarm.dll
// MVID: {AA4A0047-30B0-48B7-A6C7-298D670E112B}
.imagebase 0x00400000
.file alignment 0x00001000
.stackreserve 0x00100000
.subsystem 0x0003       // WINDOWS_CUI
.corflags 0x00000001    //  ILONLY
// Image base: 0x01180000


// =============== CLASS MEMBERS DECLARATION ===================

.class interface public abstract auto ansi AnimalFarm.IAnimal
{
  .method public hidebysig newslot specialname abstract virtual 
          instance float64  get_Weight() cil managed
  {
  } // end of method IAnimal::get_Weight

  .method public hidebysig newslot specialname abstract virtual 
          instance int32  get_Age() cil managed
  {
  } // end of method IAnimal::get_Age

  .method public hidebysig newslot abstract virtual 
          instance void  Move() cil managed
  {
  } // end of method IAnimal::Move

  .property instance float64 Weight()
  {
    .get instance float64 AnimalFarm.IAnimal::get_Weight()
  } // end of property IAnimal::Weight
  .property instance int32 Age()
  {
    .get instance int32 AnimalFarm.IAnimal::get_Age()
  } // end of property IAnimal::Age
} // end of class AnimalFarm.IAnimal

.class public auto ansi beforefieldinit AnimalFarm.Cat
       extends [mscorlib]System.Object
       implements AnimalFarm.IAnimal
{
  .method public hidebysig newslot specialname virtual final 
          instance float64  get_Weight() cil managed
  {
    // Code size       15 (0xf)
    .maxstack  1
    .locals init (float64 V_0)
    IL_0000:  nop
    IL_0001:  ldc.r8     10.
    IL_000a:  stloc.0
    IL_000b:  br.s       IL_000d

    IL_000d:  ldloc.0
    IL_000e:  ret
  } // end of method Cat::get_Weight

  .method public hidebysig newslot specialname virtual final 
          instance int32  get_Age() cil managed
  {
    // Code size       7 (0x7)
    .maxstack  1
    .locals init (int32 V_0)
    IL_0000:  nop
    IL_0001:  ldc.i4.5
    IL_0002:  stloc.0
    IL_0003:  br.s       IL_0005

    IL_0005:  ldloc.0
    IL_0006:  ret
  } // end of method Cat::get_Age

  .method public hidebysig newslot virtual final 
          instance void  Move() cil managed
  {
    // Code size       13 (0xd)
    .maxstack  8
    IL_0000:  nop
    IL_0001:  ldstr      "Slink, slink, slink"
    IL_0006:  call       void [mscorlib]System.Console::WriteLine(string)
    IL_000b:  nop
    IL_000c:  ret
  } // end of method Cat::Move

  .method public hidebysig specialname rtspecialname 
          instance void  .ctor() cil managed
  {
    // Code size       7 (0x7)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  call       instance void [mscorlib]System.Object::.ctor()
    IL_0006:  ret
  } // end of method Cat::.ctor

  .property instance float64 Weight()
  {
    .get instance float64 AnimalFarm.Cat::get_Weight()
  } // end of property Cat::Weight
  .property instance int32 Age()
  {
    .get instance int32 AnimalFarm.Cat::get_Age()
  } // end of property Cat::Age
} // end of class AnimalFarm.Cat

.class public auto ansi beforefieldinit AnimalFarm.Fish
       extends [mscorlib]System.Object
       implements AnimalFarm.IAnimal
{
  .method public hidebysig newslot specialname virtual final 
          instance float64  get_Weight() cil managed
  {
    // Code size       37 (0x25)
    .maxstack  2
    .locals init (bool V_0,
             float64 V_1,
             bool V_2)
    IL_0000:  nop
    IL_0001:  ldc.i4.1
    IL_0002:  stloc.0
    IL_0003:  ldloc.0
    IL_0004:  ldc.i4.0
    IL_0005:  ceq
    IL_0007:  stloc.2
    IL_0008:  ldloc.2
    IL_0009:  brtrue.s   IL_0017

    IL_000b:  ldc.r8     6.5
    IL_0014:  stloc.1
    IL_0015:  br.s       IL_0023

    IL_0017:  ldc.r8     0.5
    IL_0020:  stloc.1
    IL_0021:  br.s       IL_0023

    IL_0023:  ldloc.1
    IL_0024:  ret
  } // end of method Fish::get_Weight

  .method public hidebysig newslot specialname virtual final 
          instance int32  get_Age() cil managed
  {
    // Code size       7 (0x7)
    .maxstack  1
    .locals init (int32 V_0)
    IL_0000:  nop
    IL_0001:  ldc.i4.1
    IL_0002:  stloc.0
    IL_0003:  br.s       IL_0005

    IL_0005:  ldloc.0
    IL_0006:  ret
  } // end of method Fish::get_Age

  .method public hidebysig newslot virtual final 
          instance void  Move() cil managed
  {
    // Code size       13 (0xd)
    .maxstack  8
    IL_0000:  nop
    IL_0001:  ldstr      "Swim, swim, swim"
    IL_0006:  call       void [mscorlib]System.Console::WriteLine(string)
    IL_000b:  nop
    IL_000c:  ret
  } // end of method Fish::Move

  .method public hidebysig specialname rtspecialname 
          instance void  .ctor() cil managed
  {
    // Code size       7 (0x7)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  call       instance void [mscorlib]System.Object::.ctor()
    IL_0006:  ret
  } // end of method Fish::.ctor

  .property instance float64 Weight()
  {
    .get instance float64 AnimalFarm.Fish::get_Weight()
  } // end of property Fish::Weight
  .property instance int32 Age()
  {
    .get instance int32 AnimalFarm.Fish::get_Age()
  } // end of property Fish::Age
} // end of class AnimalFarm.Fish

.class public auto ansi beforefieldinit AnimalFarm.Dog
       extends [mscorlib]System.Object
       implements AnimalFarm.IAnimal
{
  .method public hidebysig newslot specialname virtual final 
          instance float64  get_Weight() cil managed
  {
    // Code size       15 (0xf)
    .maxstack  1
    .locals init (float64 V_0)
    IL_0000:  nop
    IL_0001:  ldc.r8     20.
    IL_000a:  stloc.0
    IL_000b:  br.s       IL_000d

    IL_000d:  ldloc.0
    IL_000e:  ret
  } // end of method Dog::get_Weight

  .method public hidebysig newslot specialname virtual final 
          instance int32  get_Age() cil managed
  {
    // Code size       23 (0x17)
    .maxstack  2
    .locals init (bool V_0,
             int32 V_1,
             bool V_2)
    IL_0000:  nop
    IL_0001:  ldc.i4.0
    IL_0002:  stloc.0
    IL_0003:  ldloc.0
    IL_0004:  ldc.i4.0
    IL_0005:  ceq
    IL_0007:  stloc.2
    IL_0008:  ldloc.2
    IL_0009:  brtrue.s   IL_0010

    IL_000b:  ldc.i4.s   70
    IL_000d:  stloc.1
    IL_000e:  br.s       IL_0015

    IL_0010:  ldc.i4.s   10
    IL_0012:  stloc.1
    IL_0013:  br.s       IL_0015

    IL_0015:  ldloc.1
    IL_0016:  ret
  } // end of method Dog::get_Age

  .method public hidebysig newslot virtual final 
          instance void  Move() cil managed
  {
    // Code size       13 (0xd)
    .maxstack  8
    IL_0000:  nop
    IL_0001:  ldstr      "Run, run, run"
    IL_0006:  call       void [mscorlib]System.Console::WriteLine(string)
    IL_000b:  nop
    IL_000c:  ret
  } // end of method Dog::Move

  .method public hidebysig specialname rtspecialname 
          instance void  .ctor() cil managed
  {
    // Code size       7 (0x7)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  call       instance void [mscorlib]System.Object::.ctor()
    IL_0006:  ret
  } // end of method Dog::.ctor

  .property instance float64 Weight()
  {
    .get instance float64 AnimalFarm.Dog::get_Weight()
  } // end of property Dog::Weight
  .property instance int32 Age()
  {
    .get instance int32 AnimalFarm.Dog::get_Age()
  } // end of property Dog::Age
} // end of class AnimalFarm.Dog


// =============================================================

// *********** DISASSEMBLY COMPLETE ***********************
// WARNING: Created Win32 resource file SampleDll.res

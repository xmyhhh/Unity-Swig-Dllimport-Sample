# 记录如何使用Swig导出Cpp lib（for C#）和 Unity使用DllImport导入native函数（x86 and x64）

 > SWIG is typically used to parse C/C++ interfaces and generate the 'glue code' required for the above target languages to call into the C/C++ code. 

## 如何为C#导出native C++ lib?
- 下载Windows预编译版并解压[Swig](vhttps://www.audiokinetic.com/zh/library/edge/?source=Help&id=managing_dynamic_dialogue_overview)，点击autogen.sh会自动生成swig.exe

- 目录`C:\swigwin-4.0.2\Examples\csharp`是C#样例，以`C:\swigwin-4.0.2\Examples\csharp\simple`为例，用vs studio打开该目录下`example.sln`

- 在vs studio中构建vc项目得到`lib（包括32位和64位）`、`examplePINVOKE.cs`、`example.cs`
    - 64位lib生成位置为`C:\swigwin-4.0.2\Examples\csharp\simple\x64\Debug\example.dll`
    - 32位lib生成位置为`C:\swigwin-4.0.2\Examples\csharp\simple\Win32\Debug\example.dll`
    - `examplePINVOKE.cs`和`example.cs`的生成目录都在`C:\swigwin-4.0.2\Examples\csharp\simple`

- 在vs studio中构建并运行cs项目测试生成的lib是否可用，注意需要手动拷贝lib到cs项目生成的.exe文件同级文件夹(在Unity中不需要这样，只需要保证Dll和对应cs文件在同一个程序集)
    - [dll库搜索顺序](https://docs.microsoft.com/zh-cn/windows/win32/dlls/dynamic-link-library-search-order?redirectedfrom=MSDN)
    - [运行时指定dll库搜索文件夹](https://stackoverflow.com/questions/8836093/how-can-i-specify-a-dllimport-path-at-runtime)
    - [C#运行时DllImport源码](https://github.com/dotnet/coreclr/blob/6bf04a47badd74646e21e70f4e9267c71b7bfd08/src/vm/dllimport.cpp#L6210)


## 如何在Unity中使用Swig导出的lib?
- Unity的lib放置的文件夹需要遵守一定的约定，[参考](https://docs.unity.cn/2020.3/Documentation/Manual/PluginInspector.html)，以Windows为例，把lib放在Assets/../Plugins/目录下
- 对于同名lib（同名不同平台，例如一个x86一个x64），需要在dll文件的Inspector窗口下取消选中Any Platform，以避免冲突
- 最后在Unity中正常引用对应方法即可
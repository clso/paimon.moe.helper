这是一个 https://paimon.moe/wish/import 的Windows版本导入工具  
This is a Windows version import tool to https://paimon.moe/wish/import  

现在已支持原神3.0版的导入  
Now supported for Genshin v3.0  
灵感来源 Inspired by  
https://github.com/EnderSyth/Genshin-Wish-Export  
  
您可以点此下载应用程序  
You can download the app here  
[paimon.moe.helper.exe](https://github.com/clso/paimon.moe.helper/releases/download/Release/paimon.moe.helper.exe)  
[paimon.moe.helper.exe.7z](https://github.com/clso/paimon.moe.helper/releases/download/Release/paimon.moe.helper.exe.7z)  
  
----

编译代码  
compile code  
```bat
%WINDIR%\Microsoft.NET\Framework\v4.0.30319\vbc.exe /nologo /define:_MYTYPE=\"Empty\" /imports:System,System.Collections.Generic,System.Windows.Forms -out:paimon.moe.helper.exe main.vb
```
```bat
%WINDIR%\Microsoft.NET\Framework\v4.0.30319\csc.exe /nologo -out:paimon.moe.helper.exe main.cs
```

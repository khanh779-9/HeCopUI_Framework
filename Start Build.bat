call "C:\Program Files\Microsoft Visual Studio\2022\Community\Common7\Tools\VsDevCmd.bat"
Msbuild.exe "D:\Data\Tailieu\Projects\C#\HeCopUI_Framework\HeCopUI_Framework.sln" /t:Rebuild /p:Configuration=Debug
copy "D:\Data\Tailieu\Projects\C#\HeCopUI_Framework\HeCopUI_Framework\bin\Debug\HeCopUI_Framework.dll" "C:\Lib\HecopUI_Framework\HeCopUI_Framework.dll"
pause
color 2f

set sc=..\..\Server\ServerBase\Protocol
set des=..\..\Public\Protocol
copy %sc%\NetBitStream.cs %des%\NetBitStream.cs /y
copy %sc%\ProtocolClass.cs %des%\ProtocolClass.cs /y
copy %sc%\ProtocolEnum.cs %des%\ProtocolEnum.cs /y
copy %sc%\ProtocolId.cs %des%\ProtocolId.cs /y
copy %sc%\ProtocolSerialization.cs %des%\ProtocolSerialization.cs /y
copy %sc%\Э����.docx %des%\Э����.docx /y
copy %sc%\Э����.html %des%\Э����.html /y
xcopy %sc%\Lua\*.* %des%\Lua\ /y
pause
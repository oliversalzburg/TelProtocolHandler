@ECHO OFF
SETLOCAL
SET TPH_PATH=%~dp0
SET TPH_PATH=%TPH_PATH:\=\\%

 >RegisterProtocolHandler.reg ECHO Windows Registry Editor Version 5.00
>>RegisterProtocolHandler.reg ECHO.
>>RegisterProtocolHandler.reg ECHO [HKEY_CLASSES_ROOT\tel]
>>RegisterProtocolHandler.reg ECHO "URL Protocol"=""
>>RegisterProtocolHandler.reg ECHO @="TEL:Telephone Invocation"
>>RegisterProtocolHandler.reg ECHO.
>>RegisterProtocolHandler.reg ECHO [HKEY_CLASSES_ROOT\tel\shell]
>>RegisterProtocolHandler.reg ECHO.
>>RegisterProtocolHandler.reg ECHO [HKEY_CLASSES_ROOT\tel\shell\open]
>>RegisterProtocolHandler.reg ECHO.
>>RegisterProtocolHandler.reg ECHO [HKEY_CLASSES_ROOT\tel\shell\open\command]
>>RegisterProtocolHandler.reg ECHO @="\"%TPH_PATH%TelProtocolHandler\\bin\\Release\\TelProtocolHandler.exe\" \"%%1\""
>>RegisterProtocolHandler.reg ECHO.

start RegisterProtocolHandler.reg

ENDLOCAL
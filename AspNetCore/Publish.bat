@echo off
if not exist packages (
    md packages
)

for /R "packages" %%s in (*) do (
    del %%s
)

dotnet pack src/Cosmos.AspNetCore.Extensions.Alipay -c Release -o ../../packages
dotnet pack src/Cosmos.AspNetCore.Extensions.WeChat -c Release -o ../../packages
dotnet pack src/Cosmos.AspNetCore.Extensions.AntiXss -c Release -o ../../packages
dotnet pack src/Cosmos.AspNetCore.Extensions.HttpActionResults -c Release -o ../../packages
dotnet pack src/Cosmos.AspNetCore.Extensions.HttpMultipartRequest -c Release -o ../../packages
dotnet pack src/Cosmos.AspNetCore.Extensions.ResponseCompression -c Release -o ../../packages
dotnet pack src/Cosmos.AspNetCore.Extensions.ResponseFrameOptions -c Release -o ../../packages

for /R "packages" %%s in (*symbols.nupkg) do (
    del %%s
)

set /p key=input key:
set source=https://www.myget.org/F/alexinea/api/v2/package

for /R "packages" %%s in (*.nupkg) do ( 
    call nuget push %%s %key% -Source %source%	
)

pause
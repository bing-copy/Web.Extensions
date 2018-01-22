@echo off
if not exist packages (
    md packages
)

for /R "packages" %%s in (*) do (
    del %%s
)

cd src\

for /d %%s in (*) do (
    echo %%s
    call cd %%s
	call nuget pack -OutputDirectory ..\..\packages
	call cd ..
)

cd ..

for /R "packages" %%s in (*symbols.nupkg) do (
    del %%s
)

set /p key=input key:
set source=https://www.myget.org/F/alexinea/api/v2/package

for /R "packages" %%s in (*.nupkg) do ( 
    call nuget push %%s %key% -Source %source%	
)

pause
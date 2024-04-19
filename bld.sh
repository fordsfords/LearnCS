#!/bin/sh
# bld.sh

# dotnet new console --use-program-main

PROJ=`/bin/ls *.csproj`
PROJ=`basename $PROJ .csproj`
rm -f ./bin/Debug/*/$PROJ.dll

dotnet build $PROJ.csproj /nologo /clp:NoSummary
if [ "$?" -ne 0 ]; then exit 1; fi

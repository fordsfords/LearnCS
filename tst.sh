#!/bin/sh
# tst.sh

### ./bld.sh
### if [ "$?" -ne 0 ]; then exit 1; fi

# Example: blah; ASSRT "$? -eq 0"
ASSRT() {
  eval "test $1"

  if [ $? -ne 0 ]; then
    echo "ASSRT ERROR, `date`: `basename ${BASH_SOURCE[1]}`:${BASH_LINENO[0]}, not true: '$1'" >&2
    exit 1
  fi
}  # ASSRT

GRP() {
  P="$1"
  F="$2"
  egrep "$P" $F >/dev/null
  if [ $? -ne 0 ]; then :
    echo "EGREP ERROR, `date`: `basename ${BASH_SOURCE[1]}`:${BASH_LINENO[0]}, pat '$P' not found in $F" >&2
    exit 1
  fi
}  # GRP


PROJ=`/bin/ls *.csproj`
PROJ=`basename $PROJ .csproj`
DLL=`/bin/ls ./bin/Debug/*/$PROJ.dll`
if [ ! -f "$DLL" ]; then exit 1; fi

T="$1"
if [ -n "$T" ]; then :
  dotnet $DLL $* >tst.1 2>tst.2;  echo $?
else :
  echo "Test -1: fatal error."
  dotnet $DLL -1 >tst.1 2>tst.2;  ASSRT "$? -ne 0"
  GRP "Fatal error: Invalid test -1" tst.1
  GRP "Assrt Count: 0" tst.1
  GRP "Unhandled exception. System.ArgumentException: Invalid test -1" tst.2

  echo "Test 0: null test."
  dotnet $DLL 0 >tst.1 2>tst.2;  ASSRT "$? -eq 0"
  GRP "Assrt Count: 0" tst.1
  GRP "Test 0 OK" tst.1
  ASSRT "! -s tst.2"  # tst.2 should be empty.

  echo ""; echo "Test 1: failed assertion."
  dotnet $DLL 1 >tst.1 2>tst.2;  ASSRT "$? -ne 0"
  GRP "Failed Assrt:" tst.1
  GRP "Unhandled exception. System.ArgumentException: Failed Assrt" tst.2
  ASSRT "-s tst.2"  # tst.2 should be non-empty.

  echo ""; echo "Test 2: reference parameters."
  dotnet $DLL 2 >tst.1 2>tst.2;  ASSRT "$? -eq 0"
  ASSRT "! -s tst.2"  # tst.2 should be empty.
  GRP "Test 2 OK" tst.1

  echo ""; echo "Test 3: Arrays."
  dotnet $DLL 3 >tst.1 2>tst.2;  ASSRT "$? -eq 0"
  ASSRT "! -s tst.2"  # tst.2 should be empty.
  GRP "Test 3 OK" tst.1

  echo ""; echo "Test 4: Strings."
  dotnet $DLL 4 >tst.1 2>tst.2;  ASSRT "$? -eq 0"
  ASSRT "! -s tst.2"  # tst.2 should be empty.
  GRP "Test 4 OK" tst.1

  echo ""; echo "Test 5: number types."
  dotnet $DLL 5 >tst.1 2>tst.2;  ASSRT "$? -eq 0"
  ASSRT "! -s tst.2"  # tst.2 should be empty.
  GRP "Test 5 OK" tst.1

  echo ""; echo "Test 6: parameters."
  dotnet $DLL 6 >tst.1 2>tst.2;  ASSRT "$? -eq 0"
  ASSRT "! -s tst.2"  # tst.2 should be empty.
  GRP "Test 6 OK" tst.1

  echo ""; echo "Test 7: local refs."
  dotnet $DLL 7 >tst.1 2>tst.2;  ASSRT "$? -eq 0"
  ASSRT "! -s tst.2"  # tst.2 should be empty.
  GRP "Test 7 OK" tst.1

  echo ""; echo "Test 8: target-typed 'new' expressions"
  dotnet $DLL 8 >tst.1 2>tst.2;  ASSRT "$? -eq 0"
  ASSRT "! -s tst.2"  # tst.2 should be empty.
  GRP "Test 8 OK" tst.1

  echo ""; echo "Test 9: Null operators"
  dotnet $DLL 9 >tst.1 2>tst.2;  ASSRT "$? -eq 0"
  ASSRT "! -s tst.2"  # tst.2 should be empty.
  GRP "Test 9 OK" tst.1

  echo ""; echo "Test 10: switch"
  dotnet $DLL 10 >tst.1 2>tst.2;  ASSRT "$? -eq 0"
  ASSRT "! -s tst.2"  # tst.2 should be empty.
  GRP "Test 10 OK" tst.1

  echo ""; echo "Test 11: foreach"
  dotnet $DLL 11 >tst.1 2>tst.2;  ASSRT "$? -eq 0"
  ASSRT "! -s tst.2"  # tst.2 should be empty.
  GRP "Test 11 OK" tst.1

fi

echo "Done"

#!/bin/bash

if [ $# -ne 1 ]; then
  echo "Missing argument: Day"
  exit
fi

dotnet run --project ./AdventOfCode/AdventOfCode.csproj $1

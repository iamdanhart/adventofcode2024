#!/bin/zsh

__year=2024

if [ "${1}" != "" ]; then
    padded=$(printf "%02g" ${1})
    mkdir -p ${padded}
    touch ${padded}/testinput.txt
    if [ ! -f "${padded}/input.txt" ]; then
        curl -s \
            -H "Cookie: session=`cat cookie.txt`" https://adventofcode.com/${__year}/day/${1##0}/input > "${padded}/input.txt"
    fi
    cd ${padded}
    dotnet new console
    echo "https://adventofcode.com/${__year}/day/${1}"
fi

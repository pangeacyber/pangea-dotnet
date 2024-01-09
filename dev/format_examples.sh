#!/bin/bash

# Specify the root directory
root_directory="../examples"

# Store the initial working directory
initial_directory=$(pwd)

# Find all .csproj files in subdirectories and iterate over the results
find "$root_directory" -mindepth 2 -type f -name "*.csproj" -print0 | while IFS= read -r -d '' csproj_file; do
    # Extract the directory from the full path
    dir=$(dirname "$csproj_file")

    cd "$dir" || exit
    echo "Executing 'dotnet format' in $dir"
    dotnet format

    cd "$initial_directory" || exit
done

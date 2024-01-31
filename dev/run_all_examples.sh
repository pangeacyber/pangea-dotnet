#!/usr/bin/env bash

# This script should be run from examples root directory in order to run all examples in that folder and its subfolders

root_directory=$(pwd)

# Initialize a counter
counter=0

# Find folders containing *.csproj files
folders=$(find . -type f -name '*.csproj' -exec dirname {} \;)

# Loop through each folder and perform dotnet commands
for folder in $folders; do
    ((counter++))
    echo -e "\n\n--------------------------------------------------------------\nProcessing folder: $folder"

    # Move into the folder
    cd "$folder" || exit 1

    # Run dotnet commands
    dotnet clean
    dotnet build
    echo -e "\nBuiled folder: $folder\n--------------------------------------------------------------"
    echo -e "\n--------------------------------------------------------------\nRunning folder: $folder\n"
    dotnet run

    # Move back to the root directory
    cd "$root_directory" || exit 1
    echo -e "\n--------------------------------------------------------------\nFinish folder: $folder\n"
done

echo "Processed $counter folders."

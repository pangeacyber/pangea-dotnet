#!/usr/bin/env bash

set -e

if [ $# -lt 1 ]; then
    echo "usage: validate_tag.sh <git_tag>"
    exit 1
fi

GIT_TAG=$1

if [[ ! $GIT_TAG == "v"* ]]; then
   echo "Git tag must begin with a 'v'."
   exit 1
fi

# Trim the 'v'.
GIT_TAG="${GIT_TAG:1}"

CSPROJ_VERSION=$(grep -Eo "<Version>.+<\/Version>" packages/pangea-sdk/PangeaCyber.Net/PangeaCyber.Net.csproj)

if [[ ! "$CSPROJ_VERSION" == *"$GIT_TAG"* ]]; then
   echo "Git tag version '$GIT_TAG' does not match csproj file version '$CSPROJ_VERSION'."
   exit 1
fi

CONFIG_VERSION=$(grep -Eo "public const string Version = ".+";" packages/pangea-sdk/PangeaCyber.Net/Config.cs)

if [[ ! "$CONFIG_VERSION" == *"$GIT_TAG"* ]]; then
   echo "Git tag version '$GIT_TAG' does not match Config class version '$CONFIG_VERSION'."
   exit 1
fi

VERSION_FILE=$(cat packages/pangea-sdk/VERSION)

if [[ ! "$GIT_TAG" == "$VERSION_FILE" ]]; then
   echo "Git tag version '$GIT_TAG' does not match VERSION file version '$VERSION_FILE'."
   exit 1
fi

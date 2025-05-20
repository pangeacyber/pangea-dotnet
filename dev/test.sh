#!/usr/bin/env bash

set -e

cd -- "$(dirname -- "$0")/.."

pnpm dlx start-server-and-test --expect 404 \
  "pnpm dlx @stoplight/prism-cli mock -d --json-schema-faker-fillProperties=false dev/specs/ai-guard_openapi.json" \
  4010 \
  "dotnet test packages/pangea-sdk/PangeaCyber.Tests --filter AIGuardClientTests"

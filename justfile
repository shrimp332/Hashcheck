[private]
default:
    @just --list

build:
    dotnet build

# Runs HashCheck.Cli
run:
    dotnet run --project HashCheck.Cli

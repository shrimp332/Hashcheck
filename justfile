[private]
default:
    @just --list

build:
    dotnet build

# Runs HashCheck.Cli
run *args:
    dotnet run --project HashCheck.Cli -- {{args}}

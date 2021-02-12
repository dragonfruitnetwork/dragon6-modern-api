param ([string] $ApiKey, [string]$Suffix = "")

# versioning info
$VERSION = "$(Get-Date -UFormat "%Y.%m%d").$($env:GITHUB_RUN_NUMBER)$($Suffix)"
$WORKINGDIR = Get-Location
$TARGET = "DragonFruit.Six.Api.Modern"

# build files
Write-Output "Building $TARGET Version $VERSION"
dotnet restore
dotnet build -c Release /p:PackageVersion=$VERSION

# pack into nuget files with the suffix if we have one
Write-Output "Publishing $TARGET Version $VERSION"
dotnet pack ".\$TARGET\$TARGET.csproj" -o $WORKINGDIR -c Release -p:PackageVersion=$VERSION -p:Version=$VERSION

# recursively push all nuget files created
Get-ChildItem -Path $WORKINGDIR -Filter *.nupkg -Recurse -File -Name | ForEach-Object {
    dotnet nuget push $_ --api-key $ApiKey --source https://api.nuget.org/v3/index.json --force-english-output
}

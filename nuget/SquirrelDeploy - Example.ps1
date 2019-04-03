Param (
    [switch]$Release
)

#$Release = $true

Set-Alias Squirrel '..\packages\squirrel.windows.1.9.1\tools\Squirrel.exe'
Set-Alias Nuget  '.\nuget.exe'

[xml]$XML = Get-Content '.\eDrawingFinder.nuspec'
$Title = $XML.package.metadata.id
$Version = $XML.package.metadata.version
$NugetPackageFileName = "$Title.$Version.nupkg"

if($Release) {
    $NugetOutput = ".\releases"
    $ReleaseDir = '\\pokydata1\CAD\eDrawingFinder\Releases'
} else {
    $NugetOutput = ".\local"
    $ReleaseDir = '.\local\deployment'}

Write-Host "Starting process of $Title v$Version"
Nuget pack '.\eDrawingFinder.nuspec' -OutputDirectory "$NugetOutput"

Write-Host "Starting Squirrel releasify on $NugetPackageFileName"
Squirrel --releasify "$NugetOutput\$NugetPackageFileName" --releaseDir $ReleaseDir --setupIcon "..\Resources\Images\setup.ico" --framework-version=461  --no-delta --no-msi | Write-Output
Write-Host "Succesfully deployed version $Version to '$ReleaseDir'."

#--loadingGif "..\Resources\Images\blocks.gif"

pause
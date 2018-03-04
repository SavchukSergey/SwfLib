param (
)

$start = Get-Date
$color = "green"

Set-Location ..\..\
$root = Get-Location
$output = "$root\output"

function Get-GitBranch() {
    $branches = (git branch)
    return ($branches | Where-Object -FilterScript {$_.StartsWith('*')}).Substring(2);
}

function Get-GitCommit() {
    return ((git rev-parse HEAD) | Out-String).Trim()
}
function Get-GitUserName() {
    return (git config user.name);
}

function Get-GitUserEmail() {
    return (git config user.email);
}

function GetReleaseVersion {
    [String]$branch = Get-GitBranch;
    if ($branch.StartsWith("releases/")) {
        return $branch.Substring("releases/".Length);
    }
    return "0.0.0.0";
}

function SetReleaseInfo() {
    $version = GetReleaseVersion;
    $branch = Get-GitBranch;
    $timestamp = (Get-Date).ToUniversalTime().ToString("yyyy-MM-dd HH:mm:ssZ");
    $commit = Get-GitCommit;
    $userName = Get-GitUserName;
    $userEmail = Get-GitUserEmail;
	
    if ($version -eq "0.0.0.0") {
        Write-Host -ForegroundColor yellow "You are building package from non-release branch"
    }
    $file = "using System.Reflection;

[assembly: AssemblyVersion(""$version"")]
[assembly: AssemblyTimestamp(""$timestamp"")]
[assembly: AssemblyBranch(""$branch"")]
[assembly: AssemblyEnvironment(""$envLowered"")]
[assembly: AssemblyCommit(""$commit"")]
[assembly: AssemblyUserName(""$userName"")]
[assembly: AssemblyUserEmail(""$userEmail"")]
";
    $file | Out-File "artifacts/CommonAssemblyInfo.cs"
}

function CleanUpRepository() {
    (git checkout "artifacts/CommonAssemblyInfo.cs") | Out-Null
}

function CreatePackageStructure {
    Write-Host "creating package structure..."  -ForegroundColor $color
    if (Test-Path $output) {
        Remove-Item $output -Force -Recurse
    }

    New-Item "$output" -type directory | Out-Null
}

function RestoreDotNetCore {
    Write-Host "restoring dotnet packages..."  -ForegroundColor $color
    & dotnet restore $root
    if (!$?) { Exit };
}

function RunTests() {
    Write-Host "running tests..."  -ForegroundColor $color
}

function Publish {
    Write-Host "publishing swfmill..." -ForegroundColor $color
    & dotnet build "$root\SwfLib.SwfMill" -o "$output\swfmill" -c Release -r win10-x64
    if (!$?) { Exit };
}


function ArchiveOutput {
    Write-Host "archiving output..." -ForegroundColor $color
    & "c:\Program Files\7-Zip\7z.exe" a "$output\swflib.7z" "$output\swfmill" -mx9
    if (!$?) { Exit };
}


try {
    SetReleaseInfo
    CreatePackageStructure
    RestoreDotNetCore
    RunTests
    Publish
    ArchiveOutput
}
finally {
    CleanUpRepository
}

Write-Host "done" -ForegroundColor $color

$end = Get-Date
Write-Host "Build took: $(($end - $start).TotalSeconds) seconds" -ForegroundColor $color
Set-Location "$root\artifacts\Build"
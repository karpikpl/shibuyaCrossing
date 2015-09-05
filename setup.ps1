# Download the file to a specific location
$clnt = new-object System.Net.WebClient
$url = "https://open.kattis.com/download/sampledata?id=" + $args[0]
$file = ".\sampledata.zip"
$clnt.DownloadFile($url,$file)

# Unzip the file to specified location
$shell_app=new-object -com shell.application
$filePath = [System.IO.Path]::GetFullPath($file)
$zip_file = $shell_app.namespace($filePath)
#Write-Host "Zip:" $zip_file;
$destination = $shell_app.namespace([System.IO.Path]::GetFullPath("."))
# Write-Host $destination
$destination.Copyhere($zip_file.items())

$newSlnName = $args[0]+".sln"

Rename-Item KattisSolution.sln $newSlnName

$newSubmitScript = "python submit.py -p" + $args[0] +" KattisSolution\Program.cs KattisSolution\InputOutput.cs"
New-Item "submitMe.bat" -type file -force -value $newSubmitScript

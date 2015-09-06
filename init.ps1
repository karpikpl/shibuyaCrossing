$cloneParams = "clone https://github.com/karpikpl/Kattis.git " + $args[0]
Start-Process git -ArgumentList $cloneParams -wait -NoNewWindow -PassThru

$newPath = ".\\" + $args[0]

Set-Location -Path $newPath -PassThru

$expression = ".\\setup.ps1 " + $args[0]
Invoke-Expression $expression

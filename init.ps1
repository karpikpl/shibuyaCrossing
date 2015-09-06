$cloneParams = "clone https://github.com/karpikpl/Kattis.git " + $args[0]
Start-Process git -ArgumentList $cloneParams -wait -NoNewWindow -PassThru

$expression = ".\\"+$args[0]+"\\setup.ps1 " + $args[0]
Invoke-Expression $expression

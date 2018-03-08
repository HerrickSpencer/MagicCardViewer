### $info | ?{$_ -match "^\s{2}`"(\w*)"} | %{$_; $t = [regex]::Replace($_, "^\s{2}`"([\w\s]*)\W", "$1 |||"); $t}

$file = "E:\Temp\AllCards.json\AllSets.json.01.01";
$file = "E:\Temp\AllCards.json\AllSets.json";
$outFile = "E:\Temp\testout.json";
$info = gc  $file
#write-output $info;
$infoOut = ""; $i = $info.Count;
foreach ($str in $info)
{
    $i--; write-output $i;
    #write-output $str;
    if ($str -match "^\s{2}`"(\w*)")
    {
        $str = [regex]::Replace($str, "^\s{2}`"([\w\s]*)`": {$", '  { ');
        #write-output "WOOT $str"; break;
    }
    if ($str -eq "{") { $str = '{ "CardSets": [';}
    if ($str -eq "}") { $str = ']}';}
    $infoOut += $str;
}
sc $outFile $infoOut;
notepad $outFile;
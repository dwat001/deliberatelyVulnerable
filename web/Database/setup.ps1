Import-Module sqlps

$ConnectionString = "Server=localhost;Initial Catalog=DeliberatelyVulnerable;Trusted_Connection=true"
$ConnectionStringMasterDb = "Server=localhost;Initial Catalog=master;Trusted_Connection=true"

Invoke-SqlCmd -ConnectionString $ConnectionStringMasterDb -InputFile dropandcreate.sql
Invoke-SqlCmd -ConnectionString $ConnectionString -InputFile tables.sql
Invoke-SqlCmd -ConnectionString $ConnectionString -InputFile data.sql
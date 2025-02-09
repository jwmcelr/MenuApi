-- Create a cert with name $certname and store it in User Certificates (Personal)
$certname = "testcert"    ## Replace {certificateName}
$cert = New-SelfSignedCertificate -FriendlyName "DB2Cert" -Subject "CN=$certname" -CertStoreLocation "Cert:\CurrentUser\My" -KeyExportPolicy Exportable -KeySpec Signature -KeyLength 2048 -KeyAlgorithm RSA -HashAlgorithm SHA256

-- Export the certificate to .pfx format
# Get the certificate you want to export 
$cert = Get-ChildItem Cert:\CurrentUser\My | Where-Object {$_.FriendlyName -eq "DB2Cert"}

# Set the password for the PFX file
$password = ConvertTo-SecureString -String "testdb2" -AsPlainText -Force

# Export the certificate to a PFX file
Export-PfxCertificate -Cert $cert -FilePath "C:\work\temp\DB2Certificate.pfx" -Password $password
Export-PfxCertificate -Cert $cert -FilePath "C:\work\temp\DB2Certificate2.pfx"

-- Convert the certificate to .p12 format
keytool -importkeystore -destkeystore C:\work\temp\DB2Certificate.p12 -deststoretype pkcs12 -srckeystore C:\work\temp\DB2Certificate.pfx


-- Ignore the things above
-- Create Key DB
gsk8capicmd_64 -keydb -create -db C:\work\temp\DB2CertificateServer.p12 -pw testdb2 -stash -pqc false

-- Create Certificate from Key DB
gsk8capicmd_64 -cert -create -db C:\work\temp\DB2CertificateServer.p12 -stashed -label db2selfsigned -dn "CN=mytestcert" -size 2048 -sigalg SHA256_WITH_RSA



-- Configure DB2
SERVER_ENCRYPT_TOKEN
update database manager configuration using authentication SERVER_ENCRYPT_TOKEN

db2 update dbm cfg using AUTHENTICATION SERVER

db2 update dbm cfg using SRVCON_AUTH SERVER_ENCRYPT_TOKEN

db2 update dbm cfg using SRVCON_AUTH NOT_SPECIFIED

-- Connect with db2 tool
db2 connect to mydb1 accesstoken eyJhbGciOiJSUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1c2VybmFtZSI6InRlc3QiLCJleHAiOjE3NjQ0NTk4NTUsImlzcyI6IkNvbXBhbnlYIiwiYXVkIjoieW91cmF1ZGllbmNlIn0.BD2K-Q7zlnYT_MOAHhmzm_r48RwVxqPd_qZm0fQwrCHg1WGXZmOzQ1Oc8dkdVubstiISbahnQYpP07zAlzpl1epLIFj0WAQ4CtflgMGO8FcB3zUIizEoao0-SQBDvrmqcxHf8981pP_fkiBgWlLRiCHQE2pYpmnWYvPrZCdlFn58c9itAXdGEbnE2NFKo-AUyCSdFVEIS9OC5x0xEJGE03P0veZc5RnT9E8Ih_otNsyP5HIrat17HjJZS0DxtiDp2nPu-xkcxwwE3ZgD775Mb92Lu5fkQzZu-5O1UwXZYlo6aTst3M50o6FGnCZ8A_mKKhdORssSpud5D2ai6kqm6g accesstokentype jwt
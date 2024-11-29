-- Create a cert with name $certname and store it in User Certificates (Personal)
$certname = "testcert"    ## Replace {certificateName}
$cert = New-SelfSignedCertificate -FriendlyName "DB2Cert" -Subject "CN=$certname" -CertStoreLocation "Cert:\CurrentUser\My" -KeyExportPolicy Exportable -KeySpec Signature -KeyLength 2048 -KeyAlgorithm RSA -HashAlgorithm SHA256

-- Export the certificate to .pfx format
# Get the certificate you want to export 
$cert = Get-ChildItem Cert:\CurrentUser\My | Where-Object {$_.FriendlyName -eq "DB2Cert"}

# Set the password for the PFX file
$password = ConvertTo-SecureString -String "test" -AsPlainText -Force

# Export the certificate to a PFX file
Export-PfxCertificate -Cert $cert -FilePath "C:\work\temp\DB2Certificate.pfx" -Password $password

-- Convert the certificate to .p12 format
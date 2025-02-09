using JWTTokenGenerator;

// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

JWTGenerator generator = new JWTGenerator();

generator.generateJWTToken("C:\\work\\temp\\DB2CertificateServer.p12", "testdb2", "CN=mytestcert");



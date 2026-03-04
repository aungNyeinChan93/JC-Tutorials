using Effortless.Net.Encryption;

//

// Encrypting/decrypting strings
//byte[] key = Bytes.GenerateKey();
//byte[] iv = Bytes.GenerateIV();
//string encrypted = Strings.Encrypt("Secret", key, iv);
//string decrypted = Strings.Decrypt(encrypted, key, iv);
//Assert.AreEqual("Secret", decrypted);


byte[] key = Bytes.GenerateKey();
byte[] iv = Bytes.GenerateIV();

var encryptedStr = Strings.Encrypt("this is encrypted string", key, iv);
var decryptedStr = Strings.Decrypt(encryptedStr, key, iv);
Console.WriteLine(new { encryptedStr, decryptedStr });





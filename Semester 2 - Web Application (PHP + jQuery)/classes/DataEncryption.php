<?php

//Source code taken from: https://gist.github.com/Oranzh/2520823f9d1cea603e60b8e8f3fe1d36#file-with_bcrypt_password_hash-md
class DataEncryption
{
    private $method;
    private $password;
    private $iv;

    public function __construct()
    {       
        $this->password = '3sc3RLrpd17';
        $this->method = 'aes-256-cbc';

        // Must be exact 32 chars (256 bit)
        $this->password = substr(hash('sha256', $this->password, true), 0, 32);

        // IV must be exact 16 chars (128 bit)
        $this->iv = chr(0x0) . chr(0x0) . chr(0x0) . chr(0x0) . chr(0x0) . chr(0x0) . chr(0x0) . chr(0x0) . chr(0x0) . chr(0x0) . chr(0x0) . chr(0x0) . chr(0x0) . chr(0x0) . chr(0x0) . chr(0x0);
    }

    public function EncryptPassword(string $plaintext)
    {
        // av3DYGLkwBsErphcyYp+imUW4QKs19hUnFyyYcXwURU=
        $encrypted = base64_encode(openssl_encrypt($plaintext, $this->method, $this->password, OPENSSL_RAW_DATA, $this->iv));       
        return $encrypted;       
    }

    public function DecryptPassword($encrypted)
    {
        $decrypted = openssl_decrypt(base64_decode($encrypted), $this->method, $this->password, OPENSSL_RAW_DATA, $this->iv);
        return $decrypted;
    }
}

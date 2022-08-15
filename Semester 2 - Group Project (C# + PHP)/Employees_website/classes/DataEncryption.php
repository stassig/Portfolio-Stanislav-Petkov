<?php

//Source code taken from: https://gist.github.com/Oranzh/2520823f9d1cea603e60b8e8f3fe1d36#file-with_bcrypt_password_hash-md
class DataEncryption
{
    public function EncryptPassword(string $plaintext)
    {
        $password = '3sc3RLrpd17';
        $method = 'aes-256-cbc';

        // Must be exact 32 chars (256 bit)
        $password = substr(hash('sha256', $password, true), 0, 32);

        // IV must be exact 16 chars (128 bit)
        $iv = chr(0x0) . chr(0x0) . chr(0x0) . chr(0x0) . chr(0x0) . chr(0x0) . chr(0x0) . chr(0x0) . chr(0x0) . chr(0x0) . chr(0x0) . chr(0x0) . chr(0x0) . chr(0x0) . chr(0x0) . chr(0x0);

        // av3DYGLkwBsErphcyYp+imUW4QKs19hUnFyyYcXwURU=
        $encrypted = base64_encode(openssl_encrypt($plaintext, $method, $password, OPENSSL_RAW_DATA, $iv));

        return $encrypted;       
    }
}

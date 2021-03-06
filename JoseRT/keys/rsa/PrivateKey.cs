﻿using System;
using Windows.Security.Cryptography;
using Windows.Security.Cryptography.Core;
using JoseRT.Keys.pem;

namespace JoseRT.Rsa
{
    public sealed class PrivateKey
    {
        public static CryptographicKey Load(string privKeyContent)
        {
            CryptographicPrivateKeyBlobType blobType;

            var block = new Pem(privKeyContent);

            if (block.Type == null) //not pem encoded
            {
                throw new Exception("PrivateKey.Load(): Only PEM encoded blocks are supported, but was given not PEM encoded.");
            }
            if ("PRIVATE KEY".Equals(block.Type))
            {
                blobType = CryptographicPrivateKeyBlobType.Pkcs8RawPrivateKeyInfo;
            }
            else if ("RSA PRIVATE KEY".Equals(block.Type))
            {
                blobType = CryptographicPrivateKeyBlobType.Pkcs1RsaPrivateKey;
            }
            else
            {
                throw new Exception(string.Format("PrivateKey.Load(): Unsupported type in PEM block '{0}'", block.Type));
            }

            return AsymmetricKeyAlgorithmProvider.OpenAlgorithm(AsymmetricAlgorithmNames.RsaPkcs1)
                                                 .ImportKeyPair(CryptographicBuffer.CreateFromByteArray(block.Decoded), blobType);
        }

    }
}
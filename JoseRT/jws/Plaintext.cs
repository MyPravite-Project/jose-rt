﻿using System.Runtime.InteropServices.WindowsRuntime;
using JoseRT.Util;

namespace JoseRT.Jws
{
    public sealed class Plaintext : IJwsSigner
    {
        public byte[] Sign([ReadOnlyArray] byte[] securedInput, object key)
        {
            return new byte[0];  //Arrays.Empty
        }

        public bool Verify([ReadOnlyArray] byte[] signature, [ReadOnlyArray] byte[] securedInput, object key)
        {
            Ensure.IsNull(key, "Plaintext alg expectes key to be null.");

            return signature.Length == 0;
        }

        public string Name
        {
            get { return JwsAlgorithms.None; }
        }
    }
}
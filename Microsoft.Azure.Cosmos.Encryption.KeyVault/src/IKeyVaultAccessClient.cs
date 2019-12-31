﻿//------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
//------------------------------------------------------------
namespace Microsoft.Azure.Cosmos.Encryption.KeyVault
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// This interface represents the available functions that can be done using a KeyVault Access client.
    /// </summary>
    internal interface IKeyVaultAccessClient
    {
        /// <summary>
        /// Unwrap the encrypted Key.
        /// Only supports encrypted bytes in base64 format.
        /// </summary>
        /// <param name="bytesInBase64">encrypted bytes encoded to base64 string. </param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>Result including KeyIdentifier and decrypted bytes in base64 string format, can be convert to bytes using Convert.FromBase64String().</returns>
        Task<KeyVaultUnwrapResult> UnwrapKeyAsync(
               string bytesInBase64,
               Uri keyVaultKeyUri,
               CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Wrap the Key. 
        /// Only supports bytes in base64 format.
        /// </summary>
        /// <param name="bytesInBase64">bytes encoded to base64 string. E.g. Convert.ToBase64String(bytes) .</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>Result including KeyIdentifier and encrypted bytes in base64 string format.</returns>
        Task<KeyVaultWrapResult> WrapKeyAsync(
               string bytesInBase64,
               Uri keyVaultKeyUri,
               CancellationToken cancellationToken = default(CancellationToken));
    }
}

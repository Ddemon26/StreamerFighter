﻿using System;
using System.Net;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
namespace TwitchLib.Unity {
    public class CertificateValidationFix : MonoBehaviour {
        [RuntimeInitializeOnLoadMethod( RuntimeInitializeLoadType.BeforeSceneLoad )]
        static void FixCertificateValidation() => ServicePointManager.ServerCertificateValidationCallback = CertificateValidationMonoFix;

        static bool CertificateValidationMonoFix(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors) {
            var isOk = true;

            if ( sslPolicyErrors == SslPolicyErrors.None ) {
                return true;
            }

            foreach (var status in chain.ChainStatus) {
                if ( status.Status == X509ChainStatusFlags.RevocationStatusUnknown ) {
                    continue;
                }

                chain.ChainPolicy.RevocationFlag = X509RevocationFlag.EntireChain;
                chain.ChainPolicy.RevocationMode = X509RevocationMode.Online;
                chain.ChainPolicy.UrlRetrievalTimeout = new TimeSpan( 0, 1, 0 );
                chain.ChainPolicy.VerificationFlags = X509VerificationFlags.AllFlags;

                bool chainIsValid = chain.Build( (X509Certificate2)certificate );

                if ( !chainIsValid ) {
                    isOk = false;
                }
            }

            return isOk;
        }
    }
}
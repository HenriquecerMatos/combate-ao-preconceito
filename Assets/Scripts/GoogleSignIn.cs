using UnityEngine;
using Firebase;
using Firebase.Auth;
using Google;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Net;
using System;
using static UnityEngine.UIElements.UxmlAttributeDescription;
using UnityEngine.SceneManagement;

public class GoogleSignInHandler : MonoBehaviour
{
    private FirebaseAuth auth;
    private GoogleSignInConfiguration configuration;

    void Start()
    {
        InitializeFirebase();
        InitializeGoogleSignIn();
    }

    void InitializeFirebase()
    {
        FirebaseApp.CheckAndFixDependenciesAsync().ContinueWith(task =>
        {
            FirebaseApp app = FirebaseApp.DefaultInstance;
            auth = FirebaseAuth.DefaultInstance;
        });
    }

    void InitializeGoogleSignIn()
    {
        configuration = new GoogleSignInConfiguration
        {
            WebClientId = "<YOUR_WEB_CLIENT_ID>",
            RequestEmail = true,
            RequestIdToken = true
        };
    }

    public void SignInWithGoogle()
    {
        GoogleSignIn.Configuration = configuration;
        GoogleSignIn.Configuration.UseGameSignIn = false;
        GoogleSignIn.Configuration.RequestIdToken = true;

        GoogleSignIn.DefaultInstance.SignIn().ContinueWith(OnGoogleSignIn);
    }

    void OnGoogleSignIn(Task<GoogleSignInUser> task)
    {
        if (task.IsCanceled)
        {
            Debug.Log("Google sign-in canceled.");
        }
        else if (task.IsFaulted)
        {
            Debug.Log("Google sign-in encountered an error: " + task.Exception);
        }
        else
        {
            Debug.Log("Google sign-in successful.");
            GoogleSignInUser googleUser = task.Result;
            Credential credential = GoogleAuthProvider.GetCredential(googleUser.IdToken, null);
            SignInWithFirebase(credential);

            CarregarCena();
        }
    }

    public void CarregarCena()
    {
        SceneManager.LoadScene("PainelSelectSerie");
    }

    void SignInWithFirebase(Credential credential)
    {
        auth.SignInWithCredentialAsync(credential).ContinueWith(task =>
        {
            if (task.IsCanceled)
            {
                Debug.Log("Firebase sign-in canceled.");
            }
            else if (task.IsFaulted)
            {
                Debug.Log("Firebase sign-in encountered an error: " + task.Exception);
            }
            else
            {
                FirebaseUser user = task.Result;
                Debug.Log("Firebase sign-in successful: " + user.DisplayName);
            }
        });
    }    
}

using FirebaseAdmin;
using Google.Apis.Auth.OAuth2;
using Xunit;

namespace MundoBalloonApi.test.GraphQL.Fixtures;

[CollectionDefinition("FirebaseInitializer")]
public class FirebaseInitializer : IDisposable, ICollectionFixture<FirebaseInitializer>
{
    public FirebaseInitializer()
    {
        if (FirebaseApp.DefaultInstance == null)
        {
            var firebaseCredentialString = Environment.GetEnvironmentVariable("FIREBASE_PRIVATE_KEY") ?? "";
            FirebaseApp.Create(new AppOptions
            {
                Credential = GoogleCredential.FromJson(firebaseCredentialString)
            });
        }
    }

    public void Dispose()
    {
    }
}
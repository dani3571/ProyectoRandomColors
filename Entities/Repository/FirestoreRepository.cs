using Entities.Models;
using Google.Cloud.Firestore;
using Google.Cloud.Firestore.V1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Repository
{
    public class FirestoreRepository : IFirestoreRepository
    {
        private readonly string CollectionName;
        public FirestoreDb firestoreDb;

        public FirestoreRepository(string collectionName)
        {
            string filePath = "/Users/danie/randomcolors-6bf1a-firebase-adminsdk-866ea-5bab870bc1.json";
            Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", filePath);
            firestoreDb = FirestoreDb.Create(collectionName);
            this.CollectionName = collectionName;
        }


        public T Get<T>(T record) where T: FirebaseDocument
        {
            DocumentReference docRef = firestoreDb.Collection(CollectionName).Document(record.Id);
            DocumentSnapshot snapshot = docRef.GetSnapshotAsync().GetAwaiter().GetResult();

            if (snapshot.Exists)
            {
                T usr = snapshot.ConvertTo<T>();
                usr.Id = snapshot.Id;
                return usr;
            }
            else
            {
                return null;
            }
        }
    }
}

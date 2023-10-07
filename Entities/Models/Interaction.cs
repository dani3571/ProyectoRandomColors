using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Google.Cloud.Firestore;

namespace Entities.Models
{

    [FirestoreData]
    public class Interaction : FirebaseDocument
    {
        [FirestoreProperty]
        public string Ip { get; set; }

        [FirestoreProperty]
        public DateTime Hora { get; set; }

        [FirestoreProperty]
        public Color TextColor { get; set;}


        [FirestoreProperty]
        public Color ContainerColor { get; set; }

        [FirestoreProperty]
        public int Reaccion { get; set; }
    }
}

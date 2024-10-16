using Google.Cloud.Firestore;

namespace FireStore_Demo_SanyaPanova.Models
{
    [FirestoreData]
    public class Note
    {
        public string NoteId { get; set; }
        [FirestoreProperty]
        public string Title { get; set; }
        [FirestoreProperty]
        public string Description { get; set; }
    }
}

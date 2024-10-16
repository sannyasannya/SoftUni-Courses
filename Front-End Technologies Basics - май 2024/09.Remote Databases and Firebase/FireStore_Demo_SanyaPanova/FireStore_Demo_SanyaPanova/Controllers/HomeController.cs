using FireStore_Demo_SanyaPanova.Models;
using Google.Cloud.Firestore;
using Google.Cloud.Firestore.V1;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Text.Json;

namespace FireStore_Demo_SanyaPanova.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IConfiguration _configuration;
        private readonly string projectId;
        private readonly FirestoreDb database;

        public HomeController(ILogger<HomeController> logger, IConfiguration configuration)
        {
            var filePath = Path.GetFullPath("./responsiveformdemoprojec-3254b-firebase-adminsdk-ve29i-4ab7d9cd93.json");
            Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", filePath);
            _logger = logger;
            _configuration = configuration;
            projectId = _configuration.GetValue<string>("Firestore_API:project_id");
            database = FirestoreDb.Create(projectId);
        }

        public async Task<IActionResult> Index()
        {
            Query notesQuery = database.Collection("Notes");
            QuerySnapshot notesSnapshot = await notesQuery.GetSnapshotAsync();
            List<Note> notes = new List<Note>();

            foreach (DocumentSnapshot noteData in notesSnapshot.Documents) 
            {
                if (noteData.Exists)
                {
                    Dictionary<string, object> currentNotes = noteData.ToDictionary();
                    string json = JsonSerializer.Serialize(currentNotes);
                    Note currentNote = JsonSerializer.Deserialize<Note>(json);
                    currentNote.NoteId = noteData.Id;
                    notes.Add(currentNote);
                }
            }
            return View(notes);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Edit()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View(new Note());
        }

        [HttpPost]
        public async Task<IActionResult> Create(Note model)
        {
            CollectionReference notes = database.Collection("Notes");

            if (string.IsNullOrWhiteSpace(model.Title) &&
                string.IsNullOrWhiteSpace(model.Description))
            {
                return View(model);
            }
            await notes.AddAsync(model);
            return RedirectToAction(nameof(Index));
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

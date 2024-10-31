using Frontend_MVC_00013940.Services;
using Microsoft.AspNetCore.Mvc;
using Frontend_MVC_00013940.Models;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

public class NotesController : Controller
{
    private readonly NoteService _noteService;

    public NotesController(NoteService noteService)
    {
        _noteService = noteService;
    }

    public async Task<IActionResult> Index()
    {
        var notes = await _noteService.GetNotesAsync();
        return View(notes);
    }

    public async Task<IActionResult> Create()
    {
        var tags = await _noteService.GetTagsAsync();
        ViewBag.Tags = tags; // Pass tags to the view
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Note note)
    {
        if (ModelState.IsValid)
        {
            await _noteService.CreateNoteAsync(note);
            return RedirectToAction(nameof(Index));
        }
        var tags = await _noteService.GetTagsAsync();
        ViewBag.Tags = tags;
        return View(note);
    }

    public async Task<IActionResult> Edit(int id)
    {
        var note = await _noteService.GetNoteByIdAsync(id);
        if (note == null) return NotFound();

        var tags = await _noteService.GetTagsAsync();
        ViewBag.Tags = new SelectList(tags, "Id", "TagName", note.TagId); 
        return View(note);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, Note note)
    {
        if (id != note.Id) return BadRequest();

        if (ModelState.IsValid)
        {
            await _noteService.UpdateNoteAsync(note);
            return RedirectToAction(nameof(Index));
        }
        var tags = await _noteService.GetTagsAsync();
        ViewBag.Tags = new SelectList(tags, "Id", "TagName", note.TagId);
        return View(note);
    }

    public async Task<IActionResult> Delete(int id)
    {
        var note = await _noteService.GetNoteByIdAsync(id);
        if (note == null) return NotFound();

        return View(note);
    }

    // Add the Details action
    public async Task<IActionResult> Details(int id)
    {
        var note = await _noteService.GetNoteByIdAsync(id);
        if (note == null) return NotFound();

        return View(note);
    }
}

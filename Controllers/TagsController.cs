using Microsoft.AspNetCore.Mvc;
using Frontend_MVC_00013940.Models;
using System.Threading.Tasks;

public class TagsController : Controller
{
    private readonly TagService _tagService;

    public TagsController(TagService tagService)
    {
        _tagService = tagService;
    }

    public async Task<IActionResult> Index()
    {
        var tags = await _tagService.GetTagsAsync();
        return View(tags);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Tag tag)
    {
        if (ModelState.IsValid)
        {
            await _tagService.CreateTagAsync(tag);
            return RedirectToAction(nameof(Index));
        }
        return View(tag);
    }

    public async Task<IActionResult> Edit(int id)
    {
        var tag = await _tagService.GetTagByIdAsync(id);
        if (tag == null) return NotFound();

        return View(tag);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, Tag tag)
    {
        if (id != tag.Id) return BadRequest();

        if (ModelState.IsValid)
        {
            await _tagService.UpdateTagAsync(tag);
            return RedirectToAction(nameof(Index));
        }
        return View(tag);
    }

    public async Task<IActionResult> Delete(int id)
    {
        var tag = await _tagService.GetTagByIdAsync(id);
        if (tag == null) return NotFound();

        return View(tag);
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        await _tagService.DeleteTagAsync(id);
        return RedirectToAction(nameof(Index));
    }
}

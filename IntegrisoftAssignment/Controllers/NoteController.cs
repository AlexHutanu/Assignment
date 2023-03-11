using IntegrisoftAssignment.Data;
using IntegrisoftAssignment.Models;
using IntegrisoftAssignment.Services;
using Microsoft.AspNetCore.Mvc;

namespace IntegrisoftAssignment.Controllers;

[Route("[controller]")]
[ApiController]
public class NoteController : Controller
{
    private readonly ApplicationDbContext _context;
    private readonly MediaGenerala _media;

    public NoteController(ApplicationDbContext context, MediaGenerala media)
    {
        _context = context;
        _media = media;
    }

    [HttpGet("{id}")]
    public IEnumerable<Note> InformatiiStudent(int id)
    {
        return _context.Note.Where(nota => nota.StudentId == id);
    }

    [HttpGet("media/{studentId}")]
    public double MediaGenerala(int studentId)
    {
        var mediaGenerala = _media.CalcMediaGenerala(studentId);

        return mediaGenerala;
    }
}
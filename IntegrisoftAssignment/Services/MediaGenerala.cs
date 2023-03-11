using IntegrisoftAssignment.Data;

namespace IntegrisoftAssignment.Services
{
    public class MediaGenerala
    {
        private readonly ApplicationDbContext _context;

        public MediaGenerala(ApplicationDbContext context)
        {
            _context = context;
        }

        public double CalcMediaGenerala(int studentId)
        {
            var ultimeleNota = _context.Note
                .Where(x => x.StudentId == studentId)
                .GroupBy(x => x.MaterieId)
                .Select(z => z.OrderByDescending(p => p.Nota).FirstOrDefault())
                .ToList();

            var media = _context.Note
                .Where(x => x.StudentId == studentId)
                .GroupBy(x => x.StudentId)
                .Select(x => x.Average(p => p.Nota))
                .FirstOrDefault();

            foreach (var ultimaNota in ultimeleNota)
            {
                var totalNote = _context.Note.Count(g => g.StudentId == studentId && g.MaterieId == ultimaNota.MaterieId);
                if (totalNote > 0)
                {
                    media = ((media * totalNote) + ultimaNota.Nota) / (totalNote + 1);
                }
                else
                {
                    media = ultimaNota.Nota;
                }
            }

            return Math.Round(media, 2);
        }
    }
}
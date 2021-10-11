namespace Kata.CustomTypes.BookshopFactory
{
    public class FictionSection : SectionBase
    {
        protected override void CreateGenres()
        {
            Genres.Add(new SciFiGenre());
            Genres.Add(new CrimeGenre());
        }
    }
}

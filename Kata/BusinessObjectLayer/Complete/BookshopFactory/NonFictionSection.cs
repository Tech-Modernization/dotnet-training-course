namespace BusinessObjectLayer.BookshopFactory
{
    public class NonFictionSection : SectionBase
    {
        protected override void CreateGenres()
        {
            Genres.Add(new TravelGenre());
            Genres.Add(new HistoryGenre());
            Genres.Add(new TrueCrimeGenre());
        }
    }
}

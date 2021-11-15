using System.Collections.Generic;

namespace Kata.CustomTypes.BookshopFactory
{
    public abstract class SectionBase
    {
        // 1. backing store
        private List<GenreBase> genres = new List<GenreBase>();
        // 2. property readonly
        public List<GenreBase> Genres { get { return genres; } }
        // 3. constructor
        public SectionBase()
        {
            this.CreateGenres();
        }
        // 4. factory method
        protected abstract void CreateGenres();
    }
}

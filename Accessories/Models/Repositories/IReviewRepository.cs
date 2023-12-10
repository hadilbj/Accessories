namespace Accessories.Models.Repositories
{
    public interface IReviewRepository
    {
        IList<Review> GetReviews();
        Review GetReview(int id);
        void Add (Review review);
        void Update (Review review);
        void Delete (int id);
        void DeleteAll ();
        void Edit (Review review);
    }
}

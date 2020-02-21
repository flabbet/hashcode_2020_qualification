namespace Google_Hash_Code
{
    public struct Book
    {
        public int Id { get; set; }
        public int Score { get; set; }

        public Book(int id, int score)
        {
            Id = id;
            Score = score;
        }
    }
}
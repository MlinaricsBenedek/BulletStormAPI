namespace BulletStormAPI.Dto
{
    public class ResultDto
    {
        public int Kill { get; set; }

        public int Assist { get; set; }

        public int Deaths { get; set; }

        public bool Won { get; set; }

        public DateTime UpdatedAt { get; set; }
    }
}

namespace WebApplication2.entites
{
    public abstract class base_entity
    {
        public int id{ get; set; }
        public DateTime createdate{ get; set; }
        public DateTime? updatedate { get; set; }
    }
}

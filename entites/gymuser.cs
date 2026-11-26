namespace WebApplication2.entites
{
    public abstract class gymuser : base_entity
    {
        public string name { get; set; } = default!;
        public string email { get; set; } = default!;
        public string phone { get; set; } = default!;
        public DateTime dateofbirth { get; set; } 
        public addrese addrese { get; set; } = default!;
        public gender gender{ get; set; } 

        
    }
}

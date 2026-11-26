namespace WebApplication2.entites
{
    public class plan:base_entity
    {
        public string name { get; set; } = default!;
        public string describtion { get; set; } = default!;
        public int durationdays { get; set; }
        public decimal price { get; set; } 

        public bool isactive{ get; set; }
        #region membership
        public ICollection<membership> manymembership { get; set; } = new HashSet<membership>();

        #endregion



    }
}

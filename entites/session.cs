namespace WebApplication2.entites
{
    public class session : base_entity
    {
        public int capacity { get; set; }
        public string describtaion { get; set; } = default!;
        public DateTime startdate { get; set; }
        public DateTime enddate{ get; set; }
        #region relation
        public trainer onetrainer { get; set; } = default!;
        public int trainerid { get; set; }
        #endregion
    }
}

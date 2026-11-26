namespace WebApplication2.entites
{
    public class member : gymuser
    {
        public string? photo{ get; set; }
        #region membership
        public ICollection<membership> manymembership { get; set; } = new HashSet<membership>();
        #endregion
    }
}

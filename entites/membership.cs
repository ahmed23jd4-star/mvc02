namespace WebApplication2.entites
{
    public class membership : base_entity
    {
        #region plan
        public plan oneplan{ get; set; }
        public int planid { get; set; }
        #endregion
        #region member
        public member onemember { get; set; }
        public int memberid { get; set; }
        #endregion
    }
}

namespace WebApplication2.entites
{
    public class trainer : gymuser
    {
        public DateTime hiredate{ get; set; }
        public specailisty specailisty{ get; set; }

        #region relation for session
        public ICollection<session> manysession { get; set; } = new HashSet<session>();

        #endregion
    }
}

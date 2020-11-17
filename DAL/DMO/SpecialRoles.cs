using DataService.DAL.CustomTypes;

namespace DataService.DAL.DMO
{
    public class SpecialRoles
    {
        public int UserId { get; set; }
        public RoleType RoleType { get; set; }
        public virtual Users User { get; set; }
    }
}